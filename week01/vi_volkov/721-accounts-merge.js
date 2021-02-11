const UnionFind = require('./implementations/weighted-quick-union');
// TODO: find out actual time complexity of algorithm as not clear what is T of union and find
function mergeAccounts(arr) {
    const emailMap = new Map();
    let emailCount = 0;

    // O(M*N) T
    // initializing email -> UF node id map, duplicates will have the same id
    for (let emails of arr) {
        for (let i = 1; i < emails.length; i++) {
            if (!emailMap.has(emails[i])) {
                emailMap.set(emails[i], { id: emailCount++, name: emails[0] });
            }
        }
    }

    let UF = new UnionFind(emailCount);

    // O(M*N) T
    // connecting emails in the same accounts
    for (let emails of arr) {
        if (emails.length < 3) continue; // because arr[0] is name, If arr.length < 3 - there is nothing to connect

        for (let i = 2; i < emails.length; i++) {
            let prevEmail = emails[i - 1];
            let currEmail = emails[i];

            UF.connect(emailMap.get(prevEmail).id, emailMap.get(currEmail).id);
        }
    }

    const components = new Map();

    // O(M*N) T
    // getting disjoint components
    for (let email of emailMap.keys()) {
        let val = emailMap.get(email);
        let root = UF.getRoot(val.id);
        let groupedEmails = components.get(root);
        
        if (!groupedEmails) {
            components.set(root, [val.name, email]);
        } else {
            groupedEmails.push(email);            
        }
    }

    return [...components.values()];
}

module.exports = mergeAccounts;