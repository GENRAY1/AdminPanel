import CurrentRate from "../Rates/CurrentRate.tsx";
import ClientsTable from "../Clients/ClientsTable.tsx";

const DashboardPage = () => {
    return (
        <div>
            <CurrentRate/>
            <ClientsTable/>
        </div>
    );
};

export default DashboardPage;