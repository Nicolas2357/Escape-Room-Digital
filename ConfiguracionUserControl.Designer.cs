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
            btnVolver = new Button();
            trackBarVolumen = new TrackBar();
            lblVolumen = new Label();
            btnGuardar = new Button();
            btnRegresar = new Button();
            label1 = new Label();
            comboBox1 = new ComboBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)trackBarVolumen).BeginInit();
            SuspendLayout();
            // 
            // btnVolver
            // 
            btnVolver.BackColor = SystemColors.ActiveCaptionText;
            btnVolver.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnVolver.ForeColor = SystemColors.ButtonFace;
            btnVolver.Location = new Point(154, 919);
            btnVolver.Margin = new Padding(7, 6, 7, 6);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(179, 69);
            btnVolver.TabIndex = 0;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += btnVolver_Click;
            btnVolver.MouseEnter += btnVolver_MouseEnter;
            btnVolver.MouseLeave += btnVolver_MouseLeave;
            // 
            // trackBarVolumen
            // 
            trackBarVolumen.BackColor = SystemColors.ActiveCaptionText;
            trackBarVolumen.Location = new Point(27, 477);
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
            lblVolumen.Location = new Point(491, 343);
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
            btnGuardar.Location = new Point(213, 605);
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
            btnRegresar.Location = new Point(653, 595);
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
            label1.Location = new Point(311, 173);
            label1.Name = "label1";
            label1.Size = new Size(434, 91);
            label1.TabIndex = 5;
            label1.Text = "VOLUMEN";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Español", "Ingles" });
            comboBox1.Location = new Point(1368, 343);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(354, 50);
            comboBox1.TabIndex = 6;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 48F);
            label2.Location = new Point(1358, 173);
            label2.Name = "label2";
            label2.Size = new Size(376, 91);
            label2.TabIndex = 7;
            label2.Text = "IDIOMAS";
            label2.Click += label2_Click;
            // 
            // ConfiguracionUserControl
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = SystemColors.ActiveCaptionText;
            Controls.Add(label2);
            Controls.Add(comboBox1);
            Controls.Add(label1);
            Controls.Add(btnRegresar);
            Controls.Add(btnGuardar);
            Controls.Add(lblVolumen);
            Controls.Add(trackBarVolumen);
            Controls.Add(btnVolver);
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

        private Button btnVolver;
        private TrackBar trackBarVolumen;
        private Label lblVolumen;
        private Button btnGuardar;
        private Button btnRegresar;
        private Label label1;
        private ComboBox comboBox1;
        private Label label2;
    }
}
