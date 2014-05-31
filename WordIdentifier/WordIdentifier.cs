using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace WordIdentifier
{
    class WordIdentifier
    {
        private string sentence;

        Dictionary<char, char> lowerCharList = new Dictionary<char, char>
            {
                {'A', 'a'}, {'Ă', 'ă'}, {'Â', 'â'}, {'B', 'b'}, {'C', 'c'},
                {'D', 'd'}, {'Đ', 'đ'}, {'E', 'e'}, {'Ê', 'ê'}, {'G', 'g'},
                {'H', 'h'}, {'I', 'i'}, {'K', 'k'}, {'L', 'l'}, {'M', 'm'},
                {'N', 'n'}, {'O', 'o'}, {'Ô', 'ô'}, {'Ơ', 'ơ'}, {'P', 'p'}, 
                {'Q', 'q'}, {'R', 'r'}, {'S', 's'}, {'T', 't'}, {'U', 'u'}, 
                {'Ư', 'ư'}, {'V', 'v'}, {'X', 'x'}, {'Y', 'y'},
            };

        // Constructor
        public WordIdentifier(string sentence)
        {
            this.sentence = sentence;
        }

        // Remove unneeded spaces
        public void RemoveSpaces(ref StringBuilder temp)
        {
            // Remove unneeded spaces
            PRD2XML.RemoveSpaceBeginEnd(ref temp);

            for (int i = 0; i < temp.Length - 1; ++i)
            {
                if (temp[i] != ' ' || temp[i + 1] != ' ') continue;

                temp.Remove(i, 1);
                --i;
            }

            sentence = temp.ToString();
        }

        // Change first character of first "tiếng" to lower character
        public void ChangeFirstCharacter(ref StringBuilder temp)
        {
            char lowerChar = ' ';
            temp[0] = lowerCharList.TryGetValue(temp[0], out lowerChar) ? lowerChar : temp[0];
            // MessageBox.Show("Đoạn văn bản bạn vừa nhập:\n" + temp, "Thông báo", MessageBoxButtons.OK);
            sentence = temp.ToString();
        }

        // StringBuilder temp = new StringBuilder(sentence);
        public string[] SplitTieng(ref StringBuilder temp)
        {
            // Split "tiếng" from sentences
            char[] separator = { ' ' };
            string[] input = temp.ToString().Split(separator);

            if (input.Length != 0) return input;

            MessageBox.Show("Câu rỗng", "Thông báo", MessageBoxButtons.OK);
            return null;

            /*
            foreach (string str in input)
            {
                MessageBox.Show("Tiếng:\n" + str,
                    "Thông báo", MessageBoxButtons.OK);
            }*/
        }

        // Preprocess
        public string[] Preprocess()
        {
            StringBuilder temp = new StringBuilder(sentence);

            RemoveSpaces(ref temp);
            ChangeFirstCharacter(ref temp);
            return SplitTieng(ref temp);
        }

        // Process
        public void Process(ref string[] input, ref List<string> wordList, ref LoadLexicon lexicon)
        {
            if (input == null) return;

            // 
            string lastMaxWord = "";
            int index = 0;
            wordList = new List<string>();

            //
            while (index < input.Length)
            {
                string maxWord = input[index], name = "";

                do
                {
                    XmlNodeList noteList = 
                        lexicon.doc.SelectNodes("/corpus/body/w[text()='" + maxWord + "']");
                    name = "";

                    // if 
                    if (noteList != null && noteList.Count == 0)
                    {
                        char lowerChar;

                        if (lowerCharList.TryGetValue(input[index][0], out lowerChar))
                        {
                            for (; index < input.Length; ++index)
                                if (lowerCharList.TryGetValue(input[index][0], out lowerChar))
                                    name += " " + input[index];
                                else
                                    break;
                        }

                        break;
                    }

                    index++;
                    if (index >= input.Length) continue;

                    lastMaxWord = maxWord;
                    maxWord += " " + input[index];
                } while (index < input.Length);

                wordList.Add(index == input.Length ? maxWord : lastMaxWord);

                if (name == "") continue;

                if (name[0] == ' ')
                    name.Remove(0, 1);
                wordList.Add(name);
            }
        }
    }
}
