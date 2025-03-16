function checkPalindromes(input) {
    function isPalindrome(number) {
        const reversedNumberAsString = 
        number.toString()
              .split('')
              .reverse()
              .join('');

        return number === Number(reversedNumberAsString);
    }

    input.forEach(element => console.log(isPalindrome(element)));
}
