import { UF } from './union_find';

function longestConsecutive(nums) {
    if (!nums.length) return 0;

    let map = {};
    let uf = new UF(nums.length);

    for (let i = 0; i < nums.length; i++) {
        if (map[nums[i]] === undefined) {
            map[nums[i]] = i;
        }
        if (map[nums[i] - 1] !== undefined) {
            uf.unify(map[nums[i]], map[nums[i] - 1]);
        }
        if (map[nums[i] + 1] !== undefined) {
            uf.unify(map[nums[i]], map[nums[i] + 1]);
        }
    }
    console.log(uf.id, uf.sz)
    return Math.max(...uf.sz)
};