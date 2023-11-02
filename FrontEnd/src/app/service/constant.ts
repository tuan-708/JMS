export const ITEM_LOAD = 20;

export enum AuthorizationMode {
    PUBLIC = 0,
    ACCESS_TOKEN = 1,
    BEARER_TOKEN = 2,
}

export enum apiRecruiter{
    GET_ALL_CATEGORY = "/api/recuirterCommon/all-category",
    GET_ALL_POSITION_TITLE = "/api/RecuirterCommon/all-position-title",
    GET_ALL_EMPLOYMENT_TYPE = "/api/RecuirterCommon/all-employment-type",
    POST_CREATE_JD = "/api/Recuirter/new-post"
}
