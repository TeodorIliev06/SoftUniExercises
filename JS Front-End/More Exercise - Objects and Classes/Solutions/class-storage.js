class Storage {
    constructor(capacity) {
        this.capacity = Number(capacity);
        this.storage = [];
        this.totalCost = 0;
    }

    addProduct(product) {
        if (this.capacity >= product.quantity) {
            this.capacity -= product.quantity;
            this.storage.push(product);

            this.totalCost += product.quantity * product.price;
        } 
    }

    getProducts() {
        return this.storage.map(product => 
            JSON.stringify(product)).join('\n');
    }
}

let productOne = {name: 'Cucamber', price: 1.50, quantity: 15};
let productTwo = {name: 'Tomato', price: 0.90, quantity: 25};
let productThree = {name: 'Bread', price: 1.10, quantity: 8};
let storage = new Storage(50);
storage.addProduct(productOne);
storage.addProduct(productTwo);
storage.addProduct(productThree);
console.log(storage.getProducts());
console.log(storage.capacity);
console.log(storage.totalCost);



