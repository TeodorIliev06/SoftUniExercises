function getTowns(townsInformation) {
    for (const townInformation of townsInformation) {
        const townArguments = townInformation.split(' | ');
        const townName = townArguments[0];
        const latitude = Number(townArguments[1]);
        const longitude = Number(townArguments[2]);

        const currentTown = {
            town: townName,
            latitude: latitude.toFixed(2),
            longitude: longitude.toFixed(2)
        };

        console.log(currentTown);
    }
}

getTowns(['Sofia | 42.696552 | 23.32601',
    'Beijing | 39.913818 | 116.363625']
    );
