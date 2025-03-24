function getInfo() {
    const inputEl = document.getElementById('stopId');
    const stopEl = document.getElementById('stopName');
    const busesEl = document.getElementById('buses');

    const busId = inputEl.value.trim();
    const validIds = ["1287", "1308", "1327", "2334"];
    const url = `http://localhost:3030/jsonstore/bus/businfo/${busId}`;

    stopEl.textContent = '';
    busesEl.innerHTML = '';

    if (!busId || !validIds.includes(busId)) {
        stopEl.textContent = "Error";
        return;
    }

    async function fetchBuses() {
        try {
            const response = await fetch(url);

            if (!response.ok) {
                throw new Error('Error');
            }

            const data = await response.json();

            stopEl.textContent = data.name;

            Object.entries(data.buses)
                .map(([busId, time]) => `Bus ${busId} arrives in ${time} minutes`)
                .forEach(busInfo => {
                    const listItem = document.createElement('li');
                    listItem.textContent = busInfo;
                    busesEl.appendChild(listItem);
            });
            
        } catch (error) {
            stopEl.textContent = error.message;
        } finally {
            inputEl.value = '';
        }
    }

    fetchBuses();
}
