function censor(text, word) {
    const censored = text.replaceAll(word, '*'.repeat(word.length));

    console.log(censored);
}

censor('Find the hidden word hi hidden', 'hidden');