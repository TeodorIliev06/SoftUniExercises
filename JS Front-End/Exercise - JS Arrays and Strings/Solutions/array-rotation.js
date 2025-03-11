function name(array, rotations) {
    // Handle cases where rotations > array length
    rotations = rotations % array.length;
    
    const rotatedArr = array.slice(rotations).concat(array.slice(0, rotations));

    console.log(rotatedArr.join(' '));
}