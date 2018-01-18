using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            TestNode();

            Console.ReadLine();
        }

        private static void TestNode()
        {
            // +------+-------+
            // |  3   |  null |
            // +------+-------+
            Node first = new Node { Value = 3 };

            // +------+-------+     +-------+-------+
            // |  3   |  null |     |   5   |  null |
            // +------+-------+     +-------+-------+
            Node middle = new Node { Value = 5 };

            // +------+-------+     +-------+-------+
            // |  3   |  *----|---->|   5   |  null |
            // +------+-------+     +-------+-------+
            first.Next = middle;

            // +------+-------+     +-------+-------+       +-------+-------+
            // |  3   |  *----|---->|   5   |  null |       |   7   |  null |
            // +------+-------+     +-------+-------+       +-------+-------+
            Node last = new Node { Value = 7 };

            // +------+-------+     +-------+-------+       +-------+-------+
            // |  3   |  *----|---->|   5   |  *----|----- >|   7   |  null |
            // +------+-------+     +-------+-------+       +-------+-------+
            middle.Next = last;

            // print linked list
            PrintList(first);
        }

        private static void PrintList(Node node)
        {
            while(node != null)
            {
                Console.WriteLine(node.Value);
                node = node.Next;
            }
        }
    }
}
