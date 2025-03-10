function reverseArray(num, array) {
    const reversedArray = array.slice(0, num).reverse().join(' ');

    console.log(reversedArray);
}