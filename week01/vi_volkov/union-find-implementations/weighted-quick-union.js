class QuickUnion {
    constructor(size) {
        this.arr = [];
        this.sizes = [];
        for (let i = 0; i < size; i++) {
            this.arr[i] = i;
            this.sizes[i] = 1;
        }
    }

    connect(p, q) {
        const pRoot = this.getRoot(p);
        const qRoot = this.getRoot(q);

        if (pRoot !== qRoot) {
            // always adding shorter tree under longer one
            if (this.sizes[pRoot] > this.sizes[qRoot]) {
                this.arr[qRoot] = pRoot;
                this.sizes[pRoot] += this.sizes[qRoot];
            } else {
                this.arr[pRoot] = qRoot;
                this.sizes[qRoot] += this.sizes[pRoot];
            }
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