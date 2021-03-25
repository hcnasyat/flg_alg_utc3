const createMap = nums => nums.reduce((map, i) => {
    if(map[i]) {
        map[i] +=1;
    } else {
        map[i] =1;
    }
    return map;
}, {})

function intersect(nums1, nums2) {
    const result = [];
    const map1 = createMap(nums1);
    const map2 = createMap(nums2);
    
    for (let num in map1) {
        if (map2[num]) {
            let count = Math.min(map1[num], map2[num]);
            while (count > 0) {
                result.push(Number(num))
                count--;
            }
        }
    }
    return result;
};