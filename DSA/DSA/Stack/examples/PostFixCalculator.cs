using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.Stack.examples
{
    public static class PostFixCalculator
    {

        // calc example : 5 6 7 * + 1 -
        public static int Evaluate(string[] postFix)
        {
            // stack of integers
            System.Collections.Generic.Stack<int> values = new Stack<int>();

            foreach (string token in postFix)
            {
                int value;
                if(int.TryParse(token,out value))
                {
                    values.Push(value);
                }
                else
                {
                    int rhs = values.Pop();
                    int lhs = values.Pop();

                    switch (token)
                    {
                        case "+":
                            values.Push(lhs + rhs);
                            break;
                        case "-":
                            values.Push(lhs - rhs);
                            break;
                        case "*":
                            values.Push(lhs * rhs);
                            break;
                        case "/":
                            values.Push(lhs / rhs);
                            break;
                        case "%":
                            values.Push(lhs % rhs);
                            break;
                        default:
                            throw new ArgumentException($"Unrecognized token: {token}");
                    }
                }
            }

            return values.Peek();
        }

    }
}
