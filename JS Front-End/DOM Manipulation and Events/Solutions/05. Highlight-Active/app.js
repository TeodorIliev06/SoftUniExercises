function focused() {
    //Without event delegation
    const inputElements = document.querySelectorAll('div input[type=text]');

    inputElements.forEach(el => {
        el.addEventListener('focus', (e) => {
            e.currentTarget.parentElement.classList.add('focused');
        });
        el.addEventListener('blur', (e) => {
            e.currentTarget.parentElement.classList.remove('focused');
        });
    });
}
