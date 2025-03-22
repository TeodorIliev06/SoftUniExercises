function deleteByEmail() {
    const SUCCESSFUL_DELETION_MESSAGE = 'Deleted.';
    const ERROR_MESSAGE = 'Not found.';

    const inputElement = document.querySelector('input[type=text][name=email]');
    const tdElements = document.querySelectorAll('#customers tbody td:last-child');
    const resultElement = document.getElementById('result');
    const searchEmail = inputElement.value;

    const searchElement = Array.from(tdElements)
        .find(el => el.textContent === searchEmail);

    if (searchElement) {
        searchElement.parentElement.remove();
        inputElement.value = '';
        resultElement.textContent = SUCCESSFUL_DELETION_MESSAGE;
        
    } else {
        resultElement.textContent = ERROR_MESSAGE;
    }
    
}
