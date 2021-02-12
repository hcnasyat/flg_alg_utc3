class QuickUnion {
    constructor(size) {
        this.arr = [];
        
        for (let i = 0; i < size; i++) {
            this.arr[i] = i;
        }
    }

    connect(p, q) {
        const pRoot = this.getRoot(p);
        const qRoot = this.getRoot(q);

        if (pRoot !== qRoot) {
            this.arr[pRoot] = qRoot;
        }
    }

    // O(N) T | O(1) S
    isConnected(p, q) {
        const pRoot = this.getRoot(p);
        const qRoot = this.getRoot(q);

        return pRoot === qRoot;
    }

    // O(N) T | O(1) S
    getRoot(i) {
        while (this.arr[i] !== i) {
            i = this.arr[i];
        }

        return i;
    }

    // O(N) T | O(1) S
    getNumberOfComponents() {
        let count = 0;
        for (let i = 0; i < this.arr.length; i++) {
            if (this.arr[i] === i) {
                count++;
            }
        }

        return count;
    }
}

module.exports = QuickUnion;