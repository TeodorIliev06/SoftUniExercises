function calculate(firstNum, secondNum, operator) {
    const operations = {
        'multiply': (a, b) => a * b,
        'divide': (a, b) => a / b,
        'add': (a, b) => a + b,
        'subtract': (a, b) => a - b
    }

    return operations[operator](firstNum, secondNum);
}

console.log(calculate(5, 5, 'multiply'));
