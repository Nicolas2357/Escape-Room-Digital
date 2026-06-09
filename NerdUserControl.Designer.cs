namespace Escape_Room_Digital.UserControls
{
    partial class NerdUserControl
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            btnVolver = new Button();
            lblAcertijo = new Label();
            lblIntentos = new Label();
            btnValidar = new Button();
            txtRespuesta = new TextBox();
            lblPista1 = new Label();
            lblPista2 = new Label();
            lblPista3 = new Label();
            timerCronómetro = new System.Windows.Forms.Timer(components);
            pbTiempo = new ProgressBar();
            lblCronómetro = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            pnlNerd = new Panel();
            btnContinuarRight = new Button();
            lblDialogoNerd = new Label();
            pictureBox4 = new PictureBox();
            pnlNerdIncorrecto = new Panel();
            btnContinuarFail = new Button();
            label5 = new Label();
            pictureBox1 = new PictureBox();
            pnlNerd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            pnlNerdIncorrecto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnVolver
            // 
            btnVolver.BackColor = SystemColors.ActiveCaptionText;
            btnVolver.ForeColor = SystemColors.Control;
            btnVolver.Location = new Point(1750, 980);
            btnVolver.Margin = new Padding(4, 4, 4, 4);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(140, 56);
            btnVolver.TabIndex = 0;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += btnVolver_Click;
            // 
            // lblAcertijo
            // 
            lblAcertijo.AutoSize = true;
            lblAcertijo.Font = new Font("Microsoft Sans Serif", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAcertijo.Location = new Point(50, 30);
            lblAcertijo.Margin = new Padding(4, 0, 4, 0);
            lblAcertijo.Name = "lblAcertijo";
            lblAcertijo.Size = new Size(109, 39);
            lblAcertijo.TabIndex = 1;
            lblAcertijo.Text = "label1";
            // 
            // lblIntentos
            // 
            lblIntentos.AutoSize = true;
            lblIntentos.Location = new Point(50, 140);
            lblIntentos.Margin = new Padding(4, 0, 4, 0);
            lblIntentos.Name = "lblIntentos";
            lblIntentos.Size = new Size(64, 25);
            lblIntentos.TabIndex = 2;
            lblIntentos.Text = "label1";
            // 
            // btnValidar
            // 
            btnValidar.BackColor = SystemColors.ActiveCaptionText;
            btnValidar.ForeColor = SystemColors.ButtonFace;
            btnValidar.Location = new Point(860, 1010);
            btnValidar.Margin = new Padding(4, 4, 4, 4);
            btnValidar.Name = "btnValidar";
            btnValidar.Size = new Size(180, 55);
            btnValidar.TabIndex = 3;
            btnValidar.Text = "Validar";
            btnValidar.UseVisualStyleBackColor = false;
            btnValidar.Click += btnValidar_Click;
            // 
            // txtRespuesta
            // 
            txtRespuesta.BackColor = SystemColors.InfoText;
            txtRespuesta.Font = new Font("Microsoft Sans Serif", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtRespuesta.ForeColor = SystemColors.Info;
            txtRespuesta.Location = new Point(870, 950);
            txtRespuesta.Margin = new Padding(4, 4, 4, 4);
            txtRespuesta.Name = "txtRespuesta";
            txtRespuesta.Size = new Size(160, 45);
            txtRespuesta.TabIndex = 4;
            // 
            // lblPista1
            // 
            lblPista1.AutoSize = true;
            lblPista1.BackColor = Color.FromArgb(128, 64, 0);
            lblPista1.Font = new Font("Microsoft Sans Serif", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPista1.Image = Properties.Resources.WoodImage;
            lblPista1.Location = new Point(270, 450);
            lblPista1.Margin = new Padding(4, 0, 4, 0);
            lblPista1.Name = "lblPista1";
            lblPista1.Size = new Size(200, 78);
            lblPista1.TabIndex = 5;
            lblPista1.Text = "EL LEÓN \r\nESTÁ AQUÍ";
            // 
            // lblPista2
            // 
            lblPista2.AutoSize = true;
            lblPista2.BackColor = Color.FromArgb(128, 64, 0);
            lblPista2.Font = new Font("Microsoft Sans Serif", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPista2.Image = Properties.Resources.WoodImage;
            lblPista2.Location = new Point(850, 450);
            lblPista2.Margin = new Padding(4, 0, 4, 0);
            lblPista2.Name = "lblPista2";
            lblPista2.Size = new Size(230, 78);
            lblPista2.TabIndex = 6;
            lblPista2.Text = "EL LEÓN NO \r\nESTÁ AQUÍ";
            // 
            // lblPista3
            // 
            lblPista3.AutoSize = true;
            lblPista3.BackColor = Color.FromArgb(128, 64, 0);
            lblPista3.Font = new Font("Microsoft Sans Serif", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPista3.Image = Properties.Resources.WoodImage;
            lblPista3.Location = new Point(1450, 460);
            lblPista3.Margin = new Padding(4, 0, 4, 0);
            lblPista3.Name = "lblPista3";
            lblPista3.Size = new Size(156, 39);
            lblPista3.TabIndex = 7;
            lblPista3.Text = "2+3=2X3";
            // 
            // timerCronómetro
            // 
            timerCronómetro.Interval = 1000;
            timerCronómetro.Tick += timerCronómetro_Tick;
            // 
            // pbTiempo
            // 
            pbTiempo.Location = new Point(25, 990);
            pbTiempo.Margin = new Padding(4, 4, 4, 4);
            pbTiempo.Maximum = 60;
            pbTiempo.Name = "pbTiempo";
            pbTiempo.Size = new Size(780, 40);
            pbTiempo.TabIndex = 8;
            pbTiempo.Value = 60;
            // 
            // lblCronómetro
            // 
            lblCronómetro.AutoSize = true;
            lblCronómetro.Location = new Point(25, 950);
            lblCronómetro.Margin = new Padding(4, 0, 4, 0);
            lblCronómetro.Name = "lblCronómetro";
            lblCronómetro.Size = new Size(0, 25);
            lblCronómetro.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(128, 64, 0);
            label1.Font = new Font("Microsoft Sans Serif", 60F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Image = Properties.Resources.WoodImage;
            label1.Location = new Point(300, 180);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.RightToLeft = RightToLeft.No;
            label1.Size = new Size(104, 113);
            label1.TabIndex = 10;
            label1.Text = "1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(128, 64, 0);
            label2.Font = new Font("Microsoft Sans Serif", 60F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Image = Properties.Resources.WoodImage;
            label2.Location = new Point(880, 180);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.RightToLeft = RightToLeft.No;
            label2.Size = new Size(104, 113);
            label2.TabIndex = 11;
            label2.Text = "2";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.FromArgb(128, 64, 0);
            label3.Font = new Font("Microsoft Sans Serif", 60F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Image = Properties.Resources.WoodImage;
            label3.Location = new Point(1460, 180);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.RightToLeft = RightToLeft.No;
            label3.Size = new Size(104, 113);
            label3.TabIndex = 12;
            label3.Text = "3";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = SystemColors.ActiveCaptionText;
            label4.BorderStyle = BorderStyle.FixedSingle;
            label4.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(875, 910);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(159, 38);
            label4.TabIndex = 13;
            label4.Text = "Respuesta";
            // 
            // pnlNerd
            // 
            pnlNerd.Controls.Add(btnContinuarRight);
            pnlNerd.Controls.Add(lblDialogoNerd);
            pnlNerd.Controls.Add(pictureBox4);
            pnlNerd.Location = new Point(600, 380);
            pnlNerd.Margin = new Padding(4, 4, 4, 4);
            pnlNerd.Name = "pnlNerd";
            pnlNerd.Size = new Size(720, 346);
            pnlNerd.TabIndex = 14;
            pnlNerd.Visible = false;
            pnlNerd.Paint += pnlNerd_Paint;
            // 
            // btnContinuarRight
            // 
            btnContinuarRight.BackColor = SystemColors.ActiveCaptionText;
            btnContinuarRight.ForeColor = SystemColors.ButtonHighlight;
            btnContinuarRight.Location = new Point(276, 229);
            btnContinuarRight.Margin = new Padding(4, 4, 4, 4);
            btnContinuarRight.Name = "btnContinuarRight";
            btnContinuarRight.Size = new Size(179, 71);
            btnContinuarRight.TabIndex = 19;
            btnContinuarRight.Text = "Continuar";
            btnContinuarRight.UseVisualStyleBackColor = false;
            btnContinuarRight.Click += btnContinuarRight_Click;
            // 
            // lblDialogoNerd
            // 
            lblDialogoNerd.AutoSize = true;
            lblDialogoNerd.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDialogoNerd.ForeColor = SystemColors.ButtonFace;
            lblDialogoNerd.Location = new Point(209, 36);
            lblDialogoNerd.Margin = new Padding(4, 0, 4, 0);
            lblDialogoNerd.Name = "lblDialogoNerd";
            lblDialogoNerd.Size = new Size(447, 128);
            lblDialogoNerd.TabIndex = 18;
            lblDialogoNerd.Text = "WOW! LO LOGRASTE!! Muy bien \r\nhecho, por fin pudiste \r\nresolver este acertijo tan\r\ndificil!\r\n";
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = Color.Transparent;
            pictureBox4.Image = Properties.Resources.SpamtonStill;
            pictureBox4.Location = new Point(43, 31);
            pictureBox4.Margin = new Padding(4, 4, 4, 4);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(138, 184);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 17;
            pictureBox4.TabStop = false;
            // 
            // pnlNerdIncorrecto
            // 
            pnlNerdIncorrecto.Controls.Add(btnContinuarFail);
            pnlNerdIncorrecto.Controls.Add(label5);
            pnlNerdIncorrecto.Controls.Add(pictureBox1);
            pnlNerdIncorrecto.Location = new Point(600, 380);
            pnlNerdIncorrecto.Margin = new Padding(4, 4, 4, 4);
            pnlNerdIncorrecto.Name = "pnlNerdIncorrecto";
            pnlNerdIncorrecto.Size = new Size(720, 346);
            pnlNerdIncorrecto.TabIndex = 20;
            pnlNerdIncorrecto.Visible = false;
            pnlNerdIncorrecto.Paint += pnlNerdIncorrecto_Paint;
            // 
            // btnContinuarFail
            // 
            btnContinuarFail.BackColor = SystemColors.ActiveCaptionText;
            btnContinuarFail.ForeColor = SystemColors.ButtonHighlight;
            btnContinuarFail.Location = new Point(294, 229);
            btnContinuarFail.Margin = new Padding(4, 4, 4, 4);
            btnContinuarFail.Name = "btnContinuarFail";
            btnContinuarFail.Size = new Size(179, 71);
            btnContinuarFail.TabIndex = 19;
            btnContinuarFail.Text = "Continuar";
            btnContinuarFail.UseVisualStyleBackColor = false;
            btnContinuarFail.Click += btnContinuarFail_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = SystemColors.ButtonFace;
            label5.Location = new Point(197, 31);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(338, 96);
            label5.TabIndex = 18;
            label5.Text = "Bueno, tal vez las \r\nmatemáticas no son para \r\ntodos...";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = Properties.Resources.SpamtonStill;
            pictureBox1.Location = new Point(43, 31);
            pictureBox1.Margin = new Padding(4, 4, 4, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(138, 184);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 17;
            pictureBox1.TabStop = false;
            // 
            // NerdUserControl
            // 
            AutoScaleDimensions = new SizeF(12F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            BackgroundImage = Properties.Resources.BackgroundNerd;
            BackgroundImageLayout = ImageLayout.Stretch;
            Controls.Add(pnlNerdIncorrecto);
            Controls.Add(pnlNerd);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblCronómetro);
            Controls.Add(pbTiempo);
            Controls.Add(lblPista3);
            Controls.Add(lblPista2);
            Controls.Add(lblPista1);
            Controls.Add(txtRespuesta);
            Controls.Add(btnValidar);
            Controls.Add(lblIntentos);
            Controls.Add(lblAcertijo);
            Controls.Add(btnVolver);
            DoubleBuffered = true;
            Margin = new Padding(6, 5, 6, 5);
            Name = "NerdUserControl";
            Size = new Size(1920, 1080);
            Load += NerdUserControl_Load;
            pnlNerd.ResumeLayout(false);
            pnlNerd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            pnlNerdIncorrecto.ResumeLayout(false);
            pnlNerdIncorrecto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnVolver;
        private Label lblAcertijo;
        private Label lblIntentos;
        private Button btnValidar;
        private TextBox txtRespuesta;
        private Label lblPista1;
        private Label lblPista2;
        private Label lblPista3;
        private System.Windows.Forms.Timer timerCronómetro;
        private Label lblCronómetro;
        private Label label1;
        private Label label2;
        private Label label3;
        public ProgressBar pbTiempo;
        private Label label4;
        private Panel pnlNerd;
        private PictureBox pictureBox4;
        private Label lblDialogoNerd;
        private Button btnContinuarRight;
        private Panel pnlNerdIncorrecto;
        private Button btnContinuarFail;
        private Label label5;
        private PictureBox pictureBox1;
    }
}
