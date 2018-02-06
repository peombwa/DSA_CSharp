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
            Console.WriteLine(Stack.examples.PostFixCalculator.Evaluate(postFix));

            Console.ReadLine();
        }
    }
}
