namespace DictionaryForPPC
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
            this.cmbWord = new System.Windows.Forms.ComboBox();
            this.txtMeaning = new System.Windows.Forms.TextBox();
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.mnuDictionary = new System.Windows.Forms.MenuItem();
            this.mnuTranslator = new System.Windows.Forms.MenuItem();
            this.PanelDictionary = new System.Windows.Forms.Panel();
            this.butSpeakWord = new System.Windows.Forms.Button();
            this.panelTranslator = new System.Windows.Forms.Panel();
            this.butSpeakResult = new System.Windows.Forms.Button();
            this.butSpeakText = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.butTranslate = new System.Windows.Forms.Button();
            this.cmbLanguage = new System.Windows.Forms.ComboBox();
            this.txtResultText = new System.Windows.Forms.TextBox();
            this.txtOriginalText = new System.Windows.Forms.TextBox();
            this.PanelDictionary.SuspendLayout();
            this.panelTranslator.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbWord
            // 
            this.cmbWord.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cmbWord.Location = new System.Drawing.Point(3, 244);
            this.cmbWord.Name = "cmbWord";
            this.cmbWord.Size = new System.Drawing.Size(180, 22);
            this.cmbWord.TabIndex = 0;
            this.cmbWord.SelectedIndexChanged += new System.EventHandler(this.cmbWord_SelectedIndexChanged);
            this.cmbWord.TextChanged += new System.EventHandler(this.cmbWord_TextChanged);
            // 
            // txtMeaning
            // 
            this.txtMeaning.Location = new System.Drawing.Point(3, 3);
            this.txtMeaning.Multiline = true;
            this.txtMeaning.Name = "txtMeaning";
            this.txtMeaning.ReadOnly = true;
            this.txtMeaning.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMeaning.Size = new System.Drawing.Size(234, 238);
            this.txtMeaning.TabIndex = 1;
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.mnuDictionary);
            this.mainMenu1.MenuItems.Add(this.mnuTranslator);
            // 
            // mnuDictionary
            // 
            this.mnuDictionary.Text = "Dictionary";
            // 
            // mnuTranslator
            // 
            this.mnuTranslator.Text = "Translator";
            this.mnuTranslator.Click += new System.EventHandler(this.mnuTranslator_Click);
            // 
            // PanelDictionary
            // 
            this.PanelDictionary.Controls.Add(this.butSpeakWord);
            this.PanelDictionary.Controls.Add(this.txtMeaning);
            this.PanelDictionary.Controls.Add(this.cmbWord);
            this.PanelDictionary.Location = new System.Drawing.Point(0, 0);
            this.PanelDictionary.Name = "PanelDictionary";
            this.PanelDictionary.Size = new System.Drawing.Size(240, 268);
            // 
            // butSpeakWord
            // 
            this.butSpeakWord.Location = new System.Drawing.Point(189, 246);
            this.butSpeakWord.Name = "butSpeakWord";
            this.butSpeakWord.Size = new System.Drawing.Size(47, 19);
            this.butSpeakWord.TabIndex = 2;
            this.butSpeakWord.Text = "Speak";
            this.butSpeakWord.Click += new System.EventHandler(this.butSpeakWord_Click);
            // 
            // panelTranslator
            // 
            this.panelTranslator.Controls.Add(this.butSpeakResult);
            this.panelTranslator.Controls.Add(this.butSpeakText);
            this.panelTranslator.Controls.Add(this.label2);
            this.panelTranslator.Controls.Add(this.label1);
            this.panelTranslator.Controls.Add(this.butTranslate);
            this.panelTranslator.Controls.Add(this.cmbLanguage);
            this.panelTranslator.Controls.Add(this.txtResultText);
            this.panelTranslator.Controls.Add(this.txtOriginalText);
            this.panelTranslator.Location = new System.Drawing.Point(0, 0);
            this.panelTranslator.Name = "panelTranslator";
            this.panelTranslator.Size = new System.Drawing.Size(240, 268);
            // 
            // butSpeakResult
            // 
            this.butSpeakResult.Location = new System.Drawing.Point(132, 154);
            this.butSpeakResult.Name = "butSpeakResult";
            this.butSpeakResult.Size = new System.Drawing.Size(104, 16);
            this.butSpeakResult.TabIndex = 5;
            this.butSpeakResult.Text = "Speak text";
            this.butSpeakResult.Click += new System.EventHandler(this.butSpeakResult_Click);
            // 
            // butSpeakText
            // 
            this.butSpeakText.Location = new System.Drawing.Point(132, 34);
            this.butSpeakText.Name = "butSpeakText";
            this.butSpeakText.Size = new System.Drawing.Size(104, 16);
            this.butSpeakText.TabIndex = 4;
            this.butSpeakText.Text = "Speak text";
            this.butSpeakText.Click += new System.EventHandler(this.butSpeakText_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 19);
            this.label2.Text = "Original Text";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 151);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 19);
            this.label1.Text = "Result";
            // 
            // butTranslate
            // 
            this.butTranslate.Location = new System.Drawing.Point(168, 6);
            this.butTranslate.Name = "butTranslate";
            this.butTranslate.Size = new System.Drawing.Size(69, 23);
            this.butTranslate.TabIndex = 3;
            this.butTranslate.Text = "Translate";
            this.butTranslate.Click += new System.EventHandler(this.butTranslate_Click);
            // 
            // cmbLanguage
            // 
            this.cmbLanguage.Items.Add("English to Dutch");
            this.cmbLanguage.Items.Add("English to French");
            this.cmbLanguage.Items.Add("English to German");
            this.cmbLanguage.Items.Add("English to Italian");
            this.cmbLanguage.Items.Add("English to Portuguese");
            this.cmbLanguage.Items.Add("English to Spanish");
            this.cmbLanguage.Items.Add("Dutch to English");
            this.cmbLanguage.Items.Add("French to English");
            this.cmbLanguage.Items.Add("French to Greman");
            this.cmbLanguage.Items.Add("Greman to English");
            this.cmbLanguage.Items.Add("Greman to French");
            this.cmbLanguage.Items.Add("Italian to English");
            this.cmbLanguage.Items.Add("Portuguese to English");
            this.cmbLanguage.Items.Add("Spanish to English");
            this.cmbLanguage.Location = new System.Drawing.Point(3, 7);
            this.cmbLanguage.Name = "cmbLanguage";
            this.cmbLanguage.Size = new System.Drawing.Size(159, 22);
            this.cmbLanguage.TabIndex = 2;
            // 
            // txtResultText
            // 
            this.txtResultText.Location = new System.Drawing.Point(0, 173);
            this.txtResultText.Multiline = true;
            this.txtResultText.Name = "txtResultText";
            this.txtResultText.Size = new System.Drawing.Size(237, 92);
            this.txtResultText.TabIndex = 1;
            // 
            // txtOriginalText
            // 
            this.txtOriginalText.Location = new System.Drawing.Point(3, 54);
            this.txtOriginalText.Multiline = true;
            this.txtOriginalText.Name = "txtOriginalText";
            this.txtOriginalText.Size = new System.Drawing.Size(234, 94);
            this.txtOriginalText.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.PanelDictionary);
            this.Controls.Add(this.panelTranslator);
            this.Menu = this.mainMenu1;
            this.Name = "Form1";
            this.Text = "Dictionary For PPC";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.PanelDictionary.ResumeLayout(false);
            this.panelTranslator.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbWord;
        private System.Windows.Forms.TextBox txtMeaning;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem mnuDictionary;
        private System.Windows.Forms.MenuItem mnuTranslator;
        private System.Windows.Forms.Panel PanelDictionary;
        private System.Windows.Forms.Panel panelTranslator;
        private System.Windows.Forms.Button butTranslate;
        private System.Windows.Forms.ComboBox cmbLanguage;
        private System.Windows.Forms.TextBox txtResultText;
        private System.Windows.Forms.TextBox txtOriginalText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button butSpeakWord;
        private System.Windows.Forms.Button butSpeakResult;
        private System.Windows.Forms.Button butSpeakText;
    }
}

