function getStringMatches(parameter, text) {
    const WORD_NOT_FOUND_MESSAGE = `${parameter} not found!`;

    const words = text.toLowerCase().split(' ');

    for (const word of words) {
        if (word === parameter) {
            return parameter;
        }
    }

    return WORD_NOT_FOUND_MESSAGE;
}

console.log(getStringMatches('python', 'JavaScript is the best programming language'));
