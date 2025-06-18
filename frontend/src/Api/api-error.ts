import {isAxiosError} from "axios";

interface ApiErrorData {
    type: string;
    status: string;
    detail: string;
}

const DEFAULT_ERROR:string = "Something went wrong. Please try again later"

export const getErrorMessageOrDefault = (error: unknown) : string => {
    if (isAxiosError(error) && error.response?.data) {
        return (error.response.data as ApiErrorData).detail;
    }

    return DEFAULT_ERROR;
};