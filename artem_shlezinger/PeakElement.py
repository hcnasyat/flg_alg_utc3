from typing import List

class PeakElement():
    def findPeakElement(self, nums: List[int]) -> int:
        res = -1

        l = len(nums)

        p = int(l / 2);

        while True:
            if p > 0 and nums[p-1] > nums[p]:
                l = p
                p = int(p / 2)
            elif p < l - 1 and nums[p+1] > nums[p]:
                p = int((l + p) / 2)
            else:
                res = p
                break
        
        return res


peak = PeakElement()

print(peak.findPeakElement([2,3,4,3,2,1]))