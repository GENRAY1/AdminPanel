export interface Payment {
    id: string;
    amount: number;
    createdAt: string;
    clientId: string;
    clientName: string;
    rateId: string;
    rateValue: number;
    cost: number;
}