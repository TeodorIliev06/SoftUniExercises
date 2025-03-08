function extractSpice(yield) {
    const workersConsumation = 26;
    let extractedSpice = 0, days = 0;

    while (yield >= 100) {
        days++;
        extractedSpice += yield - workersConsumation;
        yield -= 10;
    }

    if (extractedSpice >= workersConsumation) {
        extractedSpice -= workersConsumation;
    }
    console.log(days);
    console.log(extractedSpice);
}

extractSpice(450);