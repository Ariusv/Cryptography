using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Criptology
{
    public class HoffmanTree
    {
        public HoffmanNode root { get; set; }
        private List<HoffmanNode> nodes = new List<HoffmanNode>();
        public Dictionary<char, int> frequenceTable = new Dictionary<char, int>();

        public void Create(string massage)
        {
            foreach (var latter in massage)
            {
                if (!frequenceTable.ContainsKey(latter)) frequenceTable.Add(latter, 0);
                frequenceTable[latter]++;
            }

            foreach (var latter in frequenceTable)
            {
                HoffmanNode tnode = new HoffmanNode();
                tnode.letter = latter.Key;
                tnode.frequency = latter.Value;
                nodes.Add(tnode);
            }

            while (nodes.Count != 1)
            {
                List<HoffmanNode> sortedNodes = nodes.OrderBy(node => node.frequency).ToList();

                if (sortedNodes.Count > 1)
                {

                    List<HoffmanNode> temp = sortedNodes.Take(2).ToList();

                    HoffmanNode tnode = new HoffmanNode();


                    tnode.leftChild = temp[0];
                    nodes.Remove(temp[0]);

                    tnode.rightChild = temp[1];
                    nodes.Remove(temp[1]);

                    tnode.letter = ' ';
                    tnode.frequency = temp[0].frequency + temp[1].frequency;

                    nodes.Add(tnode);
                }

                root = nodes.FirstOrDefault();
            }
        }
        public Dictionary<char, List<bool>> GetLettersCodes()
        {
            var values = frequenceTable.Keys.ToList();

            Dictionary<char, List<bool>> lattersCodes = new Dictionary<char, List<bool>>();

            foreach (var value in values) lattersCodes.Add(value, root.Passing(value, new List<bool>()));

            return lattersCodes;
        }

        public BitArray enCode(string massage)
        {
            List<bool> eMassage = new List<bool>();
            Dictionary<char, List<bool>> lattersCodes = GetLettersCodes();

            foreach (var latter in massage)
            {
                if (lattersCodes.ContainsKey(latter)) eMassage.AddRange(lattersCodes[latter]);
            }
            return new BitArray(eMassage.ToArray());
        }

        public string deCode(BitArray bits)
        {
            var cur = root;
            var dec = "";

            foreach (bool bit in bits)
            { 
                if (bit&&cur.rightChild != null) cur = cur.rightChild;
                else if (cur.leftChild != null) cur = cur.leftChild;

                if (IsLeaf(cur))
                {
                    dec += cur.letter;
                    cur = root;
                }
            }

            return dec;
        }

       


        private bool IsLeaf(HoffmanNode node)
        {
            return (node.leftChild == null && node.rightChild == null);
        }
    }
}
