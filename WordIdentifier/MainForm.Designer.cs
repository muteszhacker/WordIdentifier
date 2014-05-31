namespace WordIdentifier
{
    partial class MainForm
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
            this.richTextBoxInputText = new System.Windows.Forms.RichTextBox();
            this.richTextBoxOutputWords = new System.Windows.Forms.RichTextBox();
            this.buttonIdentifyWord = new System.Windows.Forms.Button();
            this.buttonLoadDictionary = new System.Windows.Forms.Button();
            this.richTextBoxPOSTag = new System.Windows.Forms.RichTextBox();
            this.buttonPOSTag = new System.Windows.Forms.Button();
            this.buttonLoadCorpus = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBoxInputText
            // 
            this.richTextBoxInputText.Location = new System.Drawing.Point(-1, 23);
            this.richTextBoxInputText.Name = "richTextBoxInputText";
            this.richTextBoxInputText.Size = new System.Drawing.Size(320, 240);
            this.richTextBoxInputText.TabIndex = 0;
            this.richTextBoxInputText.Text = "";
            this.richTextBoxInputText.TextChanged += new System.EventHandler(this.richTextBoxInputText_TextChanged);
            // 
            // richTextBoxOutputWords
            // 
            this.richTextBoxOutputWords.Location = new System.Drawing.Point(-1, 262);
            this.richTextBoxOutputWords.Name = "richTextBoxOutputWords";
            this.richTextBoxOutputWords.ReadOnly = true;
            this.richTextBoxOutputWords.Size = new System.Drawing.Size(320, 240);
            this.richTextBoxOutputWords.TabIndex = 1;
            this.richTextBoxOutputWords.Text = "";
            // 
            // buttonIdentifyWord
            // 
            this.buttonIdentifyWord.Location = new System.Drawing.Point(159, -1);
            this.buttonIdentifyWord.Name = "buttonIdentifyWord";
            this.buttonIdentifyWord.Size = new System.Drawing.Size(80, 25);
            this.buttonIdentifyWord.TabIndex = 2;
            this.buttonIdentifyWord.Text = "Identify words";
            this.buttonIdentifyWord.UseVisualStyleBackColor = true;
            this.buttonIdentifyWord.Click += new System.EventHandler(this.buttonIdentifyWord_Click);
            // 
            // buttonLoadDictionary
            // 
            this.buttonLoadDictionary.Location = new System.Drawing.Point(81, -1);
            this.buttonLoadDictionary.Name = "buttonLoadDictionary";
            this.buttonLoadDictionary.Size = new System.Drawing.Size(80, 25);
            this.buttonLoadDictionary.TabIndex = 0;
            this.buttonLoadDictionary.Text = "Load Lexicon";
            this.buttonLoadDictionary.UseVisualStyleBackColor = true;
            this.buttonLoadDictionary.Click += new System.EventHandler(this.buttonLoadDictionary_Click);
            // 
            // richTextBoxPOSTag
            // 
            this.richTextBoxPOSTag.Location = new System.Drawing.Point(317, 23);
            this.richTextBoxPOSTag.Name = "richTextBoxPOSTag";
            this.richTextBoxPOSTag.ReadOnly = true;
            this.richTextBoxPOSTag.Size = new System.Drawing.Size(320, 480);
            this.richTextBoxPOSTag.TabIndex = 3;
            this.richTextBoxPOSTag.Text = "";
            // 
            // buttonPOSTag
            // 
            this.buttonPOSTag.Location = new System.Drawing.Point(479, -1);
            this.buttonPOSTag.Name = "buttonPOSTag";
            this.buttonPOSTag.Size = new System.Drawing.Size(80, 25);
            this.buttonPOSTag.TabIndex = 4;
            this.buttonPOSTag.Text = "POS Tag";
            this.buttonPOSTag.UseVisualStyleBackColor = true;
            this.buttonPOSTag.Click += new System.EventHandler(this.buttonPOSTag_Click);
            // 
            // buttonLoadCorpus
            // 
            this.buttonLoadCorpus.Location = new System.Drawing.Point(401, -1);
            this.buttonLoadCorpus.Name = "buttonLoadCorpus";
            this.buttonLoadCorpus.Size = new System.Drawing.Size(80, 25);
            this.buttonLoadCorpus.TabIndex = 5;
            this.buttonLoadCorpus.Text = "Load Corpus";
            this.buttonLoadCorpus.UseVisualStyleBackColor = true;
            this.buttonLoadCorpus.Click += new System.EventHandler(this.buttonLoadCorpus_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 501);
            this.Controls.Add(this.buttonLoadCorpus);
            this.Controls.Add(this.buttonPOSTag);
            this.Controls.Add(this.richTextBoxPOSTag);
            this.Controls.Add(this.buttonLoadDictionary);
            this.Controls.Add(this.buttonIdentifyWord);
            this.Controls.Add(this.richTextBoxOutputWords);
            this.Controls.Add(this.richTextBoxInputText);
            this.Name = "MainForm";
            this.Text = "WordIdentifier & POS Tagger";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxInputText;
        private System.Windows.Forms.RichTextBox richTextBoxOutputWords;
        private System.Windows.Forms.Button buttonIdentifyWord;
        private System.Windows.Forms.Button buttonLoadDictionary;
        private System.Windows.Forms.RichTextBox richTextBoxPOSTag;
        private System.Windows.Forms.Button buttonPOSTag;
        private System.Windows.Forms.Button buttonLoadCorpus;

    }
}

