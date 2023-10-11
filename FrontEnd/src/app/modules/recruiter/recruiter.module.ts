import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CKEditorModule } from '@ckeditor/ckeditor5-angular';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatSelectModule} from '@angular/material/select';

import { RecruiterRoutingModule } from './recruiter-routing.module';
import { RecruiterSignInComponent } from './components/sign-in/sign-in.component';
import { RecruiterSignUpComponent } from './components/sign-up/sign-up.component';
import { HeaderComponent } from './components/header/header.component';
import { FooterComponent } from './components/footer/footer.component';
import { RecruiterComponent } from './recruiter.component';
import { CompanyRegisterComponent } from './components/company-register/company-register.component';
import { JobPostComponent } from './components/jobpost-register/job-post.component';


@NgModule({
  declarations: [
    RecruiterSignInComponent,
    RecruiterSignUpComponent,
    HeaderComponent,
    FooterComponent,
    RecruiterComponent,
    CompanyRegisterComponent,
    JobPostComponent
  ],
  imports: [
    CommonModule,
    RecruiterRoutingModule,
    CKEditorModule,
    FormsModule,
    ReactiveFormsModule,
    MatInputModule,
    MatFormFieldModule,
    MatSelectModule
  ]
})
export class RecruiterModule { }
