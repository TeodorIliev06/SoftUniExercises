function getSubstring(input, startIndex, elementsCount) {
    const output = input.slice(startIndex, startIndex + elementsCount);

    console.log(output);
}

getSubstring('ASentence', 1, 8);