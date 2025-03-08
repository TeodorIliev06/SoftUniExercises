function getExpenses(lostFights, helmetPrice, swordPrice, shieldPrice, armorPrice) {
    const brokenHelmetsCount = Math.floor(lostFights / 2);
    const brokenSwordsCount = Math.floor(lostFights / 3);
    const brokenShieldsCount = Math.floor(lostFights / 6);
    const brokenArmorsCount = Math.floor(lostFights / 12);

    const expenses = brokenHelmetsCount * helmetPrice +
                     brokenSwordsCount * swordPrice +
                     brokenShieldsCount * shieldPrice +
                     brokenArmorsCount * armorPrice;
                    
    console.log(`Gladiator expenses: ${expenses.toFixed(2)} aureus`);
}

getExpenses(23, 12.50, 21.50, 40, 200);