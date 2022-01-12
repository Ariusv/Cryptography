using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Criptology
{
    public class VCriptyzator:ICriptyzator
    {
        private string Cyralfabet;
        private string Latalfabet;
        private string cyralfabet;
        private string latalfabet;
        private string symbs;
        private string nums;


        public VCriptyzator()
        {
            Cyralfabet = "АБВГДЕЄЖЗИІЇЙКЛМНОПРСТУФХЦЧШЩЬЮЯ";
            Latalfabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            cyralfabet = Cyralfabet.ToLower();
            latalfabet = Latalfabet.ToLower();
            symbs = ".,/.-:()[]{}!@#$%^&*_+=-? ";
            nums = "1234567890";

        }
        private string Vigenere(string text, string password, bool encrypting = true)
        {
            string repkey = Key(password, text.Length);
            string retValue = "";

            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsLetter(text[i]))
                {
                    if (cyralfabet.Contains(text[i].ToString()))
                    {
                        retValue += SupportFunc(cyralfabet, repkey, text, i, encrypting);
                    }
                    else if (latalfabet.Contains(text[i].ToString()))
                    {
                        retValue += SupportFunc(latalfabet, repkey, text, i, encrypting);
                    }
                    else if (Cyralfabet.Contains(text[i].ToString()))
                    {
                        retValue += SupportFunc(Cyralfabet, repkey, text, i, encrypting);
                    }
                    else if (Latalfabet.Contains(text[i].ToString()))
                    {
                        retValue += SupportFunc(Latalfabet, repkey, text, i, encrypting);
                    }
                    //else if (nums.Contains(text[i].ToString()))
                    //{
                    //    retValue += SupportFunc(nums, repkey, text, i, encrypting);
                    //}
                    //else if (symbs.Contains(text[i].ToString()))
                    //{
                    //    retValue += SupportFunc(symbs, repkey, text, i, encrypting);
                    //}
                }
                else
                {
                    retValue += text[i];
                }
            }

            return retValue;
        }

        private string Key(string key, int count)
        {
            string str = key;

            while (str.Length < count)
            {
                str += str;
            }

            return str.Substring(0, count);
        }


        private string SupportFunc(string alphabet, string repkey, string text, int i, bool encrypting)
        {
          
            int q = alphabet.Length;
            int lIndex = alphabet.IndexOf(text[i]);
            int cIndex = alphabet.IndexOf(repkey[i]);
            if (lIndex >= 0)
                return alphabet[(q + lIndex + ((encrypting ? 1 : -1) * cIndex)) % q].ToString();
            else
                return text[i].ToString();
        }

        public string Ecrypt(string text, object key) => Vigenere(text, (string)key);

        public string Dcrypt(string text, object key) => Vigenere(text, (string)key, false);

        public string Replace(string text, string str1, string str2)
        {
            throw new NotImplementedException();
        }
    }
}
