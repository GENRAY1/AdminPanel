import {Alert, Button, Card, Form, InputGroup} from "react-bootstrap";
import {type FormEvent, useEffect, useState} from "react";
import {rateService} from "../../Services/rate-service.ts";
import {getErrorMessageOrDefault} from "../../Api/api-error.ts";

const CurrentRate = () => {
    const [open, setOpen] = useState<boolean>(false);
    const [isLoadingFailed, setIsLoadingFailed] = useState<boolean>(false);
    const [editRateError, setEditRateError] = useState<string | undefined>(undefined);
    const [rate, setRate] = useState<number>(0);
    const [rateInput, setRateInput] = useState<string>("");

    useEffect(() => {
        const fetch = async ()=>{
            try {
               const response
                   = await rateService.getCurrentRate()

               setRate(response.value)
            }catch {
                setIsLoadingFailed(true)
            }
        }

        fetch();
    }, [])

    async function handleEditRate(event: FormEvent<HTMLFormElement>) {
        event.preventDefault();
        try {
            const value = parseFloat(rateInput)

            await rateService.createRate({value})
            setRate(value)
            setEditRateError(undefined)
        }catch(e) {
            const message = getErrorMessageOrDefault(e)
            setEditRateError(message)
        }
    }

    return (
        <Card style={{  maxWidth: '400px' }}>
            <Card.Header className="d-flex align-items-center">
                <Card.Title fw-bold='fw-bold"'>CURRENT RATE:
                    {
                        !isLoadingFailed
                            ? <span className="fs-4 text-success"> {rate} $</span>
                            : <span className="text-danger"> Failed to upload</span>
                    }
                </Card.Title>
                {!isLoadingFailed &&
                    <Button
                        variant="link"
                        onClick={() => setOpen(!open)}
                    >
                        {!open ? 'edit' : 'close'}
                    </Button>
                }
            </Card.Header>

            {open && (
                <Card.Body>

                    {editRateError && <Alert className="alert-danger">{editRateError}</Alert>}
                    <Form onSubmit={handleEditRate}>
                        <Form.Group className="mb-3" controlId="rateInput">
                            <InputGroup>
                                <Form.Control
                                    type="number"
                                    step="0.01"
                                    placeholder="Enter rate"
                                    value={rateInput}
                                    onChange={e => setRateInput(e.currentTarget.value)}
                                />
                                <Button variant="primary" type="submit">Submit</Button>
                            </InputGroup>
                        </Form.Group>
                    </Form>
                </Card.Body>
            )}
        </Card>
    );
};

export default CurrentRate;