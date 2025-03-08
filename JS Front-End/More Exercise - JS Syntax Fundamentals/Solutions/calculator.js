function solve(firstNum, operator, secondNum) {
    let result;

    switch (operator) {
        case '+':
            result = firstNum + secondNum;
            break;
        case '-':
            result = firstNum - secondNum;
            break;
        case '/':
            result = firstNum / secondNum;
            break;
        case '*':
            result = firstNum * secondNum;
            break;
    }

    console.log(result.toFixed(2));
}

solve(12, '*', 12);