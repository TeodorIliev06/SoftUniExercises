function storeStudents(input) {
    const courses = {};

    for (const entry of input) {
        if (entry.includes(':')) {
            const [courseName, capacityString] = entry.split(': ');
            const capacity = Number(capacityString);

            if (!courses[courseName]) {
                courses[courseName] = {
                    capacity,
                    students: []
                };
            } else {
                courses[courseName].capacity += capacity;
            }
        } else {
            const [userInfo, courseName] = entry.split(' joins ');
            const userMatch = userInfo.match(/^(.+?)\[(\d+)] with email (.+)$/);

            if (userMatch) {
                const [, username, credits, email] = userMatch;
                const creditCount = parseInt(credits, 10);

                if (courses[courseName] &&
                    courses[courseName].students.length < courses[courseName].capacity) {
                    courses[courseName].students.push({ username, credits: creditCount, email });
                }
            }
        }
    }

    const sortedCourses = Object.entries(courses)
        .sort((a, b) => b[1].students.length - a[1].students.length);

    for (const [courseName, courseInfo] of sortedCourses) {
        const placesLeft = courseInfo.capacity - courseInfo.students.length;
        console.log(`${courseName}: ${placesLeft} places left`);

        courseInfo.students.sort((a, b) => b.credits - a.credits);

        for (const { username, credits, email } of courseInfo.students) {
            console.log(`--- ${credits}: ${username}, ${email}`);
        }
    }
}

storeStudents([
    'JavaBasics: 2',
    'user1[25] with email user1@user.com joins C#Basics',
    'C#Advanced: 3',
    'JSCore: 4',
    'user2[30] with email user2@user.com joins C#Basics',
    'user13[50] with email user13@user.com joins JSCore',
    'user1[25] with email user1@user.com joins JSCore',
    'user8[18] with email user8@user.com joins C#Advanced',
    'user6[85] with email user6@user.com joins JSCore',
    'JSCore: 2',
    'user11[3] with email user11@user.com joins JavaBasics',
    'user45[105] with email user45@user.com joins JSCore',
    'user007[20] with email user007@user.com joins JSCore',
    'user700[29] with email user700@user.com joins JSCore',
    'user900[88] with email user900@user.com joins JSCore'
]);
