import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Employee } from '@app/models/Employee';
import { Role } from '@app/models/Role';
import { CommonModule } from '@angular/common';
import { removeEmployee } from '@app/lib/httpFunctions/Employee';
import { SharedService } from '@app/lib/services/shared.service';

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
    employeeRole: any;

    roles: Role[] = [];
    employees: Employee[] = [];

    constructor(private http: HttpClient, private sharedService: SharedService) { }

    onRemove(id: number) {
        removeEmployee(this.http, id).subscribe(
            response => {
                console.log('Employee removed successfully');
                this.getAllEmployees();
            },
            error => {
                console.error('Error removing employee:', error);
            }
        );
    }

    ngOnInit() {
        this.getAllRoles()
        // If the user adds a new employee the list of employees is updated
        this.sharedService.employeeAdded$.subscribe(() => {
            this.getAllEmployees();
        });

    }

    getAllRoles() {
        const getAllRolesUrl = 'https://epmgapi.azurewebsites.net/api/role';

        this.http.get(getAllRolesUrl).subscribe((getAllRolesResponse) => {
            this.rolesData = getAllRolesResponse;

            this.roles = this.rolesData.map((roleData: any) => {
                return {
                    roleId: roleData.roleId,
                    roleName: roleData.roleName
                }
            })
            console.log(this.roles)
            this.getAllEmployees();
        })
    }

    getAllEmployees() {
        const getAllEmployeesUrl = 'https://epmgapi.azurewebsites.net/api/employees';

        this.http.get(getAllEmployeesUrl).subscribe((getAllEmployeeResponse) => {
            this.empData = getAllEmployeeResponse;
            console.log(this.roles)
            // We map each employee to employees arrray
            this.employees = this.empData.map((employeeData: any) => {
                this.employeeRole = this.roles.find(role => role.roleId === employeeData.roleId);
                console.log(this.employeeRole.roleName)
                return {
                    employeeId: employeeData.employeeId,
                    name: employeeData.name,
                    email: employeeData.email,
                    phone: employeeData.phone,
                    address: employeeData.address,
                    city: employeeData.city,
                    state: employeeData.state,
                    postalCode: employeeData.postalCode,
                    role: this.employeeRole.roleName,
                    roleId: employeeData.roleId,
                    payGradeId: employeeData.payGradeId,
                    personalInfoId: employeeData.personalInfoId,
                    scheduleId: employeeData.scheduleId
                } as Employee;
            })
        });
    }
}
