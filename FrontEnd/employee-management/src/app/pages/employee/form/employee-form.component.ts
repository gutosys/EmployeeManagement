import { Component, Inject, Input, OnInit } from '@angular/core';
import { FormsModule, ReactiveFormsModule,FormBuilder, FormGroup, Validators  } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { EmployeeService } from '../services/employee.service';
import { MatFormField, MatFormFieldModule, MatLabel } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { IEmployee } from '../models/IEmployee';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'app-employee-form',
  imports:[
    ReactiveFormsModule, 
    MatFormField, 
    MatLabel, 
    MatFormFieldModule, 
    MatIconModule,
    FormsModule,
    MatInputModule,
    MatButtonModule] ,
  templateUrl: './employee.form.component.html',
  styleUrls: ['./employee-form.component.css']
})
export class PopupComponent implements OnInit {
  inputdata: any;
  editdata: any;
  closemessage = 'closed using directive';
  myform: FormGroup;
  @Input() registro: IEmployee = null;

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any, 
    private ref: MatDialogRef<PopupComponent>, 
    private builder: FormBuilder = new FormBuilder(),
    private service: EmployeeService,
    private fb: FormBuilder,
  ) {

  }
  ngOnInit(): void {
    // this.inputdata = this.data;
    // if(this.inputdata.code>0){
    //   this.setpopupdata(this.inputdata.code)
    // }

    this.criarFormulario();
  }

  setpopupdata(code: any) {
    // this.service.getForm(code).subscribe(item => {
    //   this.editdata = item;
    //   this.myform.setValue({name:this.editdata.name,email:this.editdata.email,phone:this.editdata.phone,
    //   status:this.editdata.status})
    // });
  }

  closepopup() {
    this.ref.close('Closed using function');
  }

  Saveuser() {
    this.service.insert(this.myform.value).subscribe(res => {
       this.closepopup();
    });
  }

  criarFormulario() {
    this.myform = this.fb.group({
      id: [
        this.registro != null && this.registro.id !== null
          ? this.registro.id
          : null,
      ],
      name: [
        this.registro != null && this.registro.name !== null
          ? this.registro.name
          : null,
        Validators.compose([Validators.required]),
      ],
      lastName: [
        this.registro != null && this.registro.lastName !== null
          ? this.registro.lastName
          : null,
        Validators.compose([Validators.required]),
      ],
      email: [
        this.registro != null && this.registro.email !== null
          ? this.registro.email
          : null,
        Validators.compose([Validators.required]),
      ],
      documentId: [
        this.registro != null && this.registro.documentId !== null
          ? this.registro.documentId
          : null,
        Validators.compose([Validators.required]),
      ],
      phoneNumber: [
        this.registro != null && this.registro.phoneNumber !== null
          ? this.registro.phoneNumber
          : null,
        Validators.compose([Validators.required]),
      ],
      password: [
        this.registro != null && this.registro.password !== null
          ? this.registro.password
          : null,
        Validators.compose([Validators.required]),
      ]
    });
}
}