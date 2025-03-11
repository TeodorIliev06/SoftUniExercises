function findSpecial(input) {
    const words = input.split(' ');

    for (const word of words) {
        if (word.startsWith('#')) {
            const specialWord = word.substring(1);
        
            //Use regex to catch only the letters
            if (/^[a-zA-Z]+$/.test(specialWord)) {
                console.log(specialWord);
            }
        }
    }
}