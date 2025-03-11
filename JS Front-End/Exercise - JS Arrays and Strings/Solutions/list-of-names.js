function sortAndPrintList(names) {
    let count = 1;

    //Safe sort across diff locales 
    names.sort((a, b) => a.localeCompare(b));
    for (const name of names) {
        console.log(`${count++}.${name}`);
    }
}