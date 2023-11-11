import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CKEditorModule } from '@ckeditor/ckeditor5-angular';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { RecruiterRoutingModule } from './recruiter-routing.module';
import { RecruiterSignInComponent } from './components/sign-in/sign-in.component';
import { RecruiterSignUpComponent } from './components/sign-up/sign-up.component';
import { HeaderComponent } from './components/header/header.component';
import { FooterComponent } from './components/footer/footer.component';
import { RecruiterComponent } from './recruiter.component';
import { CompanyRegisterComponent } from './components/company-register/company-register.component';
import { CompanyUpdateComponent } from './components/company-update/company-update.component';
import { RegisterComponent } from './components/register/register.component';
import { JdRegisterComponent } from './components/jd-register/jd-register.component';
import { ListJdsComponent } from './components/list-jds/list-jds.component';
import { NgxPaginationModule } from 'ngx-pagination';
import { JdUpdateComponent } from './components/jd-update/jd-update.component';
import { MatDialogModule } from '@angular/material/dialog';
import { JdDetailComponent } from './components/jd-detail/jd-detail.component';
import { MatTabsModule } from '@angular/material/tabs';
import { ListCandidateComponent } from './components/list-candidate/list-candidate.component';
import { MatDividerModule } from '@angular/material/divider';
import { MatListModule } from '@angular/material/list';
@NgModule({
   declarations: [
      RecruiterSignInComponent,
      RecruiterSignUpComponent,
      HeaderComponent,
      FooterComponent,
      RecruiterComponent,
      CompanyRegisterComponent,
      RegisterComponent,
      CompanyUpdateComponent,
      JdRegisterComponent,
      ListJdsComponent,
      JdUpdateComponent,
      JdDetailComponent,
      ListCandidateComponent,
   ],
   imports: [
      CommonModule,
      RecruiterRoutingModule,
      CKEditorModule,
      FormsModule,
      ReactiveFormsModule,
      MatInputModule,
      MatFormFieldModule,
      MatSelectModule,
      MatToolbarModule,
      MatButtonModule,
      MatIconModule,
      NgxPaginationModule,
      MatDialogModule,
      MatTabsModule,
      MatDividerModule,
      MatListModule,
   ]
})
export class RecruiterModule { }
