function getOccurences(text, word) {
    const regex = new RegExp(`\\b${word}\\b`, 'gi');

    const matches = text.match(regex);

    const count = matches ? matches.length : 0;

    console.log(count);
}