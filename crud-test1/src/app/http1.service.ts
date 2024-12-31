import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { IEmployee } from './interfaces/employee';

@Injectable({
  providedIn: 'root'
})
export class Http1Service {

  http = inject(HttpClient);
  apiUrl = "https://localhost:44375";
  constructor() { }

  getAllEmployee(){
    return this.http.get<IEmployee[]>(this.apiUrl+"/api/Employee");
  }
  
  AddEmployee(employee:IEmployee){
    return this.http.post(this.apiUrl+"/api/Employee",employee);
  }

  getEmployeById(id:number){
    return this.http.get<IEmployee>(this.apiUrl+"/api/Employee/"+id);
  }

  updateEmployee(id:number,employee:IEmployee){
    return this.http.put<IEmployee[]>(this.apiUrl+"/api/Employee/"+id,employee);
  }

  deleteEmploye(id:number|any){
    return this.http.delete(this.apiUrl+"/api/Employee/"+id);
  }
}
