import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-employee',
  standalone: true,
  imports: [],
  templateUrl: './employee.component.html',
  styleUrl: './employee.component.css'
})
export class EmployeeComponent implements OnInit {
  data: any;

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.fetchData();
  }
  fetchData() {
    const url = 'https://epmgapi.azurewebsites.net/api/employees';

    this.http.get(url).subscribe((response) => {
      this.data = response;
      console.log(this.data); // Log the fetched data
    });
  }
}
