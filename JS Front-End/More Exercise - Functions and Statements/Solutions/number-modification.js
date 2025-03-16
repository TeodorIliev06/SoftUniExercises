function modifyNumber(input) {
    function getDigitAverage(number) {
        const digits = number.toString().split('');
        const sum = digits.reduce((acc, digit) => acc + Number(digit), 0);
        
        const average = sum / digits.length;
        return average;
    }

    while (getDigitAverage(input) < 5) {
        input = input * 10 + 9;
    }

    console.log(input);
}

modifyNumber(5835);
