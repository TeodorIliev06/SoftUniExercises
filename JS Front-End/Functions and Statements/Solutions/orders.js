function getTotalPrice(product, quantity) {
    const productPrices = {
        coffee: 1.50,
        water: 1.00,
        coke: 1.40,
        snacks: 2.00
    };

    const totalPrice = productPrices[product] * quantity;

    console.log(totalPrice.toFixed(2));
}
