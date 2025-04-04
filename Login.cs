using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class Login : Form
    {
        private Database db;

        public Login()
        {
            InitializeComponent();
            db = new Database(); // Inicializa a conexão com o MySQL
        }

        private void Login_Load(object sender, EventArgs e)
        {
            
        }

        private void login_showPass_CheckedChanged(object sender, EventArgs e)
        {
            login_password.PasswordChar = login_showPass.Checked ? '\0' : '*';
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(login_username.Text) || string.IsNullOrWhiteSpace(login_password.Text))
            {
                MessageBox.Show("Please fill all blank fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string selectData = "SELECT * FROM admin WHERE username = @username AND passwrd = @pass";
                MySqlParameter[] parameters = {
            new MySqlParameter("@username", login_username.Text),
            new MySqlParameter("@pass", login_password.Text)
        };

                DataTable table = db.BuscarDados(selectData, parameters, this);

                if (table.Rows.Count >= 1)
                {
                    // Supondo que o nome do usuário esteja na coluna "username"
                    string nomeUsuario = table.Rows[0]["username"].ToString();

                    MessageBox.Show("Login feito com sucesso!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Principal mForm = new Principal();
                    mForm.UsuarioNome = nomeUsuario; // Passa o nome do usuário
                    mForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Incorreto Nome/Senha", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void login_registerHere_Click(object sender, EventArgs e)
        {
            Registrar sForm = new Registrar();
            sForm.Show();
            this.Hide();
        }
    }
}
