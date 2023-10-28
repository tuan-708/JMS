import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminRoutingModule } from './admin-routing.module';
import { AdminSignInComponent } from './components/sign-in/sign-in.component';
import { AdminSignUpComponent } from './components/sign-up/sign-up.component';
import { AdminSettingComponent } from './components/setting/setting.component';
import { AdminComponent } from './admin.component';
import { NavigatorComponent } from './components/navigator/navigator.component';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { DashBoardComponent } from './components/dash-board/dash-board.component';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatCardModule } from '@angular/material/card';
import { MatMenuModule } from '@angular/material/menu';
import { MatDialogModule } from '@angular/material/dialog';
@NgModule({
  declarations: [
    AdminSettingComponent,
    AdminSignInComponent,
    AdminSignUpComponent,
    AdminComponent,
    NavigatorComponent,
    DashBoardComponent
  ],
  imports: [
    CommonModule,
    AdminRoutingModule,
    MatToolbarModule,
    MatButtonModule,
    MatSidenavModule,
    MatIconModule,
    MatListModule,
    MatGridListModule,
    MatCardModule,
    MatMenuModule,
    MatDialogModule,
  ]
})
export class AdminModule { }
