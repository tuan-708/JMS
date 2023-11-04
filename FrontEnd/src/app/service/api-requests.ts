import { environment } from 'src/environments/environment';
import { AuthorizationMode } from './constant';

const apiURL = environment.apiUrl;

export const convertPayloadToQueryString = (payload: any) => {
    return Object.keys(payload).map(key => {
        return encodeURIComponent(key) + '=' + encodeURIComponent(payload[key]);
    }).join('&');
};

async function getHeader(authorizationMode: AuthorizationMode) {
    if (authorizationMode === AuthorizationMode.BEARER_TOKEN) {
        var accessToken = localStorage.getItem("accessToken");
        return {
            'Accept': 'application/json',
            'Content-Type': 'application/json',
            'Authorization': `Bearer ${accessToken}`
        };
    }
    return {
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

export async function postRequest(url: string, authorizationMode: AuthorizationMode, data: any) {
    const response = await fetch(`${apiURL}${url}`, {
        method: "POST",
        cache: "no-cache",
        headers: {
            'Accept': 'text/plain',
            'Content-Type': 'application/json',
        },
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

// export function putRequest(url: string, data: any) {
//     fetch(url, {
//         method: "PUT",
//         mode: "cors",
//         cache: "no-cache",
//         credentials: "same-origin",
//         headers: {
//             "Content-Type": "application/json",
//         },
//         redirect: "follow",
//         referrerPolicy: "no-referrer",
//         body: JSON.stringify(data),
//     })
//         .then(response => {
//             return response.json()
//         })
// }

// export function deleteRequest(url: string, data: any) {
//     fetch(url, {
//         method: "DELETE",
//         mode: "cors",
//         cache: "no-cache",
//         credentials: "same-origin",
//         headers: {
//             "Content-Type": "application/json",
//         },
//         redirect: "follow",
//         referrerPolicy: "no-referrer",
//         body: JSON.stringify(data),
//     })
//         .then(response => {
//             return response.json()
//         })
// }