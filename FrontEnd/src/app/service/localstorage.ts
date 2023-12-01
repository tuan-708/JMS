export function signOut(){
    localStorage.removeItem('token');
    localStorage.removeItem('profile');
}

export function saveToken(token:any){
    localStorage.setItem('token', token);
}

export function isLogin():boolean{
    return localStorage.getItem("token") !== null && localStorage.getItem("profile") !== null
}

export function saveItem(key:any,data:any){
    var item = JSON.stringify(data);
    localStorage.setItem(key, item);
}

export function setItem(key:any, value:any){
    localStorage.setItem(key, value);
}

export function getItem(key:any){
    return localStorage.getItem(key)
}

export function getItemJson(key:any){
    var value = localStorage.getItem(key);
    return value !== null ? JSON.parse(value) : null
}

export function removeItem(key:any){
    return localStorage.removeItem(key)
}

export function getToken(){
    var value = localStorage.getItem('token');

    if (value !== null) {
        return value
    } else {
        return null
    }
}

interface profile{
    id: number,
    userName: string,
    fullName: string,
    email: string,
    password: string,
    isMale: boolean,
    phoneNumber: string,
    dob: string,
    createdDate: string,
    lastUpdateDate:string,
    isActive: string,
    isDelete: boolean,
    avatarURL: string
}

export function getProfile():any{
    var value = localStorage.getItem('profile');

    if (value !== null) {
        return JSON.parse(value)
    } else {
        return null
    }
}