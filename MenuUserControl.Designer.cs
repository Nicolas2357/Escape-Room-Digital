namespace Escape_Room_Digital.UserControls
{
    partial class MenuUserControl
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
            label1 = new Label();
            btnJugar = new Button();
            btnConfiguración = new Button();
            btnSalir = new Button();
            btnAdministrador = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Microsoft Sans Serif", 72F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(47, 84);
            label1.Name = "label1";
            label1.Size = new Size(1178, 135);
            label1.TabIndex = 4;
            label1.Text = "Escape Room Digital";
            label1.Click += label1_Click;
            // 
            // btnJugar
            // 
            btnJugar.BackColor = Color.Transparent;
            btnJugar.FlatAppearance.BorderSize = 0;
            btnJugar.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnJugar.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnJugar.FlatStyle = FlatStyle.Flat;
            btnJugar.Font = new Font("Microsoft Sans Serif", 48F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnJugar.ForeColor = Color.Yellow;
            btnJugar.Location = new Point(47, 348);
            btnJugar.Name = "btnJugar";
            btnJugar.Size = new Size(267, 113);
            btnJugar.TabIndex = 0;
            btnJugar.Text = "Jugar";
            btnJugar.UseVisualStyleBackColor = false;
            btnJugar.Click += btnJugar_Click;
            // 
            // btnConfiguración
            // 
            btnConfiguración.BackColor = Color.Transparent;
            btnConfiguración.FlatAppearance.BorderSize = 0;
            btnConfiguración.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnConfiguración.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnConfiguración.FlatStyle = FlatStyle.Flat;
            btnConfiguración.Font = new Font("Microsoft Sans Serif", 48F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnConfiguración.ForeColor = SystemColors.ButtonFace;
            btnConfiguración.Location = new Point(47, 483);
            btnConfiguración.Name = "btnConfiguración";
            btnConfiguración.Size = new Size(581, 131);
            btnConfiguración.TabIndex = 1;
            btnConfiguración.Text = "Configuración";
            btnConfiguración.UseVisualStyleBackColor = false;
            btnConfiguración.Click += btnConfiguración_Click;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.Transparent;
            btnSalir.FlatAppearance.BorderSize = 0;
            btnSalir.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnSalir.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.Font = new Font("Microsoft Sans Serif", 48F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSalir.ForeColor = SystemColors.ButtonFace;
            btnSalir.Location = new Point(47, 620);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(280, 118);
            btnSalir.TabIndex = 2;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnAdministrador
            // 
            btnAdministrador.BackColor = Color.Transparent;
            btnAdministrador.FlatAppearance.BorderSize = 0;
            btnAdministrador.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnAdministrador.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnAdministrador.FlatStyle = FlatStyle.Flat;
            btnAdministrador.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAdministrador.ForeColor = SystemColors.Control;
            btnAdministrador.Location = new Point(22, 1003);
            btnAdministrador.Name = "btnAdministrador";
            btnAdministrador.Size = new Size(292, 53);
            btnAdministrador.TabIndex = 3;
            btnAdministrador.Text = "Administrador";
            btnAdministrador.UseVisualStyleBackColor = false;
            btnAdministrador.Click += btnAdministrador_Click;
            // 
            // MenuUserControl
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = SystemColors.ActiveCaptionText;
            BackgroundImage = Properties.Resources.BackgroundMenuImage1;
            BackgroundImageLayout = ImageLayout.Stretch;
            Controls.Add(btnAdministrador);
            Controls.Add(btnSalir);
            Controls.Add(btnConfiguración);
            Controls.Add(btnJugar);
            Controls.Add(label1);
            DoubleBuffered = true;
            Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = SystemColors.Control;
            Margin = new Padding(3, 2, 3, 2);
            Name = "MenuUserControl";
            Size = new Size(1920, 1080);
            Load += MenuUserControl_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnJugar;
        private Button btnConfiguración;
        private Button btnSalir;
        private Button btnAdministrador;
    }
}
