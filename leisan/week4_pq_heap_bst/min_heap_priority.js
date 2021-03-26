const swap = (arr, i, j) => {
    [arr[i], arr[j]] = [arr[j], arr[i]]
};

const isLessPriority = (nodeA, nodeB) => {
    if (!nodeA || !nodeB) {
        return false;
    }
    return nodeA.priority < nodeB.priority || (nodeA.priority === nodeB.priority && nodeA.val > nodeB.val);
};

class Node {
    constructor(val, priority) {
        this.val = val;
        this.priority = priority;
    }
}

class MinHeap {
    constructor(size) {
        this.size = size;
        this.data = [];
    }

    bubbleUp(index) {
        const node = this.data[index];

        while (index > 0) {
            const parentIndex = Math.floor((index - 1) / 2);
            const parent = this.data[parentIndex];

            if (isLessPriority(node, parent)) {
                swap(this.data, index, parentIndex);
                index = parentIndex;
            } else {
                break;
            }
        }
    }

    bubbleDown(index) {
        const node = this.data[index];
        while (index < this.data.length) {
            const leftIndex = 2 * index + 1;
            const rightIndex = 2 * index + 2;
            const left = this.data[leftIndex];
            const right = this.data[rightIndex];
            let smallerIndex = null;
            if (isLessPriority(left, node)) {
                smallerIndex = leftIndex;
            }
            if (smallerIndex === null && isLessPriority(right, node)) {
                smallerIndex = rightIndex;
            }
            if (smallerIndex !== null && isLessPriority(right, left)) {
                smallerIndex = rightIndex;
            }
            if (smallerIndex === null) {
                break;
            }
            swap(this.data, index, smallerIndex);
            index = smallerIndex;
        }
    }
    /**
     * T: O(LogK)
     * S: O(1)
     */
    push(val, priority) {
        const newNode = new Node(val, priority);
        if (this.data.length < this.size) {
            this.data.push(newNode);
            this.bubbleUp(this.data.length - 1);
        } else if (isLessPriority(this.data[0], newNode)) {
            this.data[0] = newNode
            this.bubbleDown(0);
        }
    }
    /**
     * T: O(LogK)
     * S: O(1)
     */
    shift() {
        const min = this.data[0];
        const lastNode = this.data.pop();
        if (this.data.length < 1) {
            return min;
        }
        this.data[0] = lastNode;
        this.bubbleDown(0);
        return min;
    }
}