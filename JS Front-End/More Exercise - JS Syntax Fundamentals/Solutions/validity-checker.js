function validateCoordinates(x1, y1, x2, y2) {
    let distance;
    const firstPoint = `{${x1}, ${y1}}`;
    const secondPoint = `{${x2}, ${y2}}`;
    const systemBeginning = `{0, 0}`;

    if (Number.isInteger(Math.sqrt(Math.pow((0 - x1), 2) + Math.pow((0 - y1), 2)))) {
        console.log(`${firstPoint} to ${systemBeginning} is valid`);
    } else {
        console.log(`${firstPoint} to ${systemBeginning} is invalid`);
    }

    if (Number.isInteger(Math.sqrt(Math.pow((0 - x2), 2) + Math.pow((0 - y2), 2)))) {
        console.log(`${secondPoint} to ${systemBeginning} is valid`);
    } else {
        console.log(`${secondPoint} to ${systemBeginning} is invalid`);
    }

    if (Number.isInteger(Math.sqrt(Math.pow((x2 - x1), 2) + Math.pow((y2 - y1), 2)))) {
        console.log(`${firstPoint} to ${secondPoint} is valid`);
    } else {
        console.log(`${firstPoint} to ${secondPoint} is invalid`);
    }
}