import React from 'react';
import { Link, useLocation } from 'react-router-dom';

const Sidebar: React.FC = () => {
    const location = useLocation();

    return (
        <div className="d-flex flex-column flex-shrink-0 p-3 bg-dark text-white" style={{ width: '300px', height: '100vh' }}>
            <Link to="/" className="d-flex align-items-center justify-content-center mb-3 mb-md-0 me-md-auto text-white text-decoration-none">
                <span className="fs-2 p-lg-0">AdminPanel</span>
            </Link>
            <hr />
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
            <hr />
            <div className="d-flex">
                <button type="button" className="btn btn-primary">Logout</button>
            </div>
        </div>
    );
};

export default Sidebar;