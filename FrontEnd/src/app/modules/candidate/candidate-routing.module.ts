import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CandidateSignInComponent } from './components/sign-in/sign-in.component';
import { CandidateSignUpComponent } from './components/sign-up/sign-up.component';
import { CandidateRegisterComponent } from './components/register/register.component';
import { CandidateHomeComponent } from './components/home/home.component';
import { CandidateForgotPasswordComponent } from './components/forgot-password/forgot-password.component';
import { CandidateCreateCvComponent } from './components/create-cv/create-cv.component';
import { CKEditorModule } from '@ckeditor/ckeditor5-angular';
import { CandidateListCompanysComponent } from './components/list-companys/list-companys.component';
import { CandidateMyCvsComponent } from './components/my-cvs/my-cvs.component';


const routes: Routes = [
   { path: "sign-in", title: "Ứng viên - Đăng nhập", component: CandidateSignInComponent },
   { path: "sign-up", title: "Ứng viên - Đăng xuất", component: CandidateSignUpComponent },
   { path: "register", title: "Ứng viên - Đăng ký", component: CandidateRegisterComponent },
   { path: "create-cv", title: "Ứng viên - Tạo CV", component: CandidateCreateCvComponent },
   { path: "your-cvs", title: "Ứng viên - Danh sách hồ sơ", component: CandidateMyCvsComponent },
   { path: "forgot-password", title: "Ứng viên - Quên mật khẩu", component: CandidateForgotPasswordComponent },
   { path: "list-companys", title: "Ứn viên - Danh sách công ty", component: CandidateListCompanysComponent },
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
