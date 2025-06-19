import {useEffect, useState} from 'react';
import {Alert, Table} from "react-bootstrap";
import type {Payment} from "../../Domain/Payments/Payment.ts";
import {getErrorMessageOrDefault} from "../../Api/api-error.ts";
import {paymentService} from "../../Services/payment-service.ts";


const TAKE_PAYMENTS:number = 20;

const PaymentTable = () => {
    const [payments, setPayments] = useState<Payment[]>([]);
    const [error, setError] = useState<string | null>(null);

    useEffect(() => {
        const fetch = async ()=>{
            try {
                const response
                    = await paymentService.GetPayments({take: TAKE_PAYMENTS})

                setPayments(response.payments)
            }catch (e){
                const message = getErrorMessageOrDefault(e)
                setError(message)
            }
        }
        fetch();
    }, []);

    return (
        <div>
            {error && <Alert className="alert-danger">Error: {error}</Alert>}
            <Table striped bordered hover responsive className="mt-3">
                <thead className="table-dark">
                <tr>
                    <th>Number of tokens</th>
                    <th>Client's name</th>
                    <th>Rate</th>
                    <th>Purchase amount</th>
                    <th>Created At</th>
                </tr>
                </thead>
                <tbody>
                {payments.length > 0 ? (
                    payments.map((p) => (
                        <tr key={p.id}>
                            <td>{p.amount}</td>
                            <td>{p.clientName}</td>
                            <td>{p.rateValue}</td>
                            <td>{p.cost}</td>
                            <td>{p.createdAt}</td>
                        </tr>
                    ))
                ) : (
                    <tr>
                        <td colSpan={7} className="text-center">
                            No payments found
                        </td>
                    </tr>
                )}
                </tbody>
            </Table>
        </div>
    );
};

export default PaymentTable;