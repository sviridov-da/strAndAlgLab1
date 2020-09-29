using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1sem2
{

    interface ITrieTree
    {
        void AddElement(String NewWord);
        void DeleteElement(String DeletingWord);
        bool isElementExists(String CheckedWord);
        void deleteWordsContainsSubstr(String Substring);
        TrieNode Head { get; }
        List<string> Words { get; }
    }
}
