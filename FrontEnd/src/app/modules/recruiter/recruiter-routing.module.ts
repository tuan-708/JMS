import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RecruiterSignInComponent } from './components/sign-in/sign-in.component';
import { RecruiterSignUpComponent } from './components/sign-up/sign-up.component';
import { CompanyRegisterComponent } from './components/company-register/company-register.component';
import { JobPostComponent } from './components/jobpost-register/job-post.component';

const routes: Routes = [
  {path: "sign-in",title: "Nhà tuyển dụng - Đăng nhập", component: RecruiterSignInComponent},
  {path: "sign-up",title: "Nhà tuyển dụng - Đăng xuất", component: RecruiterSignUpComponent},
  {path: "register-company", title: "Nhà tuyển dụng - Đăng ký company", component: CompanyRegisterComponent},
  {path: "register-jobpost",title: "Nhà tuyển dụng - Danh sách bài đăng",  component: JobPostComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RecruiterRoutingModule { }
