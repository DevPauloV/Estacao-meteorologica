using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class Registrar : Form
    {
        private Database db;

        public Registrar()
        {
            InitializeComponent();
            db = new Database(); // Inicializa a conexão com o MySQL
        }

        private void signup_showPass_CheckedChanged(object sender, EventArgs e)
        {
            signup_password.PasswordChar = signup_showPass.Checked ? '\0' : '*';
        }

        private void signup_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(signup_email.Text) ||
                string.IsNullOrWhiteSpace(signup_username.Text) ||
                string.IsNullOrWhiteSpace(signup_password.Text))
            {
                MessageBox.Show("Please fill all blank fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Verifica se o nome de usuário já existe
                string checkUsername = "SELECT * FROM admin WHERE username = @username";
                MySqlParameter[] parameters = {
                    new MySqlParameter("@username", signup_username.Text.Trim())
                };

                DataTable table = db.BuscarDados(checkUsername, parameters, this);

                if (table.Rows.Count >= 1)
                {
                    MessageBox.Show(signup_username.Text + " already exists", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // Insere novos dados
                    string insertData = "INSERT INTO admin (email, username, passwrd, date_created) " +
                                        "VALUES(@email, @username, @pass, @date)";
                    DateTime date = DateTime.Today;

                    MySqlParameter[] insertParameters = {
                        new MySqlParameter("@email", signup_email.Text.Trim()),
                        new MySqlParameter("@username", signup_username.Text.Trim()),
                        new MySqlParameter("@pass", signup_password.Text.Trim()),
                        new MySqlParameter("@date", date)
                    };

                    if (db.ExecutarComando(insertData, insertParameters, this))
                    {
                        MessageBox.Show("Registered successfully", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Muda para o formulário de login
                        Login lForm = new Login();
                        lForm.Show();
                        this.Hide();
                    }
                }
            }
        }

        private void signup_loginHere_Click(object sender, EventArgs e)
        {
            Login lForm = new Login();
            lForm.Show();
            this.Hide();
        }
    }
}
