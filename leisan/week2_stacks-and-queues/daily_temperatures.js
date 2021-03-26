function dailyTemperatures(T) {
    let stack = [];
    let prev = 0;
    let result = T.map(i => 0);

    for (let i = 0; i <= T.length; i++) {
        while (stack.length > 0 && T[stack[stack.length - 1]] < T[i]) {
            prev = stack.pop();
            result[prev] = i - prev;
        }
        stack.push(i);
    }
    return result;
};