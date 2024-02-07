export class Employee {
    employeeId: number;
    name: string;
    email: string;
    phone: string;
    address: string;
    city: string;
    state: string;
    postalCode: string;
    roleId: number;
    payGradeId: number;
    personalInfoId: number;
    personalInfo: {
        ssn: string;
        routingNumber?: string | null; // Make these properties optional if they can be null
        accountNumber?: string | null; // Use the "?" to denote optional properties
        birthdate?: Date | null;
        hireDate?: Date | null;
    };
    scheduleId: number;
    schedule: {
        mondayStart?: string | null;
        mondayEnd?: string | null;
        tuesdayStart?: string | null;
        tuesdayEnd?: string | null;
        wednesdayStart?: string | null;
        wednesdayEnd?: string | null;
        thursdayStart?: string | null;
        thursdayEnd?: string | null;
        fridayStart?: string | null;
        fridayEnd?: string | null;
        saturdayStart?: string | null;
        saturdayEnd?: string | null;
        sundayStart?: string | null;
        sundayEnd?: string | null;
    };

    constructor() {
        this.employeeId = 0;
        this.name = '';
        this.email = '';
        this.phone = '';
        this.address = '';
        this.city = '';
        this.state = '';
        this.postalCode = '';
        this.roleId = 0; // Adjust with the default value based on your business logic
        this.payGradeId = 0; // Adjust with the default value based on your business logic
        this.personalInfoId = 0;
        this.personalInfo = {
            ssn: '',
            routingNumber: null,
            accountNumber: null,
            birthdate: null,
            hireDate: null,
        };
        this.scheduleId = 0;
        this.schedule = {};
    }
}
