import type { AxiosRequestConfig } from "axios";

export abstract class ServiceBase {

    protected GetFullPath = (path: string): string => {
        return `https://localhost:7002/api/${path}`;
    }

    public GetUserJwtToken = ():string|null => {
        return localStorage.getItem("cms_user");
    }

    protected GetAxiosHeader = ():AxiosRequestConfig<any> =>{
        const conf = {
            headers: {
                'Authorization': `Bearer ${this.GetUserJwtToken()}`,
                "Language":localStorage.getItem("cms_language"),
                "LanguageId":localStorage.getItem("cms_language_id"),
                "Content-Type": "application/json"
            },
            withCredentials: true
        } as AxiosRequestConfig;

        return conf;
    }
}