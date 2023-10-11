import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CadidateRoutingModule } from './candidate-routing.module';
import { CandidateComponent } from './candidate.component';
import { HeaderComponent } from './components/header/header.component';
import { FooterComponent } from './components/footer/footer.component';
import { CandidateSignInComponent } from './components/sign-in/sign-in.component';
import { CandidateSignUpComponent } from './components/sign-up/sign-up.component';
import { CandidateRegisterComponent } from './components/register/register.component';
import { CandidateHomeComponent } from './components/home/home.component';
import { CandidateForgotPasswordComponent } from './components/forgot-password/forgot-password.component';
import { CandidateCreateCvComponent } from './components/create-cv/create-cv.component';
import { CKEditorModule } from '@ckeditor/ckeditor5-angular';
import { FormsModule } from '@angular/forms';
import { DragDropModule } from '@angular/cdk/drag-drop';


@NgModule({
  declarations: [
    CandidateComponent,
    HeaderComponent,
    FooterComponent,
    CandidateSignInComponent,
    CandidateSignUpComponent,
    CandidateRegisterComponent,
    CandidateHomeComponent,
    CandidateForgotPasswordComponent,
    CandidateCreateCvComponent,
  ],
  imports: [
    CommonModule,
    CadidateRoutingModule,
    CKEditorModule,
    FormsModule,
    DragDropModule
  ]
})
export class CandidateModule { }
