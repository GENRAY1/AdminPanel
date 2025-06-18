import {type FormEvent, useState} from 'react';
import {Form,Row,Col, Button, Container, Alert} from 'react-bootstrap';
import {authService} from "../../Services/auth-service.ts";
import {getErrorMessageOrDefault} from "../../Api/api-error.ts";
import {useNavigate} from "react-router-dom";

const LoginPage = () => {
    const [email, setEmail] = useState<string>('');
    const [password, setPassword] = useState<string>('');
    const [errorMessage, setErrorMessage] = useState<string | undefined>(undefined);
    const navigate = useNavigate();

    async function handleSubmit(e: FormEvent<HTMLFormElement>) {
        e.preventDefault();

        try {
            await authService.login(email, password);
            navigate("/")
        }catch(e) {
            const message = getErrorMessageOrDefault(e)
            setErrorMessage(message)
        }
    }

    return (
        <Container>
            <Row className="justify-content-md-center mt-5">
                <Col md={4}>
                    <h2 className="text-center mb-4">Login to CRM</h2>
                    {errorMessage && <Alert className="mt-3" variant="danger">{errorMessage}</Alert>}
                    <Form onSubmit={handleSubmit} >
                        <Form.Group controlId="formBasicEmail">
                            <Form.Label>Email address</Form.Label>
                            <Form.Control
                                type="email"
                                placeholder="Enter email"
                                value={email}
                                onChange={(e) => setEmail(e.target.value)}
                                required
                            />
                        </Form.Group>

                        <Form.Group controlId="formBasicPassword">
                            <Form.Label>Password</Form.Label>
                            <Form.Control
                                type="password"
                                placeholder="Password"
                                value={password}
                                onChange={(e) => setPassword(e.target.value)}
                                required
                            />
                        </Form.Group>
                        <Button variant="primary" type="submit" className="w-100 mt-3">
                            Login
                        </Button>
                    </Form>
                </Col>
            </Row>
        </Container>
    );
};

export default LoginPage;