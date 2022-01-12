using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Criptology
{
    public class FCriptyzator:ICriptyzator
    {
        Dictionary<char, double> fTable;

        public FCriptyzator(string frequencyPath)
        {
            fTable = File.ReadLines(frequencyPath).Select(l => l.Split(' ')).ToDictionary(k => Convert.ToChar(k[1]), k => Convert.ToDouble(k[0])); ;
        }

        public string Replace(string str, string str1, string str2)
        {


            return str
                .Replace(char.ToUpper(Convert.ToChar(str1)), char.ToUpper(Convert.ToChar(str2)))
                .Replace(char.ToLower(Convert.ToChar(str1)), char.ToLower(Convert.ToChar(str2)));
        }
        public string Ecrypt(string text, object key = null)
        {


            return text;
        }
        public string Dcrypt(string text, object key = null)
        {
            string result = "";

            Dictionary<char, double> sortFTable = fTable.OrderByDescending(u => u.Value).ToDictionary(z => z.Key, y => y.Value);
            Dictionary<char, double> cFTable = TextFrequency(text.ToUpper()).OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);


            for (int i = 0; i<text.Length; i++)
            {
                if (char.IsLetter(text[i]))
                {
                    int pos = Index(cFTable, Convert.ToChar(text[i].ToString().ToUpper()));
                    char cod = sortFTable.ElementAt(pos).Key;
                    cod = (char.IsUpper(text[i])) ? (char.ToUpper(cod)) : (char.ToLower(cod));
                    result+=cod;
                }
                else
                {
                    result += text[i];
                }
            }

            return result;
        }


        private int Index(Dictionary<char, double> dict, char k)
        {
            for (int i = 0; i < dict.Count; i++)
            {
                if (dict.ElementAt(i).Key.Equals(k)) return i; 
            }

            return -1;
        }
        private Dictionary<char, double> TextFrequency(string text)
        {
            string str = "";
            foreach (var letter in text)
            {
                if (char.IsLetter(letter))
                {
                    str+=letter;
                }
            }
            Dictionary<char, double> dict = new Dictionary<char, double>();
            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsLetter(text[i]))
                {
                    if (dict.ContainsKey(text[i])) dict[text[i]]++;
                    else dict.Add(text[i], 1);
                }
            }

            foreach (var key in dict.Keys.ToList())
            {
                dict[key] = (dict[key]/str.Length)*100;
            }
            return dict;
        }




        
    }
}
