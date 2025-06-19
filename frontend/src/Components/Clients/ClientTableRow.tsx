
import type {Client} from "../../Domain/Clients/Client.tsx";
import {clientTagLocalization, isClientTag} from "../../Domain/Clients/client-tag.ts";
import {Badge, Button, ButtonGroup} from "react-bootstrap";
import type {FC} from "react";

interface ClientTableRowProps {
    client: Client;
    onEdit: (id: string) => void;
    onDelete: (id: string) => Promise<void>;
}

const ClientTableRow : FC<ClientTableRowProps> = ({client, onEdit, onDelete}) => {
    return (
        <tr key={client.id}>
            <td>{client.name}</td>
            <td>{client.email}</td>
            <td>{client.createdAt}</td>
            <td>{client.updatedAt}</td>
            <td>{client.balance.toFixed(2)}</td>
            <td>
                <div className="d-flex flex-wrap gap-1">
                    {client.tags.map((tag) => (
                        isClientTag(tag) ? (
                            <Badge key={tag} bg="info" className="text-dark">
                                {clientTagLocalization[tag]}
                            </Badge>
                        ) : null
                    ))}
                </div>
            </td>
            <td>
                <ButtonGroup size="sm">
                    <Button
                        variant="outline-primary"
                        onClick={() => onEdit(client.id)}
                    >
                        Edit
                    </Button>
                    <Button
                        variant="outline-danger"
                        onClick={() => onDelete(client.id)}
                    >
                        Delete
                    </Button>
                </ButtonGroup>
            </td>
        </tr>
    );
};

export default ClientTableRow;