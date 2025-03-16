function addAndSubtract(firstNum, secondNum, thirdNum) {
    const sum = (x, y) => x + y;
    const subtract = (sumResult, z) => sumResult - z;

    return subtract(sum(firstNum, secondNum), thirdNum);
}
