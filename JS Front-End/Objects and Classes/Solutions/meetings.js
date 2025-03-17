function manageAppointments(input) {
    let schedule = {};

    for (const entry of input) {
        let [day, name] = entry.split(' ');

        if (schedule[day]) {
            console.log(`Conflict on ${day}!`);
            continue;
        } 

        schedule[day]= name;
        console.log(`Scheduled for ${day}`);
    }

    Object.entries(schedule)
          .forEach(([key, value]) => {
        console.log(`${key} -> ${value}`);
    });
}

manageAppointments(['Friday Bob',
    'Saturday Ted',
    'Monday Bill',
    'Monday John',
    'Wednesday George']);
