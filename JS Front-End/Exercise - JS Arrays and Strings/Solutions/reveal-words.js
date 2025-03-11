function replaceWords(input, templateString) {
    const words = input.split(', ');

    for (const word of words) {
        const template = '*'.repeat(word.length);
        
        templateString = templateString.replace(template, word);
    }

    return templateString;
}

console.log('great', 'softuni is ***** place for learning new programming languages');
