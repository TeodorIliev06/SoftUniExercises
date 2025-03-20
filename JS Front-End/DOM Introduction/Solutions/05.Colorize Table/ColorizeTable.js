function colorize() {
    const tableElements = document.querySelectorAll('table tr:nth-child(even)');

    Array.from(tableElements)
        .forEach(element => element.style.background = 'teal');
     
}
