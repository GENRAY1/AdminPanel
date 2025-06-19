import {Route, Routes} from "react-router-dom"
import LoginPage from "./Components/Pages/LoginPage.tsx";
import ProtectedRoute from "./Components/Auth/ProtectedRoute.tsx";
import DashboardPage from "./Components/Pages/DashboardPage.tsx";
import PaymentsPage from "./Components/Pages/PaymentsPage.tsx";
import Layout from "./Components/Layout/Layout.tsx";
import {ROUTS_PATHS} from "./Components/Auth/routes.ts";


function App() {
    return (
        <Routes>
            <Route path={ROUTS_PATHS.login} element={<LoginPage/>} />
            <Route element={<ProtectedRoute />}>
                <Route element={<Layout />}>
                    <Route path={ROUTS_PATHS.home} element={<DashboardPage />} />
                    <Route path={ROUTS_PATHS.dashboard} element={<DashboardPage />} />
                    <Route path={ROUTS_PATHS.payments} element={<PaymentsPage />} />
                </Route>
            </Route>
        </Routes>
    )
}

export default App
