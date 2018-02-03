using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.Net
{
    class LinkedListCSharp
    {

        public static void TestLinkedList()
        {
            LinkedList<int> list = new LinkedList<int>();
            list.AddLast(3);
            list.AddLast(5);
            list.AddLast(7);

            foreach (int value in list)
            {
                Console.WriteLine(value);
            }
        }
    }
}
