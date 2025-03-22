function addItem() {
    const DELETE_BUTTON_CONTENT = '[Delete]';

    const itemsElement = document.getElementById('items');
    const inputElement = document.getElementById('newItemText');

    //Handle empty input
    if (inputElement.value) {
        const newItemElement = document.createElement('li');
        newItemElement.textContent = inputElement.value;

        //Add delete button functionality
        const deleteButton = document.createElement('a');
        deleteButton.textContent = DELETE_BUTTON_CONTENT; 
        deleteButton.setAttribute('href', '#');

        deleteButton.addEventListener('click', (e) => {
            e.currentTarget.parentElement.remove();
        });
        
        newItemElement.append(deleteButton);
        itemsElement.append(newItemElement);
    }
    
    inputElement.value = '';
}
