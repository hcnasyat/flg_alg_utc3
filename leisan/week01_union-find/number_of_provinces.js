import { UF } from './union_find';

const getNumberOfProvinces = (isConnected) => {
    const n = isConnected.length;
    const uf = new UF(n);
    const set = new Set();

    for (let i = 0; i < n; i++) {
        for (let j = i + 1; j < n; j++) {
            if (isConnected[i][j]) {
                uf.unify(i, j);
            }
        }
    }

    for (let i = 0; i < n; i++) {
        set.add(uf.root(i))
    }

    return set.size;
};