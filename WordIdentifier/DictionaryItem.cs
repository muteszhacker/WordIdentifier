using System;
using System.Collections.Generic;
using System.Linq;

namespace WordIdentifier
{
    public class DictionaryItem : IComparable<DictionaryItem>, IComparable
    {
        public string word;
        public string POSTag;
        public int occurrence;

        private List<char> alphabet = new List<char>
        {
            ' ',    'A',    'a',    'Á',    'á',    'À',    'à',    'Ả', 
            'ả',    'Ã',    'ã',    'Ạ',    'ạ',    'Ă',    'ă',    'Ắ',  
            'ắ',    'Ằ',    'ằ',    'Ẳ',    'ẳ',    'Ẵ',    'ẵ',    'Ặ', 
            'ặ',    'Â',    'â',    'Ấ',    'ấ',    'Ầ',    'ầ',    'Ẩ', 
            'ẩ',    'Ẫ',    'ẫ',    'Ậ',    'ậ',    'B',    'b',    'C', 
            'c',    'D',    'd',    'Đ',    'đ',    'E',    'e',    'É', 
            'é',    'È',    'è',    'Ẻ',    'ẻ',    'Ẽ',    'ẽ',    'Ẹ', 
            'ẹ',    'Ê',    'ê',    'Ế',    'ế',    'Ề',    'ề',    'Ể', 
            'ể',    'Ễ',    'ễ',    'Ệ',    'ệ',    'F',    'f',    'G', 
            'g',    'H',    'h',    'I',    'i',    'Í',    'í',    'Ì', 
            'ì',    'Ỉ',    'ỉ',    'Ĩ',    'ĩ',    'Ị',    'ị',    'J', 
            'j',    'K',    'k',    'L',    'l',    'M',    'm',    'N', 
            'n',    'O',    'o',    'Ó',    'ó',    'Ò',    'ò',    'Ỏ', 
            'ỏ',    'Õ',    'õ',    'Ọ',    'ọ',    'Ô',    'ô',    'Ố', 
            'ố',    'Ồ',    'ồ',    'Ổ',    'ổ',    'Ỗ',    'ỗ',    'Ộ', 
            'ộ',    'Ơ',    'ơ',    'Ớ',    'ớ',    'Ờ',    'ờ',    'Ở', 
            'ở',    'Ỡ',    'ỡ',    'Ợ',    'ợ',    'P',    'p',    'Q', 
            'q',    'R',    'r',    'S',    's',    'T',    't',    'U', 
            'u',    'Ú',    'ú',    'Ù',    'ù',    'Ủ',    'ủ',    'Ũ', 
            'ũ',    'Ụ',    'ụ',    'Ư',    'ư',    'Ứ',    'ứ',    'Ừ', 
            'ừ',    'Ử',    'ử',    'Ữ',    'ữ',    'Ự',    'ự',    'V', 
            'v',    'W',    'w',    'X',    'x',    'Y',    'y',    'Ý',
            'ý',    'Ỳ',    'ỳ',    'Ỷ',    'ỷ',    'Ỹ',    'ỹ',    'Ỵ',
            'ỵ'
        };

        // Get position of ch in alphabet
        int GetPosition(char ch)
        {
            for (int i=0; i<alphabet.Count; ++i)
            {
                if (alphabet[i] == ch)
                    return i;
            }

            return 0;
        }

        // Compare 2 item
        public int CompareTo(DictionaryItem other)
        {
        /*
            int result = String.Compare(this.word, other.word, System.StringComparison.Ordinal);
            if (result != 0)
                return result;
            else
                return String.Compare(this.POSTag, other.POSTag, System.StringComparison.Ordinal);
        * */

            int word1Length = this.word.Length, word2Length = other.word.Length;
            int minLength = word1Length < word2Length ? word1Length : word2Length;

            int i = 0;

            while (i < minLength)
            {
                int pos1 = alphabet.IndexOf(this.word[i]);
                int pos2 = alphabet.IndexOf(other.word[i]);

                if (pos1 >= 0 && pos2 >= 0)
                {
                    if (pos1 < pos2)
                        return -1;
                    else if (pos1 > pos2)
                        return 1;
                }

                ++i;
            }

            return String.Compare(this.POSTag, other.POSTag, System.StringComparison.Ordinal);
        }

        // Compare with an object
        public int CompareTo(object obj)
        {
            var otherPerson = obj as DictionaryItem;

            if (otherPerson == null) throw new ArgumentException("...");

            return CompareTo(otherPerson);
        }
    }
}
