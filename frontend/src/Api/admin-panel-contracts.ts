import type {Client} from "../Domain/Clients/Client.tsx";

export interface LoginResponse {
    accountId: string;
    accessToken: string;
    refreshToken: string;
}

export interface LoginRequest {
    email: string;
    password: string;
}

export interface RefreshRequest {
    accountId: string;
    refreshToken: string;
}

export interface RefreshResponse {
    accessToken: string;
}

export interface CreateRateRequest {
    value: number;
}

export interface GetCurrentRateResponse {
    id: string;
    value: number;
    createdAt: string;
}

export interface CreateClientRequest {
    name: string;
    email: string;
    balance: number;
    tags: number[];
}

export interface GetClientsResponse {
    clients: Client[];
}

export interface UpdateClientRequest {
    id: string;
    name: string;
    email: string;
    balance: number;
    tags: number[];
}