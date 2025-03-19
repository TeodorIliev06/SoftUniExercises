function recordCars(input) {
    const parkingLot = new Set();

    for (const entry of input) {
        const [direction, carNumber] = entry.split(', ');

        if (direction === "IN") {
            parkingLot.add(carNumber);
        } else {
            parkingLot.delete(carNumber);
        }
    }

    const sortedCars = Array.from(parkingLot).sort();

    if (sortedCars.length === 0) {
        console.log('Parking Lot is Empty');
    } else {
        sortedCars.forEach(car => console.log(car));
    }
}
