const accountsMerge = (accounts) => {
    let n = accounts.length;
    let map = new Map()
    let indexMap = new Map()
    let parent = Array(n).fill(0).map((i, index) => index)

    let sizes = Array(n).fill(0).map((i, index) => 1)
    let res = []
    const find = p => {
        while (p !== parent[p]) {
            p = parent[p];
        }
        return p;
    };

    const union = (p, q) => {
        let x = find(p);
        let y = find(q);
        if (x === y) return;

        if (sizes[x] < sizes[y]) {
            sizes[y] += sizes[x];
            parent[x] = y;
        } else {
            sizes[x] += sizes[y];
            parent[y] = x
        }

    }

    for(let i=0; i<n; i++){
        indexMap.set(i, []);
        let arr = accounts[i]
        for(let j=1; j<arr.length; j++){
            if(!map.has(arr[j])){
                map.set(arr[j], i)
                let a = indexMap.get(i);
                indexMap.set(i, a.concat(arr[j]))
            }
            union(i, map.get(arr[j]))
        }
    }

    for(let [i, emails] of indexMap){
        if(parent[i] != i){
            let arr = indexMap.get(find(i))

            arr.push(...emails)
            indexMap.delete(i)
        }
    }

    for(let [i, emails] of indexMap){
        emails.sort()
        res.push([accounts[i][0], ...emails])
    }

    return res
};
