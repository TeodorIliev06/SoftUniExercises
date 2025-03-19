function printEmployeeInformation(employeesInformation) {
    for (const employeeInformation of employeesInformation) {
        const employee = {
            employeeName: employeeInformation,
            personalNumber: employeeInformation.length
        }

        console.log(`Name: ${employee.employeeName} -- Personal Number: ${employee.personalNumber}`);
    }
}
