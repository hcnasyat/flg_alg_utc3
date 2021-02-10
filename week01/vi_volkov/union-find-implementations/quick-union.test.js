const QuickUnion = require('./quick-union');

describe('quick union', () => {
    test('check connect 10', () => {
        const qu = new QuickUnion(10);
        expect(qu.arr).toEqual([0, 1, 2, 3, 4, 5, 6, 7, 8, 9]);

        qu.connect(4, 3);
        expect(qu.arr).toEqual([0, 1, 2, 3, 3, 5, 6, 7, 8, 9]);

        qu.connect(3, 8);
        expect(qu.arr).toEqual([0, 1, 2, 8, 3, 5, 6, 7, 8, 9]);

        qu.connect(6, 5);
        expect(qu.arr).toEqual([0, 1, 2, 8, 3, 5, 5, 7, 8, 9]);

        qu.connect(9, 4);
        expect(qu.arr).toEqual([0, 1, 2, 8, 3, 5, 5, 7, 8, 8]);

        qu.connect(2, 1);
        expect(qu.arr).toEqual([0, 1, 1, 8, 3, 5, 5, 7, 8, 8]);
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

    test('check connect 6', () => {
        const qu = new QuickUnion(6);
        expect(qu.arr).toEqual([0, 1, 2, 3, 4, 5]);

        qu.connect(0, 5);
        expect(qu.arr).toEqual([5, 1, 2, 3, 4, 5]);

        qu.connect(1, 2);
        expect(qu.arr).toEqual([5, 2, 2, 3, 4, 5]);

        qu.connect(3, 4);
        expect(qu.arr).toEqual([5, 2, 2, 4, 4, 5]);

        qu.connect(2, 3);
        expect(qu.arr).toEqual([5, 2, 4, 4, 4, 5]);

        qu.connect(5, 1);
        expect(qu.arr).toEqual([5, 2, 4, 4, 4, 4]);
    })

    test('check isConnected 6', () => {
        const qu = new QuickUnion(6);
        expect(qu.isConnected(0, 5)).toBeFalsy();

        qu.connect(0, 5);
        expect(qu.isConnected(0, 5)).toBeTruthy();

        qu.connect(1, 2);
        expect(qu.isConnected(1, 2)).toBeTruthy();
        expect(qu.isConnected(3, 0)).toBeFalsy();

        qu.connect(3, 4);
        expect(qu.isConnected(3, 4)).toBeTruthy();
        expect(qu.isConnected(4, 0)).toBeFalsy();

        qu.connect(2, 3);
        expect(qu.isConnected(2, 3)).toBeTruthy();
        expect(qu.isConnected(1, 3)).toBeTruthy();

        qu.connect(5, 1);
        expect(qu.isConnected(0, 3)).toBeTruthy();
        expect(qu.isConnected(1, 5)).toBeTruthy();
    })

    test('check getNumberOfComponents 6', () => {
        const qu = new QuickUnion(6);

        expect(qu.getNumberOfComponents()).toEqual(6);

        qu.connect(0, 5);
        expect(qu.getNumberOfComponents()).toEqual(5);

        qu.connect(1, 2);
        expect(qu.getNumberOfComponents()).toEqual(4);

        qu.connect(3, 4);
        expect(qu.getNumberOfComponents()).toEqual(3);

        qu.connect(2, 3);
        expect(qu.getNumberOfComponents()).toEqual(2);

        qu.connect(5, 1);
        expect(qu.getNumberOfComponents()).toEqual(1);
    })
});