function cleanCar(input) {
    const commands = {
        'soap': value => value + 10,
        'water': value => value * 1.2,
        'vacuum cleaner': value => value * 1.25,
        'mud': value => value * 0.9
    }

    let cleanedPercentage = 0;

    for (const command of input) {
        cleanedPercentage = commands[command](cleanedPercentage);
    }

    console.log(`The car is ${cleanedPercentage.toFixed(2)}% clean.`);
}

cleanCar(["soap", "water", "mud", "mud", "water", "mud", "vacuum cleaner"]);
