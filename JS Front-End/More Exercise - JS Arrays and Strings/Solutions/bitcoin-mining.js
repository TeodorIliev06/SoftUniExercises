function mineBitcoins(shift) {
    const GRAM_OF_GOLD_IN_LV = 67.51;
    const BITCOIN_IN_LV = 11949.16;

    let boughtBitcoins = 0;
    let dayOfFirstBitcoin = 0;
    let money = 0;

    for (let index = 1; index <= shift.length; index++) {
        let currentGoldInLv = shift[index - 1] * GRAM_OF_GOLD_IN_LV;

        if (index % 3 === 0) {
            currentGoldInLv *= 0.7;
        }

        money += currentGoldInLv;

        while (money >= BITCOIN_IN_LV) {
            if (boughtBitcoins === 0) {
                dayOfFirstBitcoin = index;
            }

            money -= BITCOIN_IN_LV;
            boughtBitcoins++;
        }
    }

    console.log(`Bought bitcoins: ${boughtBitcoins}`);

    if (boughtBitcoins > 0) {
        console.log(`Day of the first purchased bitcoin: ${dayOfFirstBitcoin}`);
    } 
        
    console.log(`Left money: ${money.toFixed(2)} lv.`);
}

mineBitcoins([3124.15, 504.212, 2511.124]);