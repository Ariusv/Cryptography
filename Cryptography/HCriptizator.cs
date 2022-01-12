using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Criptology
{
    public class HCriptizator : ICriptyzator
    {

        public HoffmanTree hTree = new HoffmanTree();

        public string Ecrypt(string text, object key)
        {
            string str = "";
            hTree.Create(text);
            var bits = hTree.enCode(text);
            foreach (bool bit in bits) str += bit ? 1 : 0;
            return str;
        }


        public string Dcrypt(string text, object key) => hTree.deCode(new BitArray(text.Select(c => c == '1').ToArray()));


        public string Replace(string text, string str1, string str2)
        {
            throw new NotImplementedException();
        }
    }
}
