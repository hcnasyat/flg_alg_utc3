const UF = require('./union-find-implementations/weighted-quick-union');

// O(N) T, O(N) S
function getLongestConsecutiveSequence(arr) {
    if (arr.length === 0) return 0;
    
    const uf = new UF(arr.length); // O(N)
    const map = {}; // map from number to it's id in arr, duplicates will have same id

    for (let i = 0; i < arr.length; i++) {
        if (map[arr[i]] === undefined) {
            map[arr[i]] = i;
        }

        if (map[arr[i] - 1] !== undefined) {
            uf.connect(map[arr[i] - 1], map[arr[i]]); // connecting indexes of numbers, not numbers itself
        }
        
        if (map[arr[i] + 1] !== undefined) {
            uf.connect(map[arr[i] + 1], map[arr[i]]);
        }
    }

    return Math.max(...uf.sizes); // O(N)
}

module.exports = getLongestConsecutiveSequence;

// mistakes:
// 1. had if else instead of 2 ifs on lines 13 and 17, which ignored nodes which had smaller and bigger element before them