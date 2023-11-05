export const ITEM_LOAD = 20;

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
    POST_CREATE_JD = "/api/JobDesc/new-post",
    CREATE_COMPANY_BY_ID = "/api/Companys/create-by-recuirter",
    UPDATE_COMPANY = "/api/Companys/update-by-recuirter",
    GET_COMPANY_PAGING = "/api/Companys/get-all",
    GET_COMPANY_BY_ID = "/api/Companys/get-by-id",
    UPDATE_IMAGE_COMPANY_AVATAR = "/api/Images/update-img-avt-company",
    UPDATE_IMAGE_COMPANY_BACKGROUND = "/api/Images/update-img-bgr-company",
    GET_COMPANY_JDS_PAGING = "/api/JobDesc/all-jd-by-company",
}
