class MyStack:

    def __init__(self):
        """
        Initialize your data structure here.
        """
        self.__helper_q = []
        self.__q_count = 0
        

    def push(self, x: int) -> None:
        """
        Push element x onto stack.
        """
        self.__helper_q.append(x)
        for i in range(self.__q_count):
            self.__helper_q.append(self.__helper_q.pop(0))
        
        self.__q_count += 1
        

    def pop(self) -> int:
        """
        Removes the element on top of the stack and returns that element.
        """
        self.__q_count -= 1
        return self.__helper_q.pop(0)
        
        

    def top(self) -> int:
        """
        Get the top element.
        """
        return self.__helper_q[0]
        

    def empty(self) -> bool:
        """
        Returns whether the stack is empty.
        """
        if len(self.__helper_q) == 0:
            return True
        else:
            return False
        


# Your MyStack object will be instantiated and called as such:
# obj = MyStack()
# obj.push(x)
# param_2 = obj.pop()
# param_3 = obj.top()
# param_4 = obj.empty()