import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CandidateSignInComponent } from './components/sign-in/sign-in.component';
import { CandidateSignUpComponent } from './components/sign-up/sign-up.component';
import { CandidateRegisterComponent } from './components/register/register.component';
import { CandidateHomeComponent } from './components/home/home.component';
import { CandidateForgotPasswordComponent } from './components/forgot-password/forgot-password.component';

const routes: Routes = [
  {path: "sign-in", component: CandidateSignInComponent},
  {path: "sign-up", component: CandidateSignUpComponent},
  {path: "register", component: CandidateRegisterComponent},
  {path: "forgot-password", component: CandidateForgotPasswordComponent},
  {path: "", component: CandidateHomeComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CadidateRoutingModule { }
