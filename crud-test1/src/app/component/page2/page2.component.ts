import { Component, inject } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Http1Service } from '../../http1.service';
import { IEmployee } from '../../interfaces/employee';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-page2',
  standalone: false,

  templateUrl: './page2.component.html',
  styleUrl: './page2.component.css',
})
export class Page2Component {
  formBuilder = inject(FormBuilder);
  httpservice = inject(Http1Service);
  route = inject(ActivatedRoute);
  router = inject(Router);

  employeeForm = this.formBuilder.group({
    name: ['', [Validators.required]],
    address: ['', [Validators.required]],
    city: ['', [Validators.required]],
  });

  employeeId!: number;
  isEdit = false;
  ngOnInit() {
    this.employeeId = this.route.snapshot.params['id'];
    if (this.employeeId) {
      this.isEdit = true;
      this.httpservice.getEmployeById(this.employeeId).subscribe((result) => {
        console.log(result);
        this.employeeForm.patchValue(result);
      });
    }
  }

  save() {
    console.log(this.employeeForm.value);
    const employee: IEmployee = {
      name: this.employeeForm.value.name!,
      address: this.employeeForm.value.address!,
      city: this.employeeForm.value.city!,
    };
    if (this.isEdit) {
      this.httpservice
        .updateEmployee(this.employeeId, employee)
        .subscribe(() => {
          console.log('Successfully update');
          // alert("Successfull add");
          this.router.navigateByUrl('/');
        });
    } else {
      this.httpservice.AddEmployee(employee).subscribe(() => {
        console.log('Success add');
        // alert("Successfull add");
        this.router.navigateByUrl('/');
      });
    }
  }
}
