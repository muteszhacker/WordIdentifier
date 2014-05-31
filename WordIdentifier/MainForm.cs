using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WordIdentifier
{
    public partial class MainForm : Form
    {
        private List<DictionaryItem> dictionary;        // Dictionary with POS tag and occurences
        LoadLexicon lexicon;                            // Form load lexicon
        LoadCorpus corpus;                              // Form load corpus
        List<string> wordList;                          // List of words identified
        private WordIdentifier identifier;
        private POSTagger tagger;

        // Constructor
        public MainForm()
        {
            InitializeComponent();

            buttonLoadDictionary.Enabled = true;
            buttonIdentifyWord.Enabled = false;
            buttonPOSTag.Enabled = false;

            dictionary = new List<DictionaryItem>();
        }

        // When clicking buttonLoadDictionary
        private void buttonLoadDictionary_Click(object sender, EventArgs e)
        {
            lexicon = new LoadLexicon();
            lexicon.Show();
            buttonIdentifyWord.Enabled = true;
        }

        // When clicking buttonIdentifyWord
        private void buttonIdentifyWord_Click(object sender, EventArgs e)
        {
            if (!lexicon.dictionaryIsLoaded)
            {
                MessageBox.Show("Please wait while loading lexicon");
                return;
            }

            identifier = new WordIdentifier(richTextBoxInputText.Text);
            string[] input = identifier.Preprocess();
            identifier.Process(ref input, ref wordList, ref lexicon);

            //
            richTextBoxOutputWords.Text = "| ";

            foreach (string str in wordList)
            {
                //MessageBox.Show("Từ:\n" + str, "Thông báo", MessageBoxButtons.OK);
                richTextBoxOutputWords.Text += str + " | ";
            }
        }

        // When text of richTextBoxInputText is Changed
        private void richTextBoxInputText_TextChanged(object sender, EventArgs e)
        {
            if (richTextBoxInputText.Text != "" && lexicon.dictionaryIsLoaded)
                buttonIdentifyWord.Enabled = true;
            else
                buttonIdentifyWord.Enabled = false;
        }

        // When clicking buttonLoadCorpus
        private void buttonLoadCorpus_Click(object sender, EventArgs e)
        {
            corpus = new LoadCorpus(ref dictionary);
            corpus.Show();
            buttonPOSTag.Enabled = true;
        }

        // When clicking buttonPOSTag
        private void buttonPOSTag_Click(object sender, EventArgs e)
        {
            if (!corpus.corpusIsLoaded)
            {
                MessageBox.Show("Please wait while loading corpus");
                return;
            }

            dictionary.Sort((item1, item2) => item1.CompareTo(item2));
            tagger = new POSTagger();
            richTextBoxPOSTag.Text = tagger.Process(ref dictionary, ref wordList);
        }
    }
}
