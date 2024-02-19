import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { EmployeeComponent } from './components/employee/employee.component';
import { MenuComponent } from './components/menu/menu.component';
import { SidebarComponent } from './components/sidebar/sidebar.component';
import { ModalComponent } from './components/modal/modal.component';
import { CommonModule } from '@angular/common';


@Component({
    selector: 'app-root',
    standalone: true,
    imports: [
        RouterOutlet,
        EmployeeComponent,
        MenuComponent,
        SidebarComponent,
        ModalComponent,
        CommonModule
    ],
    templateUrl: './app.component.html',
    styleUrl: './app.component.css'
})
export class AppComponent {
    title = 'frontend';
    isModalVisable = false;

    openModal() {
        this.isModalVisable = true;
    }
    closeModal() {
        this.isModalVisable = false;
    }
}
