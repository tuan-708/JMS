import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CandidateSignInComponent } from './components/sign-in/sign-in.component';
import { CandidateRegisterComponent } from './components/sign-up/sign-up.component';
import { CandidateHomeComponent } from './components/home/home.component';
import { CandidateForgotPasswordComponent } from './components/forgot-password/forgot-password.component';
import { CandidateCreateCvComponent } from './components/create-cv/create-cv.component';
import { CKEditorModule } from '@ckeditor/ckeditor5-angular';
import { CandidateListCompaniesComponent } from './components/list-companies/list-companies.component';
import { CandidateMyCvsComponent } from './components/my-cvs/my-cvs.component';
import { CompanyDetailComponent } from './components/company-detail/company-detail.component';
import { JdDetailComponent } from './components/jd-detail/jd-detail.component';
import { MyApplyJobComponent } from './components/my-apply-job/my-apply-job.component';
import { ViewCvComponent } from './components/view-cv/view-cv.component';
import { UpdateCvComponent } from './components/update-cv/update-cv.component';

const routes: Routes = [
   { path: "sign-in", title: "Ứng viên - Đăng nhập", component: CandidateSignInComponent },
   { path: "sign-up", title: "Ứng viên - Đăng ký", component: CandidateRegisterComponent },
   { path: "create-cv/:id", title: "Ứng viên - Tạo CV", component: CandidateCreateCvComponent },
   { path: "your-cvs", title: "Ứng viên - Danh sách hồ sơ", component: CandidateMyCvsComponent },
   { path: "your-apply-job", title: "Ứng viên - Danh sách công việc ứng tuyển", component: MyApplyJobComponent },
   { path: "forgot-password", title: "Ứng viên - Quên mật khẩu", component: CandidateForgotPasswordComponent },
   { path: "list-companies", title: "Ứng viên - Danh sách công ty", component: CandidateListCompaniesComponent },
   { path: "company-detail/:id", title: "Ứng viên - Chi tiết công ty công ty", component: CompanyDetailComponent },
   { path: "jd-detail/:id", title: "Ứng viên - Chi tiết công việc", component: JdDetailComponent },
   { path: "update-cv/:id", title: "Ứng viên - Cập nhật cv", component: UpdateCvComponent },
   { path: "view-cv/:id", title: "Ứng viên - Chi tiết Hồ sơ", component: ViewCvComponent },
   { path: "", component: CandidateHomeComponent }
];

@NgModule({
   imports: [
      RouterModule.forChild(routes),
      CKEditorModule
   ],
   exports: [RouterModule]
})
export class CadidateRoutingModule { }
