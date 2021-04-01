class MinHeap {
    constructor(size) {
        this.data = [];
        this.size = size;
    }

    compare(nodeA, nodeB) {
        return nodeA < nodeB;
    }
    getMin() {
        return this.data[0];
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
        if (this.data.length < this.size) {
            this.data.push(newNode);
            this.bubbleUp();
        } else if (this.compare(this.data[0], newNode)){
            this.data[0] = newNode;
            this.bubbleDown();
        }
    }
}


class KthLargest {
    constructor(k: number, nums: number[]) {
        this.pq = new MinHeap(k);
        for (let i = 0; i < nums.length; i++) {
            this.pq.push(nums[i]);
        }
    }

    add(val: number): number {
        this.pq.push(val)
        return this.pq.getMin()
    }
}

/**
 * Your KthLargest object will be instantiated and called as such:
 * var obj = new KthLargest(k, nums)
 * var param_1 = obj.add(val)
 */