function validatePassword(password) {
    const INVALID_PASSWORD_DIGITS_COUNT = 'Password must have at least 2 digits';
    const INVALID_PASSWORD_LENGTH = 'Password must be between 6 and 10 characters';
    const INVALID_PASSWORD_CHARACTER = 'Password must consist only of letters and digits';
    const VALID_PASSWORD_MESSAGE = 'Password is valid';

    let isValid = true;

    if (password.length < 6 || password.length > 10) {
        console.log(INVALID_PASSWORD_LENGTH);
        isValid = false;
    }

    const validCharacterRegex = /^[a-zA-Z0-9]+$/;
    if (!validCharacterRegex.test(password)) {
        console.log(INVALID_PASSWORD_CHARACTER);
        isValid = false;
    }

    //Use [] if there are no matches -> digitCount = 0
    const digitCount = (password.match(/\d/g) || []).length;
    if (digitCount < 2) {
        console.log(INVALID_PASSWORD_DIGITS_COUNT);
        isValid = false;
    }

    if (isValid) {
        console.log(VALID_PASSWORD_MESSAGE);
    }
}
