function printDnaHelix(helixLength) {
    const sequence = 'ATCGTTAGGG';
    let sequenceIndex = 0; 

    function getNextSymbols() {
        const firstSymbol = sequence[sequenceIndex % sequence.length];
        const secondSymbol = sequence[(sequenceIndex + 1) % sequence.length];
        sequenceIndex += 2; 

        return [firstSymbol, secondSymbol];
    }

    for (let i = 0; i < helixLength; i++) {
        const [firstSymbol, secondSymbol] = getNextSymbols();

        if (i % 4 === 0) {
            console.log(`**${firstSymbol}${secondSymbol}**`);
        } else if (i % 4 === 2) {
            console.log(`${firstSymbol}----${secondSymbol}`);
        } else {
            console.log(`*${firstSymbol}--${secondSymbol}*`);
        }
    }
}

printDnaHelix(10);
