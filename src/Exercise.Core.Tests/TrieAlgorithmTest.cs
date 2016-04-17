using System.Linq;
using Xunit;

namespace Exercise.Core.Tests
{
    public class TrieAlgorithmTest
    {
        [Fact]
        public void EmptyTreeShouldHaveEmptyKeysCollection()
        {
            var trie = new Trie();
            Assert.Equal(trie.Keys.Count(), 0);
        }

        [Fact]
        public void WordsShouldBeCountedProperly()
        {
            var trie = new Trie();

            string firstWord = "hi";
            string secondWord = "hello";
            string thirdWord = "who's";

            trie.Put(secondWord);
            trie.Put(secondWord);
            trie.Put(firstWord);
            trie.Put(thirdWord);
            trie.Put(thirdWord);
            trie.Put(thirdWord);

            var keys = trie.Keys;

            var first = keys.Single(key => key.Word.Equals(firstWord));
            Assert.Equal(first.Count, 1);

            var second = keys.Single(key => key.Word.Equals(secondWord));
            Assert.Equal(second.Count, 2);

            var third = keys.Single(key => key.Word.Equals(thirdWord));
            Assert.Equal(third.Count, 3);
        }
    }
}
