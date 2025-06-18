import {Route, Routes} from "react-router-dom"
import LoginPage from "./Components/Pages/LoginPage.tsx";
import ProtectedRoute from "./Components/Auth/ProtectedRoute.tsx";
import DashboardPage from "./Components/Pages/DashboardPage.tsx";
import PaymentsPage from "./Components/Pages/PaymentsPage.tsx";
import Layout from "./Components/Layout/Layout.tsx";


function App() {
    return (
        <Routes>
            <Route path="/login" element={<LoginPage/>} />
            <Route element={<ProtectedRoute />}>
                <Route element={<Layout />}>
                    <Route path="/" element={<DashboardPage />} />
                    <Route path="/dashboard" element={<DashboardPage />} />
                    <Route path="/payments" element={<PaymentsPage />} />
                </Route>
            </Route>
        </Routes>
    )
}

export default App
