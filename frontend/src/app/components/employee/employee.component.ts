import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Employee } from '@app/models/Employee';
import { Role } from '@app/models/Role';
import { CommonModule } from '@angular/common';

@Component({
    selector: 'app-employee',
    standalone: true,
    imports: [CommonModule],
    templateUrl: './employee.component.html',
    styleUrl: './employee.component.css'
})
export class EmployeeComponent implements OnInit {
    empData: any;
    rolesData: any;

    roles: Role[] = [];
    employees: Employee[] = [];

    constructor(private http: HttpClient) { }

    ngOnInit() {
        this.getAllRoles()
        this.getAllEmployees();
    }
    getAllRoles() {
        const getAllRolesUrl = 'https://epmgapi.azurewebsites.net/api/role';

        this.http.get(getAllRolesUrl).subscribe((getAllRolesResponse) => {
            this.rolesData = getAllRolesResponse;
            console.log(this.rolesData)

            this.roles = this.rolesData.map((roleData: any) => {
                return {
                    roleId: roleData.roleId,
                    roleName: roleData.name
                }
            })
        })
    }
    getAllEmployees() {
        const getAllEmployeesUrl = 'https://epmgapi.azurewebsites.net/api/employees';

        this.http.get(getAllEmployeesUrl).subscribe((getAllEmployeeResponse) => {
            this.empData = getAllEmployeeResponse;
            console.log(this.empData); // Logs the fetched data(array)

            // We map each employee to employees arrray
            this.employees = this.empData.map((employeeData: any) => {
                return {
                    employeeId: employeeData.employeeId,
                    name: employeeData.name,
                    email: employeeData.email,
                    phone: employeeData.phone,
                    address: employeeData.address,
                    city: employeeData.city,
                    state: employeeData.state,
                    postalCode: employeeData.postalCode,
                    roleId: employeeData.roleId,
                    payGradeId: employeeData.payGradeId,
                    personalInfoId: employeeData.personalInfoId,
                    scheduleId: employeeData.scheduleId
                } as Employee;
            })
        });
    }
}
