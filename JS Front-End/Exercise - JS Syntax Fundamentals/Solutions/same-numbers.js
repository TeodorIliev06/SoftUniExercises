function checkDigits(number) {
    let sum = 0;
    const digits = number.toString().split('');
    const firstDigit = digits[0];

    const allSame = digits.every(digit => digit === firstDigit);

    for (const digit of digits) {
        sum += Number(digit);
    }

    console.log(allSame);
    console.log(sum);
}

checkDigits(2222222);