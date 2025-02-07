import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

const apiUrl = `http://localhost:5268`;

@Injectable({ providedIn: 'root' })
export class LoginService {
    log: ILogin = {
            email: 'gutosys@hotmail.com', 
            password: '>09)Z4sZ61dG'
    }
  constructor(
    private http: HttpClient    
  ){}

    login()
    {
        return this.http.post<ILogin>(`${apiUrl}/v1/identity/login?useCookies=true&useSessionCookies=true`, this.log,
            {
                withCredentials: true  // Send cookies for authentication
            }
        );
    }
}

interface ILogin
{
    email:string;
    password: string;
}