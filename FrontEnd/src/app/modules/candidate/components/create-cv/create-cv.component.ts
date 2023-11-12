import { Component, ViewChild } from '@angular/core';
import ClassicEditor from 'ckeditor5-custom-build/build/ckeditor';
import DecoupledEditor from 'ckeditor5-custom-build/build/ckeditor';
import Editor from 'ckeditor5-custom-build/build/ckeditor';
import { themeList } from './constant';
import { environment } from 'src/environments/environment';
import { ActivatedRoute } from '@angular/router';

declare var $: any;

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


   constructor(private route: ActivatedRoute) {
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

   getValueSkills() {
      var titleSkills: any[] = [];
      var descriptionSkills: any[] = [];

      var inputs = $(".skillTitle");
      for (const input of inputs) { titleSkills.push($(input).val())}

      var inputs = $(".skillDescription");
      for (const input of inputs) { descriptionSkills.push($(input).val())}

      var skills = [];
      for (var i = 0; i < titleSkills.length; i++) {
         var dict:any = {}; dict["title"] = titleSkills[i]; dict["skillDescription"] = descriptionSkills[i];
         skills.push(dict);
      }
      return skills
   }

   getValueCertificates(){
      var certificateName: any[] = [];
      var certificateProvider: any[] = [];
      var issuedDate: any[] = [];
      var expiredDate: any[] = [];
      var credentialURL: any[] = [];

      var inputs = $(".certificateName");
      for (const input of inputs) { certificateName.push($(input).val())}

      var inputs = $(".issuedDateCertificate");
      for (const input of inputs) { issuedDate.push($(input).val())}

      var inputs = $(".expiredDateCertificate");
      for (const input of inputs) { expiredDate.push($(input).val())}

      var inputs = $(".credentialURLCertificate");
      for (const input of inputs) { credentialURL.push($(input).val())}

      var inputs = $(".certificateProvider");
      for (const input of inputs) { certificateProvider.push($(input).val())}

      var certificates = [];
      for (var i = 0; i < certificateName.length; i++) {
         var dict:any = {}; 
         dict["certificateName"] = certificateName[i]; dict["issuedDate"] = issuedDate[i]; 
         dict["expiredDate"] = expiredDate[i]; dict["credentialURL"] = credentialURL[i]; dict["certificateProvider"] = certificateProvider[i];
         certificates.push(dict);
      }
      return certificates
   }

   getValueAwards(){
      var fromYear: any[] = [];
      var awardName: any[] = [];
      var description: any[] = [];

      var inputs = $(".fromYearAwards");
      for (const input of inputs) { fromYear.push($(input).val())}

      var inputs = $(".awardName");
      for (const input of inputs) { awardName.push($(input).val())}

      var inputs = $(".awardDescription");
      for (const input of inputs) { description.push($(input).val())}

      var awards = [];
      for (var i = 0; i < fromYear.length; i++) {
         var dict:any = {}; 
         dict["fromYear"] = fromYear[i]; dict["awardName"] = awardName[i]; 
         dict["description"] = description[i];
         awards.push(dict);
      }
      return awards
   }

   getValuesOtherSkills(){
      var otherSkills: any[] = [];
      var inputs = $(".otherSkillsDescription");
      for (const input of inputs) { otherSkills.push($(input).val())}

      var otherSkill = [];
      for (var i = 0; i < otherSkills.length; i++) {
         var dict:any = {}; 
         dict["otherSkills"] = otherSkills[i];
         otherSkill.push(dict);
      }

      return otherSkill
   }

   getValuesExperiences(){
      var fromYear: any[] = [];
      var awardName: any[] = [];
      var description: any[] = [];
      var fromYear: any[] = [];
      var awardName: any[] = [];
      var description: any[] = [];

   
   }

   SumbitCV(event: any) {
      const email = $(".inputEmail")[0].value;
      const phone = $(".inputPhone")[0].value;
      const linkMedia = $(".inputLinkMedia")[0].value;
      const address = $(".inputAddress")[0].value;

      const skills =  this.getValueSkills()
      const certificates = this.getValueCertificates()
      const awards = this.getValueAwards()
      const otherSkills = this.getValuesOtherSkills()

      console.log(otherSkills);

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

   // Thêm sửa xoá skill
   skillAdd(event: any) {
      $(".skill:last").clone().appendTo(".form-skills");
   }
   skillSub(event: any) {
      if ($(".skill").length > 1) {
         $(".skill:last").remove();
      }
   }

   // Thêm sửa xoá chứng chỉ
   certificatesAdd(event: any) {
      $(".certificates:last").clone().appendTo(".form-Certificates");
   }
   certificatesSub(event: any) {
      if ($(".certificates").length > 1) {
         $(".certificates:last").remove();
      }
   }

   // Thêm sửa xoá giải thưởng
   prizesAdd(event: any) {
      $(".prizes:last").clone().appendTo(".form-prizes");
   }
   prizesSub(event: any) {
      if ($(".prizes").length > 1) {
         $(".prizes:last").remove();
      }
   }

   // Thêm sửa xoá kỹ năng mềm
   otherSkillsAdd(event: any) {
      $(".otherSkill:last").clone().appendTo(".form-other-skills");
   }
   otherSkillsSub(event: any) {
      if ($(".otherSkill").length > 1) {
         $(".otherSkill:last").remove();
      }
   }

   // Thêm sửa xoá kinh nghiệm
   formExperienceAdd(event: any) {
      $(".experience:last").clone().appendTo(".form-experience");
   }
   formExperienceSub(event: any) {
      if ($(".experience").length > 1) {
         $(".experience:last").remove();
      }
   }

   // Thêm sửa xoá kinh nghiệm
   formProjectAdd(event: any) {
      $(".project:last").clone().appendTo(".form-project");
   }
   formProjectSub(event: any) {
      if ($(".project").length > 1) {
         $(".project:last").remove();
      }
   }

   // Thêm sửa xoá kinh nghiệm
   formEducationAdd(event: any) {
      $(".education:last").clone().appendTo(".form-education");
   }
   formEducationSub(event: any) {
      if ($(".education").length > 1) {
         $(".education:last").remove();
      }
   }
}
