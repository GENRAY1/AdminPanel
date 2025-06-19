import type {
    GetPaymentsRequest,
    GetPaymentsResponse
} from "../Api/admin-panel-contracts.ts";
import adminPanelApi from "../Api/admin-panel-api.ts";

class PaymentService{
    readonly path:string = "/payments";
    async GetPayments(request:GetPaymentsRequest): Promise<GetPaymentsResponse> {
        const response
            = await adminPanelApi.get<GetPaymentsResponse>(this.path, {params: request})

        return response.data;
    }
}

export const paymentService = new PaymentService();