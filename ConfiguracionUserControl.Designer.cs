namespace Escape_Room_Digital.UserControls
{
    partial class ConfiguracionUserControl
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
            trackBarVolumen = new TrackBar();
            lblVolumen = new Label();
            btnGuardar = new Button();
            btnRegresar = new Button();
            label1 = new Label();
            cmbIdioma = new ComboBox();
            lblIdioma = new Label();
            _panelTrackBar = new Panel();
            ((System.ComponentModel.ISupportInitialize)trackBarVolumen).BeginInit();
            SuspendLayout();
            // 
            // trackBarVolumen
            // 
            trackBarVolumen.BackColor = SystemColors.ActiveCaptionText;
            trackBarVolumen.Location = new Point(23, 397);
            trackBarVolumen.Margin = new Padding(7, 6, 7, 6);
            trackBarVolumen.Name = "trackBarVolumen";
            trackBarVolumen.Size = new Size(1039, 56);
            trackBarVolumen.TabIndex = 1;
            trackBarVolumen.TickStyle = TickStyle.None;
            trackBarVolumen.Scroll += trackBarVolumen_Scroll;
            // 
            // lblVolumen
            // 
            lblVolumen.AutoSize = true;
            lblVolumen.BackColor = SystemColors.ActiveCaptionText;
            lblVolumen.Font = new Font("Microsoft Sans Serif", 28.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblVolumen.ForeColor = SystemColors.ButtonFace;
            lblVolumen.Location = new Point(520, 304);
            lblVolumen.Margin = new Padding(7, 0, 7, 0);
            lblVolumen.Name = "lblVolumen";
            lblVolumen.Size = new Size(75, 54);
            lblVolumen.TabIndex = 2;
            lblVolumen.Text = "00";
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = SystemColors.ActiveCaptionText;
            btnGuardar.Font = new Font("Microsoft Sans Serif", 22.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnGuardar.ForeColor = SystemColors.ButtonHighlight;
            btnGuardar.Location = new Point(686, 634);
            btnGuardar.Margin = new Padding(7, 6, 7, 6);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(190, 80);
            btnGuardar.TabIndex = 3;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            btnGuardar.MouseEnter += btnGuardar_MouseEnter;
            btnGuardar.MouseLeave += btnGuardar_MouseLeave;
            // 
            // btnRegresar
            // 
            btnRegresar.BackColor = SystemColors.ActiveCaptionText;
            btnRegresar.Location = new Point(1103, 634);
            btnRegresar.Margin = new Padding(7, 6, 7, 6);
            btnRegresar.Name = "btnRegresar";
            btnRegresar.Size = new Size(182, 80);
            btnRegresar.TabIndex = 4;
            btnRegresar.Text = "Regresar";
            btnRegresar.UseVisualStyleBackColor = false;
            btnRegresar.Click += btnRegresar_Click;
            btnRegresar.MouseEnter += btnRegresar_MouseEnter;
            btnRegresar.MouseLeave += btnRegresar_MouseLeave;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 48F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(350, 162);
            label1.Name = "label1";
            label1.Size = new Size(434, 91);
            label1.TabIndex = 5;
            label1.Text = "VOLUMEN";
            // 
            // cmbIdioma
            // 
            cmbIdioma.FormattingEnabled = true;
            cmbIdioma.Location = new Point(1383, 272);
            cmbIdioma.Name = "cmbIdioma";
            cmbIdioma.Size = new Size(217, 50);
            cmbIdioma.TabIndex = 6;
            cmbIdioma.SelectedIndexChanged += cmbIdioma_SelectedIndexChanged;
            // 
            // lblIdioma
            // 
            lblIdioma.AutoSize = true;
            lblIdioma.Font = new Font("Microsoft Sans Serif", 48F);
            lblIdioma.Location = new Point(1328, 162);
            lblIdioma.Name = "lblIdioma";
            lblIdioma.Size = new Size(323, 91);
            lblIdioma.TabIndex = 5;
            lblIdioma.Text = "IDIOMA";
            // 
            // _panelTrackBar
            // 
            _panelTrackBar.Location = new Point(23, 361);
            _panelTrackBar.Name = "_panelTrackBar";
            _panelTrackBar.Size = new Size(1039, 109);
            _panelTrackBar.TabIndex = 7;
            // 
            // ConfiguracionUserControl
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = SystemColors.ActiveCaptionText;
            Controls.Add(_panelTrackBar);
            Controls.Add(lblIdioma);
            Controls.Add(cmbIdioma);
            Controls.Add(label1);
            Controls.Add(btnRegresar);
            Controls.Add(btnGuardar);
            Controls.Add(lblVolumen);
            Controls.Add(trackBarVolumen);
            Font = new Font("Microsoft Sans Serif", 22.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = SystemColors.ButtonHighlight;
            Margin = new Padding(7, 6, 7, 6);
            Name = "ConfiguracionUserControl";
            Size = new Size(1920, 1080);
            Load += ConfiguracionUserControl_Load;
            ((System.ComponentModel.ISupportInitialize)trackBarVolumen).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TrackBar trackBarVolumen;
        private Label lblVolumen;
        private Button btnGuardar;
        private Button btnRegresar;
        private Label label1;
        private ComboBox cmbIdioma;
        private Label lblIdioma;
    }
}
