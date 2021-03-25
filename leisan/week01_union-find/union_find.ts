export class UF {
    sz: number[];
    id: number[];

    constructor(n: number) {
        this.sz = [];
        this.id = [];

        for (let i = 0; i < n; i++) {
            this.id[i] = i;
            this.sz[i] = 1;
        }
    }

    root(p: number) {
        if (p !== this.id[p]) {
            this.id[p] = this.id[this.id[p]];
            p = this.id[p];
        }
        return p;
    }

    isConnected(p: number, q: number) {
        return this.root(p) === this.root(q);
    }

    unify (p: number, q: number) {
        const rootP = this.root(p);
        const rootQ = this.root(q);

        if (rootP === rootQ) return;

        if (this.sz[rootP] < this.sz[rootQ]) {
            this.sz[rootQ] += this.sz[rootP];
            this.id[rootP] = rootQ;
        } else {
            this.sz[rootP] += this.sz[rootQ];
            this.id[rootQ] = rootP;
        }

    }
}