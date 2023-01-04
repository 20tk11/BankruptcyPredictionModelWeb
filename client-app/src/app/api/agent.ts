import axios, { AxiosResponse } from 'axios';
import { Company } from '../models/company';
import { User, UserFormValues } from '../models/user';
import { store } from '../stores/store';

const sleep = (delay: number) => {
    return new Promise((resolve) => {
        setTimeout(resolve, delay)
    })
}
console.log(process.env.REACT_APP_API_URL)
axios.defaults.baseURL = process.env.REACT_APP_API_URL;
axios.interceptors.request.use(config => {
    const token = store.commonStore.token;
    if (token && config.headers) {
        config.headers.Authorization = `Bearer ${token}`;
    }
    return config;
})
axios.interceptors.response.use(async response => {
    try {
        if (process.env.NODE_ENV === 'development') await sleep(1000);
        return response;
    } catch (error) {
        console.log(error);
        return await Promise.reject(error);
    }
})


const responseBody = <T>(response: AxiosResponse<T>) => response.data;

const requests = {
    get: <T>(url: string) => axios.get<T>(url).then(responseBody),
    post: <T>(url: string, body: {}) => axios.post<T>(url, body).then(responseBody),
    put: <T>(url: string, body: {}) => axios.put<T>(url, body).then(responseBody),
    del: <T>(url: string) => axios.delete<T>(url).then(responseBody),
}

const Users = {
    list: () => requests.get<User[]>('/users'),
    details: (id: string) => requests.get<User>(`/users/${id}`),
    create: (user: User) => axios.post<void>(`/users`, user),
    update: (user: User) => axios.put<void>(`/users/${user.id}`, user),
    delete: (id: string) => axios.delete<void>(`/users/${id}`),
    current: () => requests.get<User>('/account'),
    login: (user: UserFormValues) => requests.post<User>('/account/login', user),
    register: (user: UserFormValues) => requests.post<User>('/account/register', user),
}
const Companies = {
    list: (id: string) => requests.get<Company[]>(`/users/${id}/companies`),
    details: (id: string, idCompany: string) => requests.get<Company>(`/users/${id}/companies/${idCompany}`),
    create: (id: string, company: Company) => axios.post<void>(`/users/${id}/companies`, company),
    update: (id: string, company: Company) => axios.put<void>(`/users/${id}/companies/${company.id}`, company),
    delete: (id: string) => axios.delete<void>(`/companies/${id}`),
}
// const Coeficients = {
//     list: (id: string, idCompany: string) => requests.get<Company[]>(`/users/${id}/companies/${idCompany}/coefs`),
//     details: (id: string, idCompany: string, idCoef: string) => requests.get<Company>(`/users/${id}/companies/${idCompany}/coefs/${idCoef}`),
//     create: (company: Company) => axios.post<void>(`/companies/${}`, company),
//     update: (id: string, company: Company) => axios.put<void>(`/users/${id}/companies/${company.id}`, company),
//     delete: (id: string) => axios.delete<void>(`/companies/${id}`),
// }

const agent = {
    Users,
    Companies
}
export default agent;