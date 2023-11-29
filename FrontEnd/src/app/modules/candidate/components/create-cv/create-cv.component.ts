import { Component, ViewChild } from '@angular/core';
import ClassicEditor from 'ckeditor5-custom-build/build/ckeditor';
import DecoupledEditor from 'ckeditor5-custom-build/build/ckeditor';
import Editor from 'ckeditor5-custom-build/build/ckeditor';
import { themeList } from './constant';
import { environment } from 'src/environments/environment';
import { ActivatedRoute } from '@angular/router';
import { getRequest, postFileRequest, postRequest } from 'src/app/service/api-requests';
import { AuthorizationMode, apiCandidate, apiRecruiter } from 'src/app/service/constant';
import { ToastrService } from 'ngx-toastr';
import { getProfile, isLogin } from 'src/app/service/localstorage';

declare var $: any;

@Component({
   selector: 'app-create-cv',
   templateUrl: './create-cv.component.html',
   styleUrls: ['./create-cv.component.css'],
})


export class CandidateCreateCvComponent {
   categories: any
   levels: any
   employmentTypes: any

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
   backgroundSelectedLink = `${environment.Url}/assets/images/theme6.jpg`
   id: any;

   profile: any
   onChangeAvatar = false

   getAllCategory() {
      getRequest(apiRecruiter.GET_ALL_CATEGORY, AuthorizationMode.PUBLIC, { page: 10 })
         .then(res => {
            this.categories = res.data
         })
         .catch(data => {
            console.warn(apiRecruiter.GET_ALL_CATEGORY, data);
         })
   }

   getAllTitle(){
      getRequest(apiRecruiter.GET_ALL_LEVEL_TITLE, AuthorizationMode.PUBLIC, { page: 10 })
         .then(res => {
            this.levels = res.data
         })
         .catch(data => {
            console.warn(apiRecruiter.GET_ALL_LEVEL_TITLE, data);
         })
   }

   getAllEmploymentType(){
      getRequest(apiRecruiter.GET_ALL_EMPLOYMENT_TYPE, AuthorizationMode.PUBLIC, { page: 10 })
         .then(res => {
            this.employmentTypes = res.data
         })
         .catch(data => {
            console.warn(apiRecruiter.GET_ALL_EMPLOYMENT_TYPE, data);
         })
   }


   constructor(private route: ActivatedRoute, private toastr: ToastrService) {
      this.profile = getProfile()

      this.route.params.subscribe(params => {
         this.id = params['id'];
      });

      this.colorLeftHeader = themeList[this.id].colorLeftHeader
      this.colorRightHeader = themeList[this.id].colorRightHeader
      this.colorLeftInput = themeList[this.id].colorLeftInput
      this.ThemStyle = themeList[this.id].ThemStyle
      this.backgroundSelectedLink = themeList[this.id].backgroundSelectedLink

      this.getAllCategory()
      this.getAllTitle()
      this.getAllEmploymentType()
   }

   getValueSkills() {
      var titleSkills: any[] = [];
      var descriptionSkills: any[] = [];

      // var inputs = $(".skillTitle");
      // for (const input of inputs) { titleSkills.push($(input).val())}

      var inputs = $(".skillDescription");
      for (const input of inputs) { descriptionSkills.push($(input).val()) }

      var skills = [];
      for (var i = 0; i < descriptionSkills.length; i++) {
         var dict: any = {}; dict["title"] = ""; dict["skillDescription"] = descriptionSkills[i];
         skills.push(dict);
      }
      return skills
   }

   getValueCertificates() {
      var certificateName: any[] = [];
      var certificateProvider: any[] = [];
      var issuedDate: any[] = [];
      var expiredDate: any[] = [];
      var credentialURL: any[] = [];

      var inputs = $(".certificateName");
      for (const input of inputs) { certificateName.push($(input).val()) }

      var inputs = $(".issuedDateCertificate");
      for (const input of inputs) { issuedDate.push($(input).val()) }

      var inputs = $(".expiredDateCertificate");
      for (const input of inputs) { expiredDate.push($(input).val()) }

      var inputs = $(".credentialURLCertificate");
      for (const input of inputs) { credentialURL.push($(input).val()) }

      var inputs = $(".certificateProvider");
      for (const input of inputs) { certificateProvider.push($(input).val()) }

      var certificates = [];
      for (var i = 0; i < certificateName.length; i++) {
         var dict: any = {};
         dict["certificateName"] = certificateName[i]; dict["issuedDate"] = issuedDate[i];
         dict["expiredDate"] = expiredDate[i]; dict["credentialURL"] = credentialURL[i]; dict["certificateProvider"] = certificateProvider[i];
         certificates.push(dict);
      }
      return certificates
   }

