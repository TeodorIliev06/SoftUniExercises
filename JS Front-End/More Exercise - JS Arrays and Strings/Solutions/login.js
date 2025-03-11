function loginUser(input) {
    const username = input[0];
    const correctPassword = username.split('').reverse().join('');
    const ALLOWED_ATTEMPTS = 4;
    let attempts = 0;

    const successfulLogin = `User ${username} logged in.`;
    const blockedUser = `User ${username} blocked!`;

    for (const password of input.slice(1)) {
        attempts++;

        if (password === correctPassword) {
            return successfulLogin;
        } else if(attempts === ALLOWED_ATTEMPTS) {
            return blockedUser;
        } else {
            console.log('Incorrect password. Try again.');
        }
    }
}

console.log(loginUser(['Acer','login','go','let me in','recA']));