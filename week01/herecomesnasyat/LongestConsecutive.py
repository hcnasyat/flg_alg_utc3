class Solution:
    def find_root(self, ind):
        """
            Helping method for finding the root of the element in the tree
            With path compression
        """
        while ind != self.root_arr[ind]:
            self.root_arr[ind] = self.root_arr[self.root_arr[ind]]
            ind = self.root_arr[ind]
        return ind
    
    def longestConsecutive(self, nums):
        """
            Finding longest consecutive sequence using the UnionFind algorithm
        """
        self.root_arr = []      # Root of the elements list
        dict_ind = {}           # Dictionary of indicies
        sizes = []              # List of sizes of the tree (correct values might only be shown for roots)
        max_size = 0            # Longest consequtive sequence size
        distinct_ind = 0        # Index count for elements of the array

        for i in range(len(nums)):
            if nums[i] in dict_ind.keys():
                # If the element already is in the array, nothing to do here
                continue

            # Initializing values for the UF (corresponding index, current size, current_root, current_root_index)
            dict_ind[nums[i]] = distinct_ind
            sizes.append(1)
            self.root_arr.append(distinct_ind)
            root_lower_num_ind = distinct_ind
            
            # Looking for the smaller next number
            if (nums[i] - 1) in dict_ind.keys():
                # Finding new root for the current number, 
                # it'll be the same as the root of the next smaller value
                # (the beginning of the sequence)
                root_lower_num_ind = self.find_root(dict_ind[nums[i] - 1])
                # Changing root of the current element and correcting sizes of the trees
                self.root_arr[distinct_ind] = root_lower_num_ind
                sizes[root_lower_num_ind] += 1
                sizes[distinct_ind] = sizes[root_lower_num_ind]
                
            # Looking for the next bigger number
            if (nums[i] + 1) in dict_ind.keys():
                upper_num_ind = dict_ind[nums[i] + 1]
                # Correcting roots and changing the size of the tree at the root element
                self.root_arr[upper_num_ind] = root_lower_num_ind
                sizes[root_lower_num_ind] += sizes[upper_num_ind]

            # If current size is bigger, update max_size
            if sizes[root_lower_num_ind] >= max_size:
                max_size = sizes[root_lower_num_ind]
            distinct_ind += 1
        
        return max_size