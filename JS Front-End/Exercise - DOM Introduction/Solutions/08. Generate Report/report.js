function generateReport() {
    const INDENT_COUNT = 2;

    const checkboxElements = document.querySelectorAll('thead tr th');
    const rowElements = document.querySelectorAll('tbody tr');
    const outputElement = document.getElementById('output');

    const checkedElements = [...checkboxElements]
        .map((checkbox, index) => ({ input: checkbox.children[0], index }))
        .filter(checkbox => checkbox.input.checked);

    const output = [...rowElements].map(row => {
        return checkedElements.reduce((acc, curr) => {
            acc[curr.input.name] = row.children[curr.index].textContent;

            return acc;
        }, {});
    });

    //Add indentation for readibility
    outputElement.value = JSON.stringify(output, null, INDENT_COUNT);
}
