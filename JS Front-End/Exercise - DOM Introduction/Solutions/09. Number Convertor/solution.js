function solve() {
    const numberElement = document.querySelector('#input');
    const optionElement = document.querySelector('#selectMenuTo');
    const resultElement = document.querySelector('#result');

    function convertNumber() {
        const decimalNumber = Number(numberElement.value);
        const conversionType = optionElement.value;

        let result = '';

        if (conversionType === 'binary') {
            result = decimalNumber.toString(2);
        } else if (conversionType === 'hexadecimal') {
            result = decimalNumber.toString(16).toUpperCase();
        }

        resultElement.value = result;
    }

    // Add options to the select menu
    const binaryOption = document.createElement('option');
    binaryOption.value = 'binary';
    binaryOption.textContent = 'Binary';
    optionElement.appendChild(binaryOption);

    const hexadecimalOption = document.createElement('option');
    hexadecimalOption.value = 'hexadecimal';
    hexadecimalOption.textContent = 'Hexadecimal';
    optionElement.appendChild(hexadecimalOption);

    convertNumber();
}
