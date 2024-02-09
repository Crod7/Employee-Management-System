import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Employee } from '@app/models/Employee';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-employee',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './employee.component.html',
  styleUrl: './employee.component.css'
})
export class EmployeeComponent implements OnInit {
  data: any;

  employees: Employee[] = [];

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.fetchData();
  }
  fetchData() {
    const url = 'https://epmgapi.azurewebsites.net/api/employees';

    this.http.get(url).subscribe((response) => {
      this.data = response;

      console.log(this.data)
      this.employees = this.data.map((employeeData: any) => {
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
      console.log(this.data); // Log the fetched data
    });
  }
}
