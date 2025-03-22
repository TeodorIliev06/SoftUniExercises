function toggle() {
    const buttonElement = document.querySelector('.button');
    const extraTextElement = document.querySelector('#extra');

    const isHidden = extraTextElement.style.display === 'none' || !extraTextElement.style.display;

    extraTextElement.style.display = isHidden ? 'block' : 'none';
    buttonElement.textContent = isHidden ? 'Less' : 'More';
}
