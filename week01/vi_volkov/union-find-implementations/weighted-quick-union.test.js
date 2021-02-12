const QuickUnion = require('./weighted-quick-union');

describe('weighted quick union', () => {
    test('check connect 10', () => {
        const qu = new QuickUnion(10);
        expect(qu.arr).toEqual([0, 1, 2, 3, 4, 5, 6, 7, 8, 9]);
        expect(qu.sizes).toEqual([1, 1, 1, 1, 1, 1, 1, 1, 1, 1]);

        qu.connect(4, 3);
        expect(qu.arr).toEqual([0, 1, 2, 3, 3, 5, 6, 7, 8, 9]);
        expect(qu.sizes).toEqual([1, 1, 1, 2, 1, 1, 1, 1, 1, 1]);

        qu.connect(3, 8);
        expect(qu.arr).toEqual([0, 1, 2, 3, 3, 5, 6, 7, 3, 9]);
        expect(qu.sizes).toEqual([1, 1, 1, 3, 1, 1, 1, 1, 1, 1]);

        qu.connect(6, 5);
        expect(qu.arr).toEqual([0, 1, 2, 3, 3, 5, 5, 7, 3, 9]);
        expect(qu.sizes).toEqual([1, 1, 1, 3, 1, 2, 1, 1, 1, 1]);

        qu.connect(9, 4);
        expect(qu.arr).toEqual([0, 1, 2, 3, 3, 5, 5, 7, 3, 3]);
        expect(qu.sizes).toEqual([1, 1, 1, 4, 1, 2, 1, 1, 1, 1]);

        qu.connect(2, 1);
        expect(qu.arr).toEqual([0, 1, 1, 3, 3, 5, 5, 7, 3, 3]);
        expect(qu.sizes).toEqual([1, 2, 1, 4, 1, 2, 1, 1, 1, 1]);

        qu.connect(3, 5);
        expect(qu.arr).toEqual([0, 1, 1, 3, 3, 3, 5, 7, 3, 3]);
        expect(qu.sizes).toEqual([1, 2, 1, 6, 1, 2, 1, 1, 1, 1]);

        qu.connect(3, 1);
        expect(qu.arr).toEqual([0, 3, 1, 3, 3, 3, 5, 7, 3, 3]);
        expect(qu.sizes).toEqual([1, 2, 1, 8, 1, 2, 1, 1, 1, 1]);
    })

    test('check isConnected 10', () => {
        const qu = new QuickUnion(10);
        qu.connect(4, 3);
        qu.connect(3, 8);
        qu.connect(6, 5);
        qu.connect(9, 4);
        qu.connect(2, 1);

        expect(qu.isConnected(8, 9)).toBeTruthy();
        expect(qu.isConnected(5, 4)).toBeFalsy();
        expect(qu.isConnected(4, 9)).toBeTruthy();
        expect(qu.isConnected(1, 2)).toBeTruthy();
        expect(qu.isConnected(5, 6)).toBeTruthy();
    })
});