import type { AxiosRequestConfig } from "axios";
import axios from "axios";
import type { DtoBase } from "../../dtos/base/DtoBase";

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

    public addDataAsync = <T extends DtoBase>(path:string, requestData:Record<string,any>):Promise<T> =>{
        return axios.post<T>(this.GetFullPath(path),requestData,this.GetAxiosHeader()).then(x=>{
            return x.data as T
        });
    }

    public getDatas = <T extends DtoBase>(path:string):Promise<T[]> =>{
        return axios.get<T[]>(this.GetFullPath(path),this.GetAxiosHeader()).then(x=>{
            return x.data as Array<T>
        });
    }

}