import {authDataService} from "../../Services/auth-data-service.ts";
import {Navigate, Outlet} from "react-router-dom";


const ProtectedRoute  = () => {
    const isAuthenticated = !!authDataService.getAuthData();

    if (!isAuthenticated) {
        return <Navigate to={"/login"} replace />;
    }

    return <Outlet />;
};

export default ProtectedRoute;