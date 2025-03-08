function printAndSum(start, end) {
    let sum = 0, outputArr = [];

    for (let index = start; index <= end; index++) {
        outputArr.push(index);
        sum += index;
    }

    console.log(outputArr.join(' '));
    console.log(`Sum: ${sum}`);
}

printAndSum(5, 10);