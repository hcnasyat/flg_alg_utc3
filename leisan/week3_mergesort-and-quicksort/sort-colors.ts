function sortColors(nums: number[]): void {
    if (nums.length < 2) return;
    let first = 0;
    let t = 0;
    let i = 0;
    let last = nums.length - 1;

    while (i <= last) {
        if (nums[i] === 0) {
            t = nums[first];
            nums[first++] = nums[i];
            nums[i++] = t;
        } else if (nums[i] === 2) {
            t = nums[i];
            nums[i] = nums[last];
            nums[last--] = t;
        } else {
            i++;
        }
    }
};