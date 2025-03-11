function calculatePyramidMaterials(base, increment) {
    let totalStone = 0;
    let totalMarble = 0;
    let totalLapisLazuli = 0;
    let totalGold = 0;
    let height = 0;
    
    let step = 1;

    while (base > 2) {
        let stone = (base - 2) * (base - 2);
        let outerLayer = (base * 4) - 4;  
        
        totalStone += stone * increment;
        
        if (step % 5 === 0) {
            totalLapisLazuli += outerLayer * increment;
        } else {
            totalMarble += outerLayer * increment;
        }
        
        base -= 2;
        height++;
        step++;
    }
    
    totalGold = (base * base) * increment;
    height++;
    
    console.log(`Stone required: ${Math.ceil(totalStone)}`);
    console.log(`Marble required: ${Math.ceil(totalMarble)}`);
    console.log(`Lapis Lazuli required: ${Math.ceil(totalLapisLazuli)}`);
    console.log(`Gold required: ${Math.ceil(totalGold)}`);
    console.log(`Final pyramid height: ${Math.floor(height * increment)}`);
}

calculatePyramidMaterials(23, 0.5);