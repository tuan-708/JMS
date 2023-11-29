import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminSettingComponent } from './components/setting/setting.component';
import { AdminSignInComponent } from './components/sign-in/sign-in.component';
import { AdminSignUpComponent } from './components/sign-up/sign-up.component';
import { CompanyComponent } from './components/company/company.component';
import { MainComponent } from './components/main/main.component';
import { JdDetailComponent } from './components/jd-detail/jd-detail.component';
import { CandidateComponent } from './components/candidate/candidate.component';
import { RecruiterComponent } from './components/recruiter/recruiter.component';

const routes: Routes = [
   { path: "setting", component: AdminSettingComponent },
   { path: "sign-in", component: AdminSignInComponent },
   { path: "sign-up", component: AdminSignUpComponent },
   { path: "company-page", component: CompanyComponent },
   { path: "dashboard", component: MainComponent },
   { path: "", component: MainComponent },
   { path: "view-jd/:id", component: JdDetailComponent },
   { path: "candidate-page", component: CandidateComponent },
   { path: "recruiter-page", component: RecruiterComponent },
];

@NgModule({
   imports: [RouterModule.forChild(routes)],
   exports: [RouterModule]
})
export class AdminRoutingModule { }
