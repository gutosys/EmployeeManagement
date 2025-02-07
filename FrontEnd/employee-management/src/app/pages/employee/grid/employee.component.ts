import { Component, inject, model, OnInit, signal } from '@angular/core';
import {MatTableModule} from '@angular/material/table';
import {MatIconModule} from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { IEmployee } from '../models/IEmployee';
import { EmployeeService } from '../services/employee.service';
import { finalize } from 'rxjs';
import { LoginService } from '../services/login.service';
import { MatDialog } from '@angular/material/dialog';
import { PopupComponent } from '../form/employee-form.component';

@Component({
  selector: 'app-employee',
  imports: [MatTableModule, MatIconModule, MatButtonModule],
  templateUrl: './employee.component.html',
  styleUrl: './employee.component.css'  
})

export class EmployeeComponent  implements OnInit {
    displayedColumns: string[] = ['name', 'lastName',  'actions'];
    public dadosGrid: IEmployee[] = [];    

    readonly lastName = signal('');
    readonly name = model('');
    readonly email = model('');
    readonly documentId = model('');
    readonly phoneNumber = model('');
    readonly password = model('');
    readonly dialog = inject(MatDialog);

  constructor(
    public employeeService: EmployeeService,
    public loginService: LoginService) {
    
  }

  ngOnInit(){
    this.login();    
  }

  login(): void{
    this.loginService
      .login()      
      .pipe(
        finalize(() => {
          
        })
      )
      .subscribe(
        (response) => {      
          this.configuraDadosGrid();    
        },
        (err) => {
          //Incluir Toast Erro
        }
      );
  }

  edit(element: any){

  }

  delete(element: any){

  }

     openForm(): void {
    const dialogRef = this.dialog.open(PopupComponent, {
      data: {name: this.name(), lastName: this.lastName(), email: this.email(), documentId: this.documentId, phoneNumber: this.phoneNumber(), password: this.password()},
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      if (result !== undefined) {
        this.name.set(result);
        this.lastName.set(result);
        this.email.set(result);
        this.documentId.set(result);
        this.phoneNumber.set(result);
        this.password.set(result);
      }
    });
  }

  configuraDadosGrid(): void {
    this.employeeService
      .getGrid()
      .pipe(
        finalize(() => {
          
        })
      )
      .subscribe(
        (response) => {
          this.dadosGrid = response.data;          
        },
        (err) => {
          //Incluir Toast Erro
        }
      );
  }

  adicionar() {
    throw new Error('Method not implemented.');
  }
}