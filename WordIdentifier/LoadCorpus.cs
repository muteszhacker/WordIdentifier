using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace WordIdentifier
{
    public partial class LoadCorpus : Form
    {
        private bool buttonOption;
        public static XmlDocument doc;                // Tài liệu XML
        private PRD2XML converter;
        public bool corpusIsLoaded;
        public List<DictionaryItem> dict;

        public LoadCorpus(ref List<DictionaryItem> dictionary)
        {
            InitializeComponent();
            textBoxLoadCorpus.Text = "";
            radioButtonLoad1PRD.Checked = true;
            radioButtonLoadPRDCorpus.Checked = false;
            buttonLoadCorpus.Text = "Open";
            labelLoadCorpus.Text = "";
            buttonOption = true;
            corpusIsLoaded = false;
            dict = dictionary;
        }

        private void radioButtonLoad1PRD_CheckedChanged(object sender, EventArgs e)
        {
            radioButtonLoadPRDCorpus.Checked = !radioButtonLoad1PRD.Checked;

            textBoxLoadCorpus.Text = "";
            buttonLoadCorpus.Text = "Open";
            labelLoadCorpus.Text = "";
            buttonOption = true;
            treeViewLoadCorpus.Nodes.Clear();
            richTextBoxLoadCorpus.Text = "";
        }

        private void radioButtonLoadPRDCorpus_CheckedChanged(object sender, EventArgs e)
        {
            radioButtonLoad1PRD.Checked = !radioButtonLoadPRDCorpus.Checked;

            textBoxLoadCorpus.Text = "";
            buttonLoadCorpus.Text = "Open";
            labelLoadCorpus.Text = "";
            buttonOption = true;
            treeViewLoadCorpus.Nodes.Clear();
            richTextBoxLoadCorpus.Text = "";
        }

        // Chuyển cây XML thành TreeView
        private void ConvertXmlNodeToTreeNode(XmlNode xmlNode, TreeNodeCollection treeNodes)
        {
            // Thêm một TreeNode mô tả XmlNode này.
            TreeNode newTreeNode = treeNodes.Add(xmlNode.Name);

            // Tùy biến phần text cho TreeNode dựa vào kiểu và nội dung của XmlNode.
            switch (xmlNode.NodeType)
            {
                case XmlNodeType.ProcessingInstruction:

                case XmlNodeType.XmlDeclaration:
                    newTreeNode.Text = "<?" + xmlNode.Name + " " + xmlNode.Value + "?>";
                    break;

                case XmlNodeType.Element:
                    newTreeNode.Text = "<" + xmlNode.Name + ">";
                    break;

                case XmlNodeType.Attribute:
                    newTreeNode.Text = "ATTRIBUTE: " + xmlNode.Name;
                    break;

                case XmlNodeType.Text:

                case XmlNodeType.CDATA:
                    progressBarLoadCorpus.Value++;
                    labelLoadCorpus.Text = ((int)((100*progressBarLoadCorpus.Value) / converter.wordCounter)) + "%";
                    progressBarLoadCorpus.Refresh();
                    Application.DoEvents();
                    newTreeNode.Text = xmlNode.Value;
                    // MessageBox.Show(newTreeNode.Text);
                    break;

                case XmlNodeType.Comment:
                    newTreeNode.Text = "<!--" + xmlNode.Value + "-->";
                    break;
            }

            // Gọi phương thức này một cách đệ quy cho mỗi thuộc tính
            if (xmlNode.Attributes != null)
            {
                foreach (XmlAttribute attribute in xmlNode.Attributes)
                    ConvertXmlNodeToTreeNode(attribute, newTreeNode.Nodes);
            }

            // Gọi phương thức này một cách đệ quy cho mỗi nút con.
            foreach (XmlNode childNode in xmlNode.ChildNodes)
                ConvertXmlNodeToTreeNode(childNode, newTreeNode.Nodes);
        }

        /// <summary>
        /// Hiển thị nội dung file trong RichTextBox
        /// </summary>
        /// <param name="fileName"></param>
        private void UpdateRichTextBox(string fileName)
        {
            this.Text = "PRDEditor - " + fileName;
            StreamReader openFile = new StreamReader(fileName);
            string line;
            richTextBoxLoadCorpus.Text = "";

            while ((line = openFile.ReadLine()) != null)
                richTextBoxLoadCorpus.Text += line + "\n";

            openFile.Close();
        }

        /// <summary>
        /// Hiển thị cây XML
        /// </summary>
        /// <param name="doc"></param>
        private void DisplayXML(XmlDocument doc)
        {
            if (doc == null) throw new ArgumentNullException("doc");

            // Xóa cây.
            treeViewLoadCorpus.Nodes.Clear();

            // Đổ dữ liệu vào TreeView.
            ConvertXmlNodeToTreeNode(doc.SelectSingleNode("TEXT"), treeViewLoadCorpus.Nodes);

            // Mở rộng tất cả các nút.
            treeViewLoadCorpus.Nodes[0].ExpandAll();
        }

        private void buttonLoadCorpus_Click(object sender, EventArgs e)
        {
            if (buttonOption)
            {
                if (radioButtonLoad1PRD.Checked)
                {
                    openFileDialogLoadCorpus.ShowDialog();
                    buttonOption = false;
                    buttonLoadCorpus.Text = "Load";
                }
                else
                {
                    if (folderBrowserDialogLoadCorpus.ShowDialog() == DialogResult.OK)
                    {
                        textBoxLoadCorpus.Text = folderBrowserDialogLoadCorpus.SelectedPath;
                        buttonOption = false;
                        buttonLoadCorpus.Text = "Load";
                    }
                }
            }
            else
            {
                if (radioButtonLoad1PRD.Checked)
                {
                    converter = new PRD2XML(openFileDialogLoadCorpus.FileName);

                    // Hiển thị nội dung file trong RichTextBox
                    UpdateRichTextBox(openFileDialogLoadCorpus.FileName);

                    // Hiển thị cây cú pháp trong TreeView
                    treeViewLoadCorpus.Nodes.Clear();

                    if (openFileDialogLoadCorpus.FileName.Substring(openFileDialogLoadCorpus.FileName.Length - 4, 4)
                        .ToUpper() == ".XML")
                        doc = converter.ReadInput();
                    else
                        doc = converter.ConvertPRD2XML(ref dict);

                    // progressBarLoadCorpus.Maximum = converter.wordCounter;
                    progressBarLoadCorpus.Minimum = 0;
                    progressBarLoadCorpus.Maximum = converter.wordCounter;
                    progressBarLoadCorpus.Value = 0;
                    labelLoadCorpus.Text = "0%";

                    DisplayXML(doc);

                    ConvertXmlNodeToTreeNode(doc.FirstChild.NextSibling, treeViewLoadCorpus.Nodes);
                    treeViewLoadCorpus.Nodes[0].ExpandAll();

                    progressBarLoadCorpus.Value = converter.wordCounter;
                    labelLoadCorpus.Text = "100%";
                    buttonOption = true;
                    buttonLoadCorpus.Text = "Open";
                }
                else
                {
                    string[] allFiles = Directory.GetFiles(folderBrowserDialogLoadCorpus.SelectedPath, "*.prd");
                    progressBarLoadCorpus.Minimum = 0;
                    progressBarLoadCorpus.Maximum = allFiles.Length;
                    progressBarLoadCorpus.Value = 0;
                    labelLoadCorpus.Text = "0%";

                    foreach (string f in allFiles)
                    {
                        try
                        {
                            // MessageBox.Show(f);
                            PRD2XML multipleConverter = new PRD2XML(f);

                            multipleConverter.ConvertPRD2XML(ref dict);
                            // multipleConverter.SaveFile(f.Substring(0, f.Length - 4) + ".xml");
                            progressBarLoadCorpus.Value++;
                            labelLoadCorpus.Text = ((int)((100 * progressBarLoadCorpus.Value) / allFiles.Length)) + "%";
                            progressBarLoadCorpus.Refresh();
                            Application.DoEvents();
                        }
                        catch (PRDEditorException err)
                        {
                            MessageBox.Show(err.ToString());
                        }
                        catch (Exception err)
                        {
                            MessageBox.Show(err.Message);
                            MessageBox.Show(err.StackTrace);
                            break;
                        }
                    }

                    MessageBox.Show("All files are loaded.", "Successful");
                    progressBarLoadCorpus.Value = allFiles.Length;
                    labelLoadCorpus.Text = "100%";
                    buttonOption = true;
                    buttonLoadCorpus.Text = "Open";
                }
            }
        }

        private void openFileDialogLoadCorpus_FileOk(object sender, CancelEventArgs e)
        {
            textBoxLoadCorpus.Text = openFileDialogLoadCorpus.FileName;
            buttonOption = false;
            buttonLoadCorpus.Text = "Load";
            openFileDialogLoadCorpus.Filter = "PRD Files |*.prd|XML Files |*.xml";
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            corpusIsLoaded = true;
            this.Visible = false;
        }
    }
}
