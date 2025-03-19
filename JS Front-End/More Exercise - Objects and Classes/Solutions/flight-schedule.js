function printFlights(input) {
    const flights = {};

    input[0].forEach(flightInfo => {
        const [flightNumber, ...destinationParts] = flightInfo.split(' ');
        const destination = destinationParts.join(' ');
        flights[flightNumber] = { destination, status: "Scheduled" };  // Initially set status as "Scheduled"
    });

    input[1].forEach(statusUpdate => {
        const [flightNumber, ...statusParts] = statusUpdate.split(' ');
        const newStatus = statusParts.join(' ');

        if (flights[flightNumber]) {
            flights[flightNumber].status = newStatus;
        }
    });

    const targetStatus = input[2][0];

    if (targetStatus === 'Ready to fly') {
        for (const flight in flights) {
            if (flights[flight].status === 'Scheduled') {
                flights[flight].status = targetStatus;
                console.log(`{ Destination: '${flights[flight].destination}', Status: '${targetStatus}' }`);
            }
        }
    } else {
        for (const flight in flights) {
            if (flights[flight].status === targetStatus) {
                console.log(`{ Destination: '${flights[flight].destination}', Status: '${targetStatus}' }`);
            }
        }
    }
}

printFlights([['WN269 Delaware',
    'FL2269 Oregon',
     'WN498 Las Vegas',
     'WN3145 Ohio',
     'WN612 Alabama',
     'WN4010 New York',
     'WN1173 California',
     'DL2120 Texas',
     'KL5744 Illinois',
     'WN678 Pennsylvania'],
     ['DL2120 Cancelled',
     'WN612 Cancelled',
     'WN1173 Cancelled',
     'SK330 Cancelled'],
     ['Ready to fly']
 ] 
 );
