import { Component, EventEmitter, Output, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule, FormControl } from '@angular/forms';

@Component({
    selector: 'app-modal',
    standalone: true,
    imports: [CommonModule, ReactiveFormsModule],
    templateUrl: './modal.component.html',
    styleUrl: './modal.component.css'
})
export class ModalComponent {

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
    }

    employeeAddSubmit() {
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
