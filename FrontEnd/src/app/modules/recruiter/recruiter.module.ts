import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RecruiterRoutingModule } from './recruiter-routing.module';
import { RecruiterSignInComponent } from './components/sign-in/sign-in.component';
import { RecruiterSignUpComponent } from './components/sign-up/sign-up.component';
import { HeaderComponent } from './components/header/header.component';
import { FooterComponent } from './components/footer/footer.component';
import { RecruiterComponent } from './recruiter.component';


@NgModule({
  declarations: [
    RecruiterSignInComponent,
    RecruiterSignUpComponent,
    HeaderComponent,
    FooterComponent,
    RecruiterComponent
  ],
  imports: [
    CommonModule,
    RecruiterRoutingModule
  ]
})
export class RecruiterModule { }
