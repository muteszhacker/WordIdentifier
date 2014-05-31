using System.Drawing;

namespace WordIdentifier
{
    partial class LoadCorpus
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
            this.treeViewLoadCorpus = new System.Windows.Forms.TreeView();
            this.richTextBoxLoadCorpus = new System.Windows.Forms.RichTextBox();
            this.progressBarLoadCorpus = new System.Windows.Forms.ProgressBar();
            this.buttonLoadCorpus = new System.Windows.Forms.Button();
            this.textBoxLoadCorpus = new System.Windows.Forms.TextBox();
            this.labelLoadCorpus = new System.Windows.Forms.Label();
            this.openFileDialogLoadCorpus = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialogLoadCorpus = new System.Windows.Forms.FolderBrowserDialog();
            this.buttonOK = new System.Windows.Forms.Button();
            this.radioButtonLoadPRDCorpus = new System.Windows.Forms.RadioButton();
            this.radioButtonLoad1PRD = new System.Windows.Forms.RadioButton();
            this.radioButtonLoad1POS = new System.Windows.Forms.RadioButton();
            this.radioButtonLoadPOSCorpus = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // treeViewLoadCorpus
            // 
            this.treeViewLoadCorpus.Location = new System.Drawing.Point(0, 42);
            this.treeViewLoadCorpus.Name = "treeViewLoadCorpus";
            this.treeViewLoadCorpus.Size = new System.Drawing.Size(320, 320);
            this.treeViewLoadCorpus.TabIndex = 0;
            // 
            // richTextBoxLoadCorpus
            // 
            this.richTextBoxLoadCorpus.Location = new System.Drawing.Point(320, 41);
            this.richTextBoxLoadCorpus.Name = "richTextBoxLoadCorpus";
            this.richTextBoxLoadCorpus.Size = new System.Drawing.Size(320, 320);
            this.richTextBoxLoadCorpus.TabIndex = 1;
            this.richTextBoxLoadCorpus.Text = "";
            // 
            // progressBarLoadCorpus
            // 
            this.progressBarLoadCorpus.Location = new System.Drawing.Point(0, 363);
            this.progressBarLoadCorpus.Name = "progressBarLoadCorpus";
            this.progressBarLoadCorpus.Size = new System.Drawing.Size(594, 26);
            this.progressBarLoadCorpus.TabIndex = 3;
            // 
            // buttonLoadCorpus
            // 
            this.buttonLoadCorpus.Location = new System.Drawing.Point(479, -1);
            this.buttonLoadCorpus.Name = "buttonLoadCorpus";
            this.buttonLoadCorpus.Size = new System.Drawing.Size(81, 23);
            this.buttonLoadCorpus.TabIndex = 4;
            this.buttonLoadCorpus.UseVisualStyleBackColor = true;
            this.buttonLoadCorpus.Click += new System.EventHandler(this.buttonLoadCorpus_Click);
            // 
            // textBoxLoadCorpus
            // 
            this.textBoxLoadCorpus.Location = new System.Drawing.Point(0, 1);
            this.textBoxLoadCorpus.Name = "textBoxLoadCorpus";
            this.textBoxLoadCorpus.ReadOnly = true;
            this.textBoxLoadCorpus.Size = new System.Drawing.Size(480, 20);
            this.textBoxLoadCorpus.TabIndex = 5;
            // 
            // labelLoadCorpus
            // 
            this.labelLoadCorpus.AutoSize = true;
            this.labelLoadCorpus.Font = new System.Drawing.Font("Arial", 12F);
            this.labelLoadCorpus.Location = new System.Drawing.Point(594, 368);
            this.labelLoadCorpus.Name = "labelLoadCorpus";
            this.labelLoadCorpus.Size = new System.Drawing.Size(0, 18);
            this.labelLoadCorpus.TabIndex = 6;
            // 
            // openFileDialogLoadCorpus
            // 
            this.openFileDialogLoadCorpus.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialogLoadCorpus_FileOk);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(557, -1);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(81, 23);
            this.buttonOK.TabIndex = 9;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // radioButtonLoadPRDCorpus
            // 
            this.radioButtonLoadPRDCorpus.AutoSize = true;
            this.radioButtonLoadPRDCorpus.Location = new System.Drawing.Point(160, 23);
            this.radioButtonLoadPRDCorpus.Name = "radioButtonLoadPRDCorpus";
            this.radioButtonLoadPRDCorpus.Size = new System.Drawing.Size(111, 17);
            this.radioButtonLoadPRDCorpus.TabIndex = 8;
            this.radioButtonLoadPRDCorpus.TabStop = true;
            this.radioButtonLoadPRDCorpus.Text = "Load PRD Corpus";
            this.radioButtonLoadPRDCorpus.UseVisualStyleBackColor = true;
            this.radioButtonLoadPRDCorpus.CheckedChanged += new System.EventHandler(this.radioButtonLoadPRDCorpus_CheckedChanged);
            // 
            // radioButtonLoad1PRD
            // 
            this.radioButtonLoad1PRD.AutoSize = true;
            this.radioButtonLoad1PRD.Location = new System.Drawing.Point(0, 23);
            this.radioButtonLoad1PRD.Name = "radioButtonLoad1PRD";
            this.radioButtonLoad1PRD.Size = new System.Drawing.Size(100, 17);
            this.radioButtonLoad1PRD.TabIndex = 7;
            this.radioButtonLoad1PRD.TabStop = true;
            this.radioButtonLoad1PRD.Text = "Load a PRD file";
            this.radioButtonLoad1PRD.UseVisualStyleBackColor = true;
            this.radioButtonLoad1PRD.CheckedChanged += new System.EventHandler(this.radioButtonLoad1PRD_CheckedChanged);
            // 
            // radioButtonLoad1POS
            // 
            this.radioButtonLoad1POS.AutoSize = true;
            this.radioButtonLoad1POS.Location = new System.Drawing.Point(320, 24);
            this.radioButtonLoad1POS.Name = "radioButtonLoad1POS";
            this.radioButtonLoad1POS.Size = new System.Drawing.Size(99, 17);
            this.radioButtonLoad1POS.TabIndex = 10;
            this.radioButtonLoad1POS.TabStop = true;
            this.radioButtonLoad1POS.Text = "Load a POS file";
            this.radioButtonLoad1POS.UseVisualStyleBackColor = true;
            // 
            // radioButtonLoadPOSCorpus
            // 
            this.radioButtonLoadPOSCorpus.AutoSize = true;
            this.radioButtonLoadPOSCorpus.Location = new System.Drawing.Point(481, 23);
            this.radioButtonLoadPOSCorpus.Name = "radioButtonLoadPOSCorpus";
            this.radioButtonLoadPOSCorpus.Size = new System.Drawing.Size(110, 17);
            this.radioButtonLoadPOSCorpus.TabIndex = 11;
            this.radioButtonLoadPOSCorpus.TabStop = true;
            this.radioButtonLoadPOSCorpus.Text = "Load POS Corpus";
            this.radioButtonLoadPOSCorpus.UseVisualStyleBackColor = true;
            // 
            // LoadCorpus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 390);
            this.Controls.Add(this.radioButtonLoadPOSCorpus);
            this.Controls.Add(this.radioButtonLoad1POS);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.radioButtonLoadPRDCorpus);
            this.Controls.Add(this.radioButtonLoad1PRD);
            this.Controls.Add(this.labelLoadCorpus);
            this.Controls.Add(this.textBoxLoadCorpus);
            this.Controls.Add(this.buttonLoadCorpus);
            this.Controls.Add(this.progressBarLoadCorpus);
            this.Controls.Add(this.richTextBoxLoadCorpus);
            this.Controls.Add(this.treeViewLoadCorpus);
            this.Name = "LoadCorpus";
            this.Text = "LoadCorpus";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewLoadCorpus;
        private System.Windows.Forms.RichTextBox richTextBoxLoadCorpus;
        private System.Windows.Forms.ProgressBar progressBarLoadCorpus;
        private System.Windows.Forms.Button buttonLoadCorpus;
        private System.Windows.Forms.TextBox textBoxLoadCorpus;
        private System.Windows.Forms.Label labelLoadCorpus;
        private System.Windows.Forms.OpenFileDialog openFileDialogLoadCorpus;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogLoadCorpus;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.RadioButton radioButtonLoadPRDCorpus;
        private System.Windows.Forms.RadioButton radioButtonLoad1PRD;
        private System.Windows.Forms.RadioButton radioButtonLoad1POS;
        private System.Windows.Forms.RadioButton radioButtonLoadPOSCorpus;
    }
}