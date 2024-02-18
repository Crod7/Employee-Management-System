import { Component, EventEmitter, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
    selector: 'app-modal',
    standalone: true,
    imports: [CommonModule],
    templateUrl: './modal.component.html',
    styleUrl: './modal.component.css'
})
export class ModalComponent {
    modalForm: FormGroup;

    constructor(private fb: FormBuilder) {
        this.modalForm = this.fb.group({
            input1: ['', Validators.required],
            input2: ['', Validators.pattern(/^[A-Za-z0-9]+$/)]
        });
    }
    @Output() closeModal = new EventEmitter<void>();

    onClose() {
        this.closeModal.emit()
    }
}
