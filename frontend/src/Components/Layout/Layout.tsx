import React from 'react';
import {Link, Outlet} from "react-router-dom";
import {authService} from "../../Services/auth-service.ts";

const Layout: React.FC = () => {
    return (
        <div className="d-flex">
            <div className="d-flex flex-column flex-shrink-0 p-3 bg-dark text-white"
                 style={{width: '300px', height: '100vh'}}>
                <Link to="/"
                      className="d-flex align-items-center justify-content-center mb-3 mb-md-0 me-md-auto text-white text-decoration-none">
                    <span className="fs-2 p-lg-0">AdminPanel</span>
                </Link>
                <hr/>
                <ul className="nav nav-pills flex-column mb-auto">
                    <li className="nav-item">
                        <Link
                            to="/"
                            className={`nav-link ${location.pathname === '/' ? 'active' : 'text-white'}`}
                        >
                            <i className="bi bi-speedometer2 me-2"></i>
                            Dashboard
                        </Link>
                    </li>
                    <li>
                        <Link
                            to="/payments"
                            className={`nav-link ${location.pathname === '/payments' ? 'active' : 'text-white'}`}>
                            <i className="bi bi-credit-card me-2"></i>
                            Payments
                        </Link>
                    </li>
                </ul>
                <hr/>
                <div className="d-flex">
                    <button type="button" onClick={async ()=>await authService.logout()} className="btn btn-primary">Logout</button>
                </div>
            </div>
            <div className="flex-grow-1 p-4" style={{backgroundColor: '#f8f9fa', minHeight: '100vh'}}>
                <Outlet/>
            </div>
        </div>
    );
};

export default Layout;