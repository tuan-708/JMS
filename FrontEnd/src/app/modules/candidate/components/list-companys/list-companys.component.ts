import { Component } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import ClassicEditor from '@ckeditor/ckeditor5-build-classic';

@Component({
   selector: 'app-list-companys',
   templateUrl: './list-companys.component.html',
   styleUrls: ['./list-companys.component.css']
})
export class CandidateListCompanysComponent {
   industryData = ['Giáo dục', 'Thời trang', 'Tài chính', 'Bảo hiểm', 'CNTT Phần mềm', 'Truyền thông', 'Khác']

   industryRq = new FormControl('0', [Validators.required, Validators.min(1)]);

   getErrorMessageIndustry() {
      if (this.industryRq.hasError('required')) {
         return 'Lĩnh vực không được để trống!'
      }
      if (this.industryRq.hasError('min')) {
         return 'Lĩnh vực không được để trống!'
      }
      return
   }
}
