import axios from 'axios';
import {ADMIN_PANEL_API_URL} from "../../environment.ts";
import {authDataService} from "./auth-data-service.ts";

const API_URL = `${ADMIN_PANEL_API_URL}/auth`;

interface AuthResponse {
    accountId: string;
    accessToken: string;
    refreshToken: string;
}

class AuthService {
    async login(email: string, password: string): Promise<AuthResponse> {
        const response = await axios.post<AuthResponse>(`${API_URL}/login`, {
            email,
            password,
        });

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
            const response = await axios.post<{ accessToken: string }>(`${API_URL}/refresh`, {
                refreshToken: authData.refreshToken,
                accountId: authData.accountId,
            });

            authDataService.setAccessToken(response.data.accessToken);
        } catch (error) {
            authDataService.removeAuthData()
            throw error;
        }
    }

    async logout(): Promise<void> {
        const accessToken = authDataService.getAccessToken();

        authDataService.removeAuthData()

        if (accessToken) {
            await axios.post(`${API_URL}/logout`, {}, {
                headers: {Authorization: `Bearer ${accessToken}`}
            });
        }

        window.location.href = '/login';
    }
}

export const authService = new AuthService();