namespace _DTeaching
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                // Thiet lap visible cua panel RGB lai thanh false.
                pnRGB.Visible = false;
                // Thiet lap lai nguon sang mac dinh.
                lstLightSource[0].Enable = false;

                simpleOpenGlControlPreViewcurrent.DestroyContexts();

                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.simpleOpenGlControlPreViewcurrent = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.contentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.indexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDpDnBnDraw = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripSph = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripCubic = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripCyl = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripCone = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButtonView = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripOrtho = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripPers = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripBnRGB = new System.Windows.Forms.ToolStripButton();
            this.toolStripBnRot = new System.Windows.Forms.ToolStripButton();
            this.toolStripBnTrans = new System.Windows.Forms.ToolStripButton();
            this.toolStripBnSca = new System.Windows.Forms.ToolStripButton();
            this.toolStripBnLitg = new System.Windows.Forms.ToolStripButton();
            this.toolStripBnTex = new System.Windows.Forms.ToolStripButton();
            this.toolStripBnFog = new System.Windows.Forms.ToolStripButton();
            this.pnRGB = new System.Windows.Forms.Panel();
            this.gbChooseRGB = new System.Windows.Forms.GroupBox();
            this.rbObjectRGB = new System.Windows.Forms.RadioButton();
            this.rdBackgroundRGB = new System.Windows.Forms.RadioButton();
            this.gbAdjustmentRGB = new System.Windows.Forms.GroupBox();
            this.bnApplyRGB = new System.Windows.Forms.Button();
            this.bnUndoRGB = new System.Windows.Forms.Button();
            this.bnRedoRGB = new System.Windows.Forms.Button();
            this.rbBlack = new System.Windows.Forms.RadioButton();
            this.bnCancelRGB = new System.Windows.Forms.Button();
            this.bnResetRGB = new System.Windows.Forms.Button();
            this.bnDoneRGB = new System.Windows.Forms.Button();
            this.rbWhite = new System.Windows.Forms.RadioButton();
            this.rbCustomRGB = new System.Windows.Forms.RadioButton();
            this.trackBarRedRGB = new System.Windows.Forms.TrackBar();
            this.trackBarGreenRGB = new System.Windows.Forms.TrackBar();
            this.numericUpDownBlueRGB = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownGreenRGB = new System.Windows.Forms.NumericUpDown();
            this.trackBarBlueRGB = new System.Windows.Forms.TrackBar();
            this.numericUpDownRedRGB = new System.Windows.Forms.NumericUpDown();
            this.pnRotate = new System.Windows.Forms.Panel();
            this.lbAnyAxistabObject = new System.Windows.Forms.Label();
            this.trackBarRotZtabObject = new System.Windows.Forms.TrackBar();
            this.trackBarRotYtabObject = new System.Windows.Forms.TrackBar();
            this.trackBarRotXtabObject = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.comboBoxTopRot = new System.Windows.Forms.ComboBox();
            this.comboBoxBottomRot = new System.Windows.Forms.ComboBox();
            this.comboBoxRightRot = new System.Windows.Forms.ComboBox();
            this.comboBoxLeftRot = new System.Windows.Forms.ComboBox();
            this.numericUpDownRotYtabObject = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownRotZtabObject = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownRotXtabObject = new System.Windows.Forms.NumericUpDown();
            this.bnResetpnRottabObject = new System.Windows.Forms.Button();
            this.bnCancelpnRottabObject = new System.Windows.Forms.Button();
            this.bnDonepnRottabObject = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControlRot = new System.Windows.Forms.TabControl();
            this.tabPageObjectRot = new System.Windows.Forms.TabPage();
            this.tabPagePlaneRot = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbCustomtabPlane = new System.Windows.Forms.RadioButton();
            this.rbDefaulttabPlane = new System.Windows.Forms.RadioButton();
            this.trackBarRotZtabPlane = new System.Windows.Forms.TrackBar();
            this.trackBarRotYtabPlane = new System.Windows.Forms.TrackBar();
            this.trackBarRotXtabPlane = new System.Windows.Forms.TrackBar();
            this.numericUpDownRotYtabPlane = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownRotZtabPlane = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.numericUpDownRotxtabPlane = new System.Windows.Forms.NumericUpDown();
            this.bnResettabPlane = new System.Windows.Forms.Button();
            this.bnCanceltabPlane = new System.Windows.Forms.Button();
            this.bnDonetabPlane = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.pnTrans = new System.Windows.Forms.Panel();
            this.bnApply_pnTrans = new System.Windows.Forms.Button();
            this.rbCustomTrans = new System.Windows.Forms.RadioButton();
            this.rbBottomTrans = new System.Windows.Forms.RadioButton();
            this.rdTopTrans = new System.Windows.Forms.RadioButton();
            this.rdRightTrans = new System.Windows.Forms.RadioButton();
            this.rbLeftTrans = new System.Windows.Forms.RadioButton();
            this.numericUpDownTransZ_pnTrans = new System.Windows.Forms.NumericUpDown();
            this.trackBarTransZ_pnTrans = new System.Windows.Forms.TrackBar();
            this.lbTransZ_pnTrans = new System.Windows.Forms.Label();
            this.numericUpDownTransY_pnTrans = new System.Windows.Forms.NumericUpDown();
            this.trackBarTransY_pnTrans = new System.Windows.Forms.TrackBar();
            this.lbTransY_pnTrans = new System.Windows.Forms.Label();
            this.lbTransX_pnTrans = new System.Windows.Forms.Label();
            this.bnCancelTrans = new System.Windows.Forms.Button();
            this.bnResetTrans = new System.Windows.Forms.Button();
            this.bnDoneTrans = new System.Windows.Forms.Button();
            this.numericUpDownTransX_pnTrans = new System.Windows.Forms.NumericUpDown();
            this.trackBarTransX_pnTrans = new System.Windows.Forms.TrackBar();
            this.pnSca = new System.Windows.Forms.Panel();
            this.rbStretch_pnScale = new System.Windows.Forms.RadioButton();
            this.bnApplypnTranslate = new System.Windows.Forms.Button();
            this.bnZoomOutSca = new System.Windows.Forms.Button();
            this.bnZoomInSca = new System.Windows.Forms.Button();
            this.rbShrink_pnScale = new System.Windows.Forms.RadioButton();
            this.numericUpDownScaZ_pnScale = new System.Windows.Forms.NumericUpDown();
            this.trackBarScaZ_pnScale = new System.Windows.Forms.TrackBar();
            this.lbScaZ_pnTranslate = new System.Windows.Forms.Label();
            this.numericUpDownScaY_pnScale = new System.Windows.Forms.NumericUpDown();
            this.trackBarScaY_pnScale = new System.Windows.Forms.TrackBar();
            this.lbScaY_pnTranslate = new System.Windows.Forms.Label();
            this.lbScaX_pnScale = new System.Windows.Forms.Label();
            this.bnCancelpnTranslate = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.bnDonepnTranslate = new System.Windows.Forms.Button();
            this.numericUpDownScaX_pnScale = new System.Windows.Forms.NumericUpDown();
            this.trackBarScaX_pnScale = new System.Windows.Forms.TrackBar();
            this.pnLighting = new System.Windows.Forms.Panel();
            this.lbColor_pnLighting = new System.Windows.Forms.Label();
            this.lbBlue_pnLighting = new System.Windows.Forms.Label();
            this.lbGreen_pnLighting = new System.Windows.Forms.Label();
            this.lbRed_pnLighting = new System.Windows.Forms.Label();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.gbLightSourceLocationLitg = new System.Windows.Forms.GroupBox();
            this.lbZLitg = new System.Windows.Forms.Label();
            this.lbYLitg = new System.Windows.Forms.Label();
            this.lbXLitg = new System.Windows.Forms.Label();
            this.numericUpDown7 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown6 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown5 = new System.Windows.Forms.NumericUpDown();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.cbShowLight_pnLighting = new System.Windows.Forms.CheckBox();
            this.gbRGBFog = new System.Windows.Forms.GroupBox();
            this.rbDefaultFog = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.trackBarRed_gpRGB = new System.Windows.Forms.TrackBar();
            this.trackBar3 = new System.Windows.Forms.TrackBar();
            this.trackBar4 = new System.Windows.Forms.TrackBar();
            this.cbFogEffect_gbRGB = new System.Windows.Forms.CheckBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bnOx = new System.Windows.Forms.Button();
            this.bnOy = new System.Windows.Forms.Button();
            this.bnOz = new System.Windows.Forms.Button();
            this.bnVector = new System.Windows.Forms.Button();
            this.cbShowVector = new System.Windows.Forms.CheckBox();
            this.Axisymmetric = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.pnRGB.SuspendLayout();
            this.gbChooseRGB.SuspendLayout();
            this.gbAdjustmentRGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRedRGB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarGreenRGB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBlueRGB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGreenRGB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBlueRGB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRedRGB)).BeginInit();
            this.pnRotate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRotZtabObject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRotYtabObject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRotXtabObject)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRotYtabObject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRotZtabObject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRotXtabObject)).BeginInit();
            this.tabControlRot.SuspendLayout();
            this.tabPageObjectRot.SuspendLayout();
            this.tabPagePlaneRot.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRotZtabPlane)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRotYtabPlane)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRotXtabPlane)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRotYtabPlane)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRotZtabPlane)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRotxtabPlane)).BeginInit();
            this.pnTrans.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTransZ_pnTrans)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTransZ_pnTrans)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTransY_pnTrans)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTransY_pnTrans)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTransX_pnTrans)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTransX_pnTrans)).BeginInit();
            this.pnSca.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownScaZ_pnScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarScaZ_pnScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownScaY_pnScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarScaY_pnScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownScaX_pnScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarScaX_pnScale)).BeginInit();
            this.pnLighting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.gbLightSourceLocationLitg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).BeginInit();
            this.gbRGBFog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRed_gpRGB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // simpleOpenGlControlPreViewcurrent
            // 
            this.simpleOpenGlControlPreViewcurrent.AccumBits = ((byte)(0));
            this.simpleOpenGlControlPreViewcurrent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleOpenGlControlPreViewcurrent.AutoCheckErrors = false;
            this.simpleOpenGlControlPreViewcurrent.AutoFinish = false;
            this.simpleOpenGlControlPreViewcurrent.AutoMakeCurrent = true;
            this.simpleOpenGlControlPreViewcurrent.AutoSwapBuffers = true;
            this.simpleOpenGlControlPreViewcurrent.BackColor = System.Drawing.Color.Black;
            this.simpleOpenGlControlPreViewcurrent.ColorBits = ((byte)(32));
            this.simpleOpenGlControlPreViewcurrent.DepthBits = ((byte)(16));
            this.simpleOpenGlControlPreViewcurrent.Location = new System.Drawing.Point(107, 46);
            this.simpleOpenGlControlPreViewcurrent.Name = "simpleOpenGlControlPreViewcurrent";
            this.simpleOpenGlControlPreViewcurrent.Size = new System.Drawing.Size(435, 415);
            this.simpleOpenGlControlPreViewcurrent.StencilBits = ((byte)(0));
            this.simpleOpenGlControlPreViewcurrent.TabIndex = 24;
            this.simpleOpenGlControlPreViewcurrent.Resize += new System.EventHandler(this.simpleOpenGlControl1_Resize);
            this.simpleOpenGlControlPreViewcurrent.Paint += new System.Windows.Forms.PaintEventHandler(this.simpleOpenGlControl1_Paint);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 475);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(748, 22);
            this.statusStrip1.TabIndex = 25;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(38, 17);
            this.toolStripStatusLabel1.Text = "Ready";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(748, 24);
            this.menuStrip1.TabIndex = 26;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripSeparator,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.printToolStripMenuItem,
            this.printPreviewToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
            this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.newToolStripMenuItem.Text = "&New";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.openToolStripMenuItem.Text = "&Open";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(148, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.saveAsToolStripMenuItem.Text = "Save &As";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(148, 6);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripMenuItem.Image")));
            this.printToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.printToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.printToolStripMenuItem.Text = "&Print";
            // 
            // printPreviewToolStripMenuItem
            // 
            this.printPreviewToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printPreviewToolStripMenuItem.Image")));
            this.printPreviewToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
            this.printPreviewToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.printPreviewToolStripMenuItem.Text = "Print Pre&view";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(148, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.toolStripSeparator3,
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.toolStripSeparator4,
            this.selectAllToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.undoToolStripMenuItem.Text = "&Undo";
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.redoToolStripMenuItem.Text = "&Redo";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(147, 6);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripMenuItem.Image")));
            this.cutToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.cutToolStripMenuItem.Text = "Cu&t";
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripMenuItem.Image")));
            this.copyToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.copyToolStripMenuItem.Text = "&Copy";
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripMenuItem.Image")));
            this.pasteToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.pasteToolStripMenuItem.Text = "&Paste";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(147, 6);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.selectAllToolStripMenuItem.Text = "Select &All";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customizeToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // customizeToolStripMenuItem
            // 
            this.customizeToolStripMenuItem.Name = "customizeToolStripMenuItem";
            this.customizeToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.customizeToolStripMenuItem.Text = "&Customize";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.optionsToolStripMenuItem.Text = "&Options";
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contentsToolStripMenuItem,
            this.indexToolStripMenuItem,
            this.searchToolStripMenuItem,
            this.toolStripSeparator5,
            this.aboutToolStripMenuItem1});
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem1.Text = "&Help";
            // 
            // contentsToolStripMenuItem
            // 
            this.contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
            this.contentsToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.contentsToolStripMenuItem.Text = "&Contents";
            // 
            // indexToolStripMenuItem
            // 
            this.indexToolStripMenuItem.Name = "indexToolStripMenuItem";
            this.indexToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.indexToolStripMenuItem.Text = "&Index";
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.searchToolStripMenuItem.Text = "&Search";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(126, 6);
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(129, 22);
            this.aboutToolStripMenuItem1.Text = "&About...";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDpDnBnDraw,
            this.toolStripDropDownButtonView,
            this.toolStripBnRGB,
            this.toolStripBnRot,
            this.toolStripBnTrans,
            this.toolStripBnSca,
            this.toolStripBnLitg,
            this.toolStripBnTex,
            this.toolStripBnFog,
            this.Axisymmetric});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(93, 451);
            this.toolStrip1.TabIndex = 27;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDpDnBnDraw
            // 
            this.toolStripDpDnBnDraw.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDpDnBnDraw.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSph,
            this.toolStripCubic,
            this.toolStripCyl,
            this.toolStripCone});
            this.toolStripDpDnBnDraw.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDpDnBnDraw.Image")));
            this.toolStripDpDnBnDraw.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDpDnBnDraw.Name = "toolStripDpDnBnDraw";
            this.toolStripDpDnBnDraw.Size = new System.Drawing.Size(90, 17);
            this.toolStripDpDnBnDraw.Text = "Draw";
            this.toolStripDpDnBnDraw.ToolTipText = "Draw an object";
            // 
            // toolStripSph
            // 
            this.toolStripSph.Name = "toolStripSph";
            this.toolStripSph.Size = new System.Drawing.Size(124, 22);
            this.toolStripSph.Text = "Sphere";
            this.toolStripSph.Click += new System.EventHandler(this.toolStripSph_Click);
            // 
            // toolStripCubic
            // 
            this.toolStripCubic.Name = "toolStripCubic";
            this.toolStripCubic.Size = new System.Drawing.Size(124, 22);
            this.toolStripCubic.Text = "Cubic";
            this.toolStripCubic.Click += new System.EventHandler(this.toolStripCubic_Click);
            // 
            // toolStripCyl
            // 
            this.toolStripCyl.Name = "toolStripCyl";
            this.toolStripCyl.Size = new System.Drawing.Size(124, 22);
            this.toolStripCyl.Text = "Cylinder";
            this.toolStripCyl.Click += new System.EventHandler(this.toolStripCyl_Click);
            // 
            // toolStripCone
            // 
            this.toolStripCone.Name = "toolStripCone";
            this.toolStripCone.Size = new System.Drawing.Size(124, 22);
            this.toolStripCone.Text = "Cone";
            this.toolStripCone.Click += new System.EventHandler(this.toolStripCone_Click);
            // 
            // toolStripDropDownButtonView
            // 
            this.toolStripDropDownButtonView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButtonView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripOrtho,
            this.toolStripPers});
            this.toolStripDropDownButtonView.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButtonView.Image")));
            this.toolStripDropDownButtonView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButtonView.Name = "toolStripDropDownButtonView";
            this.toolStripDropDownButtonView.Size = new System.Drawing.Size(90, 17);
            this.toolStripDropDownButtonView.Text = "View";
            // 
            // toolStripOrtho
            // 
            this.toolStripOrtho.Checked = true;
            this.toolStripOrtho.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripOrtho.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripOrtho.Name = "toolStripOrtho";
            this.toolStripOrtho.Size = new System.Drawing.Size(141, 22);
            this.toolStripOrtho.Text = "Orthogonal";
            this.toolStripOrtho.ToolTipText = "Orthogonal";
            this.toolStripOrtho.CheckedChanged += new System.EventHandler(this.toolStripOrtho_CheckedChanged);
            this.toolStripOrtho.Click += new System.EventHandler(this.toolStripOrtho_Click);
            // 
            // toolStripPers
            // 
            this.toolStripPers.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripPers.Name = "toolStripPers";
            this.toolStripPers.Size = new System.Drawing.Size(141, 22);
            this.toolStripPers.Text = "Perspective";
            this.toolStripPers.ToolTipText = "Perspective";
            this.toolStripPers.CheckedChanged += new System.EventHandler(this.toolStripPers_CheckedChanged);
            this.toolStripPers.Click += new System.EventHandler(this.toolStripPers_Click);
            // 
            // toolStripBnRGB
            // 
            this.toolStripBnRGB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripBnRGB.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBnRGB.Image")));
            this.toolStripBnRGB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBnRGB.Name = "toolStripBnRGB";
            this.toolStripBnRGB.Size = new System.Drawing.Size(90, 17);
            this.toolStripBnRGB.Text = "RGB";
            this.toolStripBnRGB.ToolTipText = "Color";
            this.toolStripBnRGB.Click += new System.EventHandler(this.toolStripBnRGB_Click);
            // 
            // toolStripBnRot
            // 
            this.toolStripBnRot.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripBnRot.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBnRot.Image")));
            this.toolStripBnRot.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBnRot.Name = "toolStripBnRot";
            this.toolStripBnRot.Size = new System.Drawing.Size(90, 17);
            this.toolStripBnRot.Text = "Rotate";
            this.toolStripBnRot.Click += new System.EventHandler(this.toolStripBnRot_Click);
            // 
            // toolStripBnTrans
            // 
            this.toolStripBnTrans.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripBnTrans.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBnTrans.Image")));
            this.toolStripBnTrans.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBnTrans.Name = "toolStripBnTrans";
            this.toolStripBnTrans.Size = new System.Drawing.Size(90, 17);
            this.toolStripBnTrans.Text = "Translate";
            this.toolStripBnTrans.ToolTipText = "Translate";
            this.toolStripBnTrans.Click += new System.EventHandler(this.toolStripBnTrans_Click);
            // 
            // toolStripBnSca
            // 
            this.toolStripBnSca.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripBnSca.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBnSca.Image")));
            this.toolStripBnSca.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBnSca.Name = "toolStripBnSca";
            this.toolStripBnSca.Size = new System.Drawing.Size(90, 17);
            this.toolStripBnSca.Text = "Scale";
            this.toolStripBnSca.ToolTipText = "Scale";
            this.toolStripBnSca.Click += new System.EventHandler(this.toolStripBnSca_Click);
            // 
            // toolStripBnLitg
            // 
            this.toolStripBnLitg.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripBnLitg.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBnLitg.Image")));
            this.toolStripBnLitg.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBnLitg.Name = "toolStripBnLitg";
            this.toolStripBnLitg.Size = new System.Drawing.Size(90, 17);
            this.toolStripBnLitg.Text = "Lighting";
            this.toolStripBnLitg.ToolTipText = "Lighting";
            this.toolStripBnLitg.Click += new System.EventHandler(this.toolStripBnLitg_Click);
            // 
            // toolStripBnTex
            // 
            this.toolStripBnTex.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripBnTex.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBnTex.Image")));
            this.toolStripBnTex.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBnTex.Name = "toolStripBnTex";
            this.toolStripBnTex.Size = new System.Drawing.Size(90, 17);
            this.toolStripBnTex.Text = "Texture Mapping";
            this.toolStripBnTex.ToolTipText = "Texture Mapping";
            this.toolStripBnTex.Click += new System.EventHandler(this.toolStripBnTex_Click);
            // 
            // toolStripBnFog
            // 
            this.toolStripBnFog.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripBnFog.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBnFog.Image")));
            this.toolStripBnFog.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBnFog.Name = "toolStripBnFog";
            this.toolStripBnFog.Size = new System.Drawing.Size(90, 17);
            this.toolStripBnFog.Text = "Fog";
            this.toolStripBnFog.ToolTipText = "Fog";
            this.toolStripBnFog.Click += new System.EventHandler(this.toolStripBnFog_Click);
            // 
            // pnRGB
            // 
            this.pnRGB.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar;
            this.pnRGB.Controls.Add(this.gbChooseRGB);
            this.pnRGB.Controls.Add(this.gbAdjustmentRGB);
            this.pnRGB.Location = new System.Drawing.Point(548, 46);
            this.pnRGB.Name = "pnRGB";
            this.pnRGB.Size = new System.Drawing.Size(188, 415);
            this.pnRGB.TabIndex = 28;
            this.pnRGB.Visible = false;
            // 
            // gbChooseRGB
            // 
            this.gbChooseRGB.Controls.Add(this.rbObjectRGB);
            this.gbChooseRGB.Controls.Add(this.rdBackgroundRGB);
            this.gbChooseRGB.Location = new System.Drawing.Point(1, 3);
            this.gbChooseRGB.Name = "gbChooseRGB";
            this.gbChooseRGB.Size = new System.Drawing.Size(188, 60);
            this.gbChooseRGB.TabIndex = 11;
            this.gbChooseRGB.TabStop = false;
            this.gbChooseRGB.Text = "Choose";
            // 
            // rbObjectRGB
            // 
            this.rbObjectRGB.AutoSize = true;
            this.rbObjectRGB.Enabled = false;
            this.rbObjectRGB.Location = new System.Drawing.Point(41, 15);
            this.rbObjectRGB.Name = "rbObjectRGB";
            this.rbObjectRGB.Size = new System.Drawing.Size(56, 17);
            this.rbObjectRGB.TabIndex = 18;
            this.rbObjectRGB.Text = "Object";
            this.rbObjectRGB.UseVisualStyleBackColor = true;
            this.rbObjectRGB.CheckedChanged += new System.EventHandler(this.rbObjectRGB_CheckedChanged);
            // 
            // rdBackgroundRGB
            // 
            this.rdBackgroundRGB.AutoSize = true;
            this.rdBackgroundRGB.Checked = true;
            this.rdBackgroundRGB.Location = new System.Drawing.Point(41, 35);
            this.rdBackgroundRGB.Name = "rdBackgroundRGB";
            this.rdBackgroundRGB.Size = new System.Drawing.Size(83, 17);
            this.rdBackgroundRGB.TabIndex = 10;
            this.rdBackgroundRGB.TabStop = true;
            this.rdBackgroundRGB.Text = "Background";
            this.rdBackgroundRGB.UseVisualStyleBackColor = true;
            this.rdBackgroundRGB.CheckedChanged += new System.EventHandler(this.rdBackgroundRGB_CheckedChanged);
            // 
            // gbAdjustmentRGB
            // 
            this.gbAdjustmentRGB.Controls.Add(this.bnApplyRGB);
            this.gbAdjustmentRGB.Controls.Add(this.bnUndoRGB);
            this.gbAdjustmentRGB.Controls.Add(this.bnRedoRGB);
            this.gbAdjustmentRGB.Controls.Add(this.rbBlack);
            this.gbAdjustmentRGB.Controls.Add(this.bnCancelRGB);
            this.gbAdjustmentRGB.Controls.Add(this.bnResetRGB);
            this.gbAdjustmentRGB.Controls.Add(this.bnDoneRGB);
            this.gbAdjustmentRGB.Controls.Add(this.rbWhite);
            this.gbAdjustmentRGB.Controls.Add(this.rbCustomRGB);
            this.gbAdjustmentRGB.Controls.Add(this.trackBarRedRGB);
            this.gbAdjustmentRGB.Controls.Add(this.trackBarGreenRGB);
            this.gbAdjustmentRGB.Controls.Add(this.numericUpDownBlueRGB);
            this.gbAdjustmentRGB.Controls.Add(this.numericUpDownGreenRGB);
            this.gbAdjustmentRGB.Controls.Add(this.trackBarBlueRGB);
            this.gbAdjustmentRGB.Controls.Add(this.numericUpDownRedRGB);
            this.gbAdjustmentRGB.Location = new System.Drawing.Point(1, 69);
            this.gbAdjustmentRGB.Name = "gbAdjustmentRGB";
            this.gbAdjustmentRGB.Size = new System.Drawing.Size(191, 353);
            this.gbAdjustmentRGB.TabIndex = 11;
            this.gbAdjustmentRGB.TabStop = false;
            this.gbAdjustmentRGB.Text = "Adjustment";
            // 
            // bnApplyRGB
            // 
            this.bnApplyRGB.Enabled = false;
            this.bnApplyRGB.Location = new System.Drawing.Point(15, 273);
            this.bnApplyRGB.Name = "bnApplyRGB";
            this.bnApplyRGB.Size = new System.Drawing.Size(51, 23);
            this.bnApplyRGB.TabIndex = 26;
            this.bnApplyRGB.Text = "Apply";
            this.bnApplyRGB.UseVisualStyleBackColor = true;
            // 
            // bnUndoRGB
            // 
            this.bnUndoRGB.Enabled = false;
            this.bnUndoRGB.Location = new System.Drawing.Point(46, 314);
            this.bnUndoRGB.Name = "bnUndoRGB";
            this.bnUndoRGB.Size = new System.Drawing.Size(51, 23);
            this.bnUndoRGB.TabIndex = 25;
            this.bnUndoRGB.Text = "Undo";
            this.bnUndoRGB.UseVisualStyleBackColor = true;
            // 
            // bnRedoRGB
            // 
            this.bnRedoRGB.Enabled = false;
            this.bnRedoRGB.Location = new System.Drawing.Point(103, 314);
            this.bnRedoRGB.Name = "bnRedoRGB";
            this.bnRedoRGB.Size = new System.Drawing.Size(51, 23);
            this.bnRedoRGB.TabIndex = 24;
            this.bnRedoRGB.Text = "Redo";
            this.bnRedoRGB.UseVisualStyleBackColor = true;
            // 
            // rbBlack
            // 
            this.rbBlack.AutoSize = true;
            this.rbBlack.Checked = true;
            this.rbBlack.Location = new System.Drawing.Point(29, 19);
            this.rbBlack.Name = "rbBlack";
            this.rbBlack.Size = new System.Drawing.Size(52, 17);
            this.rbBlack.TabIndex = 9;
            this.rbBlack.TabStop = true;
            this.rbBlack.Text = "Black";
            this.rbBlack.UseVisualStyleBackColor = true;
            this.rbBlack.CheckedChanged += new System.EventHandler(this.rbBlack_CheckedChanged);
            // 
            // bnCancelRGB
            // 
            this.bnCancelRGB.Location = new System.Drawing.Point(130, 273);
            this.bnCancelRGB.Name = "bnCancelRGB";
            this.bnCancelRGB.Size = new System.Drawing.Size(51, 23);
            this.bnCancelRGB.TabIndex = 22;
            this.bnCancelRGB.Text = "Cancel";
            this.bnCancelRGB.UseVisualStyleBackColor = true;
            this.bnCancelRGB.Click += new System.EventHandler(this.bnCancelRGB_Click);
            // 
            // bnResetRGB
            // 
            this.bnResetRGB.Location = new System.Drawing.Point(115, 227);
            this.bnResetRGB.Name = "bnResetRGB";
            this.bnResetRGB.Size = new System.Drawing.Size(51, 23);
            this.bnResetRGB.TabIndex = 23;
            this.bnResetRGB.Text = "Reset";
            this.bnResetRGB.UseVisualStyleBackColor = true;
            this.bnResetRGB.Click += new System.EventHandler(this.bnResetRGB_Click);
            // 
            // bnDoneRGB
            // 
            this.bnDoneRGB.Location = new System.Drawing.Point(73, 273);
            this.bnDoneRGB.Name = "bnDoneRGB";
            this.bnDoneRGB.Size = new System.Drawing.Size(51, 23);
            this.bnDoneRGB.TabIndex = 21;
            this.bnDoneRGB.Text = "Done";
            this.bnDoneRGB.UseVisualStyleBackColor = true;
            this.bnDoneRGB.Click += new System.EventHandler(this.bnDoneRGB_Click);
            // 
            // rbWhite
            // 
            this.rbWhite.AutoSize = true;
            this.rbWhite.Location = new System.Drawing.Point(101, 19);
            this.rbWhite.Name = "rbWhite";
            this.rbWhite.Size = new System.Drawing.Size(53, 17);
            this.rbWhite.TabIndex = 10;
            this.rbWhite.TabStop = true;
            this.rbWhite.Text = "White";
            this.rbWhite.UseVisualStyleBackColor = true;
            this.rbWhite.CheckedChanged += new System.EventHandler(this.rbWhite_CheckedChanged);
            // 
            // rbCustomRGB
            // 
            this.rbCustomRGB.AutoSize = true;
            this.rbCustomRGB.Location = new System.Drawing.Point(60, 42);
            this.rbCustomRGB.Name = "rbCustomRGB";
            this.rbCustomRGB.Size = new System.Drawing.Size(60, 17);
            this.rbCustomRGB.TabIndex = 20;
            this.rbCustomRGB.TabStop = true;
            this.rbCustomRGB.Text = "Custom";
            this.rbCustomRGB.UseVisualStyleBackColor = true;
            // 
            // trackBarRedRGB
            // 
            this.trackBarRedRGB.BackColor = System.Drawing.Color.Red;
            this.trackBarRedRGB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.trackBarRedRGB.Location = new System.Drawing.Point(16, 70);
            this.trackBarRedRGB.Maximum = 255;
            this.trackBarRedRGB.Name = "trackBarRedRGB";
            this.trackBarRedRGB.Size = new System.Drawing.Size(104, 45);
            this.trackBarRedRGB.TabIndex = 0;
            this.trackBarRedRGB.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarRedRGB.ValueChanged += new System.EventHandler(this.trackBarRedRGB_ValueChanged);
            this.trackBarRedRGB.Scroll += new System.EventHandler(this.trackBarRedRGB_Scroll);
            // 
            // trackBarGreenRGB
            // 
            this.trackBarGreenRGB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.trackBarGreenRGB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.trackBarGreenRGB.Location = new System.Drawing.Point(16, 116);
            this.trackBarGreenRGB.Maximum = 255;
            this.trackBarGreenRGB.Name = "trackBarGreenRGB";
            this.trackBarGreenRGB.Size = new System.Drawing.Size(104, 45);
            this.trackBarGreenRGB.TabIndex = 13;
            this.trackBarGreenRGB.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarGreenRGB.ValueChanged += new System.EventHandler(this.trackBarGreenRGB_ValueChanged);
            this.trackBarGreenRGB.Scroll += new System.EventHandler(this.trackBarGreenRGB_Scroll);
            // 
            // numericUpDownBlueRGB
            // 
            this.numericUpDownBlueRGB.Location = new System.Drawing.Point(119, 167);
            this.numericUpDownBlueRGB.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.numericUpDownBlueRGB.Name = "numericUpDownBlueRGB";
            this.numericUpDownBlueRGB.Size = new System.Drawing.Size(49, 20);
            this.numericUpDownBlueRGB.TabIndex = 11;
            this.numericUpDownBlueRGB.Click += new System.EventHandler(this.numericUpDownBlueRGB_Click);
            this.numericUpDownBlueRGB.ValueChanged += new System.EventHandler(this.numericUpDownBlueRGB_ValueChanged);
            this.numericUpDownBlueRGB.KeyUp += new System.Windows.Forms.KeyEventHandler(this.numericUpDownBlueRGB_KeyUp);
            // 
            // numericUpDownGreenRGB
            // 
            this.numericUpDownGreenRGB.Location = new System.Drawing.Point(119, 120);
            this.numericUpDownGreenRGB.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.numericUpDownGreenRGB.Name = "numericUpDownGreenRGB";
            this.numericUpDownGreenRGB.Size = new System.Drawing.Size(49, 20);
            this.numericUpDownGreenRGB.TabIndex = 14;
            this.numericUpDownGreenRGB.Click += new System.EventHandler(this.numericUpDownGreenRGB_Click);
            this.numericUpDownGreenRGB.ValueChanged += new System.EventHandler(this.numericUpDownGreenRGB_ValueChanged);
            this.numericUpDownGreenRGB.KeyUp += new System.Windows.Forms.KeyEventHandler(this.numericUpDownGreenRGB_KeyUp);
            // 
            // trackBarBlueRGB
            // 
            this.trackBarBlueRGB.BackColor = System.Drawing.Color.Blue;
            this.trackBarBlueRGB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.trackBarBlueRGB.Location = new System.Drawing.Point(16, 162);
            this.trackBarBlueRGB.Maximum = 255;
            this.trackBarBlueRGB.Name = "trackBarBlueRGB";
            this.trackBarBlueRGB.Size = new System.Drawing.Size(104, 45);
            this.trackBarBlueRGB.TabIndex = 16;
            this.trackBarBlueRGB.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarBlueRGB.ValueChanged += new System.EventHandler(this.trackBarBlueRGB_ValueChanged);
            this.trackBarBlueRGB.Scroll += new System.EventHandler(this.trackBarBlueRGB_Scroll);
            // 
            // numericUpDownRedRGB
            // 
            this.numericUpDownRedRGB.AccessibleDescription = "";
            this.numericUpDownRedRGB.AccessibleName = "";
            this.numericUpDownRedRGB.Location = new System.Drawing.Point(119, 74);
            this.numericUpDownRedRGB.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownRedRGB.Name = "numericUpDownRedRGB";
            this.numericUpDownRedRGB.Size = new System.Drawing.Size(47, 20);
            this.numericUpDownRedRGB.TabIndex = 17;
            this.numericUpDownRedRGB.Click += new System.EventHandler(this.numericUpDownRedRGB_Click);
            this.numericUpDownRedRGB.ValueChanged += new System.EventHandler(this.numericUpDownRedRGB_ValueChanged);
            this.numericUpDownRedRGB.KeyUp += new System.Windows.Forms.KeyEventHandler(this.numericUpDownRedRGB_KeyUp);
            // 
            // pnRotate
            // 
            this.pnRotate.Controls.Add(this.checkBox1);
            this.pnRotate.Controls.Add(this.numericUpDown4);
            this.pnRotate.Controls.Add(this.trackBar1);
            this.pnRotate.Controls.Add(this.lbAnyAxistabObject);
            this.pnRotate.Controls.Add(this.trackBarRotZtabObject);
            this.pnRotate.Controls.Add(this.trackBarRotYtabObject);
            this.pnRotate.Controls.Add(this.trackBarRotXtabObject);
            this.pnRotate.Controls.Add(this.label4);
            this.pnRotate.Controls.Add(this.panel4);
            this.pnRotate.Controls.Add(this.numericUpDownRotYtabObject);
            this.pnRotate.Controls.Add(this.numericUpDownRotZtabObject);
            this.pnRotate.Controls.Add(this.label3);
            this.pnRotate.Controls.Add(this.label2);
            this.pnRotate.Controls.Add(this.label1);
            this.pnRotate.Controls.Add(this.numericUpDownRotXtabObject);
            this.pnRotate.Controls.Add(this.bnResetpnRottabObject);
            this.pnRotate.Controls.Add(this.bnCancelpnRottabObject);
            this.pnRotate.Controls.Add(this.bnDonepnRottabObject);
            this.pnRotate.Controls.Add(this.button1);
            this.pnRotate.Location = new System.Drawing.Point(3, 3);
            this.pnRotate.Name = "pnRotate";
            this.pnRotate.Size = new System.Drawing.Size(195, 386);
            this.pnRotate.TabIndex = 29;
            // 
            // lbAnyAxistabObject
            // 
            this.lbAnyAxistabObject.AutoSize = true;
            this.lbAnyAxistabObject.Location = new System.Drawing.Point(3, 268);
            this.lbAnyAxistabObject.Name = "lbAnyAxistabObject";
            this.lbAnyAxistabObject.Size = new System.Drawing.Size(47, 13);
            this.lbAnyAxistabObject.TabIndex = 31;
            this.lbAnyAxistabObject.Text = "Any Axis";
            // 
            // trackBarRotZtabObject
            // 
            this.trackBarRotZtabObject.Location = new System.Drawing.Point(35, 206);
            this.trackBarRotZtabObject.Maximum = 360;
            this.trackBarRotZtabObject.Minimum = -360;
            this.trackBarRotZtabObject.Name = "trackBarRotZtabObject";
            this.trackBarRotZtabObject.Size = new System.Drawing.Size(98, 45);
            this.trackBarRotZtabObject.TabIndex = 32;
            this.trackBarRotZtabObject.ValueChanged += new System.EventHandler(this.trackBarRotZtabObject_ValueChanged);
            // 
            // trackBarRotYtabObject
            // 
            this.trackBarRotYtabObject.Location = new System.Drawing.Point(35, 160);
            this.trackBarRotYtabObject.Maximum = 360;
            this.trackBarRotYtabObject.Minimum = -360;
            this.trackBarRotYtabObject.Name = "trackBarRotYtabObject";
            this.trackBarRotYtabObject.Size = new System.Drawing.Size(98, 45);
            this.trackBarRotYtabObject.TabIndex = 31;
            this.trackBarRotYtabObject.ValueChanged += new System.EventHandler(this.trackBarRotYtabObject_ValueChanged);
            // 
            // trackBarRotXtabObject
            // 
            this.trackBarRotXtabObject.Location = new System.Drawing.Point(35, 114);
            this.trackBarRotXtabObject.Maximum = 360;
            this.trackBarRotXtabObject.Minimum = -360;
            this.trackBarRotXtabObject.Name = "trackBarRotXtabObject";
            this.trackBarRotXtabObject.Size = new System.Drawing.Size(98, 45);
            this.trackBarRotXtabObject.TabIndex = 30;
            this.trackBarRotXtabObject.ValueChanged += new System.EventHandler(this.trackBarRotXtabObject_ValueChanged);
            this.trackBarRotXtabObject.Scroll += new System.EventHandler(this.trackBarRotXtabObject_Scroll);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(83, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Custom Rotate";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.comboBoxTopRot);
            this.panel4.Controls.Add(this.comboBoxBottomRot);
            this.panel4.Controls.Add(this.comboBoxRightRot);
            this.panel4.Controls.Add(this.comboBoxLeftRot);
            this.panel4.Location = new System.Drawing.Point(3, 5);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(185, 72);
            this.panel4.TabIndex = 9;
            // 
            // comboBoxTopRot
            // 
            this.comboBoxTopRot.FormattingEnabled = true;
            this.comboBoxTopRot.Items.AddRange(new object[] {
            "Top 45",
            "Top 90",
            "Top 180",
            "Top 360"});
            this.comboBoxTopRot.Location = new System.Drawing.Point(7, 48);
            this.comboBoxTopRot.Name = "comboBoxTopRot";
            this.comboBoxTopRot.Size = new System.Drawing.Size(77, 21);
            this.comboBoxTopRot.TabIndex = 12;
            this.comboBoxTopRot.Text = "Top";
            this.comboBoxTopRot.TextChanged += new System.EventHandler(this.comboBoxTopRot_TextChanged);
            // 
            // comboBoxBottomRot
            // 
            this.comboBoxBottomRot.FormattingEnabled = true;
            this.comboBoxBottomRot.Items.AddRange(new object[] {
            "Bottom 45",
            "Bottom 90",
            "Bottom 180",
            "Bottom 360"});
            this.comboBoxBottomRot.Location = new System.Drawing.Point(103, 48);
            this.comboBoxBottomRot.Name = "comboBoxBottomRot";
            this.comboBoxBottomRot.Size = new System.Drawing.Size(73, 21);
            this.comboBoxBottomRot.TabIndex = 11;
            this.comboBoxBottomRot.Text = "Bottom";
            this.comboBoxBottomRot.TextChanged += new System.EventHandler(this.comboBoxBottomRot_TextChanged);
            // 
            // comboBoxRightRot
            // 
            this.comboBoxRightRot.FormattingEnabled = true;
            this.comboBoxRightRot.Items.AddRange(new object[] {
            "Right 45",
            "Right 90",
            "Right 180",
            "Right 360"});
            this.comboBoxRightRot.Location = new System.Drawing.Point(103, 8);
            this.comboBoxRightRot.Name = "comboBoxRightRot";
            this.comboBoxRightRot.Size = new System.Drawing.Size(73, 21);
            this.comboBoxRightRot.TabIndex = 10;
            this.comboBoxRightRot.Text = "Right";
            this.comboBoxRightRot.TextChanged += new System.EventHandler(this.comboBoxRightRot_TextChanged);
            // 
            // comboBoxLeftRot
            // 
            this.comboBoxLeftRot.FormattingEnabled = true;
            this.comboBoxLeftRot.Items.AddRange(new object[] {
            "Left 45",
            "Left 90",
            "Left 180",
            "Left 360"});
            this.comboBoxLeftRot.Location = new System.Drawing.Point(7, 8);
            this.comboBoxLeftRot.Name = "comboBoxLeftRot";
            this.comboBoxLeftRot.Size = new System.Drawing.Size(77, 21);
            this.comboBoxLeftRot.TabIndex = 9;
            this.comboBoxLeftRot.Text = "Left";
            this.comboBoxLeftRot.TextChanged += new System.EventHandler(this.comboBoxLeftRot_TextChanged);
            // 
            // numericUpDownRotYtabObject
            // 
            this.numericUpDownRotYtabObject.Location = new System.Drawing.Point(136, 165);
            this.numericUpDownRotYtabObject.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.numericUpDownRotYtabObject.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.numericUpDownRotYtabObject.Name = "numericUpDownRotYtabObject";
            this.numericUpDownRotYtabObject.Size = new System.Drawing.Size(52, 20);
            this.numericUpDownRotYtabObject.TabIndex = 11;
            this.numericUpDownRotYtabObject.ValueChanged += new System.EventHandler(this.numericUpDownRotY_ValueChanged);
            this.numericUpDownRotYtabObject.KeyUp += new System.Windows.Forms.KeyEventHandler(this.numericUpDownRotY_KeyUp);
            // 
            // numericUpDownRotZtabObject
            // 
            this.numericUpDownRotZtabObject.Location = new System.Drawing.Point(136, 211);
            this.numericUpDownRotZtabObject.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.numericUpDownRotZtabObject.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.numericUpDownRotZtabObject.Name = "numericUpDownRotZtabObject";
            this.numericUpDownRotZtabObject.Size = new System.Drawing.Size(52, 20);
            this.numericUpDownRotZtabObject.TabIndex = 10;
            this.numericUpDownRotZtabObject.ValueChanged += new System.EventHandler(this.numericUpDownRotZ_ValueChanged);
            this.numericUpDownRotZtabObject.KeyUp += new System.Windows.Forms.KeyEventHandler(this.numericUpDownRotZ_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 213);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Rot Z";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Rot Y";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Rot X";
            // 
            // numericUpDownRotXtabObject
            // 
            this.numericUpDownRotXtabObject.Location = new System.Drawing.Point(134, 118);
            this.numericUpDownRotXtabObject.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.numericUpDownRotXtabObject.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.numericUpDownRotXtabObject.Name = "numericUpDownRotXtabObject";
            this.numericUpDownRotXtabObject.Size = new System.Drawing.Size(52, 20);
            this.numericUpDownRotXtabObject.TabIndex = 6;
            this.numericUpDownRotXtabObject.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            this.numericUpDownRotXtabObject.KeyUp += new System.Windows.Forms.KeyEventHandler(this.numericUpDown1_KeyUp);
            // 
            // bnResetpnRottabObject
            // 
            this.bnResetpnRottabObject.Location = new System.Drawing.Point(109, 329);
            this.bnResetpnRottabObject.Name = "bnResetpnRottabObject";
            this.bnResetpnRottabObject.Size = new System.Drawing.Size(54, 23);
            this.bnResetpnRottabObject.TabIndex = 0;
            this.bnResetpnRottabObject.Text = "Reset";
            this.bnResetpnRottabObject.UseVisualStyleBackColor = true;
            this.bnResetpnRottabObject.Click += new System.EventHandler(this.bnResetpnRot_Click);
            // 
            // bnCancelpnRottabObject
            // 
            this.bnCancelpnRottabObject.Location = new System.Drawing.Point(129, 358);
            this.bnCancelpnRottabObject.Name = "bnCancelpnRottabObject";
            this.bnCancelpnRottabObject.Size = new System.Drawing.Size(49, 23);
            this.bnCancelpnRottabObject.TabIndex = 2;
            this.bnCancelpnRottabObject.Text = "Cancel";
            this.bnCancelpnRottabObject.UseVisualStyleBackColor = true;
            this.bnCancelpnRottabObject.Click += new System.EventHandler(this.bnCancelpnRot_Click);
            // 
            // bnDonepnRottabObject
            // 
            this.bnDonepnRottabObject.Location = new System.Drawing.Point(78, 358);
            this.bnDonepnRottabObject.Name = "bnDonepnRottabObject";
            this.bnDonepnRottabObject.Size = new System.Drawing.Size(46, 23);
            this.bnDonepnRottabObject.TabIndex = 1;
            this.bnDonepnRottabObject.Text = "Done";
            this.bnDonepnRottabObject.UseVisualStyleBackColor = true;
            this.bnDonepnRottabObject.Click += new System.EventHandler(this.bnDonepnRot_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(26, 358);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(46, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Apply";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // tabControlRot
            // 
            this.tabControlRot.Controls.Add(this.tabPageObjectRot);
            this.tabControlRot.Controls.Add(this.tabPagePlaneRot);
            this.tabControlRot.Location = new System.Drawing.Point(545, 42);
            this.tabControlRot.Name = "tabControlRot";
            this.tabControlRot.SelectedIndex = 0;
            this.tabControlRot.Size = new System.Drawing.Size(200, 416);
            this.tabControlRot.TabIndex = 30;
            this.tabControlRot.Visible = false;
            // 
            // tabPageObjectRot
            // 
            this.tabPageObjectRot.Controls.Add(this.pnRotate);
            this.tabPageObjectRot.Location = new System.Drawing.Point(4, 22);
            this.tabPageObjectRot.Name = "tabPageObjectRot";
            this.tabPageObjectRot.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageObjectRot.Size = new System.Drawing.Size(192, 390);
            this.tabPageObjectRot.TabIndex = 0;
            this.tabPageObjectRot.Text = "Object";
            this.tabPageObjectRot.UseVisualStyleBackColor = true;
            // 
            // tabPagePlaneRot
            // 
            this.tabPagePlaneRot.Controls.Add(this.panel1);
            this.tabPagePlaneRot.Location = new System.Drawing.Point(4, 22);
            this.tabPagePlaneRot.Name = "tabPagePlaneRot";
            this.tabPagePlaneRot.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePlaneRot.Size = new System.Drawing.Size(192, 390);
            this.tabPagePlaneRot.TabIndex = 1;
            this.tabPagePlaneRot.Text = "Plane";
            this.tabPagePlaneRot.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbCustomtabPlane);
            this.panel1.Controls.Add(this.rbDefaulttabPlane);
            this.panel1.Controls.Add(this.trackBarRotZtabPlane);
            this.panel1.Controls.Add(this.trackBarRotYtabPlane);
            this.panel1.Controls.Add(this.trackBarRotXtabPlane);
            this.panel1.Controls.Add(this.numericUpDownRotYtabPlane);
            this.panel1.Controls.Add(this.numericUpDownRotZtabPlane);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.numericUpDownRotxtabPlane);
            this.panel1.Controls.Add(this.bnResettabPlane);
            this.panel1.Controls.Add(this.bnCanceltabPlane);
            this.panel1.Controls.Add(this.bnDonetabPlane);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Location = new System.Drawing.Point(-1, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(195, 386);
            this.panel1.TabIndex = 30;
            // 
            // rbCustomtabPlane
            // 
            this.rbCustomtabPlane.AutoSize = true;
            this.rbCustomtabPlane.Location = new System.Drawing.Point(76, 45);
            this.rbCustomtabPlane.Name = "rbCustomtabPlane";
            this.rbCustomtabPlane.Size = new System.Drawing.Size(95, 17);
            this.rbCustomtabPlane.TabIndex = 33;
            this.rbCustomtabPlane.TabStop = true;
            this.rbCustomtabPlane.Text = "Custom Rotate";
            this.rbCustomtabPlane.UseVisualStyleBackColor = true;
            // 
            // rbDefaulttabPlane
            // 
            this.rbDefaulttabPlane.AutoSize = true;
            this.rbDefaulttabPlane.Location = new System.Drawing.Point(39, 17);
            this.rbDefaulttabPlane.Name = "rbDefaulttabPlane";
            this.rbDefaulttabPlane.Size = new System.Drawing.Size(59, 17);
            this.rbDefaulttabPlane.TabIndex = 31;
            this.rbDefaulttabPlane.TabStop = true;
            this.rbDefaulttabPlane.Text = "Default";
            this.rbDefaulttabPlane.UseVisualStyleBackColor = true;
            this.rbDefaulttabPlane.CheckedChanged += new System.EventHandler(this.rbDefaulttabPlane_CheckedChanged);
            // 
            // trackBarRotZtabPlane
            // 
            this.trackBarRotZtabPlane.Location = new System.Drawing.Point(35, 187);
            this.trackBarRotZtabPlane.Maximum = 360;
            this.trackBarRotZtabPlane.Minimum = -360;
            this.trackBarRotZtabPlane.Name = "trackBarRotZtabPlane";
            this.trackBarRotZtabPlane.Size = new System.Drawing.Size(98, 45);
            this.trackBarRotZtabPlane.TabIndex = 32;
            this.trackBarRotZtabPlane.ValueChanged += new System.EventHandler(this.trackBarRotZtabPlane_ValueChanged);
            this.trackBarRotZtabPlane.Scroll += new System.EventHandler(this.trackBarRotZtabPlane_Scroll);
            // 
            // trackBarRotYtabPlane
            // 
            this.trackBarRotYtabPlane.Location = new System.Drawing.Point(35, 136);
            this.trackBarRotYtabPlane.Maximum = 360;
            this.trackBarRotYtabPlane.Minimum = -360;
            this.trackBarRotYtabPlane.Name = "trackBarRotYtabPlane";
            this.trackBarRotYtabPlane.Size = new System.Drawing.Size(98, 45);
            this.trackBarRotYtabPlane.TabIndex = 31;
            this.trackBarRotYtabPlane.ValueChanged += new System.EventHandler(this.trackBarRotYtabPlane_ValueChanged);
            this.trackBarRotYtabPlane.Scroll += new System.EventHandler(this.trackBarRotYtabPlane_Scroll);
            // 
            // trackBarRotXtabPlane
            // 
            this.trackBarRotXtabPlane.Location = new System.Drawing.Point(35, 87);
            this.trackBarRotXtabPlane.Maximum = 360;
            this.trackBarRotXtabPlane.Minimum = -360;
            this.trackBarRotXtabPlane.Name = "trackBarRotXtabPlane";
            this.trackBarRotXtabPlane.Size = new System.Drawing.Size(98, 45);
            this.trackBarRotXtabPlane.TabIndex = 30;
            this.trackBarRotXtabPlane.ValueChanged += new System.EventHandler(this.trackBarRotXtabPlane_ValueChanged);
            this.trackBarRotXtabPlane.Scroll += new System.EventHandler(this.trackBarRotXtabPlane_Scroll);
            // 
            // numericUpDownRotYtabPlane
            // 
            this.numericUpDownRotYtabPlane.Location = new System.Drawing.Point(136, 145);
            this.numericUpDownRotYtabPlane.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.numericUpDownRotYtabPlane.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.numericUpDownRotYtabPlane.Name = "numericUpDownRotYtabPlane";
            this.numericUpDownRotYtabPlane.Size = new System.Drawing.Size(52, 20);
            this.numericUpDownRotYtabPlane.TabIndex = 11;
            this.numericUpDownRotYtabPlane.Click += new System.EventHandler(this.numericUpDownRotYtabPlane_Click);
            this.numericUpDownRotYtabPlane.ValueChanged += new System.EventHandler(this.numericUpDownRotYtabPlane_ValueChanged);
            this.numericUpDownRotYtabPlane.KeyUp += new System.Windows.Forms.KeyEventHandler(this.numericUpDownRotYtabPlane_KeyUp);
            // 
            // numericUpDownRotZtabPlane
            // 
            this.numericUpDownRotZtabPlane.Location = new System.Drawing.Point(136, 196);
            this.numericUpDownRotZtabPlane.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.numericUpDownRotZtabPlane.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.numericUpDownRotZtabPlane.Name = "numericUpDownRotZtabPlane";
            this.numericUpDownRotZtabPlane.Size = new System.Drawing.Size(52, 20);
            this.numericUpDownRotZtabPlane.TabIndex = 10;
            this.numericUpDownRotZtabPlane.Click += new System.EventHandler(this.numericUpDownRotZtabPlane_Click);
            this.numericUpDownRotZtabPlane.ValueChanged += new System.EventHandler(this.numericUpDownRotZtabPlane_ValueChanged);
            this.numericUpDownRotZtabPlane.KeyUp += new System.Windows.Forms.KeyEventHandler(this.numericUpDownRotZtabPlane_KeyUp);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 203);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Rot Z";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 152);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Rot Y";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 104);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Rot X";
            // 
            // numericUpDownRotxtabPlane
            // 
            this.numericUpDownRotxtabPlane.Location = new System.Drawing.Point(135, 97);
            this.numericUpDownRotxtabPlane.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.numericUpDownRotxtabPlane.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.numericUpDownRotxtabPlane.Name = "numericUpDownRotxtabPlane";
            this.numericUpDownRotxtabPlane.Size = new System.Drawing.Size(52, 20);
            this.numericUpDownRotxtabPlane.TabIndex = 6;
            this.numericUpDownRotxtabPlane.Click += new System.EventHandler(this.numericUpDownRotxtabPlane_Click);
            this.numericUpDownRotxtabPlane.ValueChanged += new System.EventHandler(this.numericUpDownRotxPlane_ValueChanged);
            this.numericUpDownRotxtabPlane.KeyUp += new System.Windows.Forms.KeyEventHandler(this.numericUpDownRotxtabPlane_KeyUp);
            // 
            // bnResettabPlane
            // 
            this.bnResettabPlane.Location = new System.Drawing.Point(117, 258);
            this.bnResettabPlane.Name = "bnResettabPlane";
            this.bnResettabPlane.Size = new System.Drawing.Size(54, 23);
            this.bnResettabPlane.TabIndex = 0;
            this.bnResettabPlane.Text = "Reset";
            this.bnResettabPlane.UseVisualStyleBackColor = true;
            this.bnResettabPlane.Click += new System.EventHandler(this.bnResettabPlane_Click);
            // 
            // bnCanceltabPlane
            // 
            this.bnCanceltabPlane.Location = new System.Drawing.Point(130, 301);
            this.bnCanceltabPlane.Name = "bnCanceltabPlane";
            this.bnCanceltabPlane.Size = new System.Drawing.Size(49, 23);
            this.bnCanceltabPlane.TabIndex = 2;
            this.bnCanceltabPlane.Text = "Cancel";
            this.bnCanceltabPlane.UseVisualStyleBackColor = true;
            this.bnCanceltabPlane.Click += new System.EventHandler(this.bnCanceltabPlane_Click);
            // 
            // bnDonetabPlane
            // 
            this.bnDonetabPlane.Location = new System.Drawing.Point(76, 301);
            this.bnDonetabPlane.Name = "bnDonetabPlane";
            this.bnDonetabPlane.Size = new System.Drawing.Size(46, 23);
            this.bnDonetabPlane.TabIndex = 1;
            this.bnDonetabPlane.Text = "Done";
            this.bnDonetabPlane.UseVisualStyleBackColor = true;
            this.bnDonetabPlane.Click += new System.EventHandler(this.bnDonetabPlane_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(19, 301);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(46, 23);
            this.button5.TabIndex = 0;
            this.button5.Text = "Apply";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // pnTrans
            // 
            this.pnTrans.CausesValidation = false;
            this.pnTrans.Controls.Add(this.bnApply_pnTrans);
            this.pnTrans.Controls.Add(this.rbCustomTrans);
            this.pnTrans.Controls.Add(this.rbBottomTrans);
            this.pnTrans.Controls.Add(this.rdTopTrans);
            this.pnTrans.Controls.Add(this.rdRightTrans);
            this.pnTrans.Controls.Add(this.rbLeftTrans);
            this.pnTrans.Controls.Add(this.numericUpDownTransZ_pnTrans);
            this.pnTrans.Controls.Add(this.trackBarTransZ_pnTrans);
            this.pnTrans.Controls.Add(this.lbTransZ_pnTrans);
            this.pnTrans.Controls.Add(this.numericUpDownTransY_pnTrans);
            this.pnTrans.Controls.Add(this.trackBarTransY_pnTrans);
            this.pnTrans.Controls.Add(this.lbTransY_pnTrans);
            this.pnTrans.Controls.Add(this.lbTransX_pnTrans);
            this.pnTrans.Controls.Add(this.bnCancelTrans);
            this.pnTrans.Controls.Add(this.bnResetTrans);
            this.pnTrans.Controls.Add(this.bnDoneTrans);
            this.pnTrans.Controls.Add(this.numericUpDownTransX_pnTrans);
            this.pnTrans.Controls.Add(this.trackBarTransX_pnTrans);
            this.pnTrans.Location = new System.Drawing.Point(86, 157);
            this.pnTrans.Name = "pnTrans";
            this.pnTrans.Size = new System.Drawing.Size(199, 415);
            this.pnTrans.TabIndex = 31;
            this.pnTrans.Visible = false;
            // 
            // bnApply_pnTrans
            // 
            this.bnApply_pnTrans.Location = new System.Drawing.Point(15, 325);
            this.bnApply_pnTrans.Name = "bnApply_pnTrans";
            this.bnApply_pnTrans.Size = new System.Drawing.Size(59, 23);
            this.bnApply_pnTrans.TabIndex = 22;
            this.bnApply_pnTrans.Text = "Apply";
            this.bnApply_pnTrans.UseVisualStyleBackColor = true;
            // 
            // rbCustomTrans
            // 
            this.rbCustomTrans.AutoSize = true;
            this.rbCustomTrans.Location = new System.Drawing.Point(39, 80);
            this.rbCustomTrans.Name = "rbCustomTrans";
            this.rbCustomTrans.Size = new System.Drawing.Size(107, 17);
            this.rbCustomTrans.TabIndex = 11;
            this.rbCustomTrans.TabStop = true;
            this.rbCustomTrans.Text = "Custom Translate";
            this.rbCustomTrans.UseVisualStyleBackColor = true;
            // 
            // rbBottomTrans
            // 
            this.rbBottomTrans.AutoSize = true;
            this.rbBottomTrans.Location = new System.Drawing.Point(93, 42);
            this.rbBottomTrans.Name = "rbBottomTrans";
            this.rbBottomTrans.Size = new System.Drawing.Size(73, 17);
            this.rbBottomTrans.TabIndex = 21;
            this.rbBottomTrans.TabStop = true;
            this.rbBottomTrans.Text = "Bottom 50";
            this.rbBottomTrans.UseVisualStyleBackColor = true;
            this.rbBottomTrans.CheckedChanged += new System.EventHandler(this.rbBottomTrans_CheckedChanged);
            // 
            // rdTopTrans
            // 
            this.rdTopTrans.AutoSize = true;
            this.rdTopTrans.Location = new System.Drawing.Point(26, 43);
            this.rdTopTrans.Name = "rdTopTrans";
            this.rdTopTrans.Size = new System.Drawing.Size(59, 17);
            this.rdTopTrans.TabIndex = 20;
            this.rdTopTrans.TabStop = true;
            this.rdTopTrans.Text = "Top 50";
            this.rdTopTrans.UseVisualStyleBackColor = true;
            this.rdTopTrans.CheckedChanged += new System.EventHandler(this.rdTopTrans_CheckedChanged);
            // 
            // rdRightTrans
            // 
            this.rdRightTrans.AutoSize = true;
            this.rdRightTrans.Location = new System.Drawing.Point(93, 19);
            this.rdRightTrans.Name = "rdRightTrans";
            this.rdRightTrans.Size = new System.Drawing.Size(65, 17);
            this.rdRightTrans.TabIndex = 19;
            this.rdRightTrans.TabStop = true;
            this.rdRightTrans.Text = "Right 50";
            this.rdRightTrans.UseVisualStyleBackColor = true;
            this.rdRightTrans.CheckedChanged += new System.EventHandler(this.rdRightTrans_CheckedChanged);
            // 
            // rbLeftTrans
            // 
            this.rbLeftTrans.AutoSize = true;
            this.rbLeftTrans.Location = new System.Drawing.Point(26, 19);
            this.rbLeftTrans.Name = "rbLeftTrans";
            this.rbLeftTrans.Size = new System.Drawing.Size(58, 17);
            this.rbLeftTrans.TabIndex = 11;
            this.rbLeftTrans.TabStop = true;
            this.rbLeftTrans.Text = "Left 50";
            this.rbLeftTrans.UseVisualStyleBackColor = true;
            this.rbLeftTrans.CheckedChanged += new System.EventHandler(this.rbLeftTrans_CheckedChanged);
            // 
            // numericUpDownTransZ_pnTrans
            // 
            this.numericUpDownTransZ_pnTrans.Location = new System.Drawing.Point(151, 198);
            this.numericUpDownTransZ_pnTrans.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDownTransZ_pnTrans.Name = "numericUpDownTransZ_pnTrans";
            this.numericUpDownTransZ_pnTrans.Size = new System.Drawing.Size(48, 20);
            this.numericUpDownTransZ_pnTrans.TabIndex = 18;
            this.numericUpDownTransZ_pnTrans.Click += new System.EventHandler(this.numericUpDownTransZ_pnTrans_Click);
            this.numericUpDownTransZ_pnTrans.ValueChanged += new System.EventHandler(this.numericUpDownTransZ_pnTrans_ValueChanged);
            this.numericUpDownTransZ_pnTrans.KeyUp += new System.Windows.Forms.KeyEventHandler(this.numericUpDownTransZ_pnTrans_KeyUp);
            // 
            // trackBarTransZ_pnTrans
            // 
            this.trackBarTransZ_pnTrans.Cursor = System.Windows.Forms.Cursors.Hand;
            this.trackBarTransZ_pnTrans.Location = new System.Drawing.Point(50, 192);
            this.trackBarTransZ_pnTrans.Maximum = 100;
            this.trackBarTransZ_pnTrans.Minimum = -100;
            this.trackBarTransZ_pnTrans.Name = "trackBarTransZ_pnTrans";
            this.trackBarTransZ_pnTrans.Size = new System.Drawing.Size(96, 45);
            this.trackBarTransZ_pnTrans.TabIndex = 17;
            this.trackBarTransZ_pnTrans.ValueChanged += new System.EventHandler(this.trackBarTransZ_pnTrans_ValueChanged);
            this.trackBarTransZ_pnTrans.Scroll += new System.EventHandler(this.trackBarTransZ_pnTrans_Scroll);
            // 
            // lbTransZ_pnTrans
            // 
            this.lbTransZ_pnTrans.AutoSize = true;
            this.lbTransZ_pnTrans.Location = new System.Drawing.Point(4, 200);
            this.lbTransZ_pnTrans.Name = "lbTransZ_pnTrans";
            this.lbTransZ_pnTrans.Size = new System.Drawing.Size(44, 13);
            this.lbTransZ_pnTrans.TabIndex = 16;
            this.lbTransZ_pnTrans.Text = "Trans Z";
            // 
            // numericUpDownTransY_pnTrans
            // 
            this.numericUpDownTransY_pnTrans.Location = new System.Drawing.Point(151, 158);
            this.numericUpDownTransY_pnTrans.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDownTransY_pnTrans.Name = "numericUpDownTransY_pnTrans";
            this.numericUpDownTransY_pnTrans.Size = new System.Drawing.Size(48, 20);
            this.numericUpDownTransY_pnTrans.TabIndex = 15;
            this.numericUpDownTransY_pnTrans.Click += new System.EventHandler(this.numericUpDownTransY_pnTrans_Click);
            this.numericUpDownTransY_pnTrans.ValueChanged += new System.EventHandler(this.numericUpDownTransY_pnTrans_ValueChanged);
            this.numericUpDownTransY_pnTrans.KeyUp += new System.Windows.Forms.KeyEventHandler(this.numericUpDownTransY_pnTrans_KeyUp);
            // 
            // trackBarTransY_pnTrans
            // 
            this.trackBarTransY_pnTrans.Cursor = System.Windows.Forms.Cursors.Hand;
            this.trackBarTransY_pnTrans.Location = new System.Drawing.Point(50, 150);
            this.trackBarTransY_pnTrans.Maximum = 100;
            this.trackBarTransY_pnTrans.Minimum = -100;
            this.trackBarTransY_pnTrans.Name = "trackBarTransY_pnTrans";
            this.trackBarTransY_pnTrans.Size = new System.Drawing.Size(96, 45);
            this.trackBarTransY_pnTrans.TabIndex = 14;
            this.trackBarTransY_pnTrans.ValueChanged += new System.EventHandler(this.trackBarTransY_pnTrans_ValueChanged);
            this.trackBarTransY_pnTrans.Scroll += new System.EventHandler(this.trackBarTransY_pnTrans_Scroll);
            // 
            // lbTransY_pnTrans
            // 
            this.lbTransY_pnTrans.AutoSize = true;
            this.lbTransY_pnTrans.Location = new System.Drawing.Point(4, 158);
            this.lbTransY_pnTrans.Name = "lbTransY_pnTrans";
            this.lbTransY_pnTrans.Size = new System.Drawing.Size(44, 13);
            this.lbTransY_pnTrans.TabIndex = 13;
            this.lbTransY_pnTrans.Text = "Trans Y";
            // 
            // lbTransX_pnTrans
            // 
            this.lbTransX_pnTrans.AutoSize = true;
            this.lbTransX_pnTrans.Location = new System.Drawing.Point(1, 118);
            this.lbTransX_pnTrans.Name = "lbTransX_pnTrans";
            this.lbTransX_pnTrans.Size = new System.Drawing.Size(44, 13);
            this.lbTransX_pnTrans.TabIndex = 11;
            this.lbTransX_pnTrans.Text = "Trans X";
            // 
            // bnCancelTrans
            // 
            this.bnCancelTrans.Location = new System.Drawing.Point(141, 325);
            this.bnCancelTrans.Name = "bnCancelTrans";
            this.bnCancelTrans.Size = new System.Drawing.Size(53, 23);
            this.bnCancelTrans.TabIndex = 12;
            this.bnCancelTrans.Text = "Cancel";
            this.bnCancelTrans.UseVisualStyleBackColor = true;
            this.bnCancelTrans.Click += new System.EventHandler(this.bnCancelTrans_Click);
            // 
            // bnResetTrans
            // 
            this.bnResetTrans.Location = new System.Drawing.Point(102, 282);
            this.bnResetTrans.Name = "bnResetTrans";
            this.bnResetTrans.Size = new System.Drawing.Size(56, 23);
            this.bnResetTrans.TabIndex = 11;
            this.bnResetTrans.Text = "Reset";
            this.bnResetTrans.UseVisualStyleBackColor = true;
            this.bnResetTrans.Click += new System.EventHandler(this.bnResetTrans_Click);
            // 
            // bnDoneTrans
            // 
            this.bnDoneTrans.Location = new System.Drawing.Point(80, 325);
            this.bnDoneTrans.Name = "bnDoneTrans";
            this.bnDoneTrans.Size = new System.Drawing.Size(55, 23);
            this.bnDoneTrans.TabIndex = 11;
            this.bnDoneTrans.Text = "Done";
            this.bnDoneTrans.UseVisualStyleBackColor = true;
            this.bnDoneTrans.Click += new System.EventHandler(this.bnDoneTrans_Click);
            // 
            // numericUpDownTransX_pnTrans
            // 
            this.numericUpDownTransX_pnTrans.Location = new System.Drawing.Point(151, 116);
            this.numericUpDownTransX_pnTrans.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDownTransX_pnTrans.Name = "numericUpDownTransX_pnTrans";
            this.numericUpDownTransX_pnTrans.Size = new System.Drawing.Size(48, 20);
            this.numericUpDownTransX_pnTrans.TabIndex = 11;
            this.numericUpDownTransX_pnTrans.Click += new System.EventHandler(this.numericUpDownTransX_pnTrans_Click);
            this.numericUpDownTransX_pnTrans.ValueChanged += new System.EventHandler(this.numericUpDownTransX_pnTrans_ValueChanged);
            this.numericUpDownTransX_pnTrans.KeyUp += new System.Windows.Forms.KeyEventHandler(this.numericUpDownTransX_pnTrans_KeyUp);
            // 
            // trackBarTransX_pnTrans
            // 
            this.trackBarTransX_pnTrans.Cursor = System.Windows.Forms.Cursors.Hand;
            this.trackBarTransX_pnTrans.Location = new System.Drawing.Point(50, 111);
            this.trackBarTransX_pnTrans.Maximum = 100;
            this.trackBarTransX_pnTrans.Minimum = -100;
            this.trackBarTransX_pnTrans.Name = "trackBarTransX_pnTrans";
            this.trackBarTransX_pnTrans.Size = new System.Drawing.Size(96, 45);
            this.trackBarTransX_pnTrans.TabIndex = 12;
            this.trackBarTransX_pnTrans.ValueChanged += new System.EventHandler(this.trackBarTransX_pnTrans_ValueChanged);
            this.trackBarTransX_pnTrans.Scroll += new System.EventHandler(this.trackBarTransX_pnTrans_Scroll);
            // 
            // pnSca
            // 
            this.pnSca.Controls.Add(this.rbStretch_pnScale);
            this.pnSca.Controls.Add(this.bnApplypnTranslate);
            this.pnSca.Controls.Add(this.bnZoomOutSca);
            this.pnSca.Controls.Add(this.bnZoomInSca);
            this.pnSca.Controls.Add(this.rbShrink_pnScale);
            this.pnSca.Controls.Add(this.numericUpDownScaZ_pnScale);
            this.pnSca.Controls.Add(this.trackBarScaZ_pnScale);
            this.pnSca.Controls.Add(this.lbScaZ_pnTranslate);
            this.pnSca.Controls.Add(this.numericUpDownScaY_pnScale);
            this.pnSca.Controls.Add(this.trackBarScaY_pnScale);
            this.pnSca.Controls.Add(this.lbScaY_pnTranslate);
            this.pnSca.Controls.Add(this.lbScaX_pnScale);
            this.pnSca.Controls.Add(this.bnCancelpnTranslate);
            this.pnSca.Controls.Add(this.button10);
            this.pnSca.Controls.Add(this.bnDonepnTranslate);
            this.pnSca.Controls.Add(this.numericUpDownScaX_pnScale);
            this.pnSca.Controls.Add(this.trackBarScaX_pnScale);
            this.pnSca.Location = new System.Drawing.Point(328, 30);
            this.pnSca.Name = "pnSca";
            this.pnSca.Size = new System.Drawing.Size(198, 422);
            this.pnSca.TabIndex = 32;
            this.pnSca.Visible = false;
            // 
            // rbStretch_pnScale
            // 
            this.rbStretch_pnScale.AutoSize = true;
            this.rbStretch_pnScale.Location = new System.Drawing.Point(113, 86);
            this.rbStretch_pnScale.Name = "rbStretch_pnScale";
            this.rbStretch_pnScale.Size = new System.Drawing.Size(59, 17);
            this.rbStretch_pnScale.TabIndex = 23;
            this.rbStretch_pnScale.Text = "Stretch";
            this.rbStretch_pnScale.UseVisualStyleBackColor = true;
            // 
            // bnApplypnTranslate
            // 
            this.bnApplypnTranslate.Location = new System.Drawing.Point(25, 326);
            this.bnApplypnTranslate.Name = "bnApplypnTranslate";
            this.bnApplypnTranslate.Size = new System.Drawing.Size(48, 23);
            this.bnApplypnTranslate.TabIndex = 22;
            this.bnApplypnTranslate.Text = "Apply";
            this.bnApplypnTranslate.UseVisualStyleBackColor = true;
            // 
            // bnZoomOutSca
            // 
            this.bnZoomOutSca.Location = new System.Drawing.Point(25, 47);
            this.bnZoomOutSca.Name = "bnZoomOutSca";
            this.bnZoomOutSca.Size = new System.Drawing.Size(62, 23);
            this.bnZoomOutSca.TabIndex = 20;
            this.bnZoomOutSca.Text = "Zoom out";
            this.bnZoomOutSca.UseVisualStyleBackColor = true;
            this.bnZoomOutSca.Click += new System.EventHandler(this.bnZoomOutSca_Click);
            // 
            // bnZoomInSca
            // 
            this.bnZoomInSca.Location = new System.Drawing.Point(25, 21);
            this.bnZoomInSca.Name = "bnZoomInSca";
            this.bnZoomInSca.Size = new System.Drawing.Size(62, 23);
            this.bnZoomInSca.TabIndex = 19;
            this.bnZoomInSca.Text = "Zoom in";
            this.bnZoomInSca.UseVisualStyleBackColor = true;
            this.bnZoomInSca.Click += new System.EventHandler(this.bnZoomInSca_Click);
            // 
            // rbShrink_pnScale
            // 
            this.rbShrink_pnScale.AutoSize = true;
            this.rbShrink_pnScale.Checked = true;
            this.rbShrink_pnScale.Location = new System.Drawing.Point(38, 86);
            this.rbShrink_pnScale.Name = "rbShrink_pnScale";
            this.rbShrink_pnScale.Size = new System.Drawing.Size(55, 17);
            this.rbShrink_pnScale.TabIndex = 11;
            this.rbShrink_pnScale.TabStop = true;
            this.rbShrink_pnScale.Text = "Shrink";
            this.rbShrink_pnScale.UseVisualStyleBackColor = true;
            // 
            // numericUpDownScaZ_pnScale
            // 
            this.numericUpDownScaZ_pnScale.Location = new System.Drawing.Point(164, 220);
            this.numericUpDownScaZ_pnScale.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownScaZ_pnScale.Name = "numericUpDownScaZ_pnScale";
            this.numericUpDownScaZ_pnScale.Size = new System.Drawing.Size(40, 20);
            this.numericUpDownScaZ_pnScale.TabIndex = 18;
            this.numericUpDownScaZ_pnScale.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownScaZ_pnScale.ValueChanged += new System.EventHandler(this.numericUpDownScaZ_pnScale_ValueChanged);
            this.numericUpDownScaZ_pnScale.KeyUp += new System.Windows.Forms.KeyEventHandler(this.numericUpDownScaZ_pnScale_KeyUp);
            // 
            // trackBarScaZ_pnScale
            // 
            this.trackBarScaZ_pnScale.Cursor = System.Windows.Forms.Cursors.Hand;
            this.trackBarScaZ_pnScale.Location = new System.Drawing.Point(52, 218);
            this.trackBarScaZ_pnScale.Maximum = 100;
            this.trackBarScaZ_pnScale.Minimum = 1;
            this.trackBarScaZ_pnScale.Name = "trackBarScaZ_pnScale";
            this.trackBarScaZ_pnScale.Size = new System.Drawing.Size(104, 45);
            this.trackBarScaZ_pnScale.TabIndex = 17;
            this.trackBarScaZ_pnScale.Value = 1;
            this.trackBarScaZ_pnScale.ValueChanged += new System.EventHandler(this.trackBarScaZ_pnScale_ValueChanged);
            // 
            // lbScaZ_pnTranslate
            // 
            this.lbScaZ_pnTranslate.AutoSize = true;
            this.lbScaZ_pnTranslate.Location = new System.Drawing.Point(3, 224);
            this.lbScaZ_pnTranslate.Name = "lbScaZ_pnTranslate";
            this.lbScaZ_pnTranslate.Size = new System.Drawing.Size(36, 13);
            this.lbScaZ_pnTranslate.TabIndex = 16;
            this.lbScaZ_pnTranslate.Text = "Sca Z";
            // 
            // numericUpDownScaY_pnScale
            // 
            this.numericUpDownScaY_pnScale.Location = new System.Drawing.Point(164, 170);
            this.numericUpDownScaY_pnScale.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownScaY_pnScale.Name = "numericUpDownScaY_pnScale";
            this.numericUpDownScaY_pnScale.Size = new System.Drawing.Size(40, 20);
            this.numericUpDownScaY_pnScale.TabIndex = 15;
            this.numericUpDownScaY_pnScale.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownScaY_pnScale.ValueChanged += new System.EventHandler(this.numericUpDownScaY_pnScale_ValueChanged);
            this.numericUpDownScaY_pnScale.KeyUp += new System.Windows.Forms.KeyEventHandler(this.numericUpDownScaY_pnScale_KeyUp);
            // 
            // trackBarScaY_pnScale
            // 
            this.trackBarScaY_pnScale.Cursor = System.Windows.Forms.Cursors.Hand;
            this.trackBarScaY_pnScale.Location = new System.Drawing.Point(52, 167);
            this.trackBarScaY_pnScale.Maximum = 100;
            this.trackBarScaY_pnScale.Minimum = 1;
            this.trackBarScaY_pnScale.Name = "trackBarScaY_pnScale";
            this.trackBarScaY_pnScale.Size = new System.Drawing.Size(104, 45);
            this.trackBarScaY_pnScale.TabIndex = 14;
            this.trackBarScaY_pnScale.Value = 1;
            this.trackBarScaY_pnScale.ValueChanged += new System.EventHandler(this.trackBarScaY_pnScale_ValueChanged);
            // 
            // lbScaY_pnTranslate
            // 
            this.lbScaY_pnTranslate.AutoSize = true;
            this.lbScaY_pnTranslate.Location = new System.Drawing.Point(3, 174);
            this.lbScaY_pnTranslate.Name = "lbScaY_pnTranslate";
            this.lbScaY_pnTranslate.Size = new System.Drawing.Size(36, 13);
            this.lbScaY_pnTranslate.TabIndex = 13;
            this.lbScaY_pnTranslate.Text = "Sca Y";
            // 
            // lbScaX_pnScale
            // 
            this.lbScaX_pnScale.AutoSize = true;
            this.lbScaX_pnScale.Location = new System.Drawing.Point(2, 120);
            this.lbScaX_pnScale.Name = "lbScaX_pnScale";
            this.lbScaX_pnScale.Size = new System.Drawing.Size(36, 13);
            this.lbScaX_pnScale.TabIndex = 11;
            this.lbScaX_pnScale.Text = "Sca X";
            // 
            // bnCancelpnTranslate
            // 
            this.bnCancelpnTranslate.Location = new System.Drawing.Point(133, 326);
            this.bnCancelpnTranslate.Name = "bnCancelpnTranslate";
            this.bnCancelpnTranslate.Size = new System.Drawing.Size(49, 23);
            this.bnCancelpnTranslate.TabIndex = 12;
            this.bnCancelpnTranslate.Text = "Cancel";
            this.bnCancelpnTranslate.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(104, 281);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(61, 23);
            this.button10.TabIndex = 11;
            this.button10.Text = "Reset";
            this.button10.UseVisualStyleBackColor = true;
            // 
            // bnDonepnTranslate
            // 
            this.bnDonepnTranslate.Location = new System.Drawing.Point(79, 326);
            this.bnDonepnTranslate.Name = "bnDonepnTranslate";
            this.bnDonepnTranslate.Size = new System.Drawing.Size(48, 23);
            this.bnDonepnTranslate.TabIndex = 11;
            this.bnDonepnTranslate.Text = "Done";
            this.bnDonepnTranslate.UseVisualStyleBackColor = true;
            // 
            // numericUpDownScaX_pnScale
            // 
            this.numericUpDownScaX_pnScale.Location = new System.Drawing.Point(164, 115);
            this.numericUpDownScaX_pnScale.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownScaX_pnScale.Name = "numericUpDownScaX_pnScale";
            this.numericUpDownScaX_pnScale.Size = new System.Drawing.Size(40, 20);
            this.numericUpDownScaX_pnScale.TabIndex = 11;
            this.numericUpDownScaX_pnScale.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownScaX_pnScale.ValueChanged += new System.EventHandler(this.numericUpDownScaX_pnScale_ValueChanged);
            this.numericUpDownScaX_pnScale.KeyUp += new System.Windows.Forms.KeyEventHandler(this.numericUpDownScaX_pnScale_KeyUp);
            // 
            // trackBarScaX_pnScale
            // 
            this.trackBarScaX_pnScale.Cursor = System.Windows.Forms.Cursors.Hand;
            this.trackBarScaX_pnScale.Location = new System.Drawing.Point(52, 115);
            this.trackBarScaX_pnScale.Maximum = 100;
            this.trackBarScaX_pnScale.Minimum = 1;
            this.trackBarScaX_pnScale.Name = "trackBarScaX_pnScale";
            this.trackBarScaX_pnScale.Size = new System.Drawing.Size(104, 45);
            this.trackBarScaX_pnScale.TabIndex = 12;
            this.trackBarScaX_pnScale.Value = 1;
            this.trackBarScaX_pnScale.ValueChanged += new System.EventHandler(this.trackBarScaX_pnScale_ValueChanged);
            this.trackBarScaX_pnScale.Scroll += new System.EventHandler(this.trackBarScaX_pnScale_Scroll);
            // 
            // pnLighting
            // 
            this.pnLighting.Controls.Add(this.cbShowLight_pnLighting);
            this.pnLighting.Controls.Add(this.lbColor_pnLighting);
            this.pnLighting.Controls.Add(this.lbBlue_pnLighting);
            this.pnLighting.Controls.Add(this.lbGreen_pnLighting);
            this.pnLighting.Controls.Add(this.lbRed_pnLighting);
            this.pnLighting.Controls.Add(this.numericUpDown3);
            this.pnLighting.Controls.Add(this.numericUpDown2);
            this.pnLighting.Controls.Add(this.numericUpDown1);
            this.pnLighting.Controls.Add(this.button7);
            this.pnLighting.Controls.Add(this.button6);
            this.pnLighting.Controls.Add(this.button2);
            this.pnLighting.Controls.Add(this.gbLightSourceLocationLitg);
            this.pnLighting.Location = new System.Drawing.Point(544, 62);
            this.pnLighting.Name = "pnLighting";
            this.pnLighting.Size = new System.Drawing.Size(200, 410);
            this.pnLighting.TabIndex = 33;
            this.pnLighting.Visible = false;
            this.pnLighting.Paint += new System.Windows.Forms.PaintEventHandler(this.pnLighting_Paint);
            // 
            // lbColor_pnLighting
            // 
            this.lbColor_pnLighting.AutoSize = true;
            this.lbColor_pnLighting.Location = new System.Drawing.Point(17, 124);
            this.lbColor_pnLighting.Name = "lbColor_pnLighting";
            this.lbColor_pnLighting.Size = new System.Drawing.Size(31, 13);
            this.lbColor_pnLighting.TabIndex = 34;
            this.lbColor_pnLighting.Text = "Color";
            // 
            // lbBlue_pnLighting
            // 
            this.lbBlue_pnLighting.AutoSize = true;
            this.lbBlue_pnLighting.Location = new System.Drawing.Point(130, 157);
            this.lbBlue_pnLighting.Name = "lbBlue_pnLighting";
            this.lbBlue_pnLighting.Size = new System.Drawing.Size(14, 13);
            this.lbBlue_pnLighting.TabIndex = 27;
            this.lbBlue_pnLighting.Text = "B";
            // 
            // lbGreen_pnLighting
            // 
            this.lbGreen_pnLighting.AutoSize = true;
            this.lbGreen_pnLighting.Location = new System.Drawing.Point(71, 156);
            this.lbGreen_pnLighting.Name = "lbGreen_pnLighting";
            this.lbGreen_pnLighting.Size = new System.Drawing.Size(15, 13);
            this.lbGreen_pnLighting.TabIndex = 26;
            this.lbGreen_pnLighting.Text = "G";
            // 
            // lbRed_pnLighting
            // 
            this.lbRed_pnLighting.AutoSize = true;
            this.lbRed_pnLighting.Location = new System.Drawing.Point(10, 155);
            this.lbRed_pnLighting.Name = "lbRed_pnLighting";
            this.lbRed_pnLighting.Size = new System.Drawing.Size(15, 13);
            this.lbRed_pnLighting.TabIndex = 20;
            this.lbRed_pnLighting.Text = "R";
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Location = new System.Drawing.Point(147, 155);
            this.numericUpDown3.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(40, 20);
            this.numericUpDown3.TabIndex = 25;
            this.numericUpDown3.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDown3.ValueChanged += new System.EventHandler(this.numericUpDown3_ValueChanged);
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(85, 153);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(40, 20);
            this.numericUpDown2.TabIndex = 24;
            this.numericUpDown2.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDown2.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(27, 153);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(40, 20);
            this.numericUpDown1.TabIndex = 20;
            this.numericUpDown1.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDown1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.numericUpDown1_KeyUp_1);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(117, 283);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(46, 23);
            this.button7.TabIndex = 23;
            this.button7.Text = "Reset";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(127, 349);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(51, 23);
            this.button6.TabIndex = 22;
            this.button6.Text = "Cancel";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(65, 349);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(46, 23);
            this.button2.TabIndex = 21;
            this.button2.Text = "Done";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // gbLightSourceLocationLitg
            // 
            this.gbLightSourceLocationLitg.Controls.Add(this.lbZLitg);
            this.gbLightSourceLocationLitg.Controls.Add(this.lbYLitg);
            this.gbLightSourceLocationLitg.Controls.Add(this.lbXLitg);
            this.gbLightSourceLocationLitg.Controls.Add(this.numericUpDown7);
            this.gbLightSourceLocationLitg.Controls.Add(this.numericUpDown6);
            this.gbLightSourceLocationLitg.Controls.Add(this.numericUpDown5);
            this.gbLightSourceLocationLitg.Controls.Add(this.radioButton2);
            this.gbLightSourceLocationLitg.Controls.Add(this.radioButton1);
            this.gbLightSourceLocationLitg.Location = new System.Drawing.Point(0, 3);
            this.gbLightSourceLocationLitg.Name = "gbLightSourceLocationLitg";
            this.gbLightSourceLocationLitg.Size = new System.Drawing.Size(197, 109);
            this.gbLightSourceLocationLitg.TabIndex = 15;
            this.gbLightSourceLocationLitg.TabStop = false;
            this.gbLightSourceLocationLitg.Text = "Light Source Location";
            // 
            // lbZLitg
            // 
            this.lbZLitg.AutoSize = true;
            this.lbZLitg.Location = new System.Drawing.Point(137, 70);
            this.lbZLitg.Name = "lbZLitg";
            this.lbZLitg.Size = new System.Drawing.Size(14, 13);
            this.lbZLitg.TabIndex = 19;
            this.lbZLitg.Text = "Z";
            // 
            // lbYLitg
            // 
            this.lbYLitg.AutoSize = true;
            this.lbYLitg.Location = new System.Drawing.Point(75, 69);
            this.lbYLitg.Name = "lbYLitg";
            this.lbYLitg.Size = new System.Drawing.Size(14, 13);
            this.lbYLitg.TabIndex = 18;
            this.lbYLitg.Text = "Y";
            // 
            // lbXLitg
            // 
            this.lbXLitg.AutoSize = true;
            this.lbXLitg.Location = new System.Drawing.Point(11, 69);
            this.lbXLitg.Name = "lbXLitg";
            this.lbXLitg.Size = new System.Drawing.Size(14, 13);
            this.lbXLitg.TabIndex = 17;
            this.lbXLitg.Text = "X";
            // 
            // numericUpDown7
            // 
            this.numericUpDown7.Location = new System.Drawing.Point(153, 67);
            this.numericUpDown7.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDown7.Name = "numericUpDown7";
            this.numericUpDown7.Size = new System.Drawing.Size(40, 20);
            this.numericUpDown7.TabIndex = 16;
            this.numericUpDown7.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown7.ValueChanged += new System.EventHandler(this.numericUpDown7_ValueChanged);
            // 
            // numericUpDown6
            // 
            this.numericUpDown6.Location = new System.Drawing.Point(89, 67);
            this.numericUpDown6.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDown6.Name = "numericUpDown6";
            this.numericUpDown6.Size = new System.Drawing.Size(40, 20);
            this.numericUpDown6.TabIndex = 15;
            this.numericUpDown6.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDown6.ValueChanged += new System.EventHandler(this.numericUpDown6_ValueChanged);
            // 
            // numericUpDown5
            // 
            this.numericUpDown5.Location = new System.Drawing.Point(27, 67);
            this.numericUpDown5.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDown5.Name = "numericUpDown5";
            this.numericUpDown5.Size = new System.Drawing.Size(40, 20);
            this.numericUpDown5.TabIndex = 14;
            this.numericUpDown5.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDown5.ValueChanged += new System.EventHandler(this.numericUpDown5_ValueChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(14, 42);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(60, 17);
            this.radioButton2.TabIndex = 13;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Custom";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(12, 19);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(59, 17);
            this.radioButton1.TabIndex = 12;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Default";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // cbShowLight_pnLighting
            // 
            this.cbShowLight_pnLighting.AutoSize = true;
            this.cbShowLight_pnLighting.Location = new System.Drawing.Point(49, 216);
            this.cbShowLight_pnLighting.Name = "cbShowLight_pnLighting";
            this.cbShowLight_pnLighting.Size = new System.Drawing.Size(79, 17);
            this.cbShowLight_pnLighting.TabIndex = 34;
            this.cbShowLight_pnLighting.Text = "Show Light";
            this.cbShowLight_pnLighting.UseVisualStyleBackColor = true;
            this.cbShowLight_pnLighting.CheckedChanged += new System.EventHandler(this.cbShowLight_pnLighting_CheckedChanged);
            // 
            // gbRGBFog
            // 
            this.gbRGBFog.Controls.Add(this.cbFogEffect_gbRGB);
            this.gbRGBFog.Controls.Add(this.rbDefaultFog);
            this.gbRGBFog.Controls.Add(this.radioButton3);
            this.gbRGBFog.Controls.Add(this.trackBarRed_gpRGB);
            this.gbRGBFog.Controls.Add(this.trackBar3);
            this.gbRGBFog.Controls.Add(this.trackBar4);
            this.gbRGBFog.Location = new System.Drawing.Point(101, 46);
            this.gbRGBFog.Name = "gbRGBFog";
            this.gbRGBFog.Size = new System.Drawing.Size(200, 272);
            this.gbRGBFog.TabIndex = 34;
            this.gbRGBFog.TabStop = false;
            this.gbRGBFog.Text = "RGB";
            this.gbRGBFog.Visible = false;
            // 
            // rbDefaultFog
            // 
            this.rbDefaultFog.AutoSize = true;
            this.rbDefaultFog.Location = new System.Drawing.Point(39, 16);
            this.rbDefaultFog.Name = "rbDefaultFog";
            this.rbDefaultFog.Size = new System.Drawing.Size(59, 17);
            this.rbDefaultFog.TabIndex = 28;
            this.rbDefaultFog.TabStop = true;
            this.rbDefaultFog.Text = "Default";
            this.rbDefaultFog.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(39, 42);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(60, 17);
            this.radioButton3.TabIndex = 27;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Custom";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // trackBarRed_gpRGB
            // 
            this.trackBarRed_gpRGB.BackColor = System.Drawing.Color.Red;
            this.trackBarRed_gpRGB.Location = new System.Drawing.Point(23, 74);
            this.trackBarRed_gpRGB.Maximum = 100;
            this.trackBarRed_gpRGB.Minimum = -100;
            this.trackBarRed_gpRGB.Name = "trackBarRed_gpRGB";
            this.trackBarRed_gpRGB.Size = new System.Drawing.Size(104, 45);
            this.trackBarRed_gpRGB.TabIndex = 21;
            this.trackBarRed_gpRGB.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarRed_gpRGB.ValueChanged += new System.EventHandler(this.trackBarRed_gpRGB_ValueChanged);
            this.trackBarRed_gpRGB.Scroll += new System.EventHandler(this.trackBarRed_gpRGB_Scroll);
            // 
            // trackBar3
            // 
            this.trackBar3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.trackBar3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.trackBar3.Location = new System.Drawing.Point(23, 121);
            this.trackBar3.Maximum = 100;
            this.trackBar3.Minimum = -100;
            this.trackBar3.Name = "trackBar3";
            this.trackBar3.Size = new System.Drawing.Size(104, 45);
            this.trackBar3.TabIndex = 23;
            this.trackBar3.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar3.Scroll += new System.EventHandler(this.trackBar3_Scroll);
            // 
            // trackBar4
            // 
            this.trackBar4.BackColor = System.Drawing.Color.Blue;
            this.trackBar4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.trackBar4.Location = new System.Drawing.Point(23, 167);
            this.trackBar4.Maximum = 100;
            this.trackBar4.Minimum = -100;
            this.trackBar4.Name = "trackBar4";
            this.trackBar4.Size = new System.Drawing.Size(104, 45);
            this.trackBar4.TabIndex = 25;
            this.trackBar4.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar4.Scroll += new System.EventHandler(this.trackBar4_Scroll);
            // 
            // cbFogEffect_gbRGB
            // 
            this.cbFogEffect_gbRGB.AutoSize = true;
            this.cbFogEffect_gbRGB.Location = new System.Drawing.Point(65, 235);
            this.cbFogEffect_gbRGB.Name = "cbFogEffect_gbRGB";
            this.cbFogEffect_gbRGB.Size = new System.Drawing.Size(75, 17);
            this.cbFogEffect_gbRGB.TabIndex = 35;
            this.cbFogEffect_gbRGB.Text = "Fog Effect";
            this.cbFogEffect_gbRGB.UseVisualStyleBackColor = true;
            this.cbFogEffect_gbRGB.CheckedChanged += new System.EventHandler(this.cbFogEffect_gbRGB_CheckedChanged);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(40, 261);
            this.trackBar1.Maximum = 360;
            this.trackBar1.Minimum = -360;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(98, 45);
            this.trackBar1.TabIndex = 33;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // numericUpDown4
            // 
            this.numericUpDown4.Location = new System.Drawing.Point(140, 269);
            this.numericUpDown4.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.numericUpDown4.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.numericUpDown4.Name = "numericUpDown4";
            this.numericUpDown4.Size = new System.Drawing.Size(52, 20);
            this.numericUpDown4.TabIndex = 34;
            this.numericUpDown4.ValueChanged += new System.EventHandler(this.numericUpDown4_ValueChanged);
            this.numericUpDown4.KeyUp += new System.Windows.Forms.KeyEventHandler(this.numericUpDown4_KeyUp);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(26, 317);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(86, 17);
            this.checkBox1.TabIndex = 35;
            this.checkBox1.Text = "Show vector";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cbShowVector);
            this.panel2.Controls.Add(this.bnVector);
            this.panel2.Controls.Add(this.bnOz);
            this.panel2.Controls.Add(this.bnOy);
            this.panel2.Controls.Add(this.bnOx);
            this.panel2.Location = new System.Drawing.Point(325, 176);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(168, 166);
            this.panel2.TabIndex = 35;
            this.panel2.Visible = false;
            // 
            // bnOx
            // 
            this.bnOx.Location = new System.Drawing.Point(13, 14);
            this.bnOx.Name = "bnOx";
            this.bnOx.Size = new System.Drawing.Size(46, 23);
            this.bnOx.TabIndex = 0;
            this.bnOx.Text = "Ox";
            this.bnOx.UseVisualStyleBackColor = true;
            this.bnOx.Click += new System.EventHandler(this.bnOx_Click);
            // 
            // bnOy
            // 
            this.bnOy.Location = new System.Drawing.Point(13, 47);
            this.bnOy.Name = "bnOy";
            this.bnOy.Size = new System.Drawing.Size(46, 23);
            this.bnOy.TabIndex = 1;
            this.bnOy.Text = "Oy";
            this.bnOy.UseVisualStyleBackColor = true;
            this.bnOy.Click += new System.EventHandler(this.bnOy_Click);
            // 
            // bnOz
            // 
            this.bnOz.Location = new System.Drawing.Point(13, 77);
            this.bnOz.Name = "bnOz";
            this.bnOz.Size = new System.Drawing.Size(46, 23);
            this.bnOz.TabIndex = 2;
            this.bnOz.Text = "Oz";
            this.bnOz.UseVisualStyleBackColor = true;
            this.bnOz.Click += new System.EventHandler(this.bnOz_Click);
            // 
            // bnVector
            // 
            this.bnVector.Location = new System.Drawing.Point(13, 107);
            this.bnVector.Name = "bnVector";
            this.bnVector.Size = new System.Drawing.Size(46, 23);
            this.bnVector.TabIndex = 3;
            this.bnVector.Text = "Vector";
            this.bnVector.UseVisualStyleBackColor = true;
            this.bnVector.Click += new System.EventHandler(this.bnVector_Click);
            // 
            // cbShowVector
            // 
            this.cbShowVector.AutoSize = true;
            this.cbShowVector.Location = new System.Drawing.Point(62, 140);
            this.cbShowVector.Name = "cbShowVector";
            this.cbShowVector.Size = new System.Drawing.Size(86, 17);
            this.cbShowVector.TabIndex = 4;
            this.cbShowVector.Text = "Show vector";
            this.cbShowVector.UseVisualStyleBackColor = true;
            this.cbShowVector.CheckedChanged += new System.EventHandler(this.cbShowVector_CheckedChanged);
            // 
            // Axisymmetric
            // 
            this.Axisymmetric.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Axisymmetric.Image = ((System.Drawing.Image)(resources.GetObject("Axisymmetric.Image")));
            this.Axisymmetric.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Axisymmetric.Name = "Axisymmetric";
            this.Axisymmetric.Size = new System.Drawing.Size(90, 17);
            this.Axisymmetric.Text = "Axisymmetric";
            this.Axisymmetric.Click += new System.EventHandler(this.A_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 497);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.gbRGBFog);
            this.Controls.Add(this.pnLighting);
            this.Controls.Add(this.pnSca);
            this.Controls.Add(this.pnTrans);
            this.Controls.Add(this.tabControlRot);
            this.Controls.Add(this.pnRGB);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.simpleOpenGlControlPreViewcurrent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.pnRGB.ResumeLayout(false);
            this.gbChooseRGB.ResumeLayout(false);
            this.gbChooseRGB.PerformLayout();
            this.gbAdjustmentRGB.ResumeLayout(false);
            this.gbAdjustmentRGB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRedRGB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarGreenRGB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBlueRGB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGreenRGB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBlueRGB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRedRGB)).EndInit();
            this.pnRotate.ResumeLayout(false);
            this.pnRotate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRotZtabObject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRotYtabObject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRotXtabObject)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRotYtabObject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRotZtabObject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRotXtabObject)).EndInit();
            this.tabControlRot.ResumeLayout(false);
            this.tabPageObjectRot.ResumeLayout(false);
            this.tabPagePlaneRot.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRotZtabPlane)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRotYtabPlane)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRotXtabPlane)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRotYtabPlane)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRotZtabPlane)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRotxtabPlane)).EndInit();
            this.pnTrans.ResumeLayout(false);
            this.pnTrans.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTransZ_pnTrans)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTransZ_pnTrans)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTransY_pnTrans)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTransY_pnTrans)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTransX_pnTrans)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTransX_pnTrans)).EndInit();
            this.pnSca.ResumeLayout(false);
            this.pnSca.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownScaZ_pnScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarScaZ_pnScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownScaY_pnScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarScaY_pnScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownScaX_pnScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarScaX_pnScale)).EndInit();
            this.pnLighting.ResumeLayout(false);
            this.pnLighting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.gbLightSourceLocationLitg.ResumeLayout(false);
            this.gbLightSourceLocationLitg.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).EndInit();
            this.gbRGBFog.ResumeLayout(false);
            this.gbRGBFog.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRed_gpRGB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Tao.Platform.Windows.SimpleOpenGlControl simpleOpenGlControlPreViewcurrent;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButtonView;
        private System.Windows.Forms.ToolStripMenuItem toolStripOrtho;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printPreviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem contentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem indexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripPers;
        private System.Windows.Forms.ToolStripButton toolStripBnRot;
        private System.Windows.Forms.ToolStripButton toolStripBnTrans;
        private System.Windows.Forms.ToolStripButton toolStripBnSca;
        private System.Windows.Forms.ToolStripButton toolStripBnLitg;
        private System.Windows.Forms.ToolStripButton toolStripBnTex;
        private System.Windows.Forms.ToolStripButton toolStripBnFog;
        private System.Windows.Forms.RadioButton rbBlack;
        private System.Windows.Forms.Button bnCancelRGB;
        private System.Windows.Forms.Button bnResetRGB;
        private System.Windows.Forms.Button bnDoneRGB;
        private System.Windows.Forms.RadioButton rbWhite;
        private System.Windows.Forms.RadioButton rbCustomRGB;
        private System.Windows.Forms.TrackBar trackBarRedRGB;
        private System.Windows.Forms.TrackBar trackBarGreenRGB;
        private System.Windows.Forms.NumericUpDown numericUpDownBlueRGB;
        private System.Windows.Forms.NumericUpDown numericUpDownGreenRGB;
        private System.Windows.Forms.TrackBar trackBarBlueRGB;
        private System.Windows.Forms.GroupBox gbChooseRGB;
        private System.Windows.Forms.RadioButton rbObjectRGB;
        private System.Windows.Forms.RadioButton rdBackgroundRGB;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDpDnBnDraw;
        private System.Windows.Forms.ToolStripMenuItem toolStripSph;
        private System.Windows.Forms.ToolStripMenuItem toolStripCubic;
        private System.Windows.Forms.ToolStripMenuItem toolStripCyl;
        private System.Windows.Forms.ToolStripMenuItem toolStripCone;
        private System.Windows.Forms.ToolStripButton toolStripBnRGB;
        public System.Windows.Forms.GroupBox gbAdjustmentRGB;
        private System.Windows.Forms.Button bnUndoRGB;
        private System.Windows.Forms.Button bnRedoRGB;
        private System.Windows.Forms.NumericUpDown numericUpDownRedRGB;
        private System.Windows.Forms.Panel pnRGB;
        private System.Windows.Forms.Button bnApplyRGB;
        private System.Windows.Forms.Panel pnRotate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox comboBoxTopRot;
        private System.Windows.Forms.ComboBox comboBoxBottomRot;
        private System.Windows.Forms.ComboBox comboBoxRightRot;
        private System.Windows.Forms.ComboBox comboBoxLeftRot;
        private System.Windows.Forms.NumericUpDown numericUpDownRotYtabObject;
        private System.Windows.Forms.NumericUpDown numericUpDownRotZtabObject;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bnResetpnRottabObject;
        private System.Windows.Forms.Button bnCancelpnRottabObject;
        private System.Windows.Forms.Button bnDonepnRottabObject;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.NumericUpDown numericUpDownRotXtabObject;
        private System.Windows.Forms.TrackBar trackBarRotXtabObject;
        private System.Windows.Forms.TrackBar trackBarRotZtabObject;
        private System.Windows.Forms.TrackBar trackBarRotYtabObject;
        private System.Windows.Forms.TabControl tabControlRot;
        private System.Windows.Forms.TabPage tabPageObjectRot;
        private System.Windows.Forms.TabPage tabPagePlaneRot;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TrackBar trackBarRotZtabPlane;
        private System.Windows.Forms.TrackBar trackBarRotYtabPlane;
        private System.Windows.Forms.TrackBar trackBarRotXtabPlane;
        private System.Windows.Forms.NumericUpDown numericUpDownRotYtabPlane;
        private System.Windows.Forms.NumericUpDown numericUpDownRotZtabPlane;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.NumericUpDown numericUpDownRotxtabPlane;
        private System.Windows.Forms.Button bnResettabPlane;
        private System.Windows.Forms.Button bnCanceltabPlane;
        private System.Windows.Forms.Button bnDonetabPlane;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.RadioButton rbDefaulttabPlane;
        private System.Windows.Forms.RadioButton rbCustomtabPlane;
        private System.Windows.Forms.Label lbAnyAxistabObject;
        private System.Windows.Forms.Panel pnTrans;
        private System.Windows.Forms.RadioButton rbCustomTrans;
        private System.Windows.Forms.RadioButton rbBottomTrans;
        private System.Windows.Forms.RadioButton rdTopTrans;
        private System.Windows.Forms.RadioButton rdRightTrans;
        private System.Windows.Forms.RadioButton rbLeftTrans;
        private System.Windows.Forms.NumericUpDown numericUpDownTransZ_pnTrans;
        private System.Windows.Forms.TrackBar trackBarTransZ_pnTrans;
        private System.Windows.Forms.Label lbTransZ_pnTrans;
        private System.Windows.Forms.NumericUpDown numericUpDownTransY_pnTrans;
        private System.Windows.Forms.TrackBar trackBarTransY_pnTrans;
        private System.Windows.Forms.Label lbTransY_pnTrans;
        private System.Windows.Forms.Label lbTransX_pnTrans;
        private System.Windows.Forms.Button bnCancelTrans;
        private System.Windows.Forms.Button bnResetTrans;
        private System.Windows.Forms.Button bnDoneTrans;
        private System.Windows.Forms.NumericUpDown numericUpDownTransX_pnTrans;
        private System.Windows.Forms.TrackBar trackBarTransX_pnTrans;
        private System.Windows.Forms.Button bnApply_pnTrans;
        private System.Windows.Forms.Panel pnSca;
        private System.Windows.Forms.Button bnApplypnTranslate;
        private System.Windows.Forms.Button bnZoomOutSca;
        private System.Windows.Forms.Button bnZoomInSca;
        private System.Windows.Forms.RadioButton rbShrink_pnScale;
        private System.Windows.Forms.NumericUpDown numericUpDownScaZ_pnScale;
        private System.Windows.Forms.TrackBar trackBarScaZ_pnScale;
        private System.Windows.Forms.Label lbScaZ_pnTranslate;
        private System.Windows.Forms.NumericUpDown numericUpDownScaY_pnScale;
        private System.Windows.Forms.TrackBar trackBarScaY_pnScale;
        private System.Windows.Forms.Label lbScaY_pnTranslate;
        private System.Windows.Forms.Label lbScaX_pnScale;
        private System.Windows.Forms.Button bnCancelpnTranslate;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button bnDonepnTranslate;
        private System.Windows.Forms.NumericUpDown numericUpDownScaX_pnScale;
        private System.Windows.Forms.TrackBar trackBarScaX_pnScale;
        private System.Windows.Forms.RadioButton rbStretch_pnScale;
        private System.Windows.Forms.Panel pnLighting;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox gbLightSourceLocationLitg;
        private System.Windows.Forms.Label lbZLitg;
        private System.Windows.Forms.Label lbYLitg;
        private System.Windows.Forms.Label lbXLitg;
        private System.Windows.Forms.NumericUpDown numericUpDown7;
        private System.Windows.Forms.NumericUpDown numericUpDown6;
        private System.Windows.Forms.NumericUpDown numericUpDown5;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label lbColor_pnLighting;
        private System.Windows.Forms.Label lbBlue_pnLighting;
        private System.Windows.Forms.Label lbGreen_pnLighting;
        private System.Windows.Forms.Label lbRed_pnLighting;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.CheckBox cbShowLight_pnLighting;
        private System.Windows.Forms.GroupBox gbRGBFog;
        private System.Windows.Forms.RadioButton rbDefaultFog;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.TrackBar trackBarRed_gpRGB;
        private System.Windows.Forms.TrackBar trackBar3;
        private System.Windows.Forms.TrackBar trackBar4;
        private System.Windows.Forms.CheckBox cbFogEffect_gbRGB;
        private System.Windows.Forms.NumericUpDown numericUpDown4;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button bnVector;
        private System.Windows.Forms.Button bnOz;
        private System.Windows.Forms.Button bnOy;
        private System.Windows.Forms.Button bnOx;
        private System.Windows.Forms.ToolStripButton Axisymmetric;
        private System.Windows.Forms.CheckBox cbShowVector;

    }
}

