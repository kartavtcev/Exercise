using System.Collections.Generic;
using System.Text;

namespace Exercise.Core
{
    public class Trie
    {
        private const int R = 256;  // extended ASCII
        private Node _root;
        
        private int ArrayIndexByChar(char c)
        {
            return c - ((char) 0);
        }

        private char CharByArrayIndex(int i)
        {
            return (char) i;
        }

        private class Node
        {
            public readonly Node[] Next = new Node[R];
            public int Count = 0;
        }

        public void Put(string key)
        {
            _root = Put(_root, key.ToLowerInvariant(), 0);
        }

        private Node Put(Node x, string key, int d)
        {
            if(x == null) { x = new Node(); }
            if (d == key.Length)
            {
                x.Count++;
                return x;
            }
            int i = ArrayIndexByChar(key[d]);
            x.Next[i] = Put(x.Next[i], key, d + 1);
            return x;
        }

        public IEnumerable<Quant> Keys
        {
            get
            {
                IList<Quant> keys = new List<Quant>();
                Collect(_root, new StringBuilder(), keys);
                return keys;
            }
        }

        private void Collect(Node x, StringBuilder word, IList<Quant> keys)
        {
            if (x == null) { return; }
            if (x.Count > 0) { keys.Add(new Quant(word.ToString(), x.Count)); }
            for (int i = 0; i < R; i++)
            {
                char c = CharByArrayIndex(i);
                word.Append(c);
                Collect(x.Next[i], word, keys);
                word.Length--;
            }
        }
    }
}
