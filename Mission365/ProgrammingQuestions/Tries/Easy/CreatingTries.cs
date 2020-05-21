using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureAlgorithm.ProgrammingQuestions.Tries.Easy
{
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class TriesTest
    {
        [TestMethod]
        public void MyTestMethod()
        {
            Trie obj = new Trie();
            obj.Insert("apple");
            bool param_true = obj.Search("apple");
            bool param_false = obj.Search("app");
            bool param_3true = obj.StartsWith("app");
            obj.Insert("app");
            bool param_2true = obj.Search("app");
        }
    }
    public class TrieData
    {
        public char val;
        public bool isEnd;
        public Dictionary<char, TrieData> child;
        public TrieData(char c, bool isEndword)
        {
            val = c;
            isEnd = isEndword;
            child = new Dictionary<char, TrieData>();
        }
    }
    public class Trie
    {
        private TrieData root;
        /** Initialize your data structure here. */
        public Trie()
        {
            root = new TrieData('*', false);
        }

        /** Inserts a word into the trie. */
        public void Insert(string word)
        {
            Dictionary<Char, TrieData> child = root.child;
            TrieData current = null;
            for (int i = 0; i < word.Length; i++)
            {
                bool isEnd = (i == word.Length - 1);
                char c= word[i];
                if (child != null && child.ContainsKey(c))
                {
                       current = child[c];
                       child = child[c].child;
                    continue;
                }
                TrieData newItem = new TrieData(c, isEnd);
                current = newItem;
                child.Add(c, newItem);
                child = newItem.child;
            }
            if (current != null)
            {
                current.isEnd = true;
            }
        }

        /** Returns if the word is in the trie. */
        public bool Search(string word)
        {
            Dictionary<Char, TrieData> child = root.child;
            TrieData current=null;
            for (int i = 0; i < word.Length; i++)
            {
                char c= word[i];
                if (child != null && child.ContainsKey(c))
                {
                    current = child[c];
                    child = child[c].child;
                    continue;
                }
                return false;
            }
            if (current != null && current.isEnd) return true;
            return false;

        }

        /** Returns if there is any word in the trie that starts with the given prefix. */
        public bool StartsWith(string prefix)
        {
            Dictionary<Char, TrieData> child = root.child;
            for (int i = 0; i < prefix.Length; i++)
            {
                char c = prefix[i];
                if (child != null && child.ContainsKey(c))
                {
                    child = child[c].child;
                    continue;
                }
                return false;
            }
            return true;
        }
    }

    /**
     * Your Trie object will be instantiated and called as such:
     * Trie obj = new Trie();
     * obj.insert(word);
     * boolean param_2 = obj.search(word);
     * boolean param_3 = obj.startsWith(prefix);
     */
}
