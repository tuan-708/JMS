import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RecruiterSignInComponent } from './components/sign-in/sign-in.component';
import { RecruiterSignUpComponent } from './components/sign-up/sign-up.component';
import { CompanyRegisterComponent } from './components/company-register/company-register.component';
import { JdRegisterComponent } from './components/jd-register/jd-register.component';
const routes: Routes = [
   { path: "sign-in", title: "Nhà tuyển dụng - Đăng nhập", component: RecruiterSignInComponent },
   { path: "sign-up", title: "Nhà tuyển dụng - Đăng xuất", component: RecruiterSignUpComponent },
   { path: "company-register", title: "Nhà tuyển dụng - Đăng ký company", component: CompanyRegisterComponent },
   { path: "jd-register", title: "Nhà tuyển dụng - Danh sách bài đăng", component: JdRegisterComponent },
];

@NgModule({
   imports: [RouterModule.forChild(routes)],
   exports: [RouterModule]
})
export class RecruiterRoutingModule { }
