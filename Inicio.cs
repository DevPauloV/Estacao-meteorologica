using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;

namespace WindowsFormsApp1
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            // Define a cidade predefinida
            txtcity.Text = "araçatuba";

            // Inicia o Timer
            timer1.Start();

            // Obtém a data e hora atual
            DateTime now = DateTime.Now;

            // Formata a data de acordo com o formato desejado
            string formattedDate = now.ToString("dddd, dd 'de' MMMM 'de' yyyy", new System.Globalization.CultureInfo("pt-BR"));

            // Atualiza o texto do Label com a data formatada
            lblFecha.Text = formattedDate;

            // Chama o método para carregar as informações do clima ao iniciar
            LoadWeatherData();

       
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblhora.Text = DateTime.Now.ToString("HH:mm:ss"); // Formato de 24 horas
        }

        private void LoadWeatherData()
        {
            string city = txtcity.Text;
            string url = string.Format("http://api.weatherapi.com/v1/forecast.xml?key=46d22bedb4824b5485a172113201209&q={0}&days=1&lang=pt", city);

            XDocument doc = XDocument.Load(url);

            string iconUrl = (string)doc.Descendants("icon").FirstOrDefault();

            using (WebClient client = new WebClient())
            {
                byte[] image = client.DownloadData("http:" + iconUrl);

                using (MemoryStream stream = new MemoryStream(image))
                {
                    Bitmap newBitMap = new Bitmap(stream);
                    Bitmap resizedBitmap = ResizeImage(newBitMap, 100, 100);

                    string maxtemp = (string)doc.Descendants("maxtemp_c").FirstOrDefault() + "°";
                    string mintemp = (string)doc.Descendants("mintemp_c").FirstOrDefault() + "°";
                    string precip_mm = (string)doc.Descendants("precip_mm").FirstOrDefault() + " mm";
                    string country = (string)doc.Descendants("country").FirstOrDefault();
                    string cloud = (string)doc.Descendants("text").FirstOrDefault();

                    // Dicionário para traduções
                    Dictionary<string, string> translations = new Dictionary<string, string>
            {
                { "Clear", "Céu limpo" },
                { "Partly cloudy", "Parcialmente nublado" },
                { "Overcast", "Nublado" },
                { "Rain", "Chuva" },
                 { "Brasilien", "Brasil" },
                { "Snow", "Neve" },
                // Adicione outras traduções conforme necessário
            };

                    // Traduzindo a condição do tempo
                    if (translations.TryGetValue(cloud, out string translatedCondition))
                    {
                        cloud = translatedCondition;
                    }

                    txtmaxtemp.Text = maxtemp;
                    txtmintemp.Text = mintemp;
                
                    pictureBox1.Image = resizedBitmap;
                }
            }
        }



        private void weekbtn_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("País", typeof(string));
            dt.Columns.Add("Data", typeof(string));
            dt.Columns.Add("Max Temp", typeof(string));
            dt.Columns.Add("Min Temp", typeof(string));
            dt.Columns.Add("Clima", typeof(string));
            dt.Columns.Add("Icone", typeof(Image));

            string city = txtcity.Text;
            string url = string.Format("http://api.weatherapi.com/v1/forecast.xml?key=46d22bedb4824b5485a172113201209&q={0}&days=7&lang=pt", city);

            XDocument doc = XDocument.Load(url);

            // Dicionário para traduções
            Dictionary<string, string> translations = new Dictionary<string, string>
    {
        { "Clear", "Céu limpo" },
        { "Partly cloudy", "Parcialmente nublado" },
        { "Overcast", "Nublado" },
        { "Rain", "Chuva" },
        { "Brasilien", "Brasil" },
        { "Snow", "Neve" },
         
        // Adicione outras traduções conforme necessário
    };

            foreach (var npc in doc.Descendants("forecastday"))
            {
                string iconUrl = (string)npc.Descendants("icon").FirstOrDefault();

                using (WebClient client = new WebClient())
                {
                    byte[] image = client.DownloadData("http:" + iconUrl);

                    using (MemoryStream stream = new MemoryStream(image))
                    {
                        Bitmap newBitmap = new Bitmap(stream);
                        Bitmap resizedBitmap = ResizeImage(newBitmap, 100, 100); // Ajuste o tamanho conforme necessário

                        string cloud = (string)npc.Descendants("text").FirstOrDefault();

                        // Traduzindo a condição do tempo
                        if (translations.TryGetValue(cloud, out string translatedCondition))
                        {
                            cloud = translatedCondition;
                        }

                        dt.Rows.Add(new object[]
                        {
                    (string)doc.Descendants("country").FirstOrDefault(),
                    (string)npc.Descendants("date").FirstOrDefault(),
                    (string)npc.Descendants("maxtemp_c").FirstOrDefault(),
                    (string)npc.Descendants("mintemp_c").FirstOrDefault(),
                    cloud,  // Usando a condição traduzida
                    resizedBitmap
                        });
                    }
                }
            }

            dataGridView1.DataSource = dt;
        }




        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        private Bitmap ResizeImage(Bitmap originalImage, int width, int height)
        {
            Bitmap resizedImage = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(resizedImage))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(originalImage, 0, 0, width, height);
            }
            return resizedImage;
        }
    }
}