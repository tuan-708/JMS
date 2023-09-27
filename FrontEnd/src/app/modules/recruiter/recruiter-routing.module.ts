import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RecruiterSignInComponent } from './components/sign-in/sign-in.component';
import { RecruiterSignUpComponent } from './components/sign-up/sign-up.component';

const routes: Routes = [
  {path: "sign-in", component: RecruiterSignInComponent},
  {path: "sign-up", component: RecruiterSignUpComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RecruiterRoutingModule { }
