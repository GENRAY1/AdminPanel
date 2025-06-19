import { useState, useEffect } from 'react';
import {Table, Button, Alert} from 'react-bootstrap';
import type {Client} from "../../Domain/Clients/Client.tsx";
import ClientTableRow from "./ClientTableRow.tsx";
import {clientService} from "../../Services/client-service.ts";
import {getErrorMessageOrDefault} from "../../Api/api-error.ts";
import ClientModalForm from "./ClientModalForm.tsx";
import type {ClientFormData} from "../../Domain/Clients/ClientFormData.ts";


const ClientsTable = () => {
    const [clients, setClients] = useState<Client[]>([]);
    const [error, setError] = useState<string | null>(null);
    const [modalShow, setModalShow] = useState(false);
    const [currentClient, setCurrentClient] = useState<Client | null>(null);

    useEffect(() => {
        const fetchClients = async () => {
            try {
                const response
                    = await clientService.getClients();

                setClients(response.clients);
            } catch (err) {
                const message = getErrorMessageOrDefault(err)
                setError(message);
            }
        };

        fetchClients();
    }, []);

    const handleCreate = () => {
        setCurrentClient(null);
        setModalShow(true);
    };

    const handleEdit = (clientId: string) => {
        const client = clients.find(c => c.id === clientId);
        if (client) {
            setCurrentClient(client);
            setModalShow(true);
        }
    };

    const handleDelete = async (clientId: string) => {
        try {
            await clientService.deleteClient(clientId);
        } catch (err) {
            const message = getErrorMessageOrDefault(err)
            setError(message);
        }
    };

    const handleSubmit = async (clientData: ClientFormData) => {
        try {
            if (currentClient) {
                const client = await clientService.updateClient( {
                    id: currentClient.id,
                    ...clientData
                });
                setClients(prev => prev.map(c => c.id === currentClient.id ? client : c));
            } else {
                const client = await clientService.createClient({...clientData});
                setClients(prev => [...prev, client]);
            }
            setError(null);
        } catch (err) {
            const message = getErrorMessageOrDefault(err);
            setError(message);
            throw err;
        }
    };

    return (
        <div className="mt-4">
            <div className="d-flex justify-content-between mb-3 align-items-center">
                <h2>Clients</h2>
                <Button variant="primary" onClick={handleCreate}>
                    Add New Client
                </Button>
            </div>

            {error && <Alert className="alert-danger">Error: {error}</Alert>}

            <Table striped bordered hover responsive className="mt-3">
                <thead className="table-dark">
                <tr>
                    <th>Name</th>
                    <th>Email</th>
                    <th>Created At</th>
                    <th>Updated At</th>
                    <th>Token balance</th>
                    <th>Tags</th>
                    <th>Actions</th>
                </tr>
                </thead>
                <tbody>
                {clients.length > 0 ? (
                    clients.map((client) => (
                        <ClientTableRow
                            key={client.id}
                            client={client}
                            onEdit={handleEdit}
                            onDelete={handleDelete}
                        />
                    ))
                ) : (
                    <tr>
                        <td colSpan={7} className="text-center">
                            No clients found
                        </td>
                    </tr>
                )}
                </tbody>
            </Table>
            <ClientModalForm
                show={modalShow}
                onHide={() => setModalShow(false)}
                onSubmit={handleSubmit}
                client={currentClient}
                error={error}
            />
        </div>
    );
};

export default ClientsTable;