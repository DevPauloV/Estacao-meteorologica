namespace WindowsFormsApp1
{
    partial class Dashboard
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.comboBoxTx = new System.Windows.Forms.ComboBox();
            this.ComboBoxPort = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.serialPort2 = new System.IO.Ports.SerialPort(this.components);
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.Lhumidade = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.Lvento = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Ltemperatura = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.Lchuva = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.txtcity = new System.Windows.Forms.Label();
            this.verticalProgressBar1 = new WindowsFormsApp1.VerticalProgressBar();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.Menu;
            this.btnClose.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnClose.Location = new System.Drawing.Point(688, 392);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(95, 31);
            this.btnClose.TabIndex = 39;
            this.btnClose.Text = "Fechar";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.BackColor = System.Drawing.SystemColors.Menu;
            this.btnOpen.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnOpen.Location = new System.Drawing.Point(31, 106);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(95, 31);
            this.btnOpen.TabIndex = 38;
            this.btnOpen.Text = "Conectar";
            this.btnOpen.UseVisualStyleBackColor = false;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // comboBoxTx
            // 
            this.comboBoxTx.BackColor = System.Drawing.SystemColors.MenuText;
            this.comboBoxTx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTx.FormattingEnabled = true;
            this.comboBoxTx.Items.AddRange(new object[] {
            "9600",
            "38400",
            "57600",
            "115200"});
            this.comboBoxTx.Location = new System.Drawing.Point(612, 346);
            this.comboBoxTx.Name = "comboBoxTx";
            this.comboBoxTx.Size = new System.Drawing.Size(167, 21);
            this.comboBoxTx.TabIndex = 37;
            // 
            // ComboBoxPort
            // 
            this.ComboBoxPort.BackColor = System.Drawing.SystemColors.MenuText;
            this.ComboBoxPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxPort.FormattingEnabled = true;
            this.ComboBoxPort.Location = new System.Drawing.Point(612, 303);
            this.ComboBoxPort.Name = "ComboBoxPort";
            this.ComboBoxPort.Size = new System.Drawing.Size(167, 21);
            this.ComboBoxPort.TabIndex = 40;
            this.ComboBoxPort.DropDown += new System.EventHandler(this.ComboBoxPort_DropDown_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Menu;
            this.label2.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label2.Location = new System.Drawing.Point(28, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 36;
            this.label2.Text = "TX";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Menu;
            this.label1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label1.Location = new System.Drawing.Point(18, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 35;
            this.label1.Text = "Porta ";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.verticalProgressBar1);
            this.panel1.Controls.Add(this.btnOpen);
            this.panel1.Location = new System.Drawing.Point(557, 286);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(293, 150);
            this.panel1.TabIndex = 42;
            this.panel1.Tag = "";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(57, 129);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(52, 54);
            this.pictureBox2.TabIndex = 50;
            this.pictureBox2.TabStop = false;
            // 
            // Lhumidade
            // 
            this.Lhumidade.AutoSize = true;
            this.Lhumidade.Font = new System.Drawing.Font("Microsoft YaHei", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lhumidade.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Lhumidade.Location = new System.Drawing.Point(152, 142);
            this.Lhumidade.Name = "Lhumidade";
            this.Lhumidade.Size = new System.Drawing.Size(116, 39);
            this.Lhumidade.TabIndex = 1;
            this.Lhumidade.Text = "Humid";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Gainsboro;
            this.panel5.Controls.Add(this.pictureBox3);
            this.panel5.Controls.Add(this.Lvento);
            this.panel5.Location = new System.Drawing.Point(557, 88);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(303, 181);
            this.panel5.TabIndex = 45;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(21, 61);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(51, 51);
            this.pictureBox3.TabIndex = 50;
            this.pictureBox3.TabStop = false;
            // 
            // Lvento
            // 
            this.Lvento.AutoSize = true;
            this.Lvento.Font = new System.Drawing.Font("Microsoft YaHei", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lvento.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Lvento.Location = new System.Drawing.Point(105, 73);
            this.Lvento.Name = "Lvento";
            this.Lvento.Size = new System.Drawing.Size(105, 39);
            this.Lvento.TabIndex = 1;
            this.Lvento.Text = "Vento";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(61, 42);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 54);
            this.pictureBox1.TabIndex = 48;
            this.pictureBox1.TabStop = false;
            // 
            // Ltemperatura
            // 
            this.Ltemperatura.AutoSize = true;
            this.Ltemperatura.Font = new System.Drawing.Font("Microsoft YaHei", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ltemperatura.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Ltemperatura.Location = new System.Drawing.Point(152, 55);
            this.Ltemperatura.Name = "Ltemperatura";
            this.Ltemperatura.Size = new System.Drawing.Size(99, 39);
            this.Ltemperatura.TabIndex = 0;
            this.Ltemperatura.Text = "Temp";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Gainsboro;
            this.panel4.Controls.Add(this.pictureBox1);
            this.panel4.Controls.Add(this.Lhumidade);
            this.panel4.Controls.Add(this.Lchuva);
            this.panel4.Controls.Add(this.pictureBox2);
            this.panel4.Controls.Add(this.Ltemperatura);
            this.panel4.Controls.Add(this.pictureBox4);
            this.panel4.Location = new System.Drawing.Point(28, 88);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(500, 348);
            this.panel4.TabIndex = 47;
            // 
            // Lchuva
            // 
            this.Lchuva.AutoSize = true;
            this.Lchuva.Font = new System.Drawing.Font("Microsoft YaHei", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lchuva.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Lchuva.Location = new System.Drawing.Point(153, 241);
            this.Lchuva.Name = "Lchuva";
            this.Lchuva.Size = new System.Drawing.Size(196, 31);
            this.Lchuva.TabIndex = 53;
            this.Lchuva.Text = "Total de Chuva";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(40, 219);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(82, 74);
            this.pictureBox4.TabIndex = 51;
            this.pictureBox4.TabStop = false;
            // 
            // txtcity
            // 
            this.txtcity.AutoSize = true;
            this.txtcity.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtcity.Location = new System.Drawing.Point(280, 219);
            this.txtcity.Name = "txtcity";
            this.txtcity.Size = new System.Drawing.Size(35, 13);
            this.txtcity.TabIndex = 48;
            this.txtcity.Text = "label3";
            // 
            // verticalProgressBar1
            // 
            this.verticalProgressBar1.BackColor = System.Drawing.SystemColors.MenuText;
            this.verticalProgressBar1.Location = new System.Drawing.Point(232, 17);
            this.verticalProgressBar1.Name = "verticalProgressBar1";
            this.verticalProgressBar1.Size = new System.Drawing.Size(52, 120);
            this.verticalProgressBar1.TabIndex = 41;
            // 
            // Dashboard
            // 
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(914, 532);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.txtcity);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.ComboBoxPort);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.comboBoxTx);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(241, 148);
            this.Name = "Dashboard";
            this.Tag = "";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.ComboBox comboBoxTx;
        private System.Windows.Forms.ComboBox ComboBoxPort;
        private VerticalProgressBar verticalProgressBar1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.IO.Ports.SerialPort serialPort2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label Lhumidade;
        private System.Windows.Forms.Label Lvento;
        private System.Windows.Forms.Label Ltemperatura;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label Lchuva;
        private System.Windows.Forms.Label txtcity;
    }
}

