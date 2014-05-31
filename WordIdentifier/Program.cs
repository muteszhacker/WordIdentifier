using System;
using System.Windows.Forms;

namespace WordIdentifier
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());

            /*
            DictionaryItem temp1 = new DictionaryItem()
            {
                word = "tròng",
                POSTag = "A",
                occurrence = 1
            };

            DictionaryItem temp2 = new DictionaryItem()
            {
                word = "trong",
                POSTag = "N",
                occurrence = 1
            };

            MessageBox.Show(temp1.CompareTo(temp2).ToString());*/
        }
    }
}
