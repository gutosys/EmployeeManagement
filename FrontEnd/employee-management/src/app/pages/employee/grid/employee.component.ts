import { Component, OnInit } from '@angular/core';
import {MatTableModule} from '@angular/material/table';
import {MatIconModule} from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { IEmployee } from '../models/IEmployee';
import { EmployeeService } from '../services/employee.service';
import { finalize } from 'rxjs';
import { LoginService } from '../services/login.service';

@Component({
  selector: 'app-employee',
  imports: [MatTableModule, MatIconModule, MatButtonModule],
  templateUrl: './employee.component.html',
  styleUrl: './employee.component.css'  
})

export class EmployeeComponent  implements OnInit {
    displayedColumns: string[] = ['name', 'lastName',  'actions'];

    public dadosGrid: IEmployee[] = [];
    
    ELEMENT_DATA: IEmployee[] = [
    {id: 1, name: 'Gustavoa', lastName: 'Hydrogen' },
    {id: 2, name: 'Gustavo', lastName: 'Hydrogen'}    
  ];
  
  dataSource = this.ELEMENT_DATA;

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

  openForm() {
    alert('abriu');
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
          this.dataSource = this.dadosGrid;
        },
        (err) => {
          //Incluir Toast Erro
        }
      );
  }
}