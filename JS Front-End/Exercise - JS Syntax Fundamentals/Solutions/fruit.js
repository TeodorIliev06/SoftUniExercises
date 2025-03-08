function calcMoney(fruitType, grams, pricePerKg) {
    let kg = grams / 1000;
    let neededMoney = (kg * pricePerKg).toFixed(2);

    console.log(`I need $${neededMoney} to buy ${kg.toFixed(2)} kilograms ${fruitType}.`);
}

calcMoney('orange', 2500, 1.80);