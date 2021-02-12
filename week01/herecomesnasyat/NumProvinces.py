class WeightedQuickUnionWithPC:
    def __init__(self, n):
        """
            Constructor, initializing arrays and size
            Parameters: 
                n - size of the UF
        """
        self.__count = n
        self.__parent = []
        self.__size = []
        for i in range(0, n):
            self.__parent.append(i)
            self.__size.append(1)

    def getCount(self):
        return self.__count

    def find_root(self, node):
        """
            Finds the root of the node, compresses the tree
            Parameters: 
                node (int) - source node, the root of which we're looking for
            Returns:
                node (int) - root of the node
        """
        while (node != self.__parent[node]):
            # path compression
            self.__parent[node] = self.__parent[self.__parent[node]]
            node = self.__parent[node]
        return node

    def union(self, node1, node2):
        """
            Changes the internal arrays, so that  two nodes become combined
            Parameters: 
                node1 (int) - one of the nodes
                node2 (int) - another node (thanks, captain)
        """

        root1 = self.find_root(node1)
        root2 = self.find_root(node2)

        if (root1 == root2):
            return

        if (self.__size[root1] < self.__size[root2]):
            self.__parent[root1] = root2
            self.__size[root2] += self.__size[root1]
        else:
            self.__parent[root2] = root1
            self.__size[root1] += self.__size[root2]
        self.__count -= 1


class Solution:
    def findCircleNum(self, isConnected):
        size = len(isConnected)
        WQUWPC = WeightedQuickUnionWithPC(size)
        for i in range(0, len(isConnected)):
            for j in range(i, len(isConnected)):
                if isConnected[i][j] == 1 and i != j:
                    WQUWPC.union(i, j)
        return WQUWPC.getCount()