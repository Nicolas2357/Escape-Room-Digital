namespace Escape_Room_Digital.UserControls
{
    partial class GhostUserControl
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
            timerMoverDerecha = new System.Windows.Forms.Timer(components);
            timerMoverArriba = new System.Windows.Forms.Timer(components);
            timerMoverIzquierda = new System.Windows.Forms.Timer(components);
            timerMoverAbajo = new System.Windows.Forms.Timer(components);
            timerAnimacion = new System.Windows.Forms.Timer(components);
            pbJugador = new PictureBox();
            pbPiano = new PictureBox();
            pbPianoCloud = new PictureBox();
            pbClock = new PictureBox();
            pbClockCloud = new PictureBox();
            pbMap = new PictureBox();
            pbMapCloud = new PictureBox();
            pbNeedle = new PictureBox();
            pbNeedleCloud = new PictureBox();
            pbBook = new PictureBox();
            pbBookCloud = new PictureBox();
            label1 = new Label();
            pnlMap = new Panel();
            btnNoMap = new Button();
            btnSiMap = new Button();
            lblDialogoMap = new Label();
            pnlNeedle = new Panel();
            btnNoNeedle = new Button();
            btnSiNeedle = new Button();
            lblNeedle = new Label();
            pnlPiano = new Panel();
            btnNoPiano = new Button();
            btnSiPiano = new Button();
            lblPiano = new Label();
            pnlBook = new Panel();
            btnNoBook = new Button();
            btnSiBook = new Button();
            lblBook = new Label();
            pnlClock = new Panel();
            btnNoClock = new Button();
            btnSiClock = new Button();
            lblClock = new Label();
            lblCronometro = new Label();
            pbTiempo = new ProgressBar();
            lblIntentos = new Label();
            timerCronometro = new System.Windows.Forms.Timer(components);
            timerEnter = new System.Windows.Forms.Timer(components);
            pnlFail = new Panel();
            btnSeguir = new Button();
            btnIntentar = new Button();
            pictureBox3 = new PictureBox();
            btnFailContinuar = new Button();
            lblFail = new Label();
            ((System.ComponentModel.ISupportInitialize)pbJugador).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbPiano).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbPianoCloud).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbClock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbClockCloud).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbMap).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbMapCloud).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbNeedle).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbNeedleCloud).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbBook).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbBookCloud).BeginInit();
            pnlMap.SuspendLayout();
            pnlNeedle.SuspendLayout();
            pnlPiano.SuspendLayout();
            pnlBook.SuspendLayout();
            pnlClock.SuspendLayout();
            pnlFail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // btnVolver
            // 
            btnVolver.BackColor = SystemColors.ActiveCaptionText;
            btnVolver.ForeColor = SystemColors.ButtonHighlight;
            btnVolver.Location = new Point(51, 32);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(137, 56);
            btnVolver.TabIndex = 0;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += btnVolver_Click;
            // 
            // timerMoverDerecha
            // 
            timerMoverDerecha.Interval = 5;
            timerMoverDerecha.Tick += timerMoverDerecha_Tick;
            // 
            // timerMoverArriba
            // 
            timerMoverArriba.Interval = 5;
            timerMoverArriba.Tick += timerMoverArriba_Tick;
            // 
            // timerMoverIzquierda
            // 
            timerMoverIzquierda.Interval = 5;
            timerMoverIzquierda.Tick += timerMoverIzquierda_Tick;
            // 
            // timerMoverAbajo
            // 
            timerMoverAbajo.Interval = 5;
            timerMoverAbajo.Tick += timerMoverAbajo_Tick;
            // 
            // timerAnimacion
            // 
            timerAnimacion.Interval = 200;
            timerAnimacion.Tick += timerAnimacion_Tick;
            // 
            // pbJugador
            // 
            pbJugador.BackColor = Color.Transparent;
            pbJugador.Image = Properties.Resources.SkeletonWalk3;
            pbJugador.Location = new Point(1251, 897);
            pbJugador.Name = "pbJugador";
            pbJugador.Size = new Size(102, 167);
            pbJugador.SizeMode = PictureBoxSizeMode.Zoom;
            pbJugador.TabIndex = 2;
            pbJugador.TabStop = false;
            // 
            // pbPiano
            // 
            pbPiano.BackColor = Color.Transparent;
            pbPiano.Image = Properties.Resources.PianoImage;
            pbPiano.Location = new Point(1278, 448);
            pbPiano.Name = "pbPiano";
            pbPiano.Size = new Size(258, 168);
            pbPiano.SizeMode = PictureBoxSizeMode.Zoom;
            pbPiano.TabIndex = 3;
            pbPiano.TabStop = false;
            // 
            // pbPianoCloud
            // 
            pbPianoCloud.BackColor = Color.Transparent;
            pbPianoCloud.Image = Properties.Resources.InteractionCloudImage;
            pbPianoCloud.Location = new Point(1389, 402);
            pbPianoCloud.Name = "pbPianoCloud";
            pbPianoCloud.Size = new Size(46, 40);
            pbPianoCloud.SizeMode = PictureBoxSizeMode.Zoom;
            pbPianoCloud.TabIndex = 13;
            pbPianoCloud.TabStop = false;
            pbPianoCloud.Visible = false;
            // 
            // pbClock
            // 
            pbClock.BackColor = Color.Transparent;
            pbClock.Image = Properties.Resources.ClockImage;
            pbClock.Location = new Point(406, 143);
            pbClock.Name = "pbClock";
            pbClock.Size = new Size(99, 105);
            pbClock.SizeMode = PictureBoxSizeMode.Zoom;
            pbClock.TabIndex = 14;
            pbClock.TabStop = false;
            // 
            // pbClockCloud
            // 
            pbClockCloud.BackColor = Color.Transparent;
            pbClockCloud.Image = Properties.Resources.InteractionCloudImage;
            pbClockCloud.Location = new Point(430, 97);
            pbClockCloud.Name = "pbClockCloud";
            pbClockCloud.Size = new Size(46, 40);
            pbClockCloud.SizeMode = PictureBoxSizeMode.Zoom;
            pbClockCloud.TabIndex = 15;
            pbClockCloud.TabStop = false;
            pbClockCloud.Visible = false;
            // 
            // pbMap
            // 
            pbMap.BackColor = Color.Transparent;
            pbMap.Image = Properties.Resources.MapImage;
            pbMap.Location = new Point(793, 705);
            pbMap.Name = "pbMap";
            pbMap.Size = new Size(99, 105);
            pbMap.SizeMode = PictureBoxSizeMode.Zoom;
            pbMap.TabIndex = 16;
            pbMap.TabStop = false;
            // 
            // pbMapCloud
            // 
            pbMapCloud.BackColor = Color.Transparent;
            pbMapCloud.Image = Properties.Resources.InteractionCloudImage;
            pbMapCloud.Location = new Point(829, 659);
            pbMapCloud.Name = "pbMapCloud";
            pbMapCloud.Size = new Size(46, 40);
            pbMapCloud.SizeMode = PictureBoxSizeMode.Zoom;
            pbMapCloud.TabIndex = 17;
            pbMapCloud.TabStop = false;
            pbMapCloud.Visible = false;
            // 
            // pbNeedle
            // 
            pbNeedle.BackColor = Color.Transparent;
            pbNeedle.Image = Properties.Resources.NeedleImage;
            pbNeedle.Location = new Point(1389, 755);
            pbNeedle.Name = "pbNeedle";
            pbNeedle.Size = new Size(99, 105);
            pbNeedle.SizeMode = PictureBoxSizeMode.Zoom;
            pbNeedle.TabIndex = 18;
            pbNeedle.TabStop = false;
            // 
            // pbNeedleCloud
            // 
            pbNeedleCloud.BackColor = Color.Transparent;
            pbNeedleCloud.Image = Properties.Resources.InteractionCloudImage;
            pbNeedleCloud.Location = new Point(1418, 691);
            pbNeedleCloud.Name = "pbNeedleCloud";
            pbNeedleCloud.Size = new Size(46, 40);
            pbNeedleCloud.SizeMode = PictureBoxSizeMode.Zoom;
            pbNeedleCloud.TabIndex = 19;
            pbNeedleCloud.TabStop = false;
            pbNeedleCloud.Visible = false;
            // 
            // pbBook
            // 
            pbBook.BackColor = Color.Transparent;
            pbBook.Image = Properties.Resources.BookImage;
            pbBook.Location = new Point(793, 225);
            pbBook.Name = "pbBook";
            pbBook.Size = new Size(99, 105);
            pbBook.SizeMode = PictureBoxSizeMode.Zoom;
            pbBook.TabIndex = 20;
            pbBook.TabStop = false;
            // 
            // pbBookCloud
            // 
            pbBookCloud.BackColor = Color.Transparent;
            pbBookCloud.Image = Properties.Resources.InteractionCloudImage;
            pbBookCloud.Location = new Point(822, 179);
            pbBookCloud.Name = "pbBookCloud";
            pbBookCloud.Size = new Size(46, 40);
            pbBookCloud.SizeMode = PictureBoxSizeMode.Zoom;
            pbBookCloud.TabIndex = 21;
            pbBookCloud.TabStop = false;
            pbBookCloud.Visible = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Determination Mono Web", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(313, 10);
            label1.Name = "label1";
            label1.Size = new Size(1303, 30);
            label1.TabIndex = 22;
            label1.Text = "Tiene ciudades pero no casas; tiene bosques pero no árboles; tiene agua pero no peces.\r\n";
            // 
            // pnlMap
            // 
            pnlMap.Controls.Add(btnNoMap);
            pnlMap.Controls.Add(btnSiMap);
            pnlMap.Controls.Add(lblDialogoMap);
            pnlMap.Location = new Point(615, 816);
            pnlMap.Name = "pnlMap";
            pnlMap.Size = new Size(630, 261);
            pnlMap.TabIndex = 23;
            pnlMap.Visible = false;
            pnlMap.Paint += pnlMap_Paint;
            // 
            // btnNoMap
            // 
            btnNoMap.BackColor = SystemColors.ActiveCaptionText;
            btnNoMap.Font = new Font("Determination Mono Web", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnNoMap.ForeColor = SystemColors.ButtonFace;
            btnNoMap.Location = new Point(428, 164);
            btnNoMap.Name = "btnNoMap";
            btnNoMap.Size = new Size(142, 53);
            btnNoMap.TabIndex = 2;
            btnNoMap.Text = "No";
            btnNoMap.UseVisualStyleBackColor = false;
            btnNoMap.Click += btnNoMap_Click;
            // 
            // btnSiMap
            // 
            btnSiMap.BackColor = SystemColors.ActiveCaptionText;
            btnSiMap.Font = new Font("Determination Mono Web", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSiMap.ForeColor = SystemColors.ButtonFace;
            btnSiMap.Location = new Point(64, 164);
            btnSiMap.Name = "btnSiMap";
            btnSiMap.Size = new Size(157, 53);
            btnSiMap.TabIndex = 1;
            btnSiMap.Text = "Si";
            btnSiMap.UseVisualStyleBackColor = false;
            btnSiMap.Click += btnSiMap_Click;
            // 
            // lblDialogoMap
            // 
            lblDialogoMap.AutoSize = true;
            lblDialogoMap.Font = new Font("Determination Mono Web", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDialogoMap.Location = new Point(64, 50);
            lblDialogoMap.Name = "lblDialogoMap";
            lblDialogoMap.Size = new Size(103, 30);
            lblDialogoMap.TabIndex = 0;
            lblDialogoMap.Text = "label2";
            // 
            // pnlNeedle
            // 
            pnlNeedle.Controls.Add(btnNoNeedle);
            pnlNeedle.Controls.Add(btnSiNeedle);
            pnlNeedle.Controls.Add(lblNeedle);
            pnlNeedle.Location = new Point(615, 816);
            pnlNeedle.Name = "pnlNeedle";
            pnlNeedle.Size = new Size(630, 261);
            pnlNeedle.TabIndex = 24;
            pnlNeedle.Visible = false;
            pnlNeedle.Paint += pnlNeedle_Paint;
            // 
            // btnNoNeedle
            // 
            btnNoNeedle.BackColor = SystemColors.ActiveCaptionText;
            btnNoNeedle.Font = new Font("Determination Mono Web", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnNoNeedle.ForeColor = SystemColors.ButtonFace;
            btnNoNeedle.Location = new Point(434, 162);
            btnNoNeedle.Name = "btnNoNeedle";
            btnNoNeedle.Size = new Size(142, 53);
            btnNoNeedle.TabIndex = 2;
            btnNoNeedle.Text = "No";
            btnNoNeedle.UseVisualStyleBackColor = false;
            btnNoNeedle.Click += btnNoNeedle_Click;
            // 
            // btnSiNeedle
            // 
            btnSiNeedle.BackColor = SystemColors.ActiveCaptionText;
            btnSiNeedle.Font = new Font("Determination Mono Web", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSiNeedle.ForeColor = SystemColors.ButtonFace;
            btnSiNeedle.Location = new Point(104, 165);
            btnSiNeedle.Name = "btnSiNeedle";
            btnSiNeedle.Size = new Size(142, 50);
            btnSiNeedle.TabIndex = 1;
            btnSiNeedle.Text = "Si";
            btnSiNeedle.UseVisualStyleBackColor = false;
            btnSiNeedle.Click += btnSiNeedle_Click;
            // 
            // lblNeedle
            // 
            lblNeedle.AutoSize = true;
            lblNeedle.Font = new Font("Determination Mono Web", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNeedle.Location = new Point(71, 43);
            lblNeedle.Name = "lblNeedle";
            lblNeedle.Size = new Size(103, 30);
            lblNeedle.TabIndex = 0;
            lblNeedle.Text = "label2";
            // 
            // pnlPiano
            // 
            pnlPiano.Controls.Add(btnNoPiano);
            pnlPiano.Controls.Add(btnSiPiano);
            pnlPiano.Controls.Add(lblPiano);
            pnlPiano.Location = new Point(615, 816);
            pnlPiano.Name = "pnlPiano";
            pnlPiano.Size = new Size(630, 261);
            pnlPiano.TabIndex = 24;
            pnlPiano.Visible = false;
            pnlPiano.Paint += pnlPiano_Paint;
            // 
            // btnNoPiano
            // 
            btnNoPiano.BackColor = SystemColors.ActiveCaptionText;
            btnNoPiano.Font = new Font("Determination Mono Web", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnNoPiano.ForeColor = SystemColors.ButtonFace;
            btnNoPiano.Location = new Point(412, 159);
            btnNoPiano.Name = "btnNoPiano";
            btnNoPiano.Size = new Size(142, 50);
            btnNoPiano.TabIndex = 2;
            btnNoPiano.Text = "No";
            btnNoPiano.UseVisualStyleBackColor = false;
            btnNoPiano.Click += btnNoPiano_Click;
            // 
            // btnSiPiano
            // 
            btnSiPiano.BackColor = SystemColors.ActiveCaptionText;
            btnSiPiano.Font = new Font("Determination Mono Web", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSiPiano.ForeColor = SystemColors.ButtonFace;
            btnSiPiano.Location = new Point(63, 159);
            btnSiPiano.Name = "btnSiPiano";
            btnSiPiano.Size = new Size(142, 50);
            btnSiPiano.TabIndex = 1;
            btnSiPiano.Text = "Si";
            btnSiPiano.UseVisualStyleBackColor = false;
            btnSiPiano.Click += btnSiPiano_Click;
            // 
            // lblPiano
            // 
            lblPiano.AutoSize = true;
            lblPiano.Font = new Font("Determination Mono Web", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPiano.Location = new Point(56, 46);
            lblPiano.Name = "lblPiano";
            lblPiano.Size = new Size(103, 30);
            lblPiano.TabIndex = 0;
            lblPiano.Text = "label2";
            // 
            // pnlBook
            // 
            pnlBook.Controls.Add(btnNoBook);
            pnlBook.Controls.Add(btnSiBook);
            pnlBook.Controls.Add(lblBook);
            pnlBook.Location = new Point(615, 816);
            pnlBook.Name = "pnlBook";
            pnlBook.Size = new Size(630, 261);
            pnlBook.TabIndex = 24;
            pnlBook.Visible = false;
            pnlBook.Paint += pnlBook_Paint;
            // 
            // btnNoBook
            // 
            btnNoBook.BackColor = SystemColors.ActiveCaptionText;
            btnNoBook.Font = new Font("Determination Mono Web", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnNoBook.ForeColor = SystemColors.ButtonFace;
            btnNoBook.Location = new Point(420, 161);
            btnNoBook.Name = "btnNoBook";
            btnNoBook.Size = new Size(142, 50);
            btnNoBook.TabIndex = 2;
            btnNoBook.Text = "No";
            btnNoBook.UseVisualStyleBackColor = false;
            btnNoBook.Click += btnNoBook_Click;
            // 
            // btnSiBook
            // 
            btnSiBook.BackColor = SystemColors.ActiveCaptionText;
            btnSiBook.Font = new Font("Determination Mono Web", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSiBook.ForeColor = SystemColors.ButtonFace;
            btnSiBook.Location = new Point(87, 161);
            btnSiBook.Name = "btnSiBook";
            btnSiBook.Size = new Size(142, 50);
            btnSiBook.TabIndex = 1;
            btnSiBook.Text = "Si";
            btnSiBook.UseVisualStyleBackColor = false;
            btnSiBook.Click += btnSiBook_Click;
            // 
            // lblBook
            // 
            lblBook.AutoSize = true;
            lblBook.Font = new Font("Determination Mono Web", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBook.Location = new Point(63, 42);
            lblBook.Name = "lblBook";
            lblBook.Size = new Size(103, 30);
            lblBook.TabIndex = 0;
            lblBook.Text = "label2";
            // 
            // pnlClock
            // 
            pnlClock.Controls.Add(btnNoClock);
            pnlClock.Controls.Add(btnSiClock);
            pnlClock.Controls.Add(lblClock);
            pnlClock.Location = new Point(615, 816);
            pnlClock.Name = "pnlClock";
            pnlClock.Size = new Size(630, 261);
            pnlClock.TabIndex = 24;
            pnlClock.Visible = false;
            pnlClock.Paint += pnlClock_Paint;
            // 
            // btnNoClock
            // 
            btnNoClock.BackColor = SystemColors.ActiveCaptionText;
            btnNoClock.Font = new Font("Determination Mono Web", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnNoClock.ForeColor = SystemColors.ButtonFace;
            btnNoClock.Location = new Point(392, 167);
            btnNoClock.Name = "btnNoClock";
            btnNoClock.Size = new Size(142, 50);
            btnNoClock.TabIndex = 2;
            btnNoClock.Text = "No";
            btnNoClock.UseVisualStyleBackColor = false;
            btnNoClock.Click += btnNoClock_Click;
            // 
            // btnSiClock
            // 
            btnSiClock.BackColor = SystemColors.ActiveCaptionText;
            btnSiClock.Font = new Font("Determination Mono Web", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSiClock.ForeColor = SystemColors.ButtonFace;
            btnSiClock.Location = new Point(89, 167);
            btnSiClock.Name = "btnSiClock";
            btnSiClock.Size = new Size(142, 50);
            btnSiClock.TabIndex = 1;
            btnSiClock.Text = "Si";
            btnSiClock.UseVisualStyleBackColor = false;
            btnSiClock.Click += btnSiClock_Click;
            // 
            // lblClock
            // 
            lblClock.AutoSize = true;
            lblClock.Font = new Font("Determination Mono Web", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblClock.Location = new Point(65, 48);
            lblClock.Name = "lblClock";
            lblClock.Size = new Size(103, 30);
            lblClock.TabIndex = 0;
            lblClock.Text = "label2";
            // 
            // lblCronometro
            // 
            lblCronometro.AutoSize = true;
            lblCronometro.Location = new Point(38, 969);
            lblCronometro.Name = "lblCronometro";
            lblCronometro.Size = new Size(81, 24);
            lblCronometro.TabIndex = 3;
            lblCronometro.Text = "Tiempo";
            // 
            // pbTiempo
            // 
            pbTiempo.Location = new Point(38, 1013);
            pbTiempo.Maximum = 60;
            pbTiempo.Name = "pbTiempo";
            pbTiempo.Size = new Size(456, 32);
            pbTiempo.TabIndex = 25;
            pbTiempo.Value = 60;
            // 
            // lblIntentos
            // 
            lblIntentos.AutoSize = true;
            lblIntentos.Location = new Point(1581, 64);
            lblIntentos.Name = "lblIntentos";
            lblIntentos.Size = new Size(82, 24);
            lblIntentos.TabIndex = 26;
            lblIntentos.Text = "label3";
            // 
            // timerCronometro
            // 
            timerCronometro.Interval = 1000;
            timerCronometro.Tick += timerCronometro_Tick;
            // 
            // pnlFail
            // 
            pnlFail.Controls.Add(btnSeguir);
            pnlFail.Controls.Add(btnIntentar);
            pnlFail.Controls.Add(pictureBox3);
            pnlFail.Controls.Add(btnFailContinuar);
            pnlFail.Controls.Add(lblFail);
            pnlFail.Location = new Point(632, 402);
            pnlFail.Name = "pnlFail";
            pnlFail.Size = new Size(630, 261);
            pnlFail.TabIndex = 25;
            pnlFail.Visible = false;
            pnlFail.Paint += pnlFail_Paint;
            // 
            // btnSeguir
            // 
            btnSeguir.BackColor = SystemColors.ActiveCaptionText;
            btnSeguir.Font = new Font("Determination Mono Web", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSeguir.ForeColor = SystemColors.ButtonFace;
            btnSeguir.Location = new Point(251, 190);
            btnSeguir.Name = "btnSeguir";
            btnSeguir.Size = new Size(142, 50);
            btnSeguir.TabIndex = 19;
            btnSeguir.Text = "Seguir";
            btnSeguir.UseVisualStyleBackColor = false;
            btnSeguir.Visible = false;
            btnSeguir.Click += btnSeguir_Click;
            // 
            // btnIntentar
            // 
            btnIntentar.BackColor = SystemColors.ActiveCaptionText;
            btnIntentar.Font = new Font("Determination Mono Web", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnIntentar.ForeColor = SystemColors.ButtonFace;
            btnIntentar.Location = new Point(251, 190);
            btnIntentar.Name = "btnIntentar";
            btnIntentar.Size = new Size(142, 50);
            btnIntentar.TabIndex = 18;
            btnIntentar.Text = "Intentar";
            btnIntentar.UseVisualStyleBackColor = false;
            btnIntentar.Click += btnIntentar_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.Transparent;
            pictureBox3.Image = Properties.Resources.GhostImage;
            pictureBox3.Location = new Point(27, 3);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(157, 163);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 17;
            pictureBox3.TabStop = false;
            // 
            // btnFailContinuar
            // 
            btnFailContinuar.BackColor = SystemColors.ActiveCaptionText;
            btnFailContinuar.Font = new Font("Determination Mono Web", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnFailContinuar.ForeColor = SystemColors.ButtonFace;
            btnFailContinuar.Location = new Point(251, 190);
            btnFailContinuar.Name = "btnFailContinuar";
            btnFailContinuar.Size = new Size(142, 50);
            btnFailContinuar.TabIndex = 2;
            btnFailContinuar.Text = "Continuar";
            btnFailContinuar.UseVisualStyleBackColor = false;
            btnFailContinuar.Click += btnFailContinuar_Click;
            // 
            // lblFail
            // 
            lblFail.AutoSize = true;
            lblFail.Font = new Font("Determination Mono Web", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFail.Location = new Point(197, 28);
            lblFail.Name = "lblFail";
            lblFail.Size = new Size(328, 150);
            lblFail.TabIndex = 0;
            lblFail.Text = "Oh no.. Creo que esa \r\nrespuesta no era la \r\ncorrecta, oh no...\r\nIntenta otra vez \r\nsi quieres...";
            // 
            // GhostUserControl
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = SystemColors.ActiveCaptionText;
            BackgroundImage = Properties.Resources.HouseImage3;
            BackgroundImageLayout = ImageLayout.Zoom;
            Controls.Add(pnlFail);
            Controls.Add(lblIntentos);
            Controls.Add(pbTiempo);
            Controls.Add(lblCronometro);
            Controls.Add(pbJugador);
            Controls.Add(pnlClock);
            Controls.Add(pnlBook);
            Controls.Add(pnlPiano);
            Controls.Add(pnlNeedle);
            Controls.Add(pnlMap);
            Controls.Add(label1);
            Controls.Add(pbBookCloud);
            Controls.Add(pbBook);
            Controls.Add(pbNeedleCloud);
            Controls.Add(pbNeedle);
            Controls.Add(pbMapCloud);
            Controls.Add(pbMap);
            Controls.Add(pbClockCloud);
            Controls.Add(pbClock);
            Controls.Add(pbPianoCloud);
            Controls.Add(pbPiano);
            Controls.Add(btnVolver);
            DoubleBuffered = true;
            Font = new Font("Determination Mono Web", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "GhostUserControl";
            Size = new Size(1920, 1080);
            ((System.ComponentModel.ISupportInitialize)pbJugador).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbPiano).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbPianoCloud).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbClock).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbClockCloud).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbMap).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbMapCloud).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbNeedle).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbNeedleCloud).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbBook).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbBookCloud).EndInit();
            pnlMap.ResumeLayout(false);
            pnlMap.PerformLayout();
            pnlNeedle.ResumeLayout(false);
            pnlNeedle.PerformLayout();
            pnlPiano.ResumeLayout(false);
            pnlPiano.PerformLayout();
            pnlBook.ResumeLayout(false);
            pnlBook.PerformLayout();
            pnlClock.ResumeLayout(false);
            pnlClock.PerformLayout();
            pnlFail.ResumeLayout(false);
            pnlFail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnVolver;
        private System.Windows.Forms.Timer timerMoverDerecha;
        private System.Windows.Forms.Timer timerMoverArriba;
        private System.Windows.Forms.Timer timerMoverIzquierda;
        private System.Windows.Forms.Timer timerMoverAbajo;
        private System.Windows.Forms.Timer timerAnimacion;
        private PictureBox pbJugador;
        private PictureBox pbPiano;
        private PictureBox pbPianoCloud;
        private PictureBox pbClock;
        private PictureBox pbClockCloud;
        private PictureBox pbMap;
        private PictureBox pbMapCloud;
        private PictureBox pbNeedle;
        private PictureBox pbNeedleCloud;
        private PictureBox pbBook;
        private PictureBox pbBookCloud;
        private Label label1;
        private Panel pnlMap;
        private Button btnNoMap;
        private Button btnSiMap;
        private Label lblDialogoMap;
        private Panel pnlNeedle;
        private Button btnNoNeedle;
        private Button btnSiNeedle;
        private Label lblNeedle;
        private Panel pnlPiano;
        private Button btnNoPiano;
        private Button btnSiPiano;
        private Label lblPiano;
        private Panel pnlBook;
        private Button btnNoBook;
        private Button btnSiBook;
        private Label lblBook;
        private Panel pnlClock;
        private Button btnNoClock;
        private Button btnSiClock;
        private Label lblClock;
        private Label lblCronometro;
        private ProgressBar pbTiempo;
        private Label lblIntentos;
        private System.Windows.Forms.Timer timerCronometro;
        private System.Windows.Forms.Timer timerEnter;
        private Panel pnlFail;
        private Button btnFailContinuar;
        private Label lblFail;
        private PictureBox pictureBox3;
        private Button btnIntentar;
        private Button btnSeguir;
    }
}
