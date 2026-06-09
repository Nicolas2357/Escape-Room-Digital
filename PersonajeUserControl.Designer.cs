namespace Escape_Room_Digital.UserControls
{
    partial class PersonajeUserControl
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
            pbJugador = new PictureBox();
            timerAnimacion = new System.Windows.Forms.Timer(components);
            timerMoverAbajo = new System.Windows.Forms.Timer(components);
            timerMoverIzquierda = new System.Windows.Forms.Timer(components);
            timerMoverArriba = new System.Windows.Forms.Timer(components);
            timerMoverDerecha = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pbJugador).BeginInit();
            SuspendLayout();
            // 
            // pbJugador
            // 
            pbJugador.Image = Properties.Resources.SkeletonWalk3;
            pbJugador.Location = new Point(860, 837);
            pbJugador.Name = "pbJugador";
            pbJugador.Size = new Size(74, 97);
            pbJugador.SizeMode = PictureBoxSizeMode.Zoom;
            pbJugador.TabIndex = 3;
            pbJugador.TabStop = false;
            // 
            // timerAnimacion
            // 
            timerAnimacion.Interval = 200;
            // 
            // timerMoverAbajo
            // 
            timerMoverAbajo.Interval = 5;
            // 
            // timerMoverIzquierda
            // 
            timerMoverIzquierda.Interval = 5;
            // 
            // timerMoverArriba
            // 
            timerMoverArriba.Interval = 5;
            // 
            // timerMoverDerecha
            // 
            timerMoverDerecha.Interval = 5;
            // 
            // PersonajeUserControl
            // 
            AutoScaleDimensions = new SizeF(10F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            Controls.Add(pbJugador);
            Font = new Font("Determination Mono Web", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = SystemColors.ButtonFace;
            Margin = new Padding(4, 3, 4, 3);
            Name = "PersonajeUserControl";
            Size = new Size(2400, 1080);
            ((System.ComponentModel.ISupportInitialize)pbJugador).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pbJugador;
        private System.Windows.Forms.Timer timerAnimacion;
        private System.Windows.Forms.Timer timerMoverAbajo;
        private System.Windows.Forms.Timer timerMoverIzquierda;
        private System.Windows.Forms.Timer timerMoverArriba;
        private System.Windows.Forms.Timer timerMoverDerecha;
    }
}
