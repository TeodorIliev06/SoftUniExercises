function printCharsInRange(firstChar, secondChar) {
    const firstAsciiCode = firstChar.charCodeAt(0);
    const secondAsciiCode = secondChar.charCodeAt(0);

    const start = Math.min(firstAsciiCode, secondAsciiCode);
    const end = Math.max(firstAsciiCode, secondAsciiCode);

    let output = [];
    for (let index = start + 1; index < end; index++) {
        output.push(String.fromCharCode(index));
    }

    console.log(output.join(' '));
}
