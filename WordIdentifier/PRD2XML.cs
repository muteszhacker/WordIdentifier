using System;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Collections.Generic;

namespace WordIdentifier
{
    /// <summary>
    /// Lớp chuyển đổi file PRD sang XML
    /// </summary>
    class PRD2XML
    {
        private XmlDocument doc;                        // Tài liệu XML
        private Stack<XmlNode> parentStack;             // Hàng đợi nút cha trong cây cú pháp
        private string inputFilePath;                   // Đường dẫn đến file PRD / XML
        private Dictionary<string, string> signInEng;   // Dấu câu và thẻ tương ứng
        public int wordCounter;
        public List<DictionaryItem> dict;
        private string[] sign =
                {
                    "!",    "\"",   "#",    "$",    "%",    
                    "&",    "(",    ")",    "*",    "+", 
                    ",",    "-",    ".",    "/",    ":",    
                    ";",    "<",    ">",    "?",    "@", 
                    "[",    "\\",   "]",    "^",    "_", 
                    "`",    "{",    "|",    "}",    "~", 
                    "...",  "…",    "“",    "”",    "–", 
                    "''",   "'",    "...."
                };

        /// <summary>
        /// Phương thức khởi tạo có tham số đường dẫn đến file PRD / XML
        /// </summary>
        /// <param name="inputFilePath"></param>
        public PRD2XML(string inputFilePath)
        {
            parentStack = new Stack<XmlNode>();
            this.inputFilePath = inputFilePath;
            doc = new XmlDocument();
            

            signInEng = new Dictionary<string, string>
                {
                    {"!", "EXCLAIMATION"},  {"\"", "DOUBLEQUOTE"}, 
                    {"#", "HASH"},          {"$", "DOLLAR"},  
                    {"%", "PROCENTTECKEN"}, {"&", "AMPERSAND"},
                    {"(", "LEFTPARENT"},    {")", "RIGHTPARENT"},
                    {"*", "ASTERISK"},      {"+", "PLUS"},
                    {",", "COMMA"},         {"-", "HYPHEN"},
                    {".", "DOT"},           {"/", "SLASH"},
                    {":", "COLON"},         {";", "SEMICOLON"}, 
                    {"<", "LESSTHAN"},      {">", "GREATERTHAN"}, 
                    {"?", "QUESTIONMARK"},  {"@", "ATSIGN"}, 
                    {"[", "LSQUAREBRACK"},  {"\\", "BACKSLASH"}, 
                    {"]", "RSQUAREBRACK"},  {"^", "CARET"},
                    {"_", "UNDERSCORE"},    {"`", "GRAVEACCENT"}, 
                    {"{", "LCURLYBRACK"},   {"|", "VERTICALBAR"}, 
                    {"}", "RCURLYBRACK"},   {"~", "TILDE"},
                    {"...", "ELLIPSIS"},    {"…", "ELLIPSIS"},
                    {"“", "LDOUBLEQUOTE"},  {"”", "LDOUBLEQUOTE"},
                    {"–", "HYPHEN"},        {"''", "DOUBLEQUOTE"},
                    {"'", "PRIME"}
                };
            wordCounter = 0;
        }

        /// <summary>
        /// Đọc 1 trong các thành phần: tagName, attribute, value
        /// </summary>
        /// <param name="current"></param>
        /// <param name="statement"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public string ReadElement(ref int current, StringBuilder statement, int type)
        {
            StringBuilder value = new StringBuilder("");
            string endChars = "";

            switch (type)
            {
                case 0:
                    endChars = "()- ";
                    break;
                case 1:
                    endChars = "() ";
                    break;
                case 2:
                    endChars = "()";
                    break;
                default:
                    return "";
            }

            while (current < statement.Length)
            {
                foreach (char t in endChars)
                    if (statement[current] == t)
                    {
                        string result = value.ToString();
                        switch (type)
                        {
                            case 0:
                                string eng = "";
                                return signInEng.TryGetValue(result, out eng) ? eng : result;
                            case 1:
                            case 2:
                                return result != "" ? result : null;
                            default:
                                return "";
                        }
                    }

                value.Append(statement[current++]);
            }

            return "";
        }

        /// <summary>
        /// Tạo thẻ XML
        /// </summary>
        /// <param name="current"></param>
        /// <param name="statement"></param>
        /// <param name="parent"></param>
        public void CreateTag(ref int current, StringBuilder statement, ref XmlNode parent)
        {
            if (current == statement.Length) return;
            if (statement[current] != '(') return;
            if ((++current) == statement.Length) return;

            // Đọc tên thẻ
            string tagName = ReadElement(ref current, statement, 0);
            if (tagName == "") return;
            ++wordCounter;

            // Đọc giá trị thuộc tính syntax
            string attribute = "";
            if (statement[current] == '-')
            {
                // Bỏ qua dấu cách và dấu '-'
                while (current < statement.Length
                    && (statement[current] == ' ' || statement[current] == '-'))
                    ++current;

                attribute = ReadElement(ref current, statement, 1);
                ++wordCounter;
            }

            // Bỏ qua dấu cách
            while (current < statement.Length && statement[current] == ' ')
                ++current;

            // Đọc văn bản trong thẻ
            string value = ReadElement(ref current, statement, 2);
            ++wordCounter;

            
            /*
            // if (value == "ấn tượng" && tagName == "V")
            if (value == "ða số")
                System.Diagnostics.Process.Start(inputFilePath);
            */

            int i = 0;
            
            for (i = 0; i < sign.Length; ++i)
            {
                if (value == sign[i])
                    break;
            }

            int first;
            
            if (!string.IsNullOrEmpty(value) && i == sign.Length && 
                !int.TryParse(value[0].ToString(), out first))
            {
                if (tagName != "Np")
                    value = value.ToLower();
                i = 0;
                while (i < dict.Count)
                {
                    if (dict[i].word == value && dict[i].POSTag == tagName)
                    {
                        ++dict[i].occurrence;
                        break;
                    }
                    ++i;
                }

                if (i == dict.Count)
                {
                    dict.Add(new DictionaryItem {word = value, POSTag = tagName, occurrence = 1});
                }
            }

            // Nếu sau tên thẻ là dấu ')' thì thêm thẻ vào cây XML
            while (current < statement.Length - 1 && statement[current] == ')')
            {
                if (statement[current - 1] != ')')
                {
                    XMLHelper.AddAttribute("syntax", attribute,
                        XMLHelper.AddElement(tagName, value, parent));

                    if (current == statement.Length - 2)
                        return;
                }

                if (statement[current + 1] == ')')
                {
                    if (parentStack.Count == 0)
                        return;

                    parent = parentStack.Pop();
                    ++current;
                    continue;
                }

                ++current;
                CreateTag(ref current, statement, ref parent);
                return;
            }

            // Nếu sau tên thẻ là dấu '(' thì tạo nút con XML mới
            XmlNode oldParent = parent;
            parentStack.Push(parent);
            parent = XMLHelper.AddElement(tagName, value, parent);
            XMLHelper.AddAttribute("syntax", attribute, parent);

            while (current < statement.Length && statement[current] == '(')
            {
                CreateTag(ref current, statement, ref parent);
                parent = oldParent;
            }
        }

        /// <summary>
        /// Bỏ dấu cách, tab thừa ở đầu và cuối
        /// </summary>
        /// <param name="line"></param>
        public static void RemoveSpaceBeginEnd(ref StringBuilder line)
        {
            // Bỏ dấu cách ở đầu
            int start = -1;
            while (start < line.Length - 1 && (line[start + 1] == ' ' || line[start + 1] == '\t'))
                ++start;
            if (start >= 0)
                line.Remove(0, start + 1);

            // Bỏ dấu cách ở cuối
            int end = line.Length;
            while (end > 0 && (line[end - 1] == ' ' || line[end - 1] == '\t'))
                --end;

            int length = line.Length;
            if (end < length)
                line.Remove(end, length - end);
        }

        /// <summary>
        /// Loại bỏ dấu cách, tab thừa
        /// </summary>
        /// <returns></returns>
        public static void RemoveSpace(ref StringBuilder line)
        {
            // Bỏ dấu cách, tab thừa ở đầu, cuối
            RemoveSpaceBeginEnd(ref line);

            // Bỏ dấu cách, tab thừa ở giữa
            for (int i = 0; i < line.Length - 1; ++i)
            {
                if ((line[i] == '(' || line[i] == ')') && (line[i + 1] == ' ' || line[i + 1] == '\t'))
                    line = line.Remove(i + 1, 1);

                if ((line[i] == ' ' || line[i] == '\t') && (line[i + 1] == ')' || line[i + 1] == '('))
                    line = line.Remove(i, 1);
            }
        }

        /// <summary>
        /// Chuyển đổi PRD thành XML
        /// </summary>
        /// <returns></returns>
        public XmlDocument ConvertPRD2XML(ref List<DictionaryItem> dictionary)
        {
            dict = dictionary;
            doc = new XmlDocument();

            // <?xml version="1.0" encoding="UTF-8"?>
            XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(docNode);

            // <s>
            XmlNode text = doc.CreateElement("TEXT");
            doc.AppendChild(text);

            // Đọc file
            string line;
            // Regex theRegex = new Regex(@"\([^\t\r\n\(]*");
            StringBuilder statement;
            StreamReader inputFile = new StreamReader(inputFilePath);

            do
            {
                if (inputFile.ReadLine() != "<s>") continue;
                statement = new StringBuilder("");

                do
                {
                    StringBuilder temp = new StringBuilder(inputFile.ReadLine());
                    RemoveSpace(ref temp);
                    line = temp.ToString();

                    if (string.IsNullOrEmpty(line))
                        continue;
                    if (line == "</s>")
                        break;

                    statement.Append(line);
                } while (!inputFile.EndOfStream);

                // <s>
                XmlNode s = XMLHelper.AddElement("s", null, text);

                int position = 0;
                CreateTag(ref position, statement, ref s);
            } while (!inputFile.EndOfStream);

            inputFile.Close();
            return doc;
        }

        /// <summary>
        /// Lưu tài liệu
        /// </summary>
        /// <param name="outputFilePath"></param>
        public void SaveFile(string outputFilePath)
        {
            StreamWriter outputFile = new StreamWriter(outputFilePath);
            doc.Save(outputFile);
            outputFile.Close();
        }

        /// <summary>
        /// Đọc file XML
        /// </summary>
        /// <returns></returns>
        public XmlDocument ReadInput()
        {
            try
            {
                doc.Load(inputFilePath);
                if (doc == null)
                    throw new PRDEditorException("0002");
                return doc;
            }
            catch (PRDEditorException err)
            {
                MessageBox.Show(err.ToString());
                return null;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                return null;
            }
        }
    }
}
