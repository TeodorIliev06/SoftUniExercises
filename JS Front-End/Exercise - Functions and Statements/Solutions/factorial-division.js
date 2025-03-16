function divideFactorials(firstNum, secondNum) {
    function getFactorial(num, memo = {}) {
        if (num <= 1) {
            return 1;
        }
    
        if (memo[num]) {
            return memo[num];
        }
    
        memo[num] = num * getFactorial(num - 1, memo);
        return memo[num];
    }

    const firstFactorial = getFactorial(firstNum);
    const secondFactorial = getFactorial(secondNum);

    return (firstFactorial / secondFactorial).toFixed(2);
}

console.log(divideFactorials(6, 3));
