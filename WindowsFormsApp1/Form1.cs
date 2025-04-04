using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private Form2 newForm;

        public Form1()
        {
            InitializeComponent();

            newForm = new Form2();
            newForm.DadosRecebidos += Form2_DadosRecebidos;
        }

        private void Form2_DadosRecebidos(string data)
        {
            // Exiba os dados recebidos no Form1 (por exemplo, em um Label ou TextBox)
            this.Invoke(new Action(() => {
                lblTemperatura.Text = data; // Substitua lblDataReceived pelo nome do seu controle
            }));
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            newForm = new Form2();
          //  newForm.DadosRecebidos += AtualizarDadosNoForm1;
            newForm.Show();
        }

       /* private void AtualizarDadosNoForm1(string dados)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => AtualizarDadosNoForm1(dados)));
                return;
            }

            // Supondo que você tenha dois Labels: lblTemperatura e lblHumidade
            if (dados.Contains("Temperature"))
            {
                string[] parts = dados.Split(',');

                foreach (var part in parts)
                {
                    if (part.Contains("Temperature"))
                    {
                        lblTemperatura.Text = part.Trim();
                    }
                    else if (part.Contains("Humidity"))
                    {
                        lblHumidade.Text = part.Trim();
                    }
                }
            }


        } */

     
    }
}