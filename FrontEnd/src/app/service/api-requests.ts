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

export function getRequest(url: string, authorizationMode: AuthorizationMode, params = {}) {
    let data: object = { ...params };
    const query = convertPayloadToQueryString(data);

    const fullUrl = query ? `${apiURL}${url}?${query}` : `${apiURL}/${url}`;
    fetch(fullUrl, {
        method: "GET",
        cache: "no-cache",
        headers: {
            'Accept': 'text/plain',
            'Content-Type': 'application/json',
            'Access-Control-Allow-Origin': 'http://localhost:8080'
        }
    })
        .then(response => response.json())
        .then(json => console.log(json))

    // fetch('http://localhost:8080/api/Recuirter/get-all?page=10')
    //   .then(response => response.json())
    //   .then(json => console.log(json))
}

export function postRequest(url: string, data: any) {
    fetch(url, {
        method: "POST",
        mode: "cors",
        cache: "no-cache",
        credentials: "same-origin",
        headers: {
            "Content-Type": "application/json",
        },
        redirect: "follow",
        referrerPolicy: "no-referrer",
        body: JSON.stringify(data),
    })
        .then(response => {
            return response.json()
        })

}

export function putRequest(url: string, data: any) {
    fetch(url, {
        method: "PUT",
        mode: "cors",
        cache: "no-cache",
        credentials: "same-origin",
        headers: {
            "Content-Type": "application/json",
        },
        redirect: "follow",
        referrerPolicy: "no-referrer",
        body: JSON.stringify(data),
    })
        .then(response => {
            return response.json()
        })
}

export function deleteRequest(url: string, data: any) {
    fetch(url, {
        method: "DELETE",
        mode: "cors",
        cache: "no-cache",
        credentials: "same-origin",
        headers: {
            "Content-Type": "application/json",
        },
        redirect: "follow",
        referrerPolicy: "no-referrer",
        body: JSON.stringify(data),
    })
        .then(response => {
            return response.json()
        })
}