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

    // Used to add a new employee
    employeeAddSubmit(): void {
        addEmployee(this.http, this.employeeForm.value).subscribe(response => {
            console.log('Employee added successfully:', response);
        }, error => {
            console.error('Error adding employee:', error);
        });
    }

    // The 'X' button on the modal used to close the modal
    @Output() closeModal = new EventEmitter<void>();
    onClose() {
        this.closeModal.emit()
    }
}
