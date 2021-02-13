def findNumbers_str(nums):
    even_cnt = 0
    
    for num in nums:
        num_digits = len(str(num))
            
        if num_digits % 2 == 0:
            even_cnt += 1
            
    return even_cnt
    
def findNumbers_int(nums):
    even_cnt = 0
    
    for num in nums:
        num_digits = 1
        
        while num >= 10:
            num = int(num / 10)
            num_digits += 1
            
        if num_digits % 2 == 0:
            even_cnt += 1
            
    return even_cnt
    
print("expected: 2, got: ", findNumbers_str([12,345,2,6,7896]))
print("expected: 1, got: ", findNumbers_str([555,901,482,1771]))

print("expected: 2, got: ", findNumbers_int([12,345,2,6,7896]))
print("expected: 1, got: ", findNumbers_int([555,901,482,1771]))
