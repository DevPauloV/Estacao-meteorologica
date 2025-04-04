using System;
using System.Data;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class Principal : Form
    {
        private Database db;
        public string UsuarioNome { get; set; }

        public Principal()
        {
            InitializeComponent();
            db = new Database(); // Inicializa a conexão com o MySQL
        }


        [DllImport("user32.dll")]
        private extern static void ReleaseCapture();

        [DllImport("user32.dll")]
        private extern static void SendMessage(IntPtr hwnd, int wmsg, int wparam, int lparam);


        private void AbrirFormEnPanel(object Formhijo)
        {
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);
            Form fh = Formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(fh);
            this.panelContenedor.Tag = fh;
            fh.Show();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new Inicio());
            NomeUser.Text = UsuarioNome; // Atualiza a label com o nome do usuário
        }

        private void iconcerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnlogoInicio_Click(object sender, EventArgs e)
        {

        }
        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            AbrirFormEnPanel(new Inicio());
        }

      
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new Dashboard());
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new Temperature_Recorder.Consulta());
        }

        private void NomeUser_Click(object sender, EventArgs e)
        {
            // Aqui você pode adicionar lógica para exibir o nome do usuário logado, se necessário
        }

        private void btn_inicio_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new Inicio());
        }

        private void btn_consulta_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new Temperature_Recorder.Consulta());
        }

        private void btn_dashboard_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new Dashboard());
        }

        private void btn_sair_Click(object sender, EventArgs e)
        {

        }
    }
}
