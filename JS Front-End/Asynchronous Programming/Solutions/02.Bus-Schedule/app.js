function solve() {
    const infoEl = document.querySelector('.info');
    const departBtn = document.getElementById('depart');
    const arriveBtn = document.getElementById('arrive');

    let currentStop = {
        name: 'Not connected',
        next: 'depot'
    };
    
    async function depart() {
        try {
            const url = `http://localhost:3030/jsonstore/bus/schedule/${currentStop.next}`;
            const response = await fetch(url);
            
            if (!response.ok) {
                throw new Error('Error');
            }

            const data = await response.json();

            infoEl.textContent = `Next spot ${data.name}`;

            currentStop = data;

            departBtn.disabled = true;
            arriveBtn.disabled = false;
        } catch (error) {
            infoEl.textContent = error.message;
        }
    }

    async function arrive() {
        infoEl.textContent = `Arriving at ${currentStop.name}`;

        departBtn.disabled = false;
        arriveBtn.disabled = true;
    }

    return {
        depart,
        arrive
    };
}

let result = solve();
