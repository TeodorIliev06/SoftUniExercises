function addItem() {
    const itemsElement = document.getElementById('items');
    const inputElement = document.getElementById('newItemText');

    //Handle empty input
    if (inputElement.value) {
        const newItem = document.createElement('li');
        newItem.textContent = inputElement.value;
    
        itemsElement.append(newItem);
    }
    
    inputElement.value = '';
}
