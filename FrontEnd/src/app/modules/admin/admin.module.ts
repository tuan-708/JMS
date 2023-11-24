import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminRoutingModule } from './admin-routing.module';
import { AdminSignInComponent } from './components/sign-in/sign-in.component';
import { AdminSignUpComponent } from './components/sign-up/sign-up.component';
import { AdminSettingComponent } from './components/setting/setting.component';
import { AdminComponent } from './admin.component';
import { HeaderComponent } from './components/header/header.component';
import { SideNavComponent } from './components/side-nav/side-nav.component';
import { TopWidgetsComponent } from './components/top-widgets/top-widgets.component';
import { SalesByMonthComponent } from './components/sales-by-month/sales-by-month.component';
import { LastFewTransactionComponent } from './components/last-few-transaction/last-few-transaction.component';
import { TopThreeProductsComponent } from './components/top-three-products/top-three-products.component';
import { MainComponent } from './components/main/main.component';
import { SalesByCategoryComponent } from './components/sales-by-category/sales-by-category.component';
import { ChartModule } from 'angular-highcharts';
import { CompanyComponent } from './components/company/company.component';
@NgModule({
   declarations: [
      AdminSettingComponent,
      AdminSignInComponent,
      AdminSignUpComponent,
      AdminComponent,
      HeaderComponent,
      SideNavComponent,
      TopWidgetsComponent,
      SalesByMonthComponent,
      LastFewTransactionComponent,
      TopThreeProductsComponent,
      MainComponent,
      SalesByCategoryComponent,
      CompanyComponent
   ],
   imports: [
      CommonModule,
      AdminRoutingModule,
      ChartModule,
   ]
})
export class AdminModule { }
