function makeDictionary(input) {
    const dictionary = {};

    for (const entry of input) {
        const parsedEntry = JSON.parse(entry);
        const term = Object.keys(parsedEntry)[0]; //We get an array of keys(1 key)
        const definition = parsedEntry[term];

        dictionary[term] = definition;
    }

    const sorted = Object.keys(dictionary).sort((a, b) => a.localeCompare(b));

    sorted.forEach(term => 
       console.log(`Term: ${term} => Definition: ${dictionary[term]}`));
}

makeDictionary([
    '{"Coffee":"A hot drink made from the roasted and ground seeds (coffee beans) of a tropical shrub."}',
    '{"Bus":"A large motor vehicle carrying passengers by road, typically one serving the public on a fixed route and for a fare."}',
    '{"Boiler":"A fuel-burning apparatus or container for heating water."}',
    '{"Tape":"A narrow strip of material, typically used to hold or fasten something."}',
    '{"Microphone":"An instrument for converting sound waves into electrical energy variations which may then be amplified, transmitted, or recorded."}'
]);
