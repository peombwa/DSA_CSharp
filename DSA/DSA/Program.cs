using DSA.BinaryTree.exapmles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] postFix = new string[] { "5", "6", "7", "*", "+", "1", "-" };
            // Net.LinkedListCSharp.TestLinkedList();
            // Console.WriteLine(Stack.examples.PostFixCalculator.Evaluate(postFix));
            string input = string.Empty;

            while (!input.Equals("quit", StringComparison.CurrentCultureIgnoreCase))
            {
                // read the line from the user
                Console.Write("> ");
                input = Console.ReadLine();

                SortWords.Sort(input);
            }
            Console.ReadLine();
        }
    }
}
