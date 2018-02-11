using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.BinaryTree.exapmles
{
    public static class SortWords
    {
        public static void Sort(string sentance)
        {
            BinaryTree<string> tree = new BinaryTree<string>();
            
            // split the sentances into words (no space)
            string[] words = sentance.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // add each word to the tree
            foreach (string word in words)
            {
                tree.Add(word);
            }

            Console.WriteLine($"{tree.Count} words");

            // print each word using the default (in-order) enumerator
            foreach (string word in tree)
            {
                Console.Write($"{word} ");
            }

            Console.WriteLine();
            tree.Clear();
        }
    }
}
