function visualiseLoadingBar(input) {
    const filledSegments = input / 10;
    const totalSegments = 10;

    const filledBar = '%'.repeat(filledSegments);
    const unfilledBar = '.'.repeat(totalSegments - filledSegments);
    const loadingBar = filledBar + unfilledBar;

    console.log(`${input}% [${loadingBar}]`);
    
    if (input < 100) {
        console.log("Still loading...");
    } else {
        console.log("Complete!");
    }
}
