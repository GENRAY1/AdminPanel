import adminPanelApi from "../Api/admin-panel-api.ts";
import type {CreateClientRequest, GetClientsResponse, UpdateClientRequest} from "../Api/admin-panel-contracts.ts";

class ClientService{
    readonly path:string = "/clients";
    async getClients(): Promise<GetClientsResponse> {
        const response
            = await adminPanelApi.get<GetClientsResponse>(this.path)

        return response.data;
    }
    async createClient(request: CreateClientRequest): Promise<void> {
        await adminPanelApi.post(this.path, request);
    }

    async updateClient(request: UpdateClientRequest): Promise<void> {
        await adminPanelApi.put(`${this.path}/${request.id}`, request);
    }

    async deleteClient(id: string): Promise<void> {
        await adminPanelApi.delete(`${this.path}/${id}`);
    }
}

export const clientService = new ClientService();