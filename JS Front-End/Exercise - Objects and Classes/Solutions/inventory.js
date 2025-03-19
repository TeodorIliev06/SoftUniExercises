function registerHeroes(heroesInformation) {
    const register = [];

    for (const heroInformation of heroesInformation) {
        const [heroName, heroLevel, items] = heroInformation.split(' / ');
        const currentHero = {
            heroName,
            heroLevel: Number(heroLevel),
            items
        };

        register.push(currentHero);
    }

    register.sort((a, b) => a.heroLevel - b.heroLevel);

    register.forEach(hero =>
    {
        console.log(`Hero: ${hero.heroName}`);
        console.log(`level => ${hero.heroLevel}`);
        console.log(`items => ${hero.items}`);
    });
            
}
