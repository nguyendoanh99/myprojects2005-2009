namespace SimplePainBrush
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
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.tbBLine = new System.Windows.Forms.ToolBarButton();
            this.tbBEllipse = new System.Windows.Forms.ToolBarButton();
            this.imageList1 = new System.Windows.Forms.ImageList();
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.mnuColor = new System.Windows.Forms.MenuItem();
            this.mnuFill = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // toolBar1
            // 
            this.toolBar1.Buttons.Add(this.tbBLine);
            this.toolBar1.Buttons.Add(this.tbBEllipse);
            this.toolBar1.ImageList = this.imageList1;
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
            // 
            // tbBLine
            // 
            this.tbBLine.ImageIndex = 1;
            this.tbBLine.ToolTipText = "Line";
            // 
            // tbBEllipse
            // 
            this.tbBEllipse.ImageIndex = 0;
            this.tbBEllipse.ToolTipText = "Ellipse";
            this.imageList1.Images.Clear();
            this.imageList1.Images.Add(((System.Drawing.Icon)(resources.GetObject("resource"))));
            this.imageList1.Images.Add(((System.Drawing.Icon)(resources.GetObject("resource1"))));
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.mnuColor);
            this.mainMenu1.MenuItems.Add(this.mnuFill);
            // 
            // mnuColor
            // 
            this.mnuColor.Text = "Color";
            this.mnuColor.Click += new System.EventHandler(this.mnuColor_Click);
            // 
            // mnuFill
            // 
            this.mnuFill.Text = "Fill";
            this.mnuFill.Click += new System.EventHandler(this.mnuFill_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.toolBar1);
            this.Menu = this.mainMenu1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolBar toolBar1;
        private System.Windows.Forms.ToolBarButton tbBLine;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolBarButton tbBEllipse;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem mnuColor;
        private System.Windows.Forms.MenuItem mnuFill;

    }
}

