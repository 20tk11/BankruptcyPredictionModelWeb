import { Navigate, Outlet, useLocation } from "react-router-dom";


export default function RequireAuth() {
    const location = useLocation();
    const role = localStorage.getItem('role')

    if (!role) {
        return <Navigate to='/' state={{ from: location }} />
    }
    return <Outlet />
}


