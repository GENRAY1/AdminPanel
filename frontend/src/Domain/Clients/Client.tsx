
export interface Client {
    id: string;
    name: string;
    email: string;
    createdAt: string;
    updatedAt: string | null;
    balance: number;
    tags: number[];
}