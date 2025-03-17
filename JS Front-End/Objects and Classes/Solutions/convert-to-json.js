function convertTOJson(firstName, lastName, hairColor) {
    const person = {
        name: firstName,
        lastName,
        hairColor
    };

    console.log(JSON.stringify(person));
}
