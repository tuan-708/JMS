import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminRoutingModule } from './admin-routing.module';
import { AdminSignInComponent } from './components/sign-in/sign-in.component';
import { AdminSignUpComponent } from './components/sign-up/sign-up.component';
import { AdminSettingComponent } from './components/setting/setting.component';
import { AdminComponent } from './admin.component';
@NgModule({
   declarations: [
      AdminSettingComponent,
      AdminSignInComponent,
      AdminSignUpComponent,
      AdminComponent
   ],
   imports: [
      CommonModule,
      AdminRoutingModule
   ]
})
export class AdminModule { }
