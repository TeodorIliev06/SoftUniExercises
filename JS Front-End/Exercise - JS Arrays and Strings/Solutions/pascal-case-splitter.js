function splitPascalCase(input) {
    //Regex does positive lookahead
    const output = input.split(/(?=[A-Z])/);

    console.log(output.join(', '));
}