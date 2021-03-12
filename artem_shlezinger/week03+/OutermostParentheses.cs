using System;
using System.Collections.Generic;

namespace Algorithms.Stacks
{
    class OutermostParentheses
    {
        public string RemoveOuterParentheses(string S)
        {
            Stack<char> stack = new Stack<char>();

            string res = "";

            foreach (char c in S)
            {
                if (c == '(')
                {
                    if (stack.Count > 0)
                        res = String.Concat(res, "(");

                    stack.Push(c);
                }

                if (c == ')')
                {
                    stack.Pop();

                    if (stack.Count > 0)
                        res = String.Concat(res, ")");
                }
            }

            return res;
        }
    }
}
