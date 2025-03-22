function subtract() {
    const firstNumElement = document.querySelector('#firstNumber');
    const secondNumElement = document.querySelector('#secondNumber');
    const resultElement = document.getElementById('result');

    resultElement.textContent = 
        Number(firstNumElement.value) - Number(secondNumElement.value);
}
