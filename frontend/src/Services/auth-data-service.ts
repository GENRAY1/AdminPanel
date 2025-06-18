const ACCESS_TOKEN_KEY = 'accessToken';
const REFRESH_TOKEN_KEY = 'refreshToken';
const ACCOUNT_ID_KEY = 'accountId';


interface AuthData {
    accountId: string;
    accessToken: string;
    refreshToken: string;
}

class AuthDataService {
    getAccessToken(): string | null {
        return localStorage.getItem(ACCESS_TOKEN_KEY);
    }

    setAccessToken(token: string): void {
        localStorage.setItem(ACCESS_TOKEN_KEY, token);
    }

    setAuthData(accessToken:string,refreshToken:string, accountId:string): void {
        this.setAccessToken(accessToken);
        localStorage.setItem(REFRESH_TOKEN_KEY, refreshToken);
        localStorage.setItem(ACCOUNT_ID_KEY, accountId);
    }

    getAuthData():AuthData | null {
        const accessToken = this.getAccessToken()
        const refreshToken = localStorage.getItem(REFRESH_TOKEN_KEY);
        const accountId =localStorage.getItem(ACCOUNT_ID_KEY);

        return accessToken && refreshToken && accountId
            ? {accessToken, refreshToken, accountId}
            : null;
    }

    removeAuthData(): void {
        localStorage.removeItem(ACCESS_TOKEN_KEY);
        localStorage.removeItem(REFRESH_TOKEN_KEY);
        localStorage.removeItem(ACCOUNT_ID_KEY);
    }
}

export const authDataService = new AuthDataService();