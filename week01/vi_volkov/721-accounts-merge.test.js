const mergeAccounts = require('./721-accounts-merge');

const testData = [
    [
        [
            ['John', 'johnsmith@mail.com', 'john00@mail.com'],
            ['John', 'johnnybravo@mail.com'],
            ['John', 'johnsmith@mail.com', 'john_newyork@mail.com'],
            ['Mary', 'mary@mail.com'],
        ],
        [
            [
                'John',
                'johnsmith@mail.com',
                'john00@mail.com',
                'john_newyork@mail.com',
            ],
            ['John', 'johnnybravo@mail.com'],
            ['Mary', 'mary@mail.com'],
        ],// expected result
    ],
];

describe('mergeAccounts', () => {
    test.each(testData)('(%s) -> %s', (arr, expected) => {
        expect(mergeAccounts(arr)).toEqual(expected);
    });
});
