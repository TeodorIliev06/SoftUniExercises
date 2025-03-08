function convertToString(firstChar, secondChar, thirdChar) {
    const output = [firstChar, secondChar, thirdChar];

    console.log(output.reverse().join(' '));
}

convertToString('a', 'b', 'c');