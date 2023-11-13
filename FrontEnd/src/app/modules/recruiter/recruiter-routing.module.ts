import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RecruiterSignInComponent } from './components/sign-in/sign-in.component';
import { CompanyRegisterComponent } from './components/company-register/company-register.component';
import { CompanyUpdateComponent } from './components/company-update/company-update.component';
import { JdRegisterComponent } from './components/jd-register/jd-register.component';
import { ListJdsComponent } from './components/list-jds/list-jds.component';
import { JdUpdateComponent } from './components/jd-update/jd-update.component';
import { JdDetailComponent } from './components/jd-detail/jd-detail.component';
import { RegisterRecruiterComponent } from './components/sign-up/sign-up.component';

const routes: Routes = [
   { path: "sign-in", title: "Nhà tuyển dụng - Đăng nhập", component: RecruiterSignInComponent },
   { path: "sign-up", title: "Nhà tuyển dụng - Đăng ký", component: RegisterRecruiterComponent },
   { path: "company-register", title: "Nhà tuyển dụng - Đăng ký công ty", component: CompanyRegisterComponent },
   { path: "company-update", title: "Nhà tuyển dụng - Chỉnh sửa công ty", component: CompanyUpdateComponent },
   { path: "jd-register", title: "Nhà tuyển dụng - Đăng ký bài tuyển dụng", component: JdRegisterComponent },
   { path: "list-jds", title: "Nhà tuyển dụng - Danh sách bài tuyển dụng", component: ListJdsComponent },
   { path: "", title: "Nhà tuyển dụng - Danh sách bài tuyển dụng", component: ListJdsComponent },
   { path: "jd-detail/:id", title: "Nhà tuyển dụng - Cập nhật bài tuyển dụng", component: JdUpdateComponent },
   { path: "view-jd-detail/:id", title: "Nhà tuyển dụng - Chi tiết bài tuyển dụng", component: JdDetailComponent },
];

@NgModule({
   imports: [RouterModule.forChild(routes)],
   exports: [RouterModule]
})
export class RecruiterRoutingModule { }
