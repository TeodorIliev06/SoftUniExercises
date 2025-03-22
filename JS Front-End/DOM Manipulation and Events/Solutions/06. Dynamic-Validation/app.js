function validate() {
    const inputElement = document.getElementById('email');
    
    const pattern = /[a-z]+\@[a-z]+\.[a-z]+/;

    inputElement.addEventListener('change', (e) => {
        if (!pattern.test(e.currentTarget.value)) {
            return e.currentTarget.classList.add('error');
        } 
        
        e.currentTarget.classList.remove('error');
    });
}
