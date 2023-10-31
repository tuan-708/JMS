import { environment } from 'src/environments/environment';

const apiURL = environment.apiUrl;

export function getRequest(url: string) {
    fetch(apiURL+url)
        .then(response => {
            return response.json()
    })
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