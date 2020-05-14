// This is an interactive problem, only runs on leetcode 
// https://leetcode.com/explore/challenge/card/may-leetcoding-challenge/535/week-2-may-8th-may-14th/3329/

using System;

namespace day14
{
    public class TrieNode
    {
        private TrieNode[] links;
        private int R = 26;
        private bool isEnd;

        public TrieNode()
        {
            links = new TrieNode[R];
        }

        public bool ContainsKey(char c)
        {
            return links[c - 'a'] != null;
        }

        public TrieNode Get(char c)
        {
            return links[c - 'a'];
        }

        public void Put(char c, TrieNode node)
        {
            links[c - 'a'] = node;
        }

        public void SetEnd()
        {
            isEnd = true;
        }

        public bool IsEnd()
        {
            return isEnd;
        }
    }
    public class Trie
    {
        private TrieNode root;
        /** Initialize your data structure here. */
        public Trie()
        {
            root = new TrieNode();
        }

        /** Inserts a word into the trie. */
        public void Insert(string word)
        {
            TrieNode node = root;

            for (int i = 0; i < word.Length; i++)
            {
                char c = word[i];

                if (!node.ContainsKey(c))
                {
                    node.Put(c, new TrieNode());
                }

                node = node.Get(c);
            }

            node.SetEnd();
        }

        private TrieNode searchPrefix(string word)
        {
            TrieNode node = root;

            for (int i = 0; i < word.Length; i++)
            {
                char c = word[i];

                if (node.ContainsKey(c))
                {
                    node = node.Get(c);
                }
                else
                {
                    return null;
                }
            }

            return node;
        }

        /** Returns if the word is in the trie. */
        public bool Search(string word)
        {
            TrieNode node = searchPrefix(word);
            return node != null && node.IsEnd();
        }

        /** Returns if there is any word in the trie that starts with the given prefix. */
        public bool StartsWith(string prefix)
        {
            TrieNode node = searchPrefix(prefix);
            return node != null;
        }
    }

    /**
     * Your Trie object will be instantiated and called as such:
     * Trie obj = new Trie();
     * obj.Insert(word);
     * bool param_2 = obj.Search(word);
     * bool param_3 = obj.StartsWith(prefix);
     */
}
