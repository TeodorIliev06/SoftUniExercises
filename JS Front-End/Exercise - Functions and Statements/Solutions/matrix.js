function printMatrix(size) {
    for (let row = 0; row < size; row++) {
        let rowArray = [];

        for (let col = 0; col < size; col++) {
            rowArray.push(size);
        }

        console.log(rowArray.join(' '));
    }
}
