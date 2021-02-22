class Stack:

    class Node:
        def __init__(self, name):
            self.Name = name
            self.NextNode = None

    first = None

    def Push(self, item):
        node = self.Node(item)

        node.NextNode = self.first
        self.first = node

    def Pop(self):
        name = self.first.Name
        self.first = self.first.NextNode
        return name


##################### Tests #####################

stack = Stack()

stack.Push("A")
stack.Push("B")
stack.Push("C")

print(stack.Pop())
print(stack.Pop())

