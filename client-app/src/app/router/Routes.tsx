import { createBrowserRouter, RouteObject } from "react-router-dom";
import CompaniesDashboard from "../../features/companies/dashboard/CompaniesDashboard";
import CurrentCompany from "../../features/companies/dashboard/CurrentCompany";
import MyCompanies from "../../features/companies/dashboard/MyCompanies";
import CompanyDetails from "../../features/companies/details/CompanyDetails";
import HomePage from "../../features/home/HomePage";
import MainPage from "../../features/home/MainPage";
import UserDasgboard from "../../features/users/dashboard/UserDasgboard";
import UserDetails from "../../features/users/details/UserDetails";
import CompanyForm from "../../features/users/form/CompanyForm";
import UserForm from "../../features/users/form/UserForm";
import LoginForm from "../../features/users/LoginForm";
import App from "../layouts/App";

export const routes: RouteObject[] = [
    {
        path: '/',
        element: <App />,
        children: [
            { path: '', element: <HomePage /> },
            { path: 'users', element: <UserDasgboard /> },
            { path: 'users/:id', element: <UserDetails /> },
            { path: 'createUser', element: <UserForm key='create' /> },
            { path: 'editUser/:id', element: <UserForm key='manage' /> },
            { path: 'login', element: <LoginForm /> },
            { path: 'companies', element: <CurrentCompany /> },
            { path: 'users/:id/companies/:companyid', element: <CompanyDetails /> },
            { path: 'editCompany/user/:id/company/:companyId', element: <CompanyForm key='manage' /> },
            { path: 'createCompany/user/:id', element: <CompanyForm key='create' /> },
            { path: 'myCompanies', element: <MyCompanies /> },
            { path: 'mainPage', element: <MainPage /> },
        ]
    }
]


export const router = createBrowserRouter(routes);