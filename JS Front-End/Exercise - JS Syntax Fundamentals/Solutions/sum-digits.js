function sumDigits(num) {
    let sum = 0;

    while (num % 10 != 0) {
        sum += num % 10;
        num = Math.floor(num / 10);
    }

    console.log(sum);
}

sumDigits(543);