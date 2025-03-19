function arrangeStudents(input) {
    const students = {};

    for (const entry of input) {
        const [namePart, gradePart, scorePart] = entry.split(', ');
        const name = namePart.split(': ')[1];
        const grade = Number(gradePart.split(': ')[1]);
        const score = Number(scorePart.split(': ')[1]);

        if (score > 3) {
            const nextGrade = grade + 1;

            if (!students[nextGrade]) {
                students[nextGrade] = [];
            }

            students[nextGrade].push({ name, score });
        }
    }

    const sortedGrades = Object.keys(students)
                               .sort((a, b) => a - b);

    for (const grade of sortedGrades) {
        const currentStudents = students[grade];
        const names = currentStudents.map(s => s.name).join(', ');
        const totalScore = currentStudents.reduce((sum, s) => sum + s.score, 0);
        const avgScore = ( totalScore / currentStudents.length).toFixed(2);

        console.log(`${grade} Grade`);
        console.log(`List of students: ${names}`);
        console.log(`Average annual score from last year: ${avgScore}`);
        console.log(); 
    }
}

arrangeStudents([
    "Student name: Mark, Grade: 8, Graduated with an average score: 4.75",
        "Student name: Ethan, Grade: 9, Graduated with an average score: 5.66",
        "Student name: George, Grade: 8, Graduated with an average score: 2.83",
        "Student name: Steven, Grade: 10, Graduated with an average score: 4.20",
        "Student name: Joey, Grade: 9, Graduated with an average score: 4.90",
        "Student name: Angus, Grade: 11, Graduated with an average score: 2.90",
        "Student name: Bob, Grade: 11, Graduated with an average score: 5.15",
        "Student name: Daryl, Grade: 8, Graduated with an average score: 5.95",
        "Student name: Bill, Grade: 9, Graduated with an average score: 6.00",
        "Student name: Philip, Grade: 10, Graduated with an average score: 5.05",
        "Student name: Peter, Grade: 11, Graduated with an average score: 4.88",
        "Student name: Gavin, Grade: 10, Graduated with an average score: 4.00"
    ]
    );
