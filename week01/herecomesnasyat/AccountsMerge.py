class WQUWPC:
    def __init__(self):
        """
            Initializing UF lists
        """
        self.__parent = []
        self.__size = []
    
    def append(self, ind):
        """
            We don't know the size during the init and add values to UF lists on the go
        """
        self.__parent.append(ind)
        self.__size.append(1)
    
    def find_root(self, node):
        """
            Finding root of the element + flattening the tree
        """
        while self.__parent[node] != node:
            node = self.__parent[self.__parent[node]]
            node = self.__parent[node]
        return node
        
    def union(self, node1, node2):
        """
            Weighted union of the nodes
        """
        root1 = self.find_root(node1)
        root2 = self.find_root(node2)
        
        if root1 == root2:
            return
        
        if (self.__size[root1] < self.__size[root2]):
            self.__size[root2] += self.__size[root1]
            self.__parent[root1] = root2
        else:
            self.__size[root1] += self.__size[root2]
            self.__parent[root2] = root1


class Solution:
      
    def accountsMerge(self, accounts: List[List[str]]) -> List[List[str]]:
        """
            Main method for merging accounts using UnionFind
        """
        dict_email = {}         # Email to id dictionary
        dict_email_name = {}    # Email to name dictionary
        uf = WQUWPC()           # UF object
        
        cnt = 0         # Cnt / id of emails for UF

        for i in range(len(accounts)):
            # The initial element is a name
            name = accounts[i][0]
            for j in range(1, len(accounts[i])):
                # Adding emails to the dictionary if the email is new and increasing count / id if
                email = accounts[i][j] 
                dict_email_name[email] = name
                if email not in dict_email:
                    dict_email[email] = cnt
                    uf.append(cnt)
                    cnt += 1
                # Union can be done only with the first element of the array,
                # no need to make redundant links
                uf.union(dict_email[accounts[i][1]], dict_email[email])
        

        res = collections.defaultdict(list)
        # Adding each email to their root
        for email in dict_email:
            res[uf.find_root(dict_email[email])].append(email)
                   
        # Returning the sorted array formed above +
        # the name that corresponds to those emails
        return [[dict_email_name[v[0]]] + sorted(v) for v in res.values()]
            
