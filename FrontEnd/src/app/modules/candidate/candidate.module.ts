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
import { SlidersComponent } from './components/sliders/sliders.component';
import { ListJobsComponent } from './components/list-jobs/list-jobs.component';
import { CandidateListCompaniesComponent } from './components/list-companies/list-companies.component';
import { CandidateMyCvsComponent } from './components/my-cvs/my-cvs.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { ReactiveFormsModule } from '@angular/forms';
import { CompanyDetailComponent } from './components/company-detail/company-detail.component';
import { NgxPaginationModule } from 'ngx-pagination';
import { JdDetailComponent } from './components/jd-detail/jd-detail.component';
import { MatTabsModule} from '@angular/material/tabs';
import { UpdateCvComponent } from './components/update-cv/update-cv.component';

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
      CandidateListCompaniesComponent,
      CandidateMyCvsComponent,
      CompanyDetailComponent,
      JdDetailComponent,
      UpdateCvComponent,
   ],
   imports: [
      CommonModule,
      CadidateRoutingModule,
      CKEditorModule,
      FormsModule,
      MatFormFieldModule,
      MatSelectModule,
      ReactiveFormsModule,
      NgxPaginationModule,
      MatTabsModule,
      
   ]
})
export class CandidateModule { }
