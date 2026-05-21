namespace Escape_Room_Digital.UserControls
{
    partial class NerdUserControl2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NerdUserControl2));
            lblAcertijo = new Label();
            pnlNerd = new Panel();
            btnAceptarNerd = new Button();
            btnContinuarFailNerd = new Button();
            lblNerd = new Label();
            pictureBox1 = new PictureBox();
            lblRespuesta = new Label();
            txtRespuesta = new TextBox();
            btnValidar = new Button();
            pbTiempo = new ProgressBar();
            lblCronometro = new Label();
            btnVolver = new Button();
            lblIntentos = new Label();
            timerCronometro = new System.Windows.Forms.Timer(components);
            pnlNerd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblAcertijo
            // 
            resources.ApplyResources(lblAcertijo, "lblAcertijo");
            lblAcertijo.BackColor = Color.Black;
            lblAcertijo.ForeColor = SystemColors.ButtonHighlight;
            lblAcertijo.Name = "lblAcertijo";
            // 
            // pnlNerd
            // 
            pnlNerd.Controls.Add(btnAceptarNerd);
            pnlNerd.Controls.Add(btnContinuarFailNerd);
            pnlNerd.Controls.Add(lblNerd);
            pnlNerd.Controls.Add(pictureBox1);
            resources.ApplyResources(pnlNerd, "pnlNerd");
            pnlNerd.Name = "pnlNerd";
            // 
            // btnAceptarNerd
            // 
            btnAceptarNerd.BackColor = SystemColors.ActiveCaptionText;
            btnAceptarNerd.ForeColor = SystemColors.ButtonHighlight;
            resources.ApplyResources(btnAceptarNerd, "btnAceptarNerd");
            btnAceptarNerd.Name = "btnAceptarNerd";
            btnAceptarNerd.UseVisualStyleBackColor = false;
            btnAceptarNerd.Click += btnAceptarNerd_Click;
            // 
            // btnContinuarFailNerd
            // 
            btnContinuarFailNerd.BackColor = SystemColors.ActiveCaptionText;
            btnContinuarFailNerd.ForeColor = SystemColors.ButtonHighlight;
            resources.ApplyResources(btnContinuarFailNerd, "btnContinuarFailNerd");
            btnContinuarFailNerd.Name = "btnContinuarFailNerd";
            btnContinuarFailNerd.UseVisualStyleBackColor = false;
            btnContinuarFailNerd.Click += btnContinuarFailNerd_Click;
            // 
            // lblNerd
            // 
            resources.ApplyResources(lblNerd, "lblNerd");
            lblNerd.ForeColor = SystemColors.ButtonFace;
            lblNerd.Name = "lblNerd";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = Properties.Resources.NerdImage;
            resources.ApplyResources(pictureBox1, "pictureBox1");
            pictureBox1.Name = "pictureBox1";
            pictureBox1.TabStop = false;
            // 
            // lblRespuesta
            // 
            resources.ApplyResources(lblRespuesta, "lblRespuesta");
            lblRespuesta.BackColor = SystemColors.ActiveCaptionText;
            lblRespuesta.BorderStyle = BorderStyle.FixedSingle;
            lblRespuesta.ForeColor = SystemColors.ButtonHighlight;
            lblRespuesta.Name = "lblRespuesta";
            // 
            // txtRespuesta
            // 
            txtRespuesta.BackColor = SystemColors.InactiveCaptionText;
            resources.ApplyResources(txtRespuesta, "txtRespuesta");
            txtRespuesta.ForeColor = SystemColors.MenuBar;
            txtRespuesta.Name = "txtRespuesta";
            // 
            // btnValidar
            // 
            btnValidar.BackColor = SystemColors.ActiveCaptionText;
            btnValidar.ForeColor = SystemColors.ButtonFace;
            resources.ApplyResources(btnValidar, "btnValidar");
            btnValidar.Name = "btnValidar";
            btnValidar.UseVisualStyleBackColor = false;
            btnValidar.Click += btnValidar_Click;
            // 
            // pbTiempo
            // 
            resources.ApplyResources(pbTiempo, "pbTiempo");
            pbTiempo.Maximum = 60;
            pbTiempo.Name = "pbTiempo";
            pbTiempo.Value = 60;
            // 
            // lblCronometro
            // 
            resources.ApplyResources(lblCronometro, "lblCronometro");
            lblCronometro.Name = "lblCronometro";
            // 
            // btnVolver
            // 
            btnVolver.BackColor = SystemColors.ActiveCaptionText;
            btnVolver.ForeColor = SystemColors.Control;
            resources.ApplyResources(btnVolver, "btnVolver");
            btnVolver.Name = "btnVolver";
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += btnVolver_Click;
            // 
            // lblIntentos
            // 
            resources.ApplyResources(lblIntentos, "lblIntentos");
            lblIntentos.Name = "lblIntentos";
            // 
            // timerCronometro
            // 
            timerCronometro.Interval = 1000;
            timerCronometro.Tick += timerCronometro_Tick;
            // 
            // NerdUserControl2
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = SystemColors.ActiveCaptionText;
            BackgroundImage = Properties.Resources.NerdBackground2;
            resources.ApplyResources(this, "$this");
            Controls.Add(lblIntentos);
            Controls.Add(btnVolver);
            Controls.Add(lblCronometro);
            Controls.Add(pbTiempo);
            Controls.Add(btnValidar);
            Controls.Add(txtRespuesta);
            Controls.Add(lblRespuesta);
            Controls.Add(pnlNerd);
            Controls.Add(lblAcertijo);
            DoubleBuffered = true;
            ForeColor = SystemColors.ControlText;
            Name = "NerdUserControl2";
            pnlNerd.ResumeLayout(false);
            pnlNerd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblAcertijo;
        private Panel pnlNerd;
        private Button btnContinuarFailNerd;
        private Label lblNerd;
        private PictureBox pictureBox1;
        private Label lblRespuesta;
        private TextBox txtRespuesta;
        private Button btnValidar;
        public ProgressBar pbTiempo;
        private Label lblCronometro;
        private Button btnVolver;
        private Label lblIntentos;
        private System.Windows.Forms.Timer timerCronometro;
        private Button btnAceptarNerd;
    }
}
