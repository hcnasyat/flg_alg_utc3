const UF = require('./union-find-implementations/weighted-quick-union');
function getNumberOfProvinces(arr) {
    const uf = new UF(arr.length);
    
    for (let i = 0; i < arr.length; i++) {
        for (let j = i + 1; j < arr.length; j++) { // we want to traverse only top triangular of matrix
            if (arr[i][j]) {
                uf.connect(i, j);
            }
        }
    }

    return uf.getNumberOfComponents();
}

module.exports = getNumberOfProvinces;