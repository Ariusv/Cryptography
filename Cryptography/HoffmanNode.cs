using System;
using System.Collections.Generic;
using System.Text;

namespace Criptology
{
    public class HoffmanNode
    {
        public char letter { get; set; }
        public int frequency { get; set; }
        public HoffmanNode rightChild { get; set; }
        public HoffmanNode leftChild { get; set; }

        public List<bool> Passing(char letter, List<bool> bools)
        {

            if (rightChild == null && leftChild == null)
            {
                return letter.Equals(this.letter) ? bools : null;
            }
            else
            {
                List<bool> tl = null;
                List<bool> tr = null;

                if (rightChild != null) tr = rightChild.Passing(letter, AddR(bools, true));
                if (leftChild != null) tl = leftChild.Passing(letter, AddR(bools, false));
                return (tl != null) ? tl : tr;

            }


        }

        private List<bool> AddR(List<bool> bools, bool flag)
        {
            List<bool> P = new List<bool>();
            P.AddRange(bools);
            P.Add(flag);
            return P;
        }




    }
}
