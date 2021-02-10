const getNumberOfProvinces = require('./union-find-implementations');

const testData = [
    [
        [
            [1,1,0],
            [1,1,1],
            [0,1,1]
        ], 
        1 // expected number of provinces
    ],
    [
        [
            [1,0,0],
            [0,1,0],
            [0,0,1],
        ], 
        3 // expected number of provinces
    ],
    [
        [
            [1,1,0],
            [1,1,0],
            [0,0,1],
        ], 
        2 // expected number of provinces
    ],
];

describe('getNumberOfProvinces', () => {
    test.each(testData)('(%s) -> %s', (arr, expected) => {
        expect(getNumberOfProvinces(arr)).toEqual(expected);
    })
});