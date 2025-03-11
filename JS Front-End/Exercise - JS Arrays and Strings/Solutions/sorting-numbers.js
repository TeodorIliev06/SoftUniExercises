function sortNumbers(inputArr) {
    //Ascending order using a - b
    inputArr.sort((a, b) => a - b);

    let outputArr = [];
    let start = 0;
    let end = inputArr.length - 1;

    while (start <= end) {
        if (start === end) {
            outputArr.push(inputArr[start]);
        } else {
            outputArr.push(inputArr[start]);
            outputArr.push(inputArr[end]);
        }
        start++;
        end--;
    }

    return outputArr;
}

console.log(sortNumbers([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]));
