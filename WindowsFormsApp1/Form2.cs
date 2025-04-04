using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public event Action<string> DadosRecebidos;


        public Form2()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.Port_Conf_Load);
            serialPort1.DataReceived += new SerialDataReceivedEventHandler(SerialPort1_DataReceived);
        }


        private void SerialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string data = serialPort1.ReadExisting();
                if (!string.IsNullOrEmpty(data))
                {
                    DadosRecebidos?.Invoke(data);
                    Console.WriteLine("Dados recebidos: " + data); // Debug para verificar se os dados estão sendo recebidos
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao receber dados: " + ex.Message);
            }
        }



        private void Port_Conf_Load(object sender, EventArgs e)
        {
            // Get available serial ports
            string[] availablePorts = System.IO.Ports.SerialPort.GetPortNames();

            // Add available ports to PortComboBox
            comboPort.Items.Clear();
            foreach (string port in availablePorts)
            {
                comboPort.Items.Add(port);
            }

            // Selecione COM4 por padrão, se disponível
            if (comboPort.Items.Contains("COM4"))
            {
                comboPort.SelectedItem = "COM4";
            }

            // Configure BaudrateComboBox
            comboTx.Items.Clear();
            comboTx.Items.Add("4800");
            comboTx.Items.Add("9600");
            comboTx.Items.Add("19200");
            comboTx.SelectedIndex = 2;

            // Configure ParityComboBox
            comboP.Items.Clear();
            comboP.Items.Add(System.IO.Ports.Parity.None);
            comboP.Items.Add(System.IO.Ports.Parity.Odd);
            comboP.Items.Add(System.IO.Ports.Parity.Even);
            comboP.SelectedIndex = 2;
        }




        private void OkBtn_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                try
                {
                    serialPort1.PortName = "COM4"; // Abre a porta COM4
                    serialPort1.BaudRate = 9600;  // Configura a taxa de transmissão
                    serialPort1.Open();
                }
                catch
                {
                    MessageBox.Show("Falha ao abrir a porta COM4");
                    return;
                }

                if (serialPort1.IsOpen)
                {
                    OkBtn.Text = "Desconectar";
                    comboPort.Enabled = false;
                }
            }
            else
            {
                try
                {
                    serialPort1.Close();
                    comboPort.Enabled = true;
                    OkBtn.Text = "Conectar";
                }
                catch
                {
                    return;
                }
            }
        }
    }
}