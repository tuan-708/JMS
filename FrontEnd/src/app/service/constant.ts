export const ITEM_LOAD = 20;
export const AVATAR_DEFAULT_URL = 'https://gcavocats.ca/wp-content/uploads/2018/09/man-avatar-icon-flat-vector-19152370-1.jpg';
export const IMG_LOADING = 'https://truetech.com.vn/wp-content/uploads/2021/07/loading.gif';

export enum AuthorizationMode {
    PUBLIC = 0,
    ACCESS_TOKEN = 1,
    BEARER_TOKEN = 2,
}

export enum apiRecruiter{
    GET_ALL_CATEGORY = "/api/RecuirterCommon/all-category",
    GET_ALL_GENDER = "/api/RecuirterCommon/all-gender",
    GET_ALL_LEVEL_TITLE = "/api/RecuirterCommon/all-level-title",
    GET_ALL_EMPLOYMENT_TYPE = "/api/RecuirterCommon/all-employment-type",

    GET_CV_MATCHED = "/api/Recuirter/get-all-cv-matched/",
    GET_CV_SELECTED = "/api/Recuirter/get-all-cv-selected/",
    GET_CV_APPLIED = "/api/Recuirter/get-all-cv-applied/",
    MATCHING_JOB = "/api/Recuirter/matching-job/",
    GET_ESTIMATE_TIME = "/api/Recuirter/get-estimate-date-to-matching/",
    
    POST_CREATE_JD = "/api/JobDesc/new-post",
    GET_JD_BY_ID = "/api/JobDesc/get-jd-by-id",
    UPDATE_JD_BY_RECRUITER = "/api/JobDesc/update-jd",
    GET_COMPANY_JDS_PAGING = "/api/JobDesc/all-jd-by-company",
    DELETE_JD_BY_ID = "/api/JobDesc/delete-jd/",

    CREATE_COMPANY_BY_ID = "/api/Companys/create-by-recuirter",
    UPDATE_COMPANY = "/api/Companys/update-by-recuirter",
    GET_COMPANY_PAGING = "/api/Companys/get-all",
    GET_COMPANY_BY_ID = "/api/Companys/get-by-id",
    UPDATE_IMAGE_COMPANY_AVATAR = "/api/Images/update-img-avt-company",
    UPDATE_IMAGE_COMPANY_BACKGROUND = "/api/Images/update-img-bgr-company",

    LOGIN_RECRUITER = "/api/Token/login-recuirter",
    GET_PROFILE_RECRUITER = "/api/Token/get-data-recruiter"
}

export enum apiCandidate{
    GET_ALL_JDS_PAGING =  "/api/JobDesc/get-all-jd",
    GET_JD_BY_ID = "/api/JobDesc/get-jd-by-id",
    GET_ALL_CV_BY_RECRUITER_ID = "/api/CVs/all-cv",
    CREATE_CV_BY_CANDIDATE_ID= "/api/CVs/new-cv",
    UPLOAD_AVATAR_CV_ID= "/api/Images/upload-imge-cv",
    GET_ALL_CV_BY_ID = "/api/CVs/all-cv",
    CANDIDATE_APPLYJOB = "/api/Candidate/apply-cv",

    LOGIN_CANDIDATE = "/api/Token/login-candidate",
    GET_PROFILE_USER = "/api/Token/get-data-candidate"
}
