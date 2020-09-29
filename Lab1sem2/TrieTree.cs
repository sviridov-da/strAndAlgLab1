using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1sem2
{
    [Serializable]
    class TrieTree : ITrieTree
    {
        private TrieNode head;

        public TrieTree()
        {
            head = new TrieNode();
        }

        public void AddElement(string NewWord)
        {
            if (NewWord.Length != 0)
                head.AddElement(NewWord);
            else
                throw new Exception("trying to add an empty string");
        }

        public void DeleteElement(string DeletingWord)
        {
            if ((DeletingWord.Length != 0) && (head.IsElementExists(DeletingWord)))
                head.DeleteElement(DeletingWord);
            else
                throw new Exception("trying to delete an empty or unexisting string");
        }

        public void deleteWordsContainsSubstr(string Substring)
        {
            Head.DeleteWordsContainsSubstr(Substring);
        }

        

        public bool isElementExists(string CheckedWord)
        {
            if (CheckedWord.Length != 0)
                return head.IsElementExists(CheckedWord);
            else
                throw new Exception("trying to check empty string");
        }

        public TrieNode Head
        {
            get { return head; }
        }

        public List<string> Words
        {
            get
            {
                List<string> words = new List<string>();
                if (Head != null)
                    words.AddRange(Head.Words(""));
                return words;
            }
        }
    }
}
