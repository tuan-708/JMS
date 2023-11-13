import { environment } from 'src/environments/environment';
import { AuthorizationMode } from './constant';

const apiURL = environment.apiUrl;

interface MyHeaders {
    Accept: string;
    'Content-Type': string;
    Authorization?: string;
}

export const convertPayloadToQueryString = (payload: any) => {
    return Object.keys(payload).map(key => {
        return encodeURIComponent(key) + '=' + encodeURIComponent(payload[key]);
    }).join('&');
};

async function getHeader(authorizationMode: AuthorizationMode, customHeaders?: Record<string, unknown>){
    const header = customHeaders || {};

    if (authorizationMode === AuthorizationMode.BEARER_TOKEN) {
        try{
            var accessToken = localStorage.getItem("token");
            header['Authorization'] = `Bearer ${accessToken}`;
        }catch{
        }
    }
    return {
        ...header,
        'Accept': 'application/json',
        'Content-Type': 'application/json',
    };
}

export async function getRequest(url: string, authorizationMode: AuthorizationMode, params = {}) {
    let data: object = { ...params };
    const query = convertPayloadToQueryString(data);

    const fullUrl = query ? `${apiURL}${url}?${query}` : `${apiURL}${url}`;

    const response = await fetch(fullUrl, {
        method: "GET",
        cache: "no-cache",
        headers: {
            'Accept': 'text/plain',
            'Content-Type': 'application/json',
        }
    })
    const datas = await response.json();
    return datas
}

export async function postRequest(url: string, authorizationMode: AuthorizationMode, data: any)  {
    
    const headers = await getHeader(authorizationMode)

    const response = await fetch(`${apiURL}${url}`, {
        method: "POST",
        cache: "no-cache",
        headers: headers,
        body: JSON.stringify(data),
    })
    const datas = await response.json();
    return datas
}

export async function postFileRequest(url: string, authorizationMode: AuthorizationMode, data: FormData) {
    const response = await fetch(`${apiURL}${url}`, {
        method: "POST",
        cache: "no-cache",
        body: data
    })
    const datas = await response.json();
    return datas
}