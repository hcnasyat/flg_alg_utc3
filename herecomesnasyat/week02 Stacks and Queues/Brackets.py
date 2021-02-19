class Solution:
    def isValid(self, s: str) -> bool:
    	# Dictionary with corresponding brackets
        dict_brackets = {'{':'}', '(':')', '[':']' }
        stack_helper = []

        for i in range(len(s)):
        	# If the character is an opening bracket, we're putting it on the stack
            if s[i] in dict_brackets.keys():
                stack_helper.append(s[i])
            else:
            	# If it's a closing bracket, we're trying to get the last element on the stack
            	# If they're not the same or the stack is empty, the sequence is wrong 
                try:
                    if s[i] != dict_brackets[stack_helper.pop()]:
                        return False
                except:
                    return False
        # If the stack is not empty, the sequence is wrong 
        if len(stack_helper) != 0:
            return False
        
        return True