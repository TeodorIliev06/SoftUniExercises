function printElements(arr, step) {
    let output = [arr[0]];

    if (step > arr.length) {
        return output;
    }

    for (let index = step; index < arr.length; index += step) {
        output.push(arr[index]);
    }

    return output;
}

console.log(printElements(['1', '2','3', '4', '5'], 6));