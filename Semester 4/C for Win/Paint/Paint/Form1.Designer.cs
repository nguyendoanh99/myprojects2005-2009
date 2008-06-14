namespace Paint
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tButLine = new System.Windows.Forms.ToolStripButton();
            this.tButCircle = new System.Windows.Forms.ToolStripButton();
            this.tButRectangle = new System.Windows.Forms.ToolStripButton();
            this.tButPolygon = new System.Windows.Forms.ToolStripButton();
            this.tcmbPenStyle = new System.Windows.Forms.ToolStripComboBox();
            this.tcmbWidth = new System.Windows.Forms.ToolStripComboBox();
            this.tlbl = new System.Windows.Forms.ToolStripLabel();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.CausesValidation = false;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(903, 390);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 439);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(903, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.AutoSize = false;
            this.toolStripStatusLabel1.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(100, 17);
            this.toolStripStatusLabel1.Text = "0 : 0";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(903, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(95, 22);
            this.newToolStripMenuItem.Text = "&New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(95, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tButLine,
            this.tButCircle,
            this.tButRectangle,
            this.tButPolygon,
            this.tcmbPenStyle,
            this.tcmbWidth,
            this.tlbl});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(903, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tButLine
            // 
            this.tButLine.Checked = true;
            this.tButLine.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tButLine.Image = ((System.Drawing.Image)(resources.GetObject("tButLine.Image")));
            this.tButLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tButLine.Name = "tButLine";
            this.tButLine.Size = new System.Drawing.Size(46, 22);
            this.tButLine.Text = "Line";
            this.tButLine.Click += new System.EventHandler(this.tButLine_Click);
            // 
            // tButCircle
            // 
            this.tButCircle.Image = ((System.Drawing.Image)(resources.GetObject("tButCircle.Image")));
            this.tButCircle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tButCircle.Name = "tButCircle";
            this.tButCircle.Size = new System.Drawing.Size(53, 22);
            this.tButCircle.Text = "Circle";
            this.tButCircle.Click += new System.EventHandler(this.tButCircle_Click);
            // 
            // tButRectangle
            // 
            this.tButRectangle.Image = ((System.Drawing.Image)(resources.GetObject("tButRectangle.Image")));
            this.tButRectangle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tButRectangle.Name = "tButRectangle";
            this.tButRectangle.Size = new System.Drawing.Size(75, 22);
            this.tButRectangle.Text = "Rectangle";
            this.tButRectangle.Click += new System.EventHandler(this.tButRectangle_Click);
            // 
            // tButPolygon
            // 
            this.tButPolygon.Image = ((System.Drawing.Image)(resources.GetObject("tButPolygon.Image")));
            this.tButPolygon.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tButPolygon.Name = "tButPolygon";
            this.tButPolygon.Size = new System.Drawing.Size(65, 22);
            this.tButPolygon.Text = "Polygon";
            this.tButPolygon.Click += new System.EventHandler(this.tButPolygon_Click);
            // 
            // tcmbPenStyle
            // 
            this.tcmbPenStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tcmbPenStyle.Items.AddRange(new object[] {
            "PS_SOLID",
            "PS_DASH",
            "PS_DOT",
            "PS_DASHDOT",
            "PS_DASHDOTDOT"});
            this.tcmbPenStyle.Name = "tcmbPenStyle";
            this.tcmbPenStyle.Size = new System.Drawing.Size(121, 25);
            this.tcmbPenStyle.SelectedIndexChanged += new System.EventHandler(this.tcmbPenStyle_SelectedIndexChanged);
            // 
            // tcmbWidth
            // 
            this.tcmbWidth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tcmbWidth.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.tcmbWidth.Name = "tcmbWidth";
            this.tcmbWidth.Size = new System.Drawing.Size(121, 25);
            this.tcmbWidth.SelectedIndexChanged += new System.EventHandler(this.tcmbWidth_SelectedIndexChanged);
            // 
            // tlbl
            // 
            this.tlbl.Name = "tlbl";
            this.tlbl.Size = new System.Drawing.Size(169, 22);
            this.tlbl.Text = "Press Alt+O to open OptionDialog";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(903, 461);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Paint";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tButLine;
        private System.Windows.Forms.ToolStripButton tButCircle;
        private System.Windows.Forms.ToolStripButton tButRectangle;
        private System.Windows.Forms.ToolStripButton tButPolygon;
        private System.Windows.Forms.ToolStripComboBox tcmbPenStyle;
        private System.Windows.Forms.ToolStripComboBox tcmbWidth;
        private System.Windows.Forms.ToolStripLabel tlbl;

    }
}

