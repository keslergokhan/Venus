import type { AxiosRequestConfig } from "axios";
import axios from "axios";
import type { DtoBase } from "../../dtos/base/DtoBase";
import { object } from "zod";

export abstract class ServiceBase {

    protected GetFullPath = (path: string): string => {
        return `https://localhost:7002/api/${path}`;
    }

    protected GetParamsFullPath = (path:string,queryParams:Record<string,any>):string =>{
        const params = Object.entries(queryParams).map((i,x)=>{
            return `?${i[0].toString()}=${i[1].toString()}`

        })
        return `${this.GetFullPath(path)}${params}`; 
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

    public getAll = <T extends DtoBase>(path:string):Promise<T[]> =>{
        return axios.get<T[]>(this.GetFullPath(path),this.GetAxiosHeader()).then(x=>{
            return x.data as Array<T>
        });
    }

    public get = <T extends DtoBase>(path:string):Promise<T> =>{
        return axios.get<T>(this.GetFullPath(path),this.GetAxiosHeader()).then(x=>{
            return x.data as T
        });
    }

    public getById = <T extends DtoBase>(path:string,id:string):Promise<T> =>{
        return axios.get<T>(this.GetParamsFullPath(path,{id:id}),this.GetAxiosHeader()).then(x=>{
            return x.data as T
        });
    }

    public removeAsync = (path:string,id:string):Promise<void> => {
        return axios.post(this.GetFullPath(path),id,this.GetAxiosHeader()).then(x=>{
            return x.data;
        })
    }

}