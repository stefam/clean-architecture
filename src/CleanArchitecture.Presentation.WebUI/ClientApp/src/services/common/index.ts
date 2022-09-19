const resolve = async (url: string, options: RequestInit) => {
    const response = await fetch(url, options);
    const result = await response.json();
    const data = result.d;
    return data;
}

export const get = async <R>(url: string) => {
    const options = {
        method: "GET",
        headers: { "Content-Type": "application/json" }
    }

    return await resolve(url, options) as R;
}

export const post = async <T, R>(url: string, body?: T ) => {
    const options: RequestInit = {
        method: "POST",
        headers: { "Content-Type": "application/json" }
    }

    if (body)
        options.body = JSON.stringify(body);

    return await resolve(url, options) as R;
}

export const put = async <T, R>(url: string, body?: T) => {
    const options: RequestInit = {
        method: "PUT",
        headers: { "Content-Type": "application/json" }
    }

    if (body)
        options.body = JSON.stringify(body);

    return await resolve(url, options) as R;
}

export const del = async <R>(url: string) => {
    const options = {
        method: "DELETE",
        headers: { "Content-Type": "application/json" }
    }

    return await resolve(url, options) as R;
}