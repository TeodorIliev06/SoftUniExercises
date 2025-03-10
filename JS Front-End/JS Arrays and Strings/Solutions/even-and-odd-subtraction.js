function subtract(input) {
    let sum = 0;

    for (const element of input) {
        if(element % 2 == 0) {
            sum += element;
        } else {
            sum -= element;
        }
    }

    console.log(sum);
}