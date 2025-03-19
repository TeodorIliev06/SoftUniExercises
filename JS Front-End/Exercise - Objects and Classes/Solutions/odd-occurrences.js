function extractOddElements(input) {
    const wordsOccurences = {};
    const words = input.toLowerCase().split(' ');

    for (const word of words) {
        if (wordsOccurences[word]) {
            wordsOccurences[word]++;
        } else {
            wordsOccurences[word] = 1;
        }

    }

    const result = [];
    for (const [word, count] of Object.entries(wordsOccurences)) {
        if(count % 2 !== 0) {
            result.push(word);
        }
    }

    console.log(result.join(' '));
}
