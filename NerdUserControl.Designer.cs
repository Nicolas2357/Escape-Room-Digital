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
            btnVolver.Location = new Point(1656, 952);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(156, 67);
            btnVolver.TabIndex = 0;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += btnVolver_Click;
            // 
            // lblAcertijo
            // 
            lblAcertijo.AutoSize = true;
            lblAcertijo.Font = new Font("Determination Mono Web", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAcertijo.Location = new Point(56, 30);
            lblAcertijo.Name = "lblAcertijo";
            lblAcertijo.Size = new Size(117, 35);
            lblAcertijo.TabIndex = 1;
            lblAcertijo.Text = "label1";
            // 
            // lblIntentos
            // 
            lblIntentos.AutoSize = true;
            lblIntentos.Location = new Point(56, 140);
            lblIntentos.Name = "lblIntentos";
            lblIntentos.Size = new Size(69, 20);
            lblIntentos.TabIndex = 2;
            lblIntentos.Text = "label1";
            // 
            // btnValidar
            // 
            btnValidar.BackColor = SystemColors.ActiveCaptionText;
            btnValidar.ForeColor = SystemColors.ButtonFace;
            btnValidar.Location = new Point(880, 1008);
            btnValidar.Name = "btnValidar";
            btnValidar.Size = new Size(197, 57);
            btnValidar.TabIndex = 3;
            btnValidar.Text = "Validar";
            btnValidar.UseVisualStyleBackColor = false;
            btnValidar.Click += btnValidar_Click;
            // 
            // txtRespuesta
            // 
            txtRespuesta.BackColor = SystemColors.InfoText;
            txtRespuesta.Font = new Font("Determination Mono Web", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtRespuesta.ForeColor = SystemColors.Info;
            txtRespuesta.Location = new Point(889, 943);
            txtRespuesta.Name = "txtRespuesta";
            txtRespuesta.Size = new Size(177, 41);
            txtRespuesta.TabIndex = 4;
            // 
            // lblPista1
            // 
            lblPista1.AutoSize = true;
            lblPista1.BackColor = Color.FromArgb(128, 64, 0);
            lblPista1.Font = new Font("Determination Mono Web", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPista1.Image = Properties.Resources.WoodImage;
            lblPista1.Location = new Point(278, 453);
            lblPista1.Name = "lblPista1";
            lblPista1.Size = new Size(168, 70);
            lblPista1.TabIndex = 5;
            lblPista1.Text = "EL LEÓN \r\nESTÁ AQUÍ";
            // 
            // lblPista2
            // 
            lblPista2.AutoSize = true;
            lblPista2.BackColor = Color.FromArgb(128, 64, 0);
            lblPista2.Font = new Font("Determination Mono Web", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPista2.Image = Properties.Resources.WoodImage;
            lblPista2.Location = new Point(880, 453);
            lblPista2.Name = "lblPista2";
            lblPista2.Size = new Size(202, 70);
            lblPista2.TabIndex = 6;
            lblPista2.Text = "EL LEÓN NO \r\nESTÁ AQUÍ";
            // 
            // lblPista3
            // 
            lblPista3.AutoSize = true;
            lblPista3.BackColor = Color.FromArgb(128, 64, 0);
            lblPista3.Font = new Font("Determination Mono Web", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPista3.Image = Properties.Resources.WoodImage;
            lblPista3.Location = new Point(1514, 468);
            lblPista3.Name = "lblPista3";
            lblPista3.Size = new Size(134, 35);
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
            pbTiempo.Location = new Point(26, 991);
            pbTiempo.Maximum = 60;
            pbTiempo.Name = "pbTiempo";
            pbTiempo.Size = new Size(807, 42);
            pbTiempo.TabIndex = 8;
            pbTiempo.Value = 60;
            // 
            // lblCronómetro
            // 
            lblCronómetro.AutoSize = true;
            lblCronómetro.Location = new Point(26, 943);
            lblCronómetro.Name = "lblCronómetro";
            lblCronómetro.Size = new Size(0, 20);
            lblCronómetro.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(128, 64, 0);
            label1.Font = new Font("Determination Mono Web", 60F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Image = Properties.Resources.WoodImage;
            label1.Location = new Point(314, 181);
            label1.Name = "label1";
            label1.RightToLeft = RightToLeft.No;
            label1.Size = new Size(93, 102);
            label1.TabIndex = 10;
            label1.Text = "1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(128, 64, 0);
            label2.Font = new Font("Determination Mono Web", 60F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Image = Properties.Resources.WoodImage;
            label2.Location = new Point(914, 181);
            label2.Name = "label2";
            label2.RightToLeft = RightToLeft.No;
            label2.Size = new Size(93, 102);
            label2.TabIndex = 11;
            label2.Text = "2";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.FromArgb(128, 64, 0);
            label3.Font = new Font("Determination Mono Web", 60F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Image = Properties.Resources.WoodImage;
            label3.Location = new Point(1523, 181);
            label3.Name = "label3";
            label3.RightToLeft = RightToLeft.No;
            label3.Size = new Size(93, 102);
            label3.TabIndex = 12;
            label3.Text = "3";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = SystemColors.ActiveCaptionText;
            label4.BorderStyle = BorderStyle.FixedSingle;
            label4.Font = new Font("Determination Mono Web", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(904, 908);
            label4.Name = "label4";
            label4.Size = new Size(150, 32);
            label4.TabIndex = 13;
            label4.Text = "Respuesta";
            // 
            // pnlNerd
            // 
            pnlNerd.Controls.Add(btnContinuarRight);
            pnlNerd.Controls.Add(lblDialogoNerd);
            pnlNerd.Controls.Add(pictureBox4);
            pnlNerd.Location = new Point(659, 378);
            pnlNerd.Name = "pnlNerd";
            pnlNerd.Size = new Size(600, 277);
            pnlNerd.TabIndex = 14;
            pnlNerd.Visible = false;
            pnlNerd.Paint += pnlNerd_Paint;
            // 
            // btnContinuarRight
            // 
            btnContinuarRight.BackColor = SystemColors.ActiveCaptionText;
            btnContinuarRight.ForeColor = SystemColors.ButtonHighlight;
            btnContinuarRight.Location = new Point(230, 183);
            btnContinuarRight.Name = "btnContinuarRight";
            btnContinuarRight.Size = new Size(149, 57);
            btnContinuarRight.TabIndex = 19;
            btnContinuarRight.Text = "Continuar";
            btnContinuarRight.UseVisualStyleBackColor = false;
            btnContinuarRight.Click += btnContinuarRight_Click;
            // 
            // lblDialogoNerd
            // 
            lblDialogoNerd.AutoSize = true;
            lblDialogoNerd.Font = new Font("Determination Mono Web", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDialogoNerd.ForeColor = SystemColors.ButtonFace;
            lblDialogoNerd.Location = new Point(174, 29);
            lblDialogoNerd.Name = "lblDialogoNerd";
            lblDialogoNerd.Size = new Size(405, 116);
            lblDialogoNerd.TabIndex = 18;
            lblDialogoNerd.Text = "WOW! LO LOGRASTE!! Muy bien \r\nhecho, por fin pudiste \r\nresolver este acertijo tan\r\ndificil!\r\n";
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = Color.Transparent;
            pictureBox4.Image = Properties.Resources.SpamtonStill;
            pictureBox4.Location = new Point(36, 25);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(115, 147);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 17;
            pictureBox4.TabStop = false;
            // 
            // pnlNerdIncorrecto
            // 
            pnlNerdIncorrecto.Controls.Add(btnContinuarFail);
            pnlNerdIncorrecto.Controls.Add(label5);
            pnlNerdIncorrecto.Controls.Add(pictureBox1);
            pnlNerdIncorrecto.Location = new Point(659, 378);
            pnlNerdIncorrecto.Name = "pnlNerdIncorrecto";
            pnlNerdIncorrecto.Size = new Size(600, 277);
            pnlNerdIncorrecto.TabIndex = 20;
            pnlNerdIncorrecto.Visible = false;
            pnlNerdIncorrecto.Paint += pnlNerdIncorrecto_Paint;
            // 
            // btnContinuarFail
            // 
            btnContinuarFail.BackColor = SystemColors.ActiveCaptionText;
            btnContinuarFail.ForeColor = SystemColors.ButtonHighlight;
            btnContinuarFail.Location = new Point(245, 183);
            btnContinuarFail.Name = "btnContinuarFail";
            btnContinuarFail.Size = new Size(149, 57);
            btnContinuarFail.TabIndex = 19;
            btnContinuarFail.Text = "Continuar";
            btnContinuarFail.UseVisualStyleBackColor = false;
            btnContinuarFail.Click += btnContinuarFail_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Determination Mono Web", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = SystemColors.ButtonFace;
            label5.Location = new Point(164, 25);
            label5.Name = "label5";
            label5.Size = new Size(349, 87);
            label5.TabIndex = 18;
            label5.Text = "Bueno, tal vez las \r\nmatemáticas no son para \r\ntodos...";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = Properties.Resources.SpamtonStill;
            pictureBox1.Location = new Point(36, 25);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(115, 147);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 17;
            pictureBox1.TabStop = false;
            // 
            // NerdUserControl
            // 
            AutoScaleDimensions = new SizeF(10F, 20F);
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
            Name = "NerdUserControl";
            Size = new Size(1920, 1080);
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
