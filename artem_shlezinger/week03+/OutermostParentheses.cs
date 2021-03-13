using System;
using System.Collections.Generic;

namespace Algorithms.Stacks
{
    class OutermostParentheses
    {
        public string RemoveOuterParentheses(string S)
        {
            string res = "";

			int counter = 0;
			
			foreach (char c in S)        
			{
				if (c == '(')   
				{
					if (counter > 0)   
						res = String.Concat(res, "(");

					counter++;
				}

				if (c == ')')            
				{
					counter--;
	   
					if (counter > 0)
							res = String.Concat(res, ")");                
				}
			}

			return res;
        }
    }
}
