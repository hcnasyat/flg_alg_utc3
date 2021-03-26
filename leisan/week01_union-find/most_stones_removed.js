const removeStones = (stones) => {
    const uf = {};
    let islands = 0;

    const find = (x) => {

        if (!uf[x]) {
            uf[x] = x;

            islands+=1;
        }

        if (x !== uf[x]) {

            uf[x] = find(uf[x]);
        }

        return uf[x];
    }
    const union = (x,y) => {
        x=find(x);
        y=find(y);

        if (x !== y) {
            uf[x] = y;
            islands--;
        }
    }

    for (let i = 0; i < stones.length; i++) {
        union(stones[i][0], ~stones[i][1]);
    }
    return stones.length - islands;
}