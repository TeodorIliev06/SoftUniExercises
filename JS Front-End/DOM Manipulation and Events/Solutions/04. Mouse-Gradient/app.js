function attachGradientEvents() {
    const gradientElement = document.getElementById('gradient');
    const resultElement = document.getElementById('result');
    
    //Get percentage by hovering
    gradientElement.addEventListener('mousemove', (e) => {
        console.dir(resultElement);
        
        const currentPosition = e.offsetX;
        const elementWidth = e.currentTarget.clientWidth;

        const percentage = Math.floor(currentPosition / elementWidth * 100);

        resultElement.textContent = `${percentage}%`;
    });
}
