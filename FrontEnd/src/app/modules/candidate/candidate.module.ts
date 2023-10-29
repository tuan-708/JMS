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
import { SlidersComponent } from './components/sliders/sliders.component';
import { ListJobsComponent } from './components/list-jobs/list-jobs.component';
import { CandidateListCompanysComponent } from './components/list-companys/list-companys.component';
import { CandidateMyCvsComponent } from './components/my-cvs/my-cvs.component';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';


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
      SlidersComponent,
      ListJobsComponent,
      CandidateListCompanysComponent,
      CandidateMyCvsComponent,
   ],
   imports: [
      CommonModule,
      CadidateRoutingModule,
      CKEditorModule,
      FormsModule,
      DragDropModule,
      MatInputModule,
      MatFormFieldModule,
      MatSelectModule,
      MatToolbarModule,
      MatButtonModule,
      MatIconModule,
   ]
})
export class CandidateModule { }
