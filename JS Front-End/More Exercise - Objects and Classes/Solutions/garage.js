function storeCars(input) {
    const garage = {};

    for (const entry of input) {
        const [number, valuePart] = entry.split(' - ');
        const carInfo = valuePart.replace(/: /g, ' - ')

        if (!garage[number]) {
            garage[number] = [];
        }

        garage[number].push(carInfo);
    }

    for (const garageNumber in garage) {
        console.log(`Garage № ${garageNumber}`);
        garage[garageNumber].forEach(car => {
            console.log(`--- ${car}`);
        });
    }
}
 storeCars(['1 - color: green, fuel type: petrol',
    '1 - color: dark red, manufacture: WV',
    '2 - fuel type: diesel',
    '3 - color: dark blue, fuel type: petrol']
    );
