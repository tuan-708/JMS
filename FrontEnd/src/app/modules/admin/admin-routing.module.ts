import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashBoardComponent } from './components/dash-board/dash-board.component';
import { AdminSettingComponent } from './components/setting/setting.component';
import { AdminSignInComponent } from './components/sign-in/sign-in.component';
import { AdminSignUpComponent } from './components/sign-up/sign-up.component';

const routes: Routes = [
  {path: "dash-board", component: DashBoardComponent},
  {path: "setting", component: AdminSettingComponent},
  {path: "sign-in", component: AdminSignInComponent},
  {path: "sign-up", component: AdminSignUpComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