   getValueAwards() {
      var fromYear: any[] = [];
      var awardName: any[] = [];
      var description: any[] = [];

      var inputs = $(".fromYearAwards");
      for (const input of inputs) { fromYear.push($(input).val()) }

      var inputs = $(".awardName");
      for (const input of inputs) { awardName.push($(input).val()) }

      var inputs = $(".awardDescription");
      for (const input of inputs) { description.push($(input).val()) }

      var awards = [];
      for (var i = 0; i < fromYear.length; i++) {
         var dict: any = {};
         dict["fromYear"] = fromYear[i]; dict["awardName"] = awardName[i];
         dict["description"] = description[i];
         awards.push(dict);
      }
      return awards
   }

   getValuesExperiences() {
      var companyName: any[] = [];
      var position: any[] = [];
      var fromDate: any[] = [];
      var toDate: any[] = [];
      var description: any[] = [];

      var inputs = $(".companyName");
      for (const input of inputs) { companyName.push($(input).val()) }

      var inputs = $(".positionOfCompany");
      for (const input of inputs) { position.push($(input).val()) }

      var inputs = $(".fromDateExperience");
      for (const input of inputs) { fromDate.push($(input).val()) }

      var inputs = $(".toDateExperience");
      for (const input of inputs) { toDate.push($(input).val()) }

      var inputs = $(".experienceDescription");
      for (const input of inputs) { description.push($(input).val()) }

      var experiences = [];
      for (var i = 0; i < companyName.length; i++) {
         var dict: any = {};
         dict["ComapanyName"] = companyName[i]; dict["position"] = position[i];
         dict["fromDate"] = fromDate[i]; dict["toDate"] = toDate[i];
         dict["description"] = description[i];
         dict["employmentTypeName"] = "1";
         experiences.push(dict);
      }

      return experiences
   }

   getValuesProjects() {
      var projectName: any[] = [];
      var fromDate: any[] = [];
      var toDate: any[] = [];
      var description: any[] = [];
      var isStillWorking: any[] = [];

      var inputs = $(".projectName");
      for (const input of inputs) { projectName.push($(input).val()) }

      var inputs = $(".fromDateProject");
      for (const input of inputs) { fromDate.push($(input).val()) }

      var inputs = $(".toDateProject");
      for (const input of inputs) { toDate.push($(input).val()) }

      var inputs = $(".projectDescription");
      for (const input of inputs) { description.push($(input).val()) }

      var inputs = $(".isStillWorking");
      for (const input of inputs) { isStillWorking.push($(input).prop('checked')) }


      var projects = [];
      for (var i = 0; i < projectName.length; i++) {
         var dict: any = {};
         dict["projectName"] = projectName[i]; dict["fromDate"] = fromDate[i]; dict["toDate"] = toDate[i];
         dict["description"] = description[i]; dict["isStillWorking"] = isStillWorking[i];
         projects.push(dict);
      }
      return projects
   }

   getValueEducation() {
      var schoolName: any[] = [];
      var majorName: any[] = [];
      var description: any[] = [];
      var fromYear: any[] = [];
      var toYear: any[] = [];
      var stillLearning: any[] = [];

      var inputs = $(".schoolName");
      for (const input of inputs) { schoolName.push($(input).val()) }

      var inputs = $(".majorName");
      for (const input of inputs) { majorName.push($(input).val()) }

      var inputs = $(".educationDescription");
      for (const input of inputs) { description.push($(input).val()) }

      var inputs = $(".fromYearEducation");
      for (const input of inputs) { fromYear.push($(input).val()) }

      var inputs = $(".toYearEducation");
      for (const input of inputs) { toYear.push($(input).val()) }

      var inputs = $(".stillLearning");
      for (const input of inputs) { stillLearning.push($(input).prop('checked')) }

      var educations = [];
      for (var i = 0; i < schoolName.length; i++) {
         var dict: any = {};
         dict["schoolName"] = schoolName[i]; dict["majorName"] = majorName[i]; dict["description"] = description[i];
         dict["fromYear"] = fromYear[i]; dict["toYear"] = toYear[i]; dict["stillLearning"] = stillLearning[i];
         educations.push(dict);
      }
      return educations
   }

   showSuccess() {
      this.toastr.success('Tạo hồ sơ thành công', 'Thành công', {
         progressBar: true,
         timeOut: 3000,
      });
   }

   showError() {
      this.toastr.error('Đã có lỗi xảy ra, xem lại trường dữ liệu', 'Thất bại', {
         progressBar: true,
         timeOut: 3000,
      });
   }

   showErrorUploadImage() {
      this.toastr.error('Đăng ảnh hồ sơ lỗi', 'Thất bại', {
         progressBar: true,
         timeOut: 3000,
      });
   }


