import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CKEditorModule } from '@ckeditor/ckeditor5-angular';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule } from '@angular/forms';
import { ConfirmDialogComponent } from './components/confirm-dialog/confirm-dialog.component';
import { ChartModule } from 'angular-highcharts';
import { ToastrModule } from 'ngx-toastr';

@NgModule({
   declarations: [
      AppComponent,
      ConfirmDialogComponent,
   ],
   imports: [
      BrowserModule,
      AppRoutingModule,
      CKEditorModule,
      BrowserAnimationsModule,
      FormsModule,
      ToastrModule.forRoot(),
      ChartModule,
   ],
   providers: [],
   bootstrap: [AppComponent],
})
export class AppModule { }
