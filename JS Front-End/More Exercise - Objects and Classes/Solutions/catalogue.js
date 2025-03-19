function printCatalogue(input) {
    const productCatalogue = new Map();

    for (const entry of input) {
        const [productName, productPrice] = entry.split(' : ');
        const initial = productName[0];

        if (!productCatalogue.has(initial)) {
            productCatalogue.set(initial, []);
        }

        productCatalogue.get(initial)
                        .push({name: productName, price: Number(productPrice)});
    }

    const sortedKeys = Array.from(productCatalogue.keys()).sort();

    for (const key of sortedKeys) {
        console.log(key);
        
        productCatalogue.get(key)
                        .sort((a, b) => a.name.localeCompare(b.name))
                        .forEach(product => console.log(`  ${product.name}: ${product.price}`));
    }
}

printCatalogue([
    'Appricot : 20.4',
    'Fridge : 1500',
    'TV : 1499',
    'Deodorant : 10',
    'Boiler : 300',
    'Apple : 1.25',
    'Anti-Bug Spray : 15',
    'T-Shirt : 10'
    ]
    );
