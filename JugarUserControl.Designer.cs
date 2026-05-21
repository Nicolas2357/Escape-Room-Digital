namespace Escape_Room_Digital.UserControls
{
    partial class JugarUserControl
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
            pbJugador = new PictureBox();
            timerMoverDerecha = new System.Windows.Forms.Timer(components);
            timerMoverAbajo = new System.Windows.Forms.Timer(components);
            timerMoverIzquierda = new System.Windows.Forms.Timer(components);
            timerMoverArriba = new System.Windows.Forms.Timer(components);
            timerAnimacion = new System.Windows.Forms.Timer(components);
            pbTenna = new PictureBox();
            pbRoulx = new PictureBox();
            pbSpamton = new PictureBox();
            pbGhost = new PictureBox();
            pbJester = new PictureBox();
            pbRoulxCloud = new PictureBox();
            pbTurtleCloud = new PictureBox();
            pbGhostCloud = new PictureBox();
            pbJesterCloud = new PictureBox();
            pbSpamtonCloud = new PictureBox();
            lblMision = new Label();
            pnlDialogoUnico = new Panel();
            lblNombreUnico = new Label();
            btnContinuar = new Button();
            pbRetratoPanel = new PictureBox();
            btnNo = new Button();
            btnSi = new Button();
            lblTextoUnico = new Label();
            timerAgrandar = new System.Windows.Forms.Timer(components);
            timerCambioFondo = new System.Windows.Forms.Timer(components);
            timerAnimacionTexto = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pbJugador).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbTenna).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbRoulx).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbSpamton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbGhost).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbJester).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbRoulxCloud).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbTurtleCloud).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbGhostCloud).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbJesterCloud).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbSpamtonCloud).BeginInit();
            pnlDialogoUnico.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbRetratoPanel).BeginInit();
            SuspendLayout();
            // 
            // btnVolver
            // 
            btnVolver.BackColor = SystemColors.ActiveCaptionText;
            btnVolver.ForeColor = SystemColors.ButtonHighlight;
            btnVolver.Location = new Point(1653, 17);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(187, 78);
            btnVolver.TabIndex = 0;
            btnVolver.TabStop = false;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += btnVolver_Click;
            // 
            // pbJugador
            // 
            pbJugador.BackColor = Color.Transparent;
            pbJugador.Image = Properties.Resources.SkeletonWalk3;
            pbJugador.Location = new Point(890, 746);
            pbJugador.Name = "pbJugador";
            pbJugador.Size = new Size(131, 156);
            pbJugador.SizeMode = PictureBoxSizeMode.Zoom;
            pbJugador.TabIndex = 1;
            pbJugador.TabStop = false;
            // 
            // timerMoverDerecha
            // 
            timerMoverDerecha.Interval = 5;
            timerMoverDerecha.Tick += timerMoverDerecha_Tick;
            // 
            // timerMoverAbajo
            // 
            timerMoverAbajo.Interval = 5;
            timerMoverAbajo.Tick += timerMoverAbajo_Tick;
            // 
            // timerMoverIzquierda
            // 
            timerMoverIzquierda.Interval = 5;
            timerMoverIzquierda.Tick += timerMoverIzquierda_Tick;
            // 
            // timerMoverArriba
            // 
            timerMoverArriba.Interval = 5;
            timerMoverArriba.Tick += timerMoverArriba_Tick;
            // 
            // timerAnimacion
            // 
            timerAnimacion.Interval = 200;
            timerAnimacion.Tick += timerAnimacion_Tick;
            // 
            // pbTenna
            // 
            pbTenna.BackColor = Color.Transparent;
            pbTenna.Image = Properties.Resources.TennaDancingGangamStyle;
            pbTenna.Location = new Point(877, 215);
            pbTenna.Name = "pbTenna";
            pbTenna.Size = new Size(176, 250);
            pbTenna.SizeMode = PictureBoxSizeMode.Zoom;
            pbTenna.TabIndex = 2;
            pbTenna.TabStop = false;
            // 
            // pbRoulx
            // 
            pbRoulx.BackColor = Color.Transparent;
            pbRoulx.Image = Properties.Resources.RoulxKaard;
            pbRoulx.Location = new Point(405, 802);
            pbRoulx.Name = "pbRoulx";
            pbRoulx.Size = new Size(131, 168);
            pbRoulx.SizeMode = PictureBoxSizeMode.Zoom;
            pbRoulx.TabIndex = 3;
            pbRoulx.TabStop = false;
            // 
            // pbSpamton
            // 
            pbSpamton.BackColor = Color.Transparent;
            pbSpamton.Image = Properties.Resources.SpamtonStill;
            pbSpamton.Location = new Point(206, 300);
            pbSpamton.Name = "pbSpamton";
            pbSpamton.Size = new Size(128, 160);
            pbSpamton.SizeMode = PictureBoxSizeMode.Zoom;
            pbSpamton.TabIndex = 4;
            pbSpamton.TabStop = false;
            // 
            // pbGhost
            // 
            pbGhost.BackColor = Color.Transparent;
            pbGhost.Image = Properties.Resources.GhostImage;
            pbGhost.Location = new Point(1393, 798);
            pbGhost.Name = "pbGhost";
            pbGhost.Size = new Size(146, 172);
            pbGhost.SizeMode = PictureBoxSizeMode.Zoom;
            pbGhost.TabIndex = 5;
            pbGhost.TabStop = false;
            // 
            // pbJester
            // 
            pbJester.BackColor = Color.Transparent;
            pbJester.Image = Properties.Resources.Jevil;
            pbJester.Location = new Point(1568, 304);
            pbJester.Name = "pbJester";
            pbJester.Size = new Size(146, 149);
            pbJester.SizeMode = PictureBoxSizeMode.Zoom;
            pbJester.TabIndex = 6;
            pbJester.TabStop = false;
            // 
            // pbRoulxCloud
            // 
            pbRoulxCloud.BackColor = Color.Transparent;
            pbRoulxCloud.Image = Properties.Resources.InteractionCloudImage;
            pbRoulxCloud.Location = new Point(435, 705);
            pbRoulxCloud.Name = "pbRoulxCloud";
            pbRoulxCloud.Size = new Size(75, 80);
            pbRoulxCloud.SizeMode = PictureBoxSizeMode.Zoom;
            pbRoulxCloud.TabIndex = 11;
            pbRoulxCloud.TabStop = false;
            pbRoulxCloud.Visible = false;
            // 
            // pbTurtleCloud
            // 
            pbTurtleCloud.BackColor = Color.Transparent;
            pbTurtleCloud.Image = Properties.Resources.InteractionCloudImage;
            pbTurtleCloud.Location = new Point(925, 140);
            pbTurtleCloud.Name = "pbTurtleCloud";
            pbTurtleCloud.Size = new Size(97, 69);
            pbTurtleCloud.SizeMode = PictureBoxSizeMode.Zoom;
            pbTurtleCloud.TabIndex = 12;
            pbTurtleCloud.TabStop = false;
            pbTurtleCloud.Visible = false;
            // 
            // pbGhostCloud
            // 
            pbGhostCloud.BackColor = Color.Transparent;
            pbGhostCloud.Image = Properties.Resources.InteractionCloudImage;
            pbGhostCloud.Location = new Point(1425, 699);
            pbGhostCloud.Name = "pbGhostCloud";
            pbGhostCloud.Size = new Size(78, 86);
            pbGhostCloud.SizeMode = PictureBoxSizeMode.Zoom;
            pbGhostCloud.TabIndex = 13;
            pbGhostCloud.TabStop = false;
            pbGhostCloud.Visible = false;
            // 
            // pbJesterCloud
            // 
            pbJesterCloud.BackColor = Color.Transparent;
            pbJesterCloud.Image = Properties.Resources.InteractionCloudImage;
            pbJesterCloud.Location = new Point(1615, 224);
            pbJesterCloud.Name = "pbJesterCloud";
            pbJesterCloud.Size = new Size(70, 70);
            pbJesterCloud.SizeMode = PictureBoxSizeMode.Zoom;
            pbJesterCloud.TabIndex = 14;
            pbJesterCloud.TabStop = false;
            pbJesterCloud.Visible = false;
            // 
            // pbSpamtonCloud
            // 
            pbSpamtonCloud.BackColor = Color.Transparent;
            pbSpamtonCloud.Image = Properties.Resources.InteractionCloudImage;
            pbSpamtonCloud.Location = new Point(236, 220);
            pbSpamtonCloud.Name = "pbSpamtonCloud";
            pbSpamtonCloud.Size = new Size(75, 74);
            pbSpamtonCloud.SizeMode = PictureBoxSizeMode.Zoom;
            pbSpamtonCloud.TabIndex = 15;
            pbSpamtonCloud.TabStop = false;
            pbSpamtonCloud.Visible = false;
            // 
            // lblMision
            // 
            lblMision.AutoSize = true;
            lblMision.Font = new Font("Determination Mono Web", 22.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMision.ForeColor = SystemColors.ButtonFace;
            lblMision.Location = new Point(32, 19);
            lblMision.Name = "lblMision";
            lblMision.Size = new Size(307, 76);
            lblMision.TabIndex = 18;
            lblMision.Text = "Objetivos:\r\n*Habla con Tenna\r\n";
            // 
            // pnlDialogoUnico
            // 
            pnlDialogoUnico.Controls.Add(lblNombreUnico);
            pnlDialogoUnico.Controls.Add(btnContinuar);
            pnlDialogoUnico.Controls.Add(pbRetratoPanel);
            pnlDialogoUnico.Controls.Add(btnNo);
            pnlDialogoUnico.Controls.Add(btnSi);
            pnlDialogoUnico.Controls.Add(lblTextoUnico);
            pnlDialogoUnico.Location = new Point(533, 502);
            pnlDialogoUnico.Margin = new Padding(3, 3, 3, 20);
            pnlDialogoUnico.Name = "pnlDialogoUnico";
            pnlDialogoUnico.Size = new Size(843, 294);
            pnlDialogoUnico.TabIndex = 20;
            pnlDialogoUnico.Visible = false;
            // 
            // lblNombreUnico
            // 
            lblNombreUnico.AutoSize = true;
            lblNombreUnico.Font = new Font("Determination Mono Web", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNombreUnico.ForeColor = SystemColors.ButtonFace;
            lblNombreUnico.Location = new Point(39, 12);
            lblNombreUnico.Name = "lblNombreUnico";
            lblNombreUnico.Size = new Size(103, 30);
            lblNombreUnico.TabIndex = 20;
            lblNombreUnico.Text = "label1";
            // 
            // btnContinuar
            // 
            btnContinuar.BackColor = SystemColors.ActiveCaptionText;
            btnContinuar.ForeColor = SystemColors.ButtonHighlight;
            btnContinuar.Location = new Point(344, 210);
            btnContinuar.Name = "btnContinuar";
            btnContinuar.Size = new Size(174, 57);
            btnContinuar.TabIndex = 2;
            btnContinuar.Text = "Continuar";
            btnContinuar.UseVisualStyleBackColor = false;
            btnContinuar.Visible = false;
            btnContinuar.Click += btnContinuar_Click;
            // 
            // pbRetratoPanel
            // 
            pbRetratoPanel.BackColor = Color.Transparent;
            pbRetratoPanel.Image = Properties.Resources.SpamtonStill;
            pbRetratoPanel.Location = new Point(39, 52);
            pbRetratoPanel.Name = "pbRetratoPanel";
            pbRetratoPanel.Size = new Size(121, 152);
            pbRetratoPanel.SizeMode = PictureBoxSizeMode.Zoom;
            pbRetratoPanel.TabIndex = 16;
            pbRetratoPanel.TabStop = false;
            // 
            // btnNo
            // 
            btnNo.BackColor = SystemColors.ActiveCaptionText;
            btnNo.ForeColor = SystemColors.ButtonHighlight;
            btnNo.Location = new Point(540, 210);
            btnNo.Name = "btnNo";
            btnNo.Size = new Size(271, 57);
            btnNo.TabIndex = 2;
            btnNo.Text = "No";
            btnNo.UseVisualStyleBackColor = false;
            // 
            // btnSi
            // 
            btnSi.BackColor = SystemColors.ActiveCaptionText;
            btnSi.ForeColor = SystemColors.ButtonHighlight;
            btnSi.Location = new Point(55, 210);
            btnSi.Name = "btnSi";
            btnSi.Size = new Size(258, 57);
            btnSi.TabIndex = 2;
            btnSi.Text = "Si";
            btnSi.UseVisualStyleBackColor = false;
            btnSi.Click += btnSi_Click;
            // 
            // lblTextoUnico
            // 
            lblTextoUnico.Font = new Font("Determination Mono Web", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTextoUnico.ForeColor = SystemColors.ButtonFace;
            lblTextoUnico.Location = new Point(182, 52);
            lblTextoUnico.Name = "lblTextoUnico";
            lblTextoUnico.Size = new Size(629, 139);
            lblTextoUnico.TabIndex = 0;
            lblTextoUnico.Text = "label1";
            // 
            // timerAgrandar
            // 
            timerAgrandar.Interval = 30;
            // 
            // timerCambioFondo
            // 
            timerCambioFondo.Interval = 500;
            // 
            // timerAnimacionTexto
            // 
            timerAnimacionTexto.Interval = 30;
            timerAnimacionTexto.Tick += timerAnimacionTexto_Tick;
            // 
            // JugarUserControl
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = SystemColors.ActiveCaptionText;
            BackgroundImage = Properties.Resources.TennaBackground;
            BackgroundImageLayout = ImageLayout.Stretch;
            Controls.Add(pnlDialogoUnico);
            Controls.Add(lblMision);
            Controls.Add(pbSpamtonCloud);
            Controls.Add(pbJesterCloud);
            Controls.Add(pbGhostCloud);
            Controls.Add(pbTenna);
            Controls.Add(pbTurtleCloud);
            Controls.Add(pbRoulxCloud);
            Controls.Add(pbJugador);
            Controls.Add(pbJester);
            Controls.Add(pbGhost);
            Controls.Add(pbSpamton);
            Controls.Add(pbRoulx);
            Controls.Add(btnVolver);
            DoubleBuffered = true;
            Font = new Font("Determination Mono Web", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 2, 3, 2);
            Name = "JugarUserControl";
            Size = new Size(1920, 1080);
            ((System.ComponentModel.ISupportInitialize)pbJugador).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbTenna).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbRoulx).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbSpamton).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbGhost).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbJester).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbRoulxCloud).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbTurtleCloud).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbGhostCloud).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbJesterCloud).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbSpamtonCloud).EndInit();
            pnlDialogoUnico.ResumeLayout(false);
            pnlDialogoUnico.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbRetratoPanel).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnVolver;
        private PictureBox pbJugador;
        private System.Windows.Forms.Timer timerMoverDerecha;
        private System.Windows.Forms.Timer timerMoverAbajo;
        private System.Windows.Forms.Timer timerMoverIzquierda;
        private System.Windows.Forms.Timer timerMoverArriba;
        private System.Windows.Forms.Timer timerAnimacion;
        private PictureBox pbTenna;
        private PictureBox pbRoulx;
        private PictureBox pbSpamton;
        private PictureBox pbGhost;
        private PictureBox pbJester;
        private PictureBox pbRoulxCloud;
        private PictureBox pbTurtleCloud;
        private PictureBox pbGhostCloud;
        private PictureBox pbJesterCloud;
        private PictureBox pbSpamtonCloud;
        private Label lblMision;
        private Panel pnlDialogoUnico;
        private Button btnContinuar;
        private PictureBox pbRetratoPanel;
        private Button btnNo;
        private Button btnSi;
        private Label lblTextoUnico;
        private Label lblNombreUnico;
        private System.Windows.Forms.Timer timerAgrandar;
        private System.Windows.Forms.Timer timerCambioFondo;
        private System.Windows.Forms.Timer timerAnimacionTexto;
    }
}
