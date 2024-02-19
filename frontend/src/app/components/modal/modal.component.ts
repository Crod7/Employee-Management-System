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
            requiredField: ['', Validators.required],
            nonRequiredField: [''],
            phonePart1: ['', [Validators.required, Validators.maxLength(3), Validators.pattern('^[0-9]+$')]],
            phonePart2: ['', [Validators.required, Validators.maxLength(3), Validators.pattern('^[0-9]+$')]],
            phonePart3: ['', [Validators.required, Validators.maxLength(4), Validators.pattern('^[0-9]+$')]]
        });
    }

    @Output() closeModal = new EventEmitter<void>();

    onClose() {
        this.closeModal.emit()
    }
}
