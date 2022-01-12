using System;

namespace Criptology
{
    public class CaeserCriptyzator : ICriptyzator
    {
        private string Cyralfabet;
        private string Latalfabet;
        private string cyralfabet;
        private string latalfabet;
        private string symbs;
        private string nums;
        public CaeserCriptyzator()
        {
            Cyralfabet = "АБВГДЕЄЖЗИІЇЙКЛМНОПРСТУФХЦЧШЩЬЮЯ";
            Latalfabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            cyralfabet = Cyralfabet.ToLower();
            latalfabet = Latalfabet.ToLower();
            symbs = ".,/.-()[]{}!@#$%^&*_+=-?";
            nums = "1234567890";

        }
        private string Algo(string text, int k)
        {
            string str = "";
            for (int i = 0; i < text.Length; i++)
            {
                var c = text[i];
                if (cyralfabet.Contains(c.ToString()))
                {
                    str += SupportFunc(c, cyralfabet, k);
                }
                else if (latalfabet.Contains(c.ToString()))
                {
                    str += SupportFunc(c, latalfabet, k);
                }
                else if (Cyralfabet.Contains(c.ToString()))
                {
                    str += SupportFunc(c, Cyralfabet, k);
                }
                else if (Latalfabet.Contains(c.ToString()))
                {
                    str += SupportFunc(c, Latalfabet, k);
                }
                else if (nums.Contains(c.ToString()))
                {
                    str += SupportFunc(c, nums, k);
                }
                else if (symbs.Contains(c.ToString()))
                {
                    str += SupportFunc(c, symbs, k);
                }
                else
                {
                    str += c;
                }
            }

            return str;
        }

        private string SupportFunc(char c, string alf, int k)
        {
            string str = "";
            int count = alf.Length;
            int ind = alf.IndexOf(c);
            if (ind < 0) str += c;
            else str += alf[(count + ind + k) % count];
            return str;
        }
        public string Ecrypt(string text, object key) => Algo(text, (int)key);

        public string Dcrypt(string text, object key)
        {
            int k = (int)key;
            return Algo(text, -k);
        }

        public string Replace(string text, string str1, string str2)
        {
            throw new NotImplementedException();
        }
    }
}
