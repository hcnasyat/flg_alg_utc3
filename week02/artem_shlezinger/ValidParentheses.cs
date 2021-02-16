using System.Collections.Generic;

namespace Algorithms.Stacks
{
    class ValidParentheses
    {
        public bool IsValid(string s)
        {
            Stack<char> stack = new Stack<char>();

            foreach (char ch in s)
            {
                char? p = null;

                if (ch == '}' || ch == ')' || ch == ']')
                {
                    if (stack.Count > 0)
                        p = stack.Pop();

                    if(ch == '}' && p != '{' || ch == ')' && p != '(' || ch == ']' && p != '[')
                        return false;
                }
                else
                    stack.Push(ch);

            }

            if (stack.Count > 0)
                return false;

            return true;
        }
    }
}
