function isPerfect(number) {
    const PERFECT_NUMBER_MESSAGE = 'We have a perfect number!';
    const NOT_PERFECT_NUMBER_MESSAGE = 'It\'s not so perfect.';
    let aliqiotSum = 0;

    for (let index = 1; index < number; index++) {
        if (number % index === 0) {
            aliqiotSum += index;
        }
    }

    if (aliqiotSum === number) {
        return PERFECT_NUMBER_MESSAGE;
    }

    return NOT_PERFECT_NUMBER_MESSAGE;
}
