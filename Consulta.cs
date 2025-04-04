using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using WindowsFormsApp1;

namespace Temperature_Recorder
{
    public partial class Consulta : Form
    {
        private Database db; // Instância da classe Database

        public Consulta()
        {
            InitializeComponent();
            db = new Database(); // Inicializa a conexão com o MySQL
        }

        private void Consulta_Load(object sender, EventArgs e)
        {
            LoadClimaData(DateTime.Now); // Carrega os dados da tabela "clima" para a data atual
        }

        private void LoadClimaData(DateTime selectedDate)
        {
            try
            {
                string query;

                // Verifica se a data selecionada é a data atual
                if (selectedDate.Date == DateTime.Now.Date)
                {
                    query = "SELECT * FROM clima"; // Carrega todos os dados
                }
                else
                {
                    query = $"SELECT * FROM clima WHERE DATE(data) = '{selectedDate:yyyy-MM-dd}'"; // Carrega dados para a data selecionada
                }

                DataTable dataTable = db.BuscarDados(query);
                dataGridView2.DataSource = dataTable;

                // Definindo os nomes das colunas
                dataGridView2.Columns[0].HeaderText = "ID";
                dataGridView2.Columns[1].HeaderText = "Data";
                dataGridView2.Columns[2].HeaderText = "Temperatura";
                dataGridView2.Columns[3].HeaderText = "Umidade";
                dataGridView2.Columns[4].HeaderText = "Vento";
                dataGridView2.Columns[5].HeaderText = "Chuva";

                CustomizeDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados da tabela clima: " + ex.Message);
            }
        }

        private void CustomizeDataGridView()
        {
            dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.LightBlue;
            dataGridView2.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            dataGridView2.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);
            dataGridView2.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            dataGridView2.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            dataGridView2.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 10);
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.LightGray;
            dataGridView2.BorderStyle = BorderStyle.FixedSingle;
            dataGridView2.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dataGridView2.GridColor = System.Drawing.Color.DarkGray;
            dataGridView2.ReadOnly = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView2.Rows.Count > 0)
                {
                    Microsoft.Office.Interop.Excel.Application xcelApp = new Microsoft.Office.Interop.Excel.Application();
                    xcelApp.Application.Workbooks.Add(Type.Missing);

                    for (int i = 1; i < dataGridView2.Columns.Count + 1; i++)
                    {
                        xcelApp.Cells[1, i] = dataGridView2.Columns[i - 1].HeaderText;
                    }

                    for (int i = 0; i < dataGridView2.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataGridView2.Columns.Count; j++)
                        {
                            xcelApp.Cells[i + 2, j + 1] = dataGridView2.Rows[i].Cells[j].Value?.ToString();
                        }
                    }

                    xcelApp.Columns.AutoFit();
                    xcelApp.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao exportar para Excel: " + ex.Message);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            // Carrega os dados da tabela clima para a data selecionada no DateTimePicker
            LoadClimaData(dateTimePicker1.Value);
        }
    }
}
