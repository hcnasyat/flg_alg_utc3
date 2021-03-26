var regionsBySlashes = function(grid) {
    const n = grid.length;
    if (n === 1) return grid[0][0] === ' ' ? 1 : 2;
    let count = n * n * 2;
    let parents = Array(count).fill(0).map((_, i) => i);
    let sizes = Array(count).fill(0);

    const find = p => {
        if (p !== parents[p]) {
            parents[p] = find(parents[p]);
        }
        return parents[p];
    }
    const union = (p, q) => {
        let parentP = find(p);
        let parentQ = find(q);
        if (parentP === parentQ) return;

        if (sizes[parentP] < sizes[parentQ]) {
            sizes[parentQ] += sizes[parentP];
            parents[parentP] = parentQ;
        } else {
            sizes[parentP] += sizes[parentQ];
            parents[parentQ] = parentP;
        }
        count--;
    }
    const getKeys = (i, j, n) => {
        var pos = i * n + j;
        return [pos*2, pos*2 + 1];
    }


    for (let i = 0; i < grid.length; i++) {
        for (let j = 0; j < grid.length; j++) {
            let [left, right] = getKeys(i, j, n);
            if (grid[i][j] === ' ') union(left, right);
            if (i !== 0) {
                let [upLeft, upRight] = getKeys(i - 1, j, n);
                let up = grid[i - 1][j] === '/' ? upRight : upLeft;
                let current = grid[i][j] === '/' ? left : right;
                union(up, current);
            }
            if (j !==0) {
                let [leftLeft, leftRight] = getKeys(i, j - 1, n);
                union(leftRight, left)
            }
        }
    }

    return count;
};