class Solution:
    def isValid(self, s: str) -> bool:
        dict_brackets = {'{':'}', '(':')', '[':']' }
        stack_helper = []
        for i in range(len(s)):
            if s[i] in dict_brackets.keys():
                stack_helper.append(s[i])
            else:
                try:
                    if s[i] != dict_brackets[stack_helper.pop()]:
                        return False
                except:
                    return False
        if len(stack_helper) != 0:
            return False
        
        return True