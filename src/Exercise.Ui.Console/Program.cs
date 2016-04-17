using System.Linq;
using System.Text.RegularExpressions;
using Exercise.Core;

namespace Exercise.Ui.Console
{
    internal class Program
    {
        static void Main()
        {
            var regex = new Regex(@"[^\W\d](\w|[-']{1,2}(?=\w))*");
            var trie = new Trie();

            string line;
            System.Console.WriteLine("Enter one or more lines of text (press CTRL+Z to exit):");
            System.Console.WriteLine();
            do
            {
                line = System.Console.ReadLine();
                if (line != null)
                {
                    var matches = regex.Matches(line).Cast<Match>().Select(m => m.Value);
                    foreach (var word in matches)
                    {
                        trie.Put(word);
                    }
                }
            } while (line != null);

            foreach (var key in trie.Keys.OrderByDescending(key => key.Count).ThenBy(key => key.Word))
            {
                System.Console.WriteLine("{0} : {1}", key.Word, key.Count);
            }

            System.Console.ReadKey();
        }
    }
}
