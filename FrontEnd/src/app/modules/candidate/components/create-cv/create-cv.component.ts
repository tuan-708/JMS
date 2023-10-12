import { Component, ViewChild } from '@angular/core';
import ClassicEditor from 'ckeditor5-custom-build/build/ckeditor';
import DecoupledEditor from 'ckeditor5-custom-build/build/ckeditor';
import Editor from 'ckeditor5-custom-build/build/ckeditor';
import { themeList } from './constant';
import { environment } from 'src/environments/environment';

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
  apiURL = environment.apiUrl;
  fileSrc: any;
  fontCV = "Sans-serif"

  colorLeftHeader = "#FFFFFF"
  colorRightHeader = "#111111"
  colorLeftInput = "#FFFFFF"
  ThemStyle = "ThemeDefault"
  backgroudSelectedLink = `${environment.apiUrl}/assets/images/themeDefault.jpg`



  getFile(event: any){
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

  selectedFont(event: any){
    this.fontCV = event.target.value
    // console.log(event.target.value);
  }

  SelectedBackGround(value : any){
    this.colorLeftHeader = themeList[value].colorLeftHeader
    this.colorRightHeader = themeList[value].colorRightHeader
    this.colorLeftInput = themeList[value].colorLeftInput
    this.ThemStyle = themeList[value].ThemStyle
    this.backgroudSelectedLink = themeList[value].backgroudSelectedLink
    
  }

}
