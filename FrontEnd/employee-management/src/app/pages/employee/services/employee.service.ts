import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, Subscription } from 'rxjs';
import { IEmployee } from '../models/IEmployee';
import { IResponse } from '../models/IResponse';

const apiUrl = `http://localhost:5268`;

@Injectable({ providedIn: 'root' })
export class EmployeeService {
  constructor(
    private http: HttpClient    
  ) {}

  getGrid(): Observable<IResponse> {
    return this.http.get<IResponse>(`${apiUrl}/v1/employees`, {
        withCredentials: true  // Send cookies for authentication
      });
  }

  getForm(dados: IEmployee) {
    return this.http.get<IEmployee>(`${apiUrl}/Form/${dados.id}`);
  }  

  insert(dados: IEmployee) {
    return this.http.post<IEmployee>(apiUrl, dados);
  }

  disable(dados: IEmployee) {
    return this.http.put<IEmployee>(`${apiUrl}/Disable`, dados);
  }

  update(dados: IEmployee) {
    return this.http.put<IEmployee>(`${apiUrl}`, dados);
  }

  delete(dados: IEmployee) {
    return this.http.delete<IEmployee>(`${apiUrl}/${dados.id}`);
  }
}