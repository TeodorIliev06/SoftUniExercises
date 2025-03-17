function printCityInfo(city) {
    Object.entries(city)
          .forEach(([key, value]) => {
        console.log(`${key} -> ${value}`);
    });
}

printCityInfo({
    name: "Sofia",
    area: 492,
    population: 1238438,
    country: "Bulgaria",
    postCode: "1000"
}
);
