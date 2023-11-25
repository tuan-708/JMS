import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminDashBoardComponent } from './components/dash-board/dash-board.component';
import { AdminSettingComponent } from './components/setting/setting.component';
import { AdminSignInComponent } from './components/sign-in/sign-in.component';
import { AdminSignUpComponent } from './components/sign-up/sign-up.component';
import { CompanyComponent } from './components/company/company.component';
import { MainComponent } from './components/main/main.component';

const routes: Routes = [
   { path: "dash-board", component: AdminDashBoardComponent },
   { path: "setting", component: AdminSettingComponent },
   { path: "sign-in", component: AdminSignInComponent },
   { path: "sign-up", component: AdminSignUpComponent },
   { path: "company-page", component: CompanyComponent },
   { path: "dashboard", component: MainComponent },
   { path: "", component: MainComponent },
];

@NgModule({
   imports: [RouterModule.forChild(routes)],
   exports: [RouterModule]
})
export class AdminRoutingModule { }
