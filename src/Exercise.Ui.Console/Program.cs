using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exercise.Core;

namespace Exercise.Ui.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var trie = new Trie();
            trie.Put("Hello");
            trie.Put("Hi");
            trie.Put("Hi");

            var keys = trie.Keys;

            foreach (var key in keys)
            {
                System.Console.WriteLine("{0} : {1}", key.Word, key.Count);
            }

            System.Console.ReadKey();
        }
    }
}
