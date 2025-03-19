function trackWords(input) {
    const wordsOccurences = [];
    const words = input[0].split(' ');

    for (const word of words) {
        const wordOccurence = {
            name: word,
            count:  0
        }

        wordsOccurences.push(wordOccurence);
    }

    for (const word of input.splice(1)) {
        const wordOccurence = wordsOccurences.find(w => w.name === word);

        if (wordOccurence) {
            wordOccurence.count++;
        }
    }

    wordsOccurences.sort((a, b) => b.count - a.count);

    wordsOccurences.forEach(word => {
        console.log(`${word.name} - ${word.count}`);
    });
}

trackWords([
    'this sentence', 
    'In', 'this', 'sentence', 'you', 'have', 'to', 'count', 'the', 'occurrences', 'of', 'the', 'words', 'this', 'and', 'sentence', 'because', 'this', 'is', 'your', 'task'
    ]
    );
