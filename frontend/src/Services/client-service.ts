import adminPanelApi from "../Api/admin-panel-api.ts";
import type {CreateClientRequest, GetClientsResponse, UpdateClientRequest} from "../Api/admin-panel-contracts.ts";
import type {Client} from "../Domain/Clients/Client.tsx";

class ClientService{
    readonly path:string = "/clients";
    async getClients(): Promise<GetClientsResponse> {
        const response
            = await adminPanelApi.get<GetClientsResponse>(this.path)

        return response.data;
    }
    async createClient(request: CreateClientRequest): Promise<Client> {
        const response = await adminPanelApi.post<Client>(this.path, request);

        return response.data;
    }

    async updateClient(request: UpdateClientRequest): Promise<Client> {
        const response
            = await adminPanelApi.put<Client>(`${this.path}/${request.id}`, request);

        return response.data;
    }

    async deleteClient(id: string): Promise<void> {
        await adminPanelApi.delete(`${this.path}/${id}`);
    }
}

export const clientService = new ClientService();