using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1sem2
{
    [Serializable]
    class TrieNode
    {
        private bool isExists;
        private Dictionary<char, TrieNode> Childrens;

        public TrieNode()
        {
            isExists = false;
            Childrens = new Dictionary<char, TrieNode>();
        }

        public void AddElement(String NewWord)
        {
            if (NewWord.Length == 0)
                isExists = true;
            else
            {
                TrieNode tmpNode;
                if (!Childrens.ContainsKey(NewWord[0]))
                    Childrens.Add(NewWord[0], new TrieNode());
                Childrens.TryGetValue(NewWord[0], out tmpNode);
                tmpNode.AddElement(NewWord.Remove(0, 1));
            }

        }
        public bool IsElementExists(String CheckedWord)
        {
            if (CheckedWord.Length == 0)
                return isExists;
            else
            {
                if (!Childrens.ContainsKey(CheckedWord[0]))
                    return false;
                else
                {
                    TrieNode tmpNode;
                    Childrens.TryGetValue(CheckedWord[0], out tmpNode);
                    return tmpNode.IsElementExists(CheckedWord.Remove(0, 1));
                }
            }
        }
        public void DeleteElement(String DeletingWord)
        {
            if (DeletingWord.Length != 0)
            {
                if (!Childrens.ContainsKey(DeletingWord[0]))
                    throw new Exception("trying to delete unexisting string");
                else
                {
                    TrieNode tmpNode;
                    Childrens.TryGetValue(DeletingWord[0], out tmpNode);
                    tmpNode.DeleteElement(DeletingWord.Remove(0, 1));
                }
            }
            else
                isExists = false;    
        }

        public TreeNode TreeNode(string pred)
        {
           TreeNode treeNode = new TreeNode(pred);
            if (this.isExists)
                treeNode.BackColor = Color.Red;
           foreach (char symbol in Childrens.Keys)
           {
               treeNode.Nodes.Add(Childrens[symbol].TreeNode(symbol.ToString()));
           }
           return treeNode;
        }

        public void DeleteWordsContainsSubstr(string substr)
        {
            if (substr.Length == 0)
            {
                DeleteAll();
                return;
            }
            if(Childrens.ContainsKey(substr[0]))
            {
                Childrens[substr[0]].DeleteWordsContainsSubstr(substr.Substring(1));
            }
            foreach (char symbol in Childrens.Keys)
                Childrens[symbol].DeleteWordsContainsSubstr(substr);
        }

        void DeleteAll()
        {
            isExists = false;
            foreach (char symbol in Childrens.Keys)
                Childrens[symbol].DeleteAll();
        }

        public List<string> Words(string pred)
        {
            List<string> words = new List<string>();
            if (isExists)
                words.Add(pred);
            foreach (char symbol in Childrens.Keys)
                words.AddRange(Childrens[symbol].Words(pred+symbol));
            return words;
        }
    }
}
