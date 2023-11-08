import { Component, ViewChild } from '@angular/core';
import ClassicEditor from 'ckeditor5-custom-build/build/ckeditor';
import DecoupledEditor from 'ckeditor5-custom-build/build/ckeditor';
import Editor from 'ckeditor5-custom-build/build/ckeditor';
import { themeList } from './constant';
import { environment } from 'src/environments/environment';
import { ActivatedRoute } from '@angular/router';

@Component({
   selector: 'app-create-cv',
   templateUrl: './create-cv.component.html',
   styleUrls: ['./create-cv.component.css']
})

export class CandidateCreateCvComponent {
   // @ViewChild('editor') myEditor: any;

   // title = 'angular';

   // public model = {
   //   editorData:
   //     `
   //   `
   // };

   // public Editor = DecoupledEditor;

   // public onReady(editor: DecoupledEditor): void {
   //   const element = editor.ui.getEditableElement()!;
   //   const parent = element.parentElement!;

   //   parent.insertBefore(
   //     editor.ui.view.toolbar.element!,
   //     element
   //   );
   // }

   // private getArticleContent() {
   //   if (this.myEditor && this.myEditor.editorInstance) {
   //     return this.myEditor.editorInstance.getData();
   //   }

   //   return '';
   // }

   // public handleSave(editor: any): void {
   //   console.log(this.getArticleContent());
   // }

   hideImage = "block"
   displayImage = "none"
   displayChange = "none"
   apiURL = environment.Url;
   fileSrc: any;
   fontCV = "Sans-serif"

   colorLeftHeader = "#444444"
   colorRightHeader = "#111111"
   colorLeftInput = "#111111"
   ThemStyle = "Theme6"
   backgroudSelectedLink = `${environment.Url}/assets/images/theme6.jpg`


   constructor(private route: ActivatedRoute){
      let id: any;
      this.route.params.subscribe(params => {
        id = params['id'];
      });

      this.colorLeftHeader = themeList[id].colorLeftHeader
      this.colorRightHeader = themeList[id].colorRightHeader
      this.colorLeftInput = themeList[id].colorLeftInput
      this.ThemStyle = themeList[id].ThemStyle
      this.backgroudSelectedLink = themeList[id].backgroudSelectedLink
   }


   getFile(event: any) {
      if (event.target.files && event.target.files[0]) {
         this.hideImage = "none"
         this.displayImage = "block"
         this.displayChange = "block"

         var reader = new FileReader();

         reader.readAsDataURL(event.target.files[0]);

         reader.onload = (event) => {
            this.fileSrc = event.target?.result;
         }
      }
   }

   selectedFont(event: any) {
      this.fontCV = event.target.value
      // console.log(event.target.value);
   }

   SelectedBackGround(value: any) {
      this.colorLeftHeader = themeList[value].colorLeftHeader
      this.colorRightHeader = themeList[value].colorRightHeader
      this.colorLeftInput = themeList[value].colorLeftInput
      this.ThemStyle = themeList[value].ThemStyle
      this.backgroudSelectedLink = themeList[value].backgroudSelectedLink
   }

}
