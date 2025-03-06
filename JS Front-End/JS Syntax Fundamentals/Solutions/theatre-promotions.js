function getPromotion(dayType, age) {
    let ticketPrice;

    if (age >= 0 && age <= 18) {
        switch (dayType) {
            case 'Weekday':
                ticketPrice = '12$';
                break;
            case 'Weekend':
                ticketPrice = '15$';
                break;
            case 'Holiday':
                ticketPrice = '5$';
                break;
            default:
                ticketPrice = 'Error!';
        }
    } else if (age > 18 && age <= 64) {
        switch (dayType) {
            case 'Weekday':
                ticketPrice = '18$';
                break;
            case 'Weekend':
                ticketPrice = '20$';
                break;
            case 'Holiday':
                ticketPrice = '12$';
                break;
            default:
                ticketPrice = 'Error!';
        }
    } else if (age > 64 && age <= 122) {
        switch (dayType) {
            case 'Weekday':
                ticketPrice = '12$';
                break;
            case 'Weekend':
                ticketPrice = '15$';
                break;
            case 'Holiday':
                ticketPrice = '10$';
                break;
            default:
                ticketPrice = 'Error!';
        }
    } else {
        // This will handle ages less than 0 or greater than 122
        ticketPrice = 'Error!';
    }

    console.log(ticketPrice);
}