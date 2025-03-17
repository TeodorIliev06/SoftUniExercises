function convertToObject(jsonString) {
    const person = JSON.parse(jsonString);

    Object.entries(person)
          .forEach(([key, value]) => {
        console.log(`${key}: ${value}`);
    });
}
