namespace Escape_Room_Digital.UserControls
{
    partial class InicioDelJuegoUserControl
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
            pbTenna = new PictureBox();
            t = new System.Windows.Forms.Timer(components);
            pbTennaCloud = new PictureBox();
            pnlTexto = new Panel();
            pbFlecha = new PictureBox();
            pbFaceTenna = new PictureBox();
            txtNombre = new TextBox();
            lblNombre = new Label();
            btnNoTenna = new Button();
            btnSiTenna = new Button();
            btnEmpezarTenna = new Button();
            btnContinuarTenna = new Button();
            lblTexto = new Label();
            t2 = new System.Windows.Forms.Timer(components);
            btnRegresar = new Button();
            timerAnimacion = new System.Windows.Forms.Timer(components);
            timerFlecha = new System.Windows.Forms.Timer(components);
            pnlFlash = new Panel();
            timerFlash = new System.Windows.Forms.Timer(components);
            btnSaltar = new Button();
            ((System.ComponentModel.ISupportInitialize)pbTenna).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbTennaCloud).BeginInit();
            pnlTexto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbFlecha).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbFaceTenna).BeginInit();
            SuspendLayout();
            // 
            // pbTenna
            // 
            pbTenna.BackColor = Color.Transparent;
            pbTenna.Image = Properties.Resources.TennaTalkingImage;
            pbTenna.Location = new Point(816, 230);
            pbTenna.Name = "pbTenna";
            pbTenna.Size = new Size(281, 376);
            pbTenna.SizeMode = PictureBoxSizeMode.Zoom;
            pbTenna.TabIndex = 0;
            pbTenna.TabStop = false;
            // 
            // t
            // 
            t.Interval = 20;
            // 
            // pbTennaCloud
            // 
            pbTennaCloud.BackColor = Color.Transparent;
            pbTennaCloud.Image = Properties.Resources.InteractionCloudImage;
            pbTennaCloud.Location = new Point(914, 133);
            pbTennaCloud.Name = "pbTennaCloud";
            pbTennaCloud.Size = new Size(97, 69);
            pbTennaCloud.SizeMode = PictureBoxSizeMode.Zoom;
            pbTennaCloud.TabIndex = 13;
            pbTennaCloud.TabStop = false;
            pbTennaCloud.Visible = false;
            // 
            // pnlTexto
            // 
            pnlTexto.BackColor = Color.Black;
            pnlTexto.Controls.Add(pbFlecha);
            pnlTexto.Controls.Add(pbFaceTenna);
            pnlTexto.Controls.Add(txtNombre);
            pnlTexto.Controls.Add(lblNombre);
            pnlTexto.Controls.Add(btnNoTenna);
            pnlTexto.Controls.Add(btnSiTenna);
            pnlTexto.Controls.Add(btnEmpezarTenna);
            pnlTexto.Controls.Add(btnContinuarTenna);
            pnlTexto.Controls.Add(lblTexto);
            pnlTexto.ForeColor = SystemColors.ControlText;
            pnlTexto.Location = new Point(496, 647);
            pnlTexto.Name = "pnlTexto";
            pnlTexto.Size = new Size(924, 402);
            pnlTexto.TabIndex = 14;
            pnlTexto.Paint += pnlTexto_Paint;
            // 
            // pbFlecha
            // 
            pbFlecha.Image = Properties.Resources.ArrowImage1;
            pbFlecha.Location = new Point(801, 207);
            pbFlecha.Name = "pbFlecha";
            pbFlecha.Size = new Size(68, 62);
            pbFlecha.SizeMode = PictureBoxSizeMode.Zoom;
            pbFlecha.TabIndex = 16;
            pbFlecha.TabStop = false;
            pbFlecha.Visible = false;
            // 
            // pbFaceTenna
            // 
            pbFaceTenna.Image = Properties.Resources.TennaFace;
            pbFaceTenna.Location = new Point(18, 97);
            pbFaceTenna.Name = "pbFaceTenna";
            pbFaceTenna.Size = new Size(159, 158);
            pbFaceTenna.SizeMode = PictureBoxSizeMode.Zoom;
            pbFaceTenna.TabIndex = 16;
            pbFaceTenna.TabStop = false;
            // 
            // txtNombre
            // 
            txtNombre.BackColor = SystemColors.InactiveCaptionText;
            txtNombre.Font = new Font("Determination Mono Web", 25.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNombre.ForeColor = SystemColors.Menu;
            txtNombre.Location = new Point(275, 245);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(325, 51);
            txtNombre.TabIndex = 15;
            txtNombre.Visible = false;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Determination Mono Web", 28.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNombre.ForeColor = Color.FromArgb(255, 255, 128);
            lblNombre.Location = new Point(28, 18);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(158, 48);
            lblNombre.TabIndex = 21;
            lblNombre.Text = "label1";
            // 
            // btnNoTenna
            // 
            btnNoTenna.BackColor = SystemColors.ActiveCaptionText;
            btnNoTenna.ForeColor = SystemColors.ControlLightLight;
            btnNoTenna.Location = new Point(454, 312);
            btnNoTenna.Name = "btnNoTenna";
            btnNoTenna.Size = new Size(161, 55);
            btnNoTenna.TabIndex = 18;
            btnNoTenna.Text = "No";
            btnNoTenna.UseVisualStyleBackColor = false;
            btnNoTenna.Visible = false;
            btnNoTenna.Click += btnContinuarTenna_Click;
            // 
            // btnSiTenna
            // 
            btnSiTenna.BackColor = SystemColors.ActiveCaptionText;
            btnSiTenna.ForeColor = SystemColors.ControlLightLight;
            btnSiTenna.Location = new Point(275, 312);
            btnSiTenna.Name = "btnSiTenna";
            btnSiTenna.Size = new Size(161, 55);
            btnSiTenna.TabIndex = 17;
            btnSiTenna.Text = "Si";
            btnSiTenna.UseVisualStyleBackColor = false;
            btnSiTenna.Visible = false;
            btnSiTenna.Click += btnContinuarTenna_Click;
            // 
            // btnEmpezarTenna
            // 
            btnEmpezarTenna.BackColor = SystemColors.ActiveCaptionText;
            btnEmpezarTenna.ForeColor = SystemColors.ControlLightLight;
            btnEmpezarTenna.Location = new Point(681, 312);
            btnEmpezarTenna.Name = "btnEmpezarTenna";
            btnEmpezarTenna.Size = new Size(161, 55);
            btnEmpezarTenna.TabIndex = 20;
            btnEmpezarTenna.Text = "Empezar";
            btnEmpezarTenna.UseVisualStyleBackColor = false;
            btnEmpezarTenna.Visible = false;
            btnEmpezarTenna.Click += btnEmpezarTenna_Click;
            // 
            // btnContinuarTenna
            // 
            btnContinuarTenna.BackColor = SystemColors.ActiveCaptionText;
            btnContinuarTenna.ForeColor = SystemColors.ControlLightLight;
            btnContinuarTenna.Location = new Point(60, 312);
            btnContinuarTenna.Name = "btnContinuarTenna";
            btnContinuarTenna.Size = new Size(161, 55);
            btnContinuarTenna.TabIndex = 16;
            btnContinuarTenna.Text = "Continuar";
            btnContinuarTenna.UseVisualStyleBackColor = false;
            btnContinuarTenna.Click += btnContinuarTenna_Click;
            // 
            // lblTexto
            // 
            lblTexto.BackColor = Color.Black;
            lblTexto.Font = new Font("Determination Mono Web", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTexto.ForeColor = SystemColors.ButtonFace;
            lblTexto.Location = new Point(206, 97);
            lblTexto.Name = "lblTexto";
            lblTexto.Size = new Size(691, 212);
            lblTexto.TabIndex = 19;
            lblTexto.Text = "label1";
            // 
            // t2
            // 
            t2.Interval = 50;
            // 
            // btnRegresar
            // 
            btnRegresar.BackColor = Color.Transparent;
            btnRegresar.BackgroundImage = Properties.Resources.ArrowImage;
            btnRegresar.BackgroundImageLayout = ImageLayout.Zoom;
            btnRegresar.FlatStyle = FlatStyle.Flat;
            btnRegresar.ForeColor = SystemColors.ControlText;
            btnRegresar.Location = new Point(23, 19);
            btnRegresar.Name = "btnRegresar";
            btnRegresar.Size = new Size(118, 126);
            btnRegresar.TabIndex = 15;
            btnRegresar.UseVisualStyleBackColor = false;
            btnRegresar.Click += btnRegresar_Click;
            // 
            // timerAnimacion
            // 
            timerAnimacion.Interval = 30;
            timerAnimacion.Tick += timerAnimacion_Tick;
            // 
            // pnlFlash
            // 
            pnlFlash.BackColor = SystemColors.ButtonHighlight;
            pnlFlash.Location = new Point(78, 1073);
            pnlFlash.Name = "pnlFlash";
            pnlFlash.Size = new Size(1920, 1080);
            pnlFlash.TabIndex = 16;
            pnlFlash.Visible = false;
            // 
            // btnSaltar
            // 
            btnSaltar.BackColor = SystemColors.ActiveCaptionText;
            btnSaltar.ForeColor = SystemColors.ControlLightLight;
            btnSaltar.Location = new Point(1715, 19);
            btnSaltar.Name = "btnSaltar";
            btnSaltar.Size = new Size(161, 55);
            btnSaltar.TabIndex = 22;
            btnSaltar.Text = "Saltar";
            btnSaltar.UseVisualStyleBackColor = false;
            btnSaltar.Click += btnSaltar_Click;
            // 
            // InicioDelJuegoUserControl
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = SystemColors.ActiveCaptionText;
            BackgroundImageLayout = ImageLayout.Zoom;
            Controls.Add(btnSaltar);
            Controls.Add(pnlFlash);
            Controls.Add(btnRegresar);
            Controls.Add(pnlTexto);
            Controls.Add(pbTennaCloud);
            Controls.Add(pbTenna);
            DoubleBuffered = true;
            Font = new Font("Determination Mono Web", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = SystemColors.ControlText;
            Margin = new Padding(5, 4, 5, 4);
            Name = "InicioDelJuegoUserControl";
            Size = new Size(1920, 1080);
            ((System.ComponentModel.ISupportInitialize)pbTenna).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbTennaCloud).EndInit();
            pnlTexto.ResumeLayout(false);
            pnlTexto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbFlecha).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbFaceTenna).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Timer t;
        protected PictureBox pbTenna;
        protected PictureBox pbTennaCloud;
        protected Panel pnlTexto;
        protected TextBox txtNombre;
        protected Button btnContinuarTenna;
        protected Button btnNoTenna;
        protected Button btnSiTenna;
        protected Label lblTexto;
        protected Button btnEmpezarTenna;
        private Label lblNombre;
        private System.Windows.Forms.Timer t2;
        private Button btnRegresar;
        private PictureBox pbFaceTenna;
        private System.Windows.Forms.Timer timerAnimacion;
        private PictureBox pbFlecha;
        private System.Windows.Forms.Timer timerFlecha;
        private Panel pnlFlash;
        private System.Windows.Forms.Timer timerFlash;
        protected Button btnSaltar;
    }
}
