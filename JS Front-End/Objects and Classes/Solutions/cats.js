function createCats(cats) {
    class Cat {
        constructor(name, age) {
            this.name = name;
            this.age = age;
        }
    
        meow() {
            console.log(`${this.name}, age ${this.age} says Meow`);
        }
    }

    for (const cat of cats) {
        let [name, age] = cat.split(' ');
        const currentCat = new Cat(name, age);

        currentCat.meow();
    }
}

createCats(['Mellow 2', 'Tom 5']);
