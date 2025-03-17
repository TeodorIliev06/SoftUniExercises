function sortAndPrintInAddressBook(input) {
    let addressBook = {};

    for (const entry of input) {
        let [name, address] = entry.split(':');

        addressBook[name] = address;
    }

    Object.keys(addressBook)
        .sort((a, b) => a.localeCompare(b))
        .forEach((key) => {
            console.log(`${key} -> ${addressBook[key]}`);
        });
}

sortAndPrintInAddressBook(['Tim:Doe Crossing',
    'Bill:Nelson Place',
    'Peter:Carlyle Ave',
    'Bill:Ornery Rd']
   );
