import { Component } from '@angular/core';
import ClassicEditor from '@ckeditor/ckeditor5-build-classic';
import { FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-company-register',
  templateUrl: './company-register.component.html',
  styleUrls: ['./company-register.component.css']
})
export class CompanyRegisterComponent {
  title = 'angular';
  public Editor = ClassicEditor;

  nameRq = new FormControl('', [Validators.required]);
  emailRq = new FormControl('', [Validators.required, Validators.email]);
  taxNumRq = new FormControl('', [Validators.required]);
  industryRq = new FormControl('0', [Validators.required, Validators.min(1)]);
  sizeRq = new FormControl('0', [Validators.required, Validators.min(1)]);
  addressRq = new FormControl('', [Validators.required]);
  phoneRq = new FormControl('', [Validators.required]);

  getErrorMessageName(){
    if(this.nameRq.hasError('required')){
      return 'Tên công ty không được để trống!'
    }
    return
  }
  getErrorMessageEmail(){
    if(this.emailRq.hasError('required')){
      return 'Email không được để trống!'
    }
    if(this.emailRq.hasError('email')){
      return 'Email không hợp lệ!'
    }
    return
  }
  getErrorMessageTaxNum(){
    if(this.taxNumRq.hasError('required')){
      return 'Mã số thuế không được để trống!'
    }
    return
  }
  getErrorMessageIndustry(){
    if(this.industryRq.hasError('required')){
      return 'Lĩnh vực không được để trống!'
    }
    if(this.industryRq.hasError('min')){
      return 'Lĩnh vực không được để trống!'
    }
    return
  }
  getErrorMessageSize(){
    if(this.sizeRq.hasError('required')){
      return 'Quy mô không được để trống!'
    }
    if(this.sizeRq.hasError('min')){
      return 'Quy mô không được để trống!'
    }
    return
  }
  getErrorMessageAddress(){
    if(this.addressRq.hasError('required')){
      return 'Địa chỉ không được để trống!'
    }
    return
  }
  getErrorMessagePhone(){
    if(this.phoneRq.hasError('required')){
      return 'Số điện thoại không được để trống!'
    }
    return
  }

  submitButtonClicked(){
      this.nameRq.markAllAsTouched()
      this.emailRq.markAllAsTouched()
      this.taxNumRq.markAllAsTouched()
      this.industryRq.markAllAsTouched()
      this.sizeRq.markAllAsTouched()
      this.addressRq.markAllAsTouched()
      this.phoneRq.markAllAsTouched()
  
      console.log('submit button clicked')
      return
  }
}
