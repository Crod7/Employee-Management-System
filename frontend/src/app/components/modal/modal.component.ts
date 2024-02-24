import { Component, EventEmitter, Output, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { FormGroup, ReactiveFormsModule, FormControl } from '@angular/forms';
import { addEmployee } from '@app/lib/httpFunctions/Employee';

@Component({
    selector: 'app-modal',
    standalone: true,
    imports: [CommonModule, ReactiveFormsModule],
    templateUrl: './modal.component.html',
    styleUrl: './modal.component.css'
})
export class ModalComponent {
    constructor(private http: HttpClient) { }
    employeeForm = new FormGroup({
        name: new FormControl(''),
        email: new FormControl(''),
        phonePart1: new FormControl(''),
        phonePart2: new FormControl(''),
        phonePart3: new FormControl(''),
        address1: new FormControl(''),
        address2: new FormControl(''),
        city: new FormControl(''),
        state: new FormControl(''),
        zipcode: new FormControl('')
    });

    submitApplication(
        name: string,
        email: string,
        phonePart1: string,
        phonePart2: string,
        phonePart3: string,
        address1: string,
        address2: string,
        city: string,
        state: string,
        zipcode: string
    ) {
        console.log(name)
        console.log(this.employeeForm.value)
        addEmployee(this.http, this.employeeForm.value).subscribe(response => {
            console.log('Employee added successfully:', response);
        }, error => {
            console.error('Error adding employee:', error);
        });
    }

    employeeAddSubmit(): void {
        this.submitApplication(
            this.employeeForm.value.name ?? '',
            this.employeeForm.value.email ?? '',
            this.employeeForm.value.phonePart1 ?? '',
            this.employeeForm.value.phonePart2 ?? '',
            this.employeeForm.value.phonePart3 ?? '',
            this.employeeForm.value.address1 ?? '',
            this.employeeForm.value.address2 ?? '',
            this.employeeForm.value.city ?? '',
            this.employeeForm.value.state ?? '',
            this.employeeForm.value.zipcode ?? ''
        )
    }

    @Output() closeModal = new EventEmitter<void>();

    onClose() {
        this.closeModal.emit()
    }
}
