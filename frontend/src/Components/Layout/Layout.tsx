import React from 'react';
import {Outlet} from "react-router-dom";
import Sidebar from "./Sidebar.tsx";

const Layout: React.FC = () => {
    return (
        <div className="d-flex">
            <Sidebar/>
            <div className="flex-grow-1 p-4" style={{backgroundColor: '#f8f9fa', minHeight: '100vh'}}>
                <Outlet/>
            </div>
        </div>
    );
};

export default Layout;