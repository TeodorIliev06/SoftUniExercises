function repeatString(input, count) {
    if (count === 1) {
        return input;
    }

    return input + repeatString(input, count - 1)
}

console.log(repeatString('abc', 5));

