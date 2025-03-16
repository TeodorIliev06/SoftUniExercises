function recommendProcedure(input) {
    const targetThickness = input[0];
    const crystals = input.slice(1);

    const operations = {
        'cut': thickness => thickness / 4,
        'lap': thickness => thickness * 0.8,
        'grind': thickness => thickness - 20,
        'etch': thickness => thickness - 2,
        'x-ray': thickness => thickness + 1,
        'transporting and washing': thickness => Math.floor(thickness)
    };

    function processOperation(crystal, operation, target, operationName) {
        let count = 0;

        while (operations[operation](crystal) >= target) {
            crystal = operations[operation](crystal);
            count++;
        }

        if (count > 0) {
            console.log(`${operationName} x${count}`);
            crystal = operations['transporting and washing'](crystal);
            console.log(`Transporting and washing`);
        }
        return crystal;
    }

    for (let crystal of crystals) {
        console.log(`Processing chunk ${crystal} microns`);

        crystal = processOperation(crystal, 'cut', targetThickness, 'Cut');
        crystal = processOperation(crystal, 'lap', targetThickness, 'Lap');
        crystal = processOperation(crystal, 'grind', targetThickness, 'Grind');
        crystal = processOperation(crystal, 'etch', targetThickness - 1, 'Etch');

        if (crystal === targetThickness - 1) {
            crystal = operations['x-ray'](crystal);
            console.log(`X-ray x1`);
        }

        console.log(`Finished crystal ${targetThickness} microns`);
    }
}

recommendProcedure([1000, 4000, 8100]);
