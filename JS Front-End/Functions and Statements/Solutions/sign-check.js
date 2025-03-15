function checkSign(firstNum, secondNum, thirdNum) {
    const negativeCount = [firstNum, secondNum, thirdNum].filter(num => num < 0).length;
    
    if (negativeCount % 2 !== 0) {
        return 'Negative';
    } else {
        return 'Positive';
    }
}
