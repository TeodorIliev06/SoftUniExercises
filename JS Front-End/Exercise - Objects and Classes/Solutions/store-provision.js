function printProductWithQuantity(stock, order) {
    const products = {};

    for (let index = 0; index < stock.length; index += 2) {
        const productName = stock[index];
        const productquantity = Number(stock[index + 1]);

        products[productName] = productquantity;
    }

    for (let index = 0; index < order.length; index += 2) {
        const productName = order[index];
        const productquantity = Number(order[index + 1]);

        if (productName in products) {
            products[productName] += productquantity;
        } else {
            products[productName] = productquantity;
        }
    }

    Object.entries(products)
          .forEach(([productName, productQuantity]) => {
            console.log(`${productName} -> ${productQuantity}`);
          });
}
