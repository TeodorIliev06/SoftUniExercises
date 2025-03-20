function sumTable() {
    const resultElemnt = document.getElementById('sum');
    const tdElements = document.querySelectorAll('table tbody tr td:nth-child(2):not(#sum)');

    resultElemnt.textContent = Array
        .from(tdElements)
        .reduce((sum, td) => sum + Number(td.textContent), 0);;
}
