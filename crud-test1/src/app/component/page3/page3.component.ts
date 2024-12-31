import { Component, inject } from '@angular/core';
import { IEmployee } from '../../interfaces/employee';
import { Http1Service } from '../../http1.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-page3',
  standalone: false,

  templateUrl: './page3.component.html',
  styleUrl: './page3.component.css',
})
export class Page3Component {
  employeeList: IEmployee[] = [];
  httpService = inject(Http1Service);
  route = inject(Router);


  ngOnInit() {
   this.getEmployeeFromServer();
  }

  getEmployeeFromServer(){
    this.httpService.getAllEmployee().subscribe(
      (result) => {
        this.employeeList = result;
        console.log(this.employeeList);
      },
      (error) => {
        console.error('Error fetching employee data', error);
      }
    );
  }
  edit(id: number | undefined) {
    console.log(id);
    this.route.navigateByUrl('/home/' + id);
  }
  delete(id: number | any) {
    this.httpService.deleteEmploye(id).subscribe(() => {
      console.log('deleted');
      // this.employeeList = this.employeeList.filter(x=>x.id!=id);  // filter the employee singel request
      this.getEmployeeFromServer();
    });
  }
}