   showErrorInput(message: string) {
      this.toastr.error(message, 'Thất bại', {
         progressBar: true,
         timeOut: 3000,
         enableHtml: true
      });
   }

   validInput() {
      var massage = ""
      var valid = true;
      if ($(".categoryId")[0].value == "0") {
         massage += "- Lĩnh vực không được để trống <br/>"
         var valid = false;
      }

      if ($(".levelId")[0].value == "0") {
         massage += "- Cấp bậc không được để trống <br/>"
         var valid = false;
      }

      if ($(".employmentTypeId")[0].value == "0") {
         massage += "- loại việc làm không được để trống <br/>"
         var valid = false;
      }

      if ($(".inputPhone")[0].value == "") {
         massage += "- Số điện thoại không được để trống <br/>"
         var valid = false;
      }

      if ($(".inputDob")[0].value == "") {
         massage += "- Ngày sinh không được để trống <br/>"
         var valid = false;
      }

      if ($(".cvTitle")[0].value == "") {
         massage += "- Tên hồ sơ không được để trống <br/>"
         var valid = false;
      }

      if (!valid) {
         this.showErrorInput(massage)
      }

      return valid
   }


   SubmitCV(event: any) {
      if (this.validInput()) {
         const displayEmail = $(".inputEmail")[0].value;
         const phone = $(".inputPhone")[0].value;

         const address = $(".inputAddress")[0].value;
         const dob = $(".inputDob")[0].value;
         const displayName = $(".displayName")[0].value;
         const careerGoal = $(".careerGoal")[0].value;
         const positionTitleName = $(".positionTitleName")[0].value;
         const cvTitle = $(".cvTitle")[0].value;
         const levelId = $(".levelId")[0].value;
         const categoryId = $(".categoryId")[0].value;
         const employmentTypeName = $(".employmentTypeId")[0].value;
         const theme = this.id;
         const font = this.fontCV;
         const gender = $("input[name='gender']:checked").val();


         const skills = this.getValueSkills()
         const certificates = this.getValueCertificates()
         const awards = this.getValueAwards()
         const experiences = this.getValuesExperiences()
         const projects = this.getValuesProjects()
         const educations = this.getValueEducation()

         const data = {
            'id': 0,
            'candidateId': 1,
            'careerGoal': careerGoal,
            'employmentTypeName': employmentTypeName.toString(),
            'phone': phone,
            'displayName': displayName,
            'genderDisplay': gender,
            'gender': gender,
            'displayEmail': displayEmail,
            'address': address,
            'dob': dob,
            "createdDateDisplay": null,
            "lastUpdateDateDisplay": null,
            'positionTitleName': positionTitleName,
            'jobExperiences': experiences,
            'skills': skills,
            'educations': educations,
            'projects': projects,
            'certificates': certificates,
            'awards': awards,
            'avatarURL': null,
            'categoryName': "",
            'categoryId': categoryId,
            'genderId': gender,
            'isFindingJob': true,
            'levelTitle': levelId.toString(),
            'cvTitle': cvTitle,
            'theme': theme,
            'font': font
         }

         const isLog = isLogin();
         if (isLog) {
            postRequest(`${apiCandidate.CREATE_CV_BY_CANDIDATE_ID}/${this.profile.id}`, AuthorizationMode.BEARER_TOKEN, data)
               .then(res => {
                  if (res?.statusCode == 201) {
                     const cvIdCreated = res?.data

                     if (this.onChangeAvatar) {
                        if ($('#avatarCv')[0].files[0]) {

                           let formData: FormData = new FormData();
                           let file: File = $('#avatarCv')[0].files[0];
                           formData.append('file', file, file.name);

                           postFileRequest(`${apiCandidate.UPDATE_IMAGES_CV}/${this.profile.id}/${cvIdCreated}`, AuthorizationMode.BEARER_TOKEN, formData)
                              .then(res => {
                                 console.log(res);
                              })
                              .catch(data => {
                                 this.showErrorUploadImage()
                                 console.log(data);
                              })
                        }
                     }

                     this.showSuccess()
                  }
               })
               .catch(data => {
                  this.showError()
                  console.log(data);
               })
         }
      }
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

         this.onChangeAvatar = true
      }
   }

   selectedFont(event: any) {
      this.fontCV = event.target.value
   }

   SelectedBackGround(value: any) {
      this.colorLeftHeader = themeList[value].colorLeftHeader
      this.colorRightHeader = themeList[value].colorRightHeader
      this.colorLeftInput = themeList[value].colorLeftInput
      this.ThemStyle = themeList[value].ThemStyle
      this.backgroundSelectedLink = themeList[value].backgroundSelectedLink
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
