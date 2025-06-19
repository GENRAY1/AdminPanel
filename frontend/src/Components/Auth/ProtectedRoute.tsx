import {authDataService} from "../../Services/auth-data-service.ts";
import {Navigate, Outlet} from "react-router-dom";
import {ROUTS_PATHS} from "./routes.ts";


const ProtectedRoute  = () => {
    const isAuthenticated = !!authDataService.getAuthData();

    if (!isAuthenticated) {
        return <Navigate to={ROUTS_PATHS.login} replace />;
    }

    return <Outlet />;
};

export default ProtectedRoute;