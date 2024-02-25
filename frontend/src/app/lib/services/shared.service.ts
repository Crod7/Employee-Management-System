import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
    providedIn: 'root',
})
export class SharedService {
    private employeeAddedSource = new Subject<void>();

    employeeAdded$ = this.employeeAddedSource.asObservable();

    triggerEmployeeAdded() {
        this.employeeAddedSource.next();
    }
}
