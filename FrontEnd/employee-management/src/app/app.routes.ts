import { Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { EmployeeComponent } from './pages/employee/grid/employee.component';

export const routes: Routes = [
    { path: '', redirectTo: 'home', pathMatch: 'full' },
    { path: 'home', component: HomeComponent },
    { path: 'employee', component: EmployeeComponent }
];
