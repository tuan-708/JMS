import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RecruiterSignInComponent } from './components/sign-in/sign-in.component';
import { RecruiterSignUpComponent } from './components/sign-up/sign-up.component';
import { CompanyRegisterComponent } from './components/company-register/company-register.component';
import { JobPostComponent } from './components/jobpost-register/job-post.component';

const routes: Routes = [
  {path: "sign-in", component: RecruiterSignInComponent},
  {path: "sign-up", component: RecruiterSignUpComponent},
  {path: "register-company", component: CompanyRegisterComponent},
  {path: "register-jobpost", component: JobPostComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RecruiterRoutingModule { }
