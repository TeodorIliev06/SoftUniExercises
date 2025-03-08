function getPromotion(groupSize, groupType, dayType) {
    let ticketPrice, discount, totalPrice;

    if (groupType === 'Students') {
        switch (dayType) {
            case 'Friday':
                ticketPrice = 8.45;
                break;
            case 'Saturday':
                ticketPrice = 9.80;
                break;
            case 'Sunday':
                ticketPrice = 10.46;
                break;
        }
    } else if (groupType === 'Business') {
        switch (dayType) {
            case 'Friday':
                ticketPrice = 10.90;
                break;
            case 'Saturday':
                ticketPrice = 15.60;
                break;
            case 'Sunday':
                ticketPrice = 16;
                break;
        }
    } else if (groupType === 'Regular') {
        switch (dayType) {
            case 'Friday':
                ticketPrice = 15;
                break;
            case 'Saturday':
                ticketPrice = 20;
                break;
            case 'Sunday':
                ticketPrice = 22.50;
                break;
        }
    }

    totalPrice = ticketPrice * groupSize;

    if (groupSize >= 30 && groupType === 'Students') {
        discount = totalPrice * 0.15;
        totalPrice -= discount;
    } else if (groupSize >= 100 && groupType === 'Business') {
        discount = ticketPrice * 10;
        totalPrice -= discount;
    } else if (groupSize >= 10 && groupSize <= 20 && groupType === 'Regular') {
        discount = totalPrice * 0.05;
        totalPrice -= discount;
    }

    console.log(`Total price: ${totalPrice.toFixed(2)}`);
}

getPromotion(40, 'Regular', 'Saturday');