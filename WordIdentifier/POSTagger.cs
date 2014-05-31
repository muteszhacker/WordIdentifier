using System.Collections.Generic;
using System.IO;

namespace WordIdentifier
{
    class POSTagger
    {
        public POSTagger()
        {
            
        }

        // POS Tag
        public string Process(ref List<DictionaryItem> dictionary, ref List<string> wordList)
        {
            /*
            richTextBoxPOSTag.Text = "";
            for (int i = 0; i < dictionary.Count; ++i)
            {
                richTextBoxPOSTag.Text +=   dictionary[i].word + " - " +
                                            dictionary[i].POSTag + " - " +
                                            dictionary[i].occurrence + "\n";
            }
            * */

            string result = "";

            
            StreamWriter writer = new StreamWriter("result.out");
            foreach (DictionaryItem item in dictionary)
            {
                writer.WriteLine(item.word + " - " + item.POSTag + " - " + item.occurrence);
            }
            writer.Close();
            

            foreach (string word in wordList)
            {
                string POS = "";
                int maxFreq = 0;

                foreach (DictionaryItem item in dictionary)
                {
                    if (POS != "" && item.word != word) break;

                    if (item.word != word || maxFreq >= item.occurrence) continue;

                    POS = item.POSTag;
                    maxFreq = item.occurrence;
                }

                if (POS == "")
                    POS = "N";

                result += word + " --- " + POS + "\n";
            }

            return result;
        }
    }
}
