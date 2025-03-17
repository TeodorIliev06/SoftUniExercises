function replaceNamesInPhonebook(input) {
    let phoneBook = {};

    for (const entry of input) {
        let [name, phone] = entry.split(' ');

        phoneBook[name] = phone;
    }

    Object.entries(phoneBook)
          .forEach(([key, value]) => {
        console.log(`${key} -> ${value}`);
    });
}
