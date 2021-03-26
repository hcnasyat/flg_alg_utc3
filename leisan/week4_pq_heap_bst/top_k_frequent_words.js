class MaxHeap {
    constructor(size) {
        this.data = [];
        this.size = size;
    }

    compare(nodeA, nodeB) {
        if (!nodeA || !nodeB) return false;
        if (nodeA.count === nodeB.count) {
            return nodeA.val < nodeB.val;
        }
        return nodeA.count > nodeB.count;
    }

    swap(i, j) {
        [this.data[i], this.data[j]] = [this.data[j], this.data[i]]
    }

    bubbleUp() {
        let index = this.data.length - 1;
        const node = this.data[index];

        while (index > 0) {
            const parentIndex = Math.floor((index - 1) / 2);
            const parent = this.data[parentIndex];

            if (this.compare(node, parent)) {
                this.swap(index, parentIndex);
                index = parentIndex;
            } else {
                break;
            }
        }
    }
    bubbleDown() {
        let index = 0
        const node = this.data[index];
        while (index < this.data.length) {
            const leftIndex = 2 * index + 1;
            const rightIndex = 2 * index + 2;
            const left = this.data[leftIndex];
            const right = this.data[rightIndex];
            let smallerIndex = null;
            if (this.compare(left, node)) {
                smallerIndex = leftIndex;
            }
            if (smallerIndex === null && this.compare(right, node)) {
                smallerIndex = rightIndex;
            }
            if (smallerIndex !== null && this.compare(right, left)) {
                smallerIndex = rightIndex;
            }
            if (smallerIndex === null) {
                break;
            }
            this.swap(index, smallerIndex);
            index = smallerIndex;
        }
    }

    push(newNode) {
        this.data.push(newNode);
        this.bubbleUp();
    }

    shift() {
        let max = this.data[0];
        let last = this.data.pop()
        this.data[0] = last;
        this.bubbleDown();
        return max;
    }
}

function topKFrequent(words, k) {
    let heap = new MaxHeap(k);
    let result = []
    let map = words.reduce((sum, i) => {
        sum[i] = sum[i] + 1 || 1;
        return sum;
    }, {});

    for(let i in map) {
        heap.push({val: i, count: map[i]})
    }
    for (let i=0; i < k; i++) {
        result.push(heap.shift().val)
    }

    return result;
};