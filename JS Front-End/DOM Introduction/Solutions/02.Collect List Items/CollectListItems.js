function extractText(element) {
    const itemElements = document.getElementById('items');
    const resultElement = document.getElementById('result');

    //Not recommended
    resultElement.textContent = itemElements.innerText;
}
