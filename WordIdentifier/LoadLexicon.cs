using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml;

namespace WordIdentifier
{
    public partial class LoadLexicon : Form
    {
        public XmlDocument doc;                // Tài liệu XML
        private int wordNumber;
        private int buttonOption;
        public bool dictionaryIsLoaded;

        public LoadLexicon()
        {
            InitializeComponent();
            buttonLoadLexicon.Enabled = true;
            dictionaryIsLoaded = false;
            buttonOption = 0;
            buttonLoadLexicon.Text = "Choose file";
            textBoxLoadLexicon.Text = "";
        }

        private void buttonLoadLexicon_Click(object sender, EventArgs e)
        {
            if (buttonOption == 0)
                openFileDialogLoadLexicon.ShowDialog();
            else if (buttonOption == 1)
            {
                doc = new XmlDocument();
                doc.Load(openFileDialogLoadLexicon.FileName);

                // treeViewXML.Nodes.Clear();
                // ConvertXmlNodeToTreeNode(doc.FirstChild.NextSibling, treeViewXML.Nodes);
                // treeViewXML.Nodes[0].ExpandAll();

                listBoxLoadLexicon.Items.Clear();
                int.TryParse(doc.FirstChild.NextSibling.FirstChild.Value, out wordNumber);

                progressBarLoadLexicon.Minimum = 0;
                progressBarLoadLexicon.Maximum = wordNumber;
                labelLoadLexicon.Text = "0%";

                ConvertXmlNodeToLinkedListNode(doc.FirstChild.NextSibling.ChildNodes.Item(1));

                progressBarLoadLexicon.Value = wordNumber;
                labelLoadLexicon.Text = "100%";
                Application.DoEvents();
                buttonOption = 2;
                buttonLoadLexicon.Text = "OK";
            }
            else if (buttonOption == 2)
            {
                dictionaryIsLoaded = true;
                this.Visible = false;
                // this.Dispose();
            }
        }

        // Chuyển cây XML thành ListBox
        private void ConvertXmlNodeToLinkedListNode(XmlNode xmlNode)
        {
            foreach (XmlNode childNode in xmlNode.ChildNodes)
            {
                if (childNode.NodeType == XmlNodeType.Element)
                    listBoxLoadLexicon.Items.Add(childNode.InnerText);
                progressBarLoadLexicon.Value++;
                labelLoadLexicon.Text = ((int)((100 * progressBarLoadLexicon.Value) / wordNumber)) + "%";
                progressBarLoadLexicon.Refresh();
                Application.DoEvents();
            }
        }

        private void openFileDialogLoadLexicon_FileOk(object sender, CancelEventArgs e)
        {
            textBoxLoadLexicon.Text = openFileDialogLoadLexicon.FileName;
            buttonOption = 1;
            buttonLoadLexicon.Text = "Load";
        }
    }
}
