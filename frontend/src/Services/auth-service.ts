import axios from 'axios';
import {ADMIN_PANEL_API_URL} from "../../environment.ts";
import {authDataService} from "./auth-data-service.ts";
import type {LoginRequest, LoginResponse, RefreshRequest, RefreshResponse} from "../Api/admin-panel-contracts.ts";
import {ROUTS_PATHS} from "../Components/Auth/routes.ts";


class AuthService {
    readonly path: string = `${ADMIN_PANEL_API_URL}/auth`;

    async login(request:LoginRequest): Promise<LoginResponse> {
        const response = await axios.post<LoginResponse>(`${this.path}/login`, request);

        if (response.data.accessToken && response.data.refreshToken && response.data.accountId) {
            authDataService.setAuthData(
                response.data.accessToken,
                response.data.refreshToken,
                response.data.accountId);
        }

        return response.data;
    }

    async refresh(): Promise<void> {
        const authData = authDataService.getAuthData();
        if (!authData) {
            throw new Error("Authentication data not found");
        }

        try {
            const request:RefreshRequest = {
                refreshToken: authData.refreshToken,
                accountId: authData.accountId,
            }

            const response = await axios.post<RefreshResponse>(`${this.path}/refresh`, request);

            authDataService.setAccessToken(response.data.accessToken);
        } catch (error) {
            authDataService.removeAuthData()
            window.location.href = ROUTS_PATHS.login;
            throw error;
        }
    }

    async logout(): Promise<void> {
        const accessToken = authDataService.getAccessToken();

        authDataService.removeAuthData()

        if (accessToken) {
            await axios.post(`${this.path}/logout`, {}, {
                headers: {Authorization: `Bearer ${accessToken}`}
            });
        }

        window.location.href = ROUTS_PATHS.login;
    }
}

export const authService = new AuthService();