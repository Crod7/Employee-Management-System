import { Component, EventEmitter, Output, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { FormGroup, ReactiveFormsModule, FormControl } from '@angular/forms';
import { addEmployee } from '@app/lib/httpFunctions/Employee';
import { SharedService } from '@app/lib/services/shared.service';

@Component({
    selector: 'app-modal',
    standalone: true,
    imports: [CommonModule, ReactiveFormsModule],
    templateUrl: './modal.component.html',
    styleUrl: './modal.component.css'
})
export class ModalComponent {

    // Inits the http call and the sharedService function
    constructor(private http: HttpClient, private sharedService: SharedService) { }

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
            this.sharedService.triggerEmployeeAdded(); // Trigger the function in the employee Component
        }, error => {
            console.error('Error adding employee:', error);
        });
        this.onClose();
    }

    // The 'X' button on the modal used to close the modal
    @Output() closeModal = new EventEmitter<void>();
    onClose() {
        this.closeModal.emit()
    }
}
