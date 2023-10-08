import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CandidateSignInComponent } from './components/sign-in/sign-in.component';
import { CandidateSignUpComponent } from './components/sign-up/sign-up.component';
import { CandidateRegisterComponent } from './components/register/register.component';
import { CandidateHomeComponent } from './components/home/home.component';
import { CandidateForgotPasswordComponent } from './components/forgot-password/forgot-password.component';
import { CandidateCreateCvComponent } from './components/create-cv/create-cv.component';
import { CKEditorModule } from '@ckeditor/ckeditor5-angular';


const routes: Routes = [
  {path: "sign-in", component: CandidateSignInComponent},
  {path: "sign-up", component: CandidateSignUpComponent},
  {path: "register", component: CandidateRegisterComponent},
  {path: "create-cv", component: CandidateCreateCvComponent},
  {path: "forgot-password", component: CandidateForgotPasswordComponent},
  {path: "", component: CandidateHomeComponent}
];

@NgModule({
  imports: [
    RouterModule.forChild(routes),
    CKEditorModule
  ],
  exports: [RouterModule]
})
export class CadidateRoutingModule { }
