namespace WordIdentifier
{
    partial class LoadLexicon
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
            this.listBoxLoadLexicon = new System.Windows.Forms.ListBox();
            this.buttonLoadLexicon = new System.Windows.Forms.Button();
            this.progressBarLoadLexicon = new System.Windows.Forms.ProgressBar();
            this.openFileDialogLoadLexicon = new System.Windows.Forms.OpenFileDialog();
            this.textBoxLoadLexicon = new System.Windows.Forms.TextBox();
            this.labelLoadLexicon = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBoxLoadLexicon
            // 
            this.listBoxLoadLexicon.FormattingEnabled = true;
            this.listBoxLoadLexicon.Location = new System.Drawing.Point(1, 22);
            this.listBoxLoadLexicon.Name = "listBoxLoadLexicon";
            this.listBoxLoadLexicon.Size = new System.Drawing.Size(334, 394);
            this.listBoxLoadLexicon.TabIndex = 0;
            // 
            // buttonLoadLexicon
            // 
            this.buttonLoadLexicon.Location = new System.Drawing.Point(264, -1);
            this.buttonLoadLexicon.Name = "buttonLoadLexicon";
            this.buttonLoadLexicon.Size = new System.Drawing.Size(72, 23);
            this.buttonLoadLexicon.TabIndex = 1;
            this.buttonLoadLexicon.UseVisualStyleBackColor = true;
            this.buttonLoadLexicon.Click += new System.EventHandler(this.buttonLoadLexicon_Click);
            // 
            // progressBarLoadLexicon
            // 
            this.progressBarLoadLexicon.Location = new System.Drawing.Point(1, 418);
            this.progressBarLoadLexicon.Name = "progressBarLoadLexicon";
            this.progressBarLoadLexicon.Size = new System.Drawing.Size(288, 23);
            this.progressBarLoadLexicon.TabIndex = 2;
            // 
            // openFileDialogLoadLexicon
            // 
            this.openFileDialogLoadLexicon.Filter = "XML Files |*.xml";
            this.openFileDialogLoadLexicon.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialogLoadLexicon_FileOk);
            // 
            // textBoxLoadLexicon
            // 
            this.textBoxLoadLexicon.Location = new System.Drawing.Point(1, 1);
            this.textBoxLoadLexicon.Name = "textBoxLoadLexicon";
            this.textBoxLoadLexicon.ReadOnly = true;
            this.textBoxLoadLexicon.Size = new System.Drawing.Size(264, 20);
            this.textBoxLoadLexicon.TabIndex = 4;
            // 
            // labelLoadLexicon
            // 
            this.labelLoadLexicon.AutoSize = true;
            this.labelLoadLexicon.Font = new System.Drawing.Font("Arial", 12F);
            this.labelLoadLexicon.Location = new System.Drawing.Point(289, 422);
            this.labelLoadLexicon.Name = "labelLoadLexicon";
            this.labelLoadLexicon.Size = new System.Drawing.Size(0, 13);
            this.labelLoadLexicon.TabIndex = 5;
            // 
            // LoadLexicon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 442);
            this.Controls.Add(this.labelLoadLexicon);
            this.Controls.Add(this.textBoxLoadLexicon);
            this.Controls.Add(this.progressBarLoadLexicon);
            this.Controls.Add(this.buttonLoadLexicon);
            this.Controls.Add(this.listBoxLoadLexicon);
            this.Name = "LoadLexicon";
            this.Text = "LoadLexicon";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxLoadLexicon;
        private System.Windows.Forms.Button buttonLoadLexicon;
        private System.Windows.Forms.ProgressBar progressBarLoadLexicon;
        private System.Windows.Forms.OpenFileDialog openFileDialogLoadLexicon;
        private System.Windows.Forms.TextBox textBoxLoadLexicon;
        private System.Windows.Forms.Label labelLoadLexicon;
    }
}