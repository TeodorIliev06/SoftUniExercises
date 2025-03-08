function performOperations(startingNumber, operation1, operation2, operation3, operation4, operation5) {
    let number = Number(startingNumber);

    const operations = {
        chop: (num) => num / 2,
        dice: (num) => Math.sqrt(num),
        spice: (num) => num + 1,
        bake: (num) => num * 3,
        fillet: (num) => num * 0.8,
    };

    // Store the operations in an array
    const operationList = [operation1, operation2, operation3, operation4, operation5];

    // Iterate through the operations and perform them
    for (let operation of operationList) {
        if (operations[operation]) {
            number = operations[operation](number);
            console.log(number);
        }
    }
}

performOperations('32', 'chop', 'chop', 'chop', 'chop', 'chop');
