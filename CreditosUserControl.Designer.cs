namespace Escape_Room_Digital.UserControls
{
    partial class CreditosUserControl
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
            btnSalir = new Button();
            lblPuntuacion = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.Transparent;
            btnSalir.FlatAppearance.BorderSize = 0;
            btnSalir.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnSalir.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.Font = new Font("Determination Mono Web", 48F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSalir.ForeColor = SystemColors.ButtonFace;
            btnSalir.Location = new Point(787, 874);
            btnSalir.Margin = new Padding(4, 3, 4, 3);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(350, 118);
            btnSalir.TabIndex = 4;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            btnSalir.MouseEnter += btnSalir_MouseEnter;
            btnSalir.MouseLeave += btnSalir_MouseLeave;
            // 
            // lblPuntuacion
            // 
            lblPuntuacion.AutoSize = true;
            lblPuntuacion.Font = new Font("Determination Mono Web", 28.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPuntuacion.Location = new Point(751, 99);
            lblPuntuacion.Margin = new Padding(4, 0, 4, 0);
            lblPuntuacion.Name = "lblPuntuacion";
            lblPuntuacion.Size = new Size(273, 48);
            lblPuntuacion.TabIndex = 5;
            lblPuntuacion.Text = "Puntuación:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Determination Mono Web", 28.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(733, 366);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(436, 48);
            label1.TabIndex = 6;
            label1.Text = "Gracias por Jugar!";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.PapyrusGif;
            pictureBox1.Location = new Point(401, 784);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(412, 267);
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // CreditosUserControl
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = SystemColors.ActiveCaptionText;
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Controls.Add(lblPuntuacion);
            Controls.Add(btnSalir);
            Font = new Font("Determination Mono Web", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = SystemColors.ControlLight;
            Margin = new Padding(4, 3, 4, 3);
            Name = "CreditosUserControl";
            Size = new Size(1920, 1080);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSalir;
        private Label lblPuntuacion;
        private Label label1;
        private PictureBox pictureBox1;
    }
}
