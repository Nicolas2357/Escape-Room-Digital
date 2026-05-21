namespace Escape_Room_Digital.UserControls
{
    partial class JefeFinalTenna
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
            btnRegresar = new Button();
            pbStand = new PictureBox();
            lblStand = new Label();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            pnlDialogoUnico = new Panel();
            lblTextoUnico = new Label();
            btnValidar = new Button();
            txtBoxRespuesta = new TextBox();
            lblNombreUnico = new Label();
            btnContinuar = new Button();
            pbRetratoPanel = new PictureBox();
            pbTacha1 = new PictureBox();
            pbTacha2 = new PictureBox();
            pbTacha3 = new PictureBox();
            timerCronometro = new System.Windows.Forms.Timer(components);
            timerAnimacionTexto = new System.Windows.Forms.Timer(components);
            pbTiempo = new ProgressBar();
            lblCronometro = new Label();
            timerCambioFondo = new System.Windows.Forms.Timer(components);
            btnReintentar = new Button();
            btnSalirFinal = new Button();
            ((System.ComponentModel.ISupportInitialize)pbStand).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            pnlDialogoUnico.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbRetratoPanel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbTacha1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbTacha2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbTacha3).BeginInit();
            SuspendLayout();
            // 
            // btnRegresar
            // 
            btnRegresar.BackColor = SystemColors.ActiveCaptionText;
            btnRegresar.ForeColor = SystemColors.ButtonFace;
            btnRegresar.Location = new Point(1751, 34);
            btnRegresar.Name = "btnRegresar";
            btnRegresar.Size = new Size(151, 61);
            btnRegresar.TabIndex = 0;
            btnRegresar.Text = "Regresar";
            btnRegresar.UseVisualStyleBackColor = false;
            btnRegresar.Click += btnRegresar_Click;
            // 
            // pbStand
            // 
            pbStand.BackColor = Color.Transparent;
            pbStand.Image = Properties.Resources.StandTenna1;
            pbStand.Location = new Point(199, 661);
            pbStand.Name = "pbStand";
            pbStand.Size = new Size(321, 336);
            pbStand.SizeMode = PictureBoxSizeMode.StretchImage;
            pbStand.TabIndex = 1;
            pbStand.TabStop = false;
            // 
            // lblStand
            // 
            lblStand.BackColor = Color.LightSeaGreen;
            lblStand.Font = new Font("Determination Mono Web", 22.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStand.ForeColor = SystemColors.ButtonHighlight;
            lblStand.Location = new Point(245, 746);
            lblStand.Name = "lblStand";
            lblStand.Size = new Size(230, 63);
            lblStand.TabIndex = 2;
            lblStand.Text = "Desconocido";
            lblStand.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = Properties.Resources.SkeletonRightWalk;
            pictureBox1.Location = new Point(118, 402);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(521, 511);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Image = Properties.Resources.TennaIdle;
            pictureBox2.Location = new Point(1218, 171);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(600, 756);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 4;
            pictureBox2.TabStop = false;
            // 
            // pnlDialogoUnico
            // 
            pnlDialogoUnico.Controls.Add(lblTextoUnico);
            pnlDialogoUnico.Controls.Add(btnValidar);
            pnlDialogoUnico.Controls.Add(txtBoxRespuesta);
            pnlDialogoUnico.Controls.Add(lblNombreUnico);
            pnlDialogoUnico.Controls.Add(btnContinuar);
            pnlDialogoUnico.Controls.Add(pbRetratoPanel);
            pnlDialogoUnico.Location = new Point(547, 766);
            pnlDialogoUnico.Margin = new Padding(3, 3, 3, 20);
            pnlDialogoUnico.Name = "pnlDialogoUnico";
            pnlDialogoUnico.Size = new Size(843, 294);
            pnlDialogoUnico.TabIndex = 21;
            pnlDialogoUnico.Visible = false;
            pnlDialogoUnico.Paint += pnlDialogoUnico_Paint;
            // 
            // lblTextoUnico
            // 
            lblTextoUnico.BackColor = Color.Black;
            lblTextoUnico.Font = new Font("Determination Mono Web", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTextoUnico.ForeColor = Color.White;
            lblTextoUnico.Location = new Point(176, 38);
            lblTextoUnico.Name = "lblTextoUnico";
            lblTextoUnico.Size = new Size(646, 178);
            lblTextoUnico.TabIndex = 0;
            lblTextoUnico.Text = "label1";
            // 
            // btnValidar
            // 
            btnValidar.BackColor = SystemColors.ActiveCaptionText;
            btnValidar.ForeColor = SystemColors.ButtonHighlight;
            btnValidar.Location = new Point(648, 219);
            btnValidar.Name = "btnValidar";
            btnValidar.Size = new Size(174, 57);
            btnValidar.TabIndex = 22;
            btnValidar.Text = "Validar";
            btnValidar.UseVisualStyleBackColor = false;
            btnValidar.Visible = false;
            btnValidar.Click += btnValidar_Click;
            // 
            // txtBoxRespuesta
            // 
            txtBoxRespuesta.BackColor = SystemColors.InactiveCaptionText;
            txtBoxRespuesta.Font = new Font("Determination Mono Web", 22.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBoxRespuesta.ForeColor = SystemColors.Info;
            txtBoxRespuesta.Location = new Point(219, 223);
            txtBoxRespuesta.Name = "txtBoxRespuesta";
            txtBoxRespuesta.Size = new Size(414, 45);
            txtBoxRespuesta.TabIndex = 21;
            txtBoxRespuesta.Visible = false;
            // 
            // lblNombreUnico
            // 
            lblNombreUnico.AutoSize = true;
            lblNombreUnico.Font = new Font("Determination Mono Web", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNombreUnico.ForeColor = SystemColors.ButtonFace;
            lblNombreUnico.Location = new Point(57, 27);
            lblNombreUnico.Name = "lblNombreUnico";
            lblNombreUnico.Size = new Size(103, 30);
            lblNombreUnico.TabIndex = 20;
            lblNombreUnico.Text = "label1";
            // 
            // btnContinuar
            // 
            btnContinuar.BackColor = SystemColors.ActiveCaptionText;
            btnContinuar.ForeColor = SystemColors.ButtonHighlight;
            btnContinuar.Location = new Point(39, 219);
            btnContinuar.Name = "btnContinuar";
            btnContinuar.Size = new Size(174, 57);
            btnContinuar.TabIndex = 19;
            btnContinuar.Text = "Continuar";
            btnContinuar.UseVisualStyleBackColor = false;
            btnContinuar.Click += btnContinuar_Click;
            // 
            // pbRetratoPanel
            // 
            pbRetratoPanel.BackColor = Color.Transparent;
            pbRetratoPanel.Image = Properties.Resources.TennaIdle;
            pbRetratoPanel.Location = new Point(48, 72);
            pbRetratoPanel.Name = "pbRetratoPanel";
            pbRetratoPanel.Size = new Size(112, 132);
            pbRetratoPanel.SizeMode = PictureBoxSizeMode.Zoom;
            pbRetratoPanel.TabIndex = 16;
            pbRetratoPanel.TabStop = false;
            // 
            // pbTacha1
            // 
            pbTacha1.BackColor = Color.Transparent;
            pbTacha1.Image = Properties.Resources.XSymbol;
            pbTacha1.Location = new Point(24, 18);
            pbTacha1.Name = "pbTacha1";
            pbTacha1.Size = new Size(189, 194);
            pbTacha1.SizeMode = PictureBoxSizeMode.Zoom;
            pbTacha1.TabIndex = 22;
            pbTacha1.TabStop = false;
            pbTacha1.Visible = false;
            // 
            // pbTacha2
            // 
            pbTacha2.BackColor = Color.Transparent;
            pbTacha2.Image = Properties.Resources.XSymbol;
            pbTacha2.Location = new Point(219, 18);
            pbTacha2.Name = "pbTacha2";
            pbTacha2.Size = new Size(189, 194);
            pbTacha2.SizeMode = PictureBoxSizeMode.Zoom;
            pbTacha2.TabIndex = 23;
            pbTacha2.TabStop = false;
            pbTacha2.Visible = false;
            // 
            // pbTacha3
            // 
            pbTacha3.BackColor = Color.Transparent;
            pbTacha3.Image = Properties.Resources.XSymbol;
            pbTacha3.Location = new Point(414, 18);
            pbTacha3.Name = "pbTacha3";
            pbTacha3.Size = new Size(189, 194);
            pbTacha3.SizeMode = PictureBoxSizeMode.Zoom;
            pbTacha3.TabIndex = 24;
            pbTacha3.TabStop = false;
            pbTacha3.Visible = false;
            // 
            // timerCronometro
            // 
            timerCronometro.Interval = 1000;
            timerCronometro.Tick += timerCronometro_Tick;
            // 
            // timerAnimacionTexto
            // 
            timerAnimacionTexto.Interval = 50;
            timerAnimacionTexto.Tick += timerAnimacionTexto_Tick;
            // 
            // pbTiempo
            // 
            pbTiempo.Location = new Point(1406, 989);
            pbTiempo.Maximum = 300;
            pbTiempo.Name = "pbTiempo";
            pbTiempo.Size = new Size(446, 45);
            pbTiempo.TabIndex = 25;
            pbTiempo.Value = 300;
            // 
            // lblCronometro
            // 
            lblCronometro.AutoSize = true;
            lblCronometro.BackColor = Color.Transparent;
            lblCronometro.ForeColor = SystemColors.ActiveCaptionText;
            lblCronometro.Location = new Point(1406, 940);
            lblCronometro.Name = "lblCronometro";
            lblCronometro.Size = new Size(133, 30);
            lblCronometro.TabIndex = 26;
            lblCronometro.Text = "Tiempo: ";
            // 
            // btnReintentar
            // 
            btnReintentar.BackColor = SystemColors.ActiveCaptionText;
            btnReintentar.ForeColor = SystemColors.ButtonHighlight;
            btnReintentar.Location = new Point(118, 305);
            btnReintentar.Name = "btnReintentar";
            btnReintentar.Size = new Size(197, 72);
            btnReintentar.TabIndex = 23;
            btnReintentar.Text = "Reintentar";
            btnReintentar.UseVisualStyleBackColor = false;
            btnReintentar.Visible = false;
            // 
            // btnSalirFinal
            // 
            btnSalirFinal.BackColor = SystemColors.ActiveCaptionText;
            btnSalirFinal.ForeColor = SystemColors.ButtonHighlight;
            btnSalirFinal.Location = new Point(442, 305);
            btnSalirFinal.Name = "btnSalirFinal";
            btnSalirFinal.Size = new Size(197, 72);
            btnSalirFinal.TabIndex = 27;
            btnSalirFinal.Text = "Salir";
            btnSalirFinal.UseVisualStyleBackColor = false;
            btnSalirFinal.Visible = false;
            // 
            // JefeFinalTenna
            // 
            AutoScaleDimensions = new SizeF(15F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            BackgroundImage = Properties.Resources.TennaQuizzesBackground;
            BackgroundImageLayout = ImageLayout.Zoom;
            Controls.Add(btnSalirFinal);
            Controls.Add(btnReintentar);
            Controls.Add(lblCronometro);
            Controls.Add(pbTiempo);
            Controls.Add(pbTacha3);
            Controls.Add(pbTacha2);
            Controls.Add(pbTacha1);
            Controls.Add(pnlDialogoUnico);
            Controls.Add(pictureBox2);
            Controls.Add(lblStand);
            Controls.Add(pbStand);
            Controls.Add(btnRegresar);
            Controls.Add(pictureBox1);
            Font = new Font("Determination Mono Web", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = SystemColors.ButtonHighlight;
            Margin = new Padding(6, 4, 6, 4);
            Name = "JefeFinalTenna";
            Size = new Size(1920, 1080);
            ((System.ComponentModel.ISupportInitialize)pbStand).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            pnlDialogoUnico.ResumeLayout(false);
            pnlDialogoUnico.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbRetratoPanel).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbTacha1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbTacha2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbTacha3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnRegresar;
        private PictureBox pbStand;
        private Label lblStand;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Panel pnlDialogoUnico;
        private Label lblNombreUnico;
        private Button btnContinuar;
        private PictureBox pbRetratoPanel;
        private Label lblTextoUnico;
        private Button btnValidar;
        private TextBox txtBoxRespuesta;
        private PictureBox pbTacha1;
        private PictureBox pbTacha2;
        private PictureBox pbTacha3;
        private System.Windows.Forms.Timer timerCronometro;
        private System.Windows.Forms.Timer timerAnimacionTexto;
        private ProgressBar pbTiempo;
        private Label lblCronometro;
        private System.Windows.Forms.Timer timerCambioFondo;
        private Button btnReintentar;
        private Button btnSalirFinal;
    }
}
