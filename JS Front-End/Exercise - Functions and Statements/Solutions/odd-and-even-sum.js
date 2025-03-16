function printOddAndEvenSums(input) {
    let oddSum = 0, evenSum = 0;

    while (input !== 0) {
        const currentDigit = input % 10;

        if (currentDigit % 2 === 0) {
            evenSum += currentDigit;
        } else {
            oddSum += currentDigit
        }

        input = Math.floor(input / 10);
    }

    console.log(`Odd sum = ${oddSum}, Even sum = ${evenSum}`);
}

printOddAndEvenSums(3495892137259234);
