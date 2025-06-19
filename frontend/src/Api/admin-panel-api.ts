import axios, {HttpStatusCode} from 'axios';
import {ADMIN_PANEL_API_URL} from "../../environment.ts";
import {authService} from "../Services/auth-service.ts";
import {authDataService} from "../Services/auth-data-service.ts";


const adminPanelApi = axios.create({
    baseURL: ADMIN_PANEL_API_URL,
});

adminPanelApi.interceptors.request.use(
    async (config) => {
        const accessToken = authDataService.getAccessToken();

        if (accessToken) {
            config.headers.Authorization = `Bearer ${accessToken}`;
        }

        return config;
    },
    (error) => {
        return Promise.reject(error);
    }
);

adminPanelApi.interceptors.response.use(
    (response) => response,
    async (error) => {
        const originalRequest = error.config;

        if (error.response?.status === HttpStatusCode.Unauthorized && !originalRequest._retry) {
            originalRequest._retry = true;

            try {
                await authService.refresh();

                const newAccessToken = authDataService.getAccessToken();

                if (newAccessToken) {
                    originalRequest.headers.Authorization = `Bearer ${newAccessToken}`;
                    return adminPanelApi(originalRequest);
                }
            } catch (refreshError) {
                return Promise.reject(refreshError);
            }
        }

        return Promise.reject(error);
    }
);

export default adminPanelApi;