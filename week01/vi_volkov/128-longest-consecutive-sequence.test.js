const getLongestConsecutiveSequence = require('./128-longest-consecutive-sequence');

const testData = [
    [[100, 4, 200, 1, 3, 2], 4],
    [[1, 2, 3, 4, 5, 6], 6],
    [[0, 0, 0, 0, 0], 1],
    [[100, 200, 300, 400, 402, 401], 3],
    [[7, 0, 4, 1, 5, 6, 3, 2], 8],
    [[7, 0, 4, 1, 5, 6, 3, 2, 9, 10, 11], 8],
    [[1], 1],
    [[], 0],
];

describe('getLongestConsecutiveSequence', () => {
    test.each(testData)('(%s) -> %s', (arr, expected) => {
        expect(getLongestConsecutiveSequence(arr)).toEqual(expected);
    });
});
