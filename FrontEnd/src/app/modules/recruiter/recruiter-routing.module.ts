import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RecruiterSignInComponent } from './components/sign-in/sign-in.component';
import { CreateCompanyComponent } from './components/create-company/create-company.component';
import { CompanyUpdateComponent } from './components/company-update/company-update.component';
import { CreateJdComponent } from './components/create-jd/create-jd.component';
import { ListJdsComponent } from './components/list-jds/list-jds.component';
import { JdUpdateComponent } from './components/jd-update/jd-update.component';
import { JdDetailComponent } from './components/jd-detail/jd-detail.component';
import { RegisterRecruiterComponent } from './components/sign-up/sign-up.component';
import { LandingPageComponent } from './components/landing-page/landing-page.component';
import { CompanyViewComponent } from './components/company-view/company-view.component';
import { ProfileComponent } from './components/profile/profile.component';
import { ForgotPasswordComponent } from './components/forgot-password/forgot-password.component';
import { authGuard } from './auth.guard';

const routes: Routes = [
   { path: "sign-in", title: "Nhà tuyển dụng - Đăng nhập", component: RecruiterSignInComponent },
   { path: "sign-up", title: "Nhà tuyển dụng - Đăng ký", component: RegisterRecruiterComponent },
   { path: "create-company", title: "Nhà tuyển dụng - Đăng ký công ty", component: CreateCompanyComponent, canActivate: [authGuard] },
   { path: "company-update", title: "Nhà tuyển dụng - Chỉnh sửa công ty", component: CompanyUpdateComponent, canActivate: [authGuard] },
   { path: "create-jd", title: "Nhà tuyển dụng - Đăng ký bài tuyển dụng", component: CreateJdComponent, canActivate: [authGuard] },
   { path: "list-jds", title: "Nhà tuyển dụng - Danh sách bài tuyển dụng", component: ListJdsComponent, canActivate: [authGuard] },
   { path: "", title: "Nhà tuyển dụng - Landing Page", component: LandingPageComponent },
   { path: "jd-detail/:id", title: "Nhà tuyển dụng - Cập nhật bài tuyển dụng", component: JdUpdateComponent, canActivate: [authGuard] },
   { path: "view-jd-detail/:id", title: "Nhà tuyển dụng - Chi tiết bài tuyển dụng", component: JdDetailComponent, canActivate: [authGuard] },
   { path: "landing-page", title: "Landing Page", component: LandingPageComponent },
   { path: "view-company", title: "Nhà tuyển dụng - Thông Tin Công Ty", component: CompanyViewComponent, canActivate: [authGuard] },
   { path: "profile", title: "Nhà tuyển dụng - Thông Tin Cá Nhân", component: ProfileComponent, canActivate: [authGuard] },
   { path: "forget-password", title: "Nhà tuyển dụng - Quên Mật Khẩu", component: ForgotPasswordComponent },
];

@NgModule({
   imports: [RouterModule.forChild(routes)],
   exports: [RouterModule]
})
export class RecruiterRoutingModule { }
