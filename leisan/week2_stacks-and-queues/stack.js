var Stack = function() {
    this.queue = [];
    this.tmp = [];
};

/**
 * @param {number} x
 * @returns {void}
 */
Stack.prototype.push = function(x) {
    this.queue.push(x);
};

/**
 * @returns {void}
 */
Stack.prototype.pop = function() {
    while (this.queue.length > 1){
        this.tmp.push(this.queue.shift());
    }
    this.queue.shift();
    this.queue = this.tmp;
    this.tmp = [];
};

/**
 * @returns {number}
 */
Stack.prototype.top = function() {
    while (this.queue.length > 1){
        this.tmp.push(this.queue.shift());
    }
    var ele = this.queue.shift();
    this.tmp.push(ele);
    this.queue = this.tmp;
    this.tmp = [];
    return ele;
};

/**
 * @returns {boolean}
 */
Stack.prototype.empty = function() {
    return this.queue.length === 0;

};