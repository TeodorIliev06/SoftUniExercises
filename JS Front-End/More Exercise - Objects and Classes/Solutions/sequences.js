function extractUniqueNumbers(input) {
    const sequences = new Map();

    for (const entry of input) {
        const numbers = JSON.parse(entry);
        numbers.sort((a, b) => b - a);

        const key = numbers.toString();

        if (!sequences.has(key)) {
            sequences.set(key, numbers);
        }
    }

    const sortedSequences = Array.from(sequences.values())
        .sort((a, b) => a.length - b.length);

    for (const sequence of sortedSequences) {
        console.log(`[${sequence.join(', ')}]`);
    }
}

extractUniqueNumbers(["[7.14, 7.180, 7.339, 80.099]",
    "[7.339, 80.0990, 7.140000, 7.18]",
    "[7.339, 7.180, 7.14, 80.099]"]
    );
