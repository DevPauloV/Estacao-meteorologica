using System;
using System.IO.Ports;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Net;
using System.Xml.Linq;
using System.Linq;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class Dashboard : Form
    {
        private Database db; // Instância da classe Database
        private string serialDataIn;

        public Dashboard()
        {
            InitializeComponent();
            db = new Database(); // Inicializa a conexão com o MySQL
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            // Define a cidade padrão
            txtcity.Text = "Bilac-SP, Brasil";

            // Inicializa a lista de portas COM
            string[] portLists = SerialPort.GetPortNames();
            ComboBoxPort.Items.Clear();
            ComboBoxPort.Items.AddRange(portLists);

            btnOpen.Enabled = true;
            btnClose.Enabled = false;
            verticalProgressBar1.Value = 0;
            comboBoxTx.Text = "9600";

            // Inicializa o SerialPort
            serialPort2 = new SerialPort();

            // Carrega os dados climáticos para a cidade padrão
            LoadWeatherData();
        }

        private void LoadWeatherData()
        {
            // Cidade predefinida
            string city = txtcity.Text; 


        


            string url = string.Format("http://api.weatherapi.com/v1/forecast.xml?key=46d22bedb4824b5485a172113201209&q={0}&days=1", city);


            




            // Carrega os dados XML da API
            XDocument doc = XDocument.Load(url);

            // Extrai o ícone do tempo
            string iconUrl = (string)doc.Descendants("icon").FirstOrDefault();

            using (WebClient client = new WebClient())
            {
                byte[] image = client.DownloadData("http:" + iconUrl);

                using (MemoryStream stream = new MemoryStream(image))
                {
                    Bitmap newBitMap = new Bitmap(stream);
                    // Se necessário, você pode exibir a imagem em algum PictureBox
                }
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                // Configura o SerialPort para a porta COM selecionada
                serialPort2.PortName = ComboBoxPort.Text;
                serialPort2.BaudRate = Convert.ToInt32(comboBoxTx.Text);
                serialPort2.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
                serialPort2.Open();

                btnOpen.Enabled = false;
                btnClose.Enabled = true;
                verticalProgressBar1.Value = 100;

                MessageBox.Show("Connected to " + serialPort2.PortName);
            }
            catch (Exception error)
            {
                MessageBox.Show("Error connecting: " + error.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort2.IsOpen)
                {
                    serialPort2.DataReceived -= DataReceivedHandler; // Desinscreve do evento
                    serialPort2.Close();
                }

                btnOpen.Enabled = true;
                btnClose.Enabled = false;
                verticalProgressBar1.Value = 0;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            serialDataIn = serialPort2.ReadLine(); // Lê a linha recebida
            ProcessData(); // Processa os dados
        }

       private void ProcessData()
{
    if (InvokeRequired)
    {
        Invoke(new Action(ProcessData));
        return;
    }

    try
    {
        // Log para diagnóstico
        Console.WriteLine("Dados recebidos: " + serialDataIn);

        // Verifica se a string recebida não está vazia
        if (!string.IsNullOrEmpty(serialDataIn))
        {
            // Divide a string em um array de valores numéricos usando o ponto e vírgula como separador
            string[] valores = serialDataIn.Split(';');

            // Verifica se temos exatamente 4 valores (temperatura, umidade, vento, chuva)
            if (valores.Length == 4)
            {
                string temperature = valores[0].Trim();
                string humidity = valores[1].Trim();
                string windspeed = valores[2].Trim();
                string rain = valores[3].Trim();

                // Atualiza os valores no UI
                Ltemperatura.Text = temperature + " °C";
                Lhumidade.Text = humidity + " %";
                Lvento.Text = windspeed + " m/s";
                Lchuva.Text = rain + " mm";  // Exibe o total de chuva acumulada

                // Armazena os dados no banco de dados
                StoreWeatherData(temperature, humidity, windspeed, rain);
            }
            else
            {
                MessageBox.Show("Dados recebidos em formato inesperado: " + serialDataIn);
            }
        }
    }
    catch (Exception error)
    {
        MessageBox.Show("Erro ao processar os dados: " + error.Message);
    }
}


        private void StoreWeatherData(string temperature, string humidity, string windspeed, string rain)
        {
            try
            {
                // Log para diagnóstico
                Console.WriteLine($"Armazenando dados: Temperatura: {temperature}, Umidade: {humidity}, Vento: {windspeed}, Chuva: {rain}");

                // Cria uma string de conexão para o MySQL
                string query = "INSERT INTO clima (Temperatura, Umidade, Vento, Chuva) VALUES (@Temperature, @Humidity, @Windspeed, @Rain)";
                MySqlParameter[] parameters = new MySqlParameter[]
                {
            new MySqlParameter("@Temperature", temperature),  // Armazena como VARCHAR
            new MySqlParameter("@Humidity", humidity),        // Armazena como VARCHAR
            new MySqlParameter("@Windspeed", windspeed),      // Armazena como VARCHAR
            new MySqlParameter("@Rain", rain)                 // Armazena como VARCHAR
                };


                /* Usa a classe Database para executar o comando
                if (db.ExecutarComando(query, parameters))
                {
                    MessageBox.Show("Dados armazenados com sucesso!");
                }
                else
                {
                    MessageBox.Show("Erro ao executar o comando SQL.");
                }*/

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao armazenar dados: " + ex.Message + "\n" + ex.StackTrace);
            }
        }




        private void ComboBoxPort_DropDown_1(object sender, EventArgs e)
        {
            string[] portLists = SerialPort.GetPortNames();
            ComboBoxPort.Items.Clear();
            ComboBoxPort.Items.AddRange(portLists);
        }

       

    }
}
