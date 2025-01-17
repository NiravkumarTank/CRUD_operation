import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { Page1Component } from './component/page1/page1.component';
import { Page2Component } from './component/page2/page2.component';
import { Page3Component } from './component/page3/page3.component';

const routes: Routes = [
  {
    path:"",
    component:Page3Component
  },
  {
    path:"about",
    component:Page1Component
  },
  {
    path:"add",
    component:Page2Component
  },
  {
    path:"home",
    component:Page3Component
  },
  {
    path:"home/:id",
    component:Page2Component
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
