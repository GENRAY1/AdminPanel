import React, {type FC, useEffect, useState} from "react";
import {Alert, Badge, Button, Form, Modal} from "react-bootstrap";
import type {Client} from "../../Domain/Clients/Client.tsx";
import {allClientTags, clientTagLocalization} from "../../Domain/Clients/client-tag.ts";
import type {ClientFormData} from "../../Domain/Clients/ClientFormData.ts";

interface ClientModalProps {
    show: boolean;
    onHide: () => void;
    onSubmit: (client: ClientFormData) => Promise<void>;
    client?: Client | null;
    error?: string | null;
}

const ClientModalForm: FC<ClientModalProps> = ({ show, onHide, onSubmit, client, error }) => {
    const [name, setName] = useState('');
    const [email, setEmail] = useState('');
    const [balance, setBalance] = useState(0);
    const [tags, setTags] = useState<number[]>([]);
    const [isSubmitting, setIsSubmitting] = useState(false);

    useEffect(() => {
        if (client) {
            setName(client.name);
            setEmail(client.email);
            setBalance(client.balance);
            setTags(client.tags);
        } else {
            setName('');
            setEmail('');
            setBalance(0);
            setTags([]);
        }
    }, [client, show]);

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        setIsSubmitting(true);
        try {
            await onSubmit({
                name,
                email,
                balance,
                tags
            });
            onHide();
        } finally {
            setIsSubmitting(false);
        }
    };

    const toggleTag = (tagId: number) => {
        setTags(prev =>
            prev.includes(tagId)
                ? prev.filter(id => id !== tagId)
                : [...prev, tagId]
        );
    };

    return (
        <Modal show={show} onHide={onHide} centered>
            <Modal.Header closeButton>
                <Modal.Title>{client ? 'Edit Client' : 'Create New Client'}</Modal.Title>
            </Modal.Header>
            <Form onSubmit={handleSubmit}>
                <Modal.Body>
                    {error && <Alert variant="danger">{error}</Alert>}

                    <Form.Group className="mb-3">
                        <Form.Label>Name</Form.Label>
                        <Form.Control
                            type="text"
                            value={name}
                            onChange={(e) => setName(e.target.value)}
                            required
                        />
                    </Form.Group>

                    <Form.Group className="mb-3">
                        <Form.Label>Email</Form.Label>
                        <Form.Control
                            type="email"
                            value={email}
                            onChange={(e) => setEmail(e.target.value)}
                            required
                        />
                    </Form.Group>

                    <Form.Group className="mb-3">
                        <Form.Label>Balance</Form.Label>
                        <Form.Control
                            type="number"
                            step="0.01"
                            value={balance}
                            onChange={(e) => setBalance(parseFloat(e.target.value))}
                            required
                        />
                    </Form.Group>

                    <Form.Group className="mb-3">
                        <Form.Label>Tags</Form.Label>
                        <div className="d-flex flex-wrap gap-2">
                            {allClientTags.map(tag => (
                                <Badge
                                    key={tag}
                                    bg={tags.includes(tag) ? 'primary' : 'secondary'}
                                    role="button"
                                    onClick={() => toggleTag(tag)}
                                    style={{ cursor: 'pointer' }}
                                >
                                    {clientTagLocalization[tag]}
                                </Badge>
                            ))}
                        </div>
                    </Form.Group>
                </Modal.Body>
                <Modal.Footer>
                    <Button variant="secondary" onClick={onHide} disabled={isSubmitting}>
                        Cancel
                    </Button>
                    <Button variant="primary" type="submit" disabled={isSubmitting}>
                        {isSubmitting ? 'Saving...' : 'Save Changes'}
                    </Button>
                </Modal.Footer>
            </Form>
        </Modal>
    );
};

export default ClientModalForm;