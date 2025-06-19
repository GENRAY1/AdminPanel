import type {CreateRateRequest, GetCurrentRateResponse} from "../Api/admin-panel-contracts.ts";
import adminPanelApi from "../Api/admin-panel-api.ts";

class RateService{
    readonly path:string = "/rate";
    async getCurrentRate(): Promise<GetCurrentRateResponse> {
        const response
            = await adminPanelApi.get<GetCurrentRateResponse>(this.path)

        return response.data;
    }
    async createRate(request: CreateRateRequest): Promise<void> {
        await adminPanelApi.post(this.path, request);
    }
}

export const rateService = new RateService();