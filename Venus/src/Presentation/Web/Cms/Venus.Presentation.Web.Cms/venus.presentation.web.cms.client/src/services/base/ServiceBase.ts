import type { AxiosRequestConfig } from "axios";
import axios from "axios";
import type { DtoBase, DynamicPropertiesDtoBase } from "../../dtos/base/DtoBase";
import { object } from "zod";
import { SessionKeys, SessionStorageHelper } from "../../helpers";

export abstract class ServiceBase {

    protected GetFullPath(path: string): string {
        return `https://localhost:7002/api/${path}`;
    }

    protected GetParamsFullPath(path:string,queryParams:Record<string,any>):string{
        const params = Object.entries(queryParams).map((i,x)=>{
            return `?${i[0].toString()}=${i[1].toString()}`

        })
        return `${this.GetFullPath(path)}${params}`; 
    }

    public GetUserJwtToken():string|null {
        return SessionStorageHelper.get<string>(SessionKeys.cmsUser);
    }

    protected GetAxiosHeader():AxiosRequestConfig<any> {
        const conf = {
            headers: {
                'Authorization': `Bearer ${this.GetUserJwtToken()}`,
                "Language":SessionStorageHelper.get(SessionKeys.language),
                "LanguageId":SessionStorageHelper.get(SessionKeys.languageId),
                "Content-Type": "application/json"
            },
            withCredentials: true
        } as AxiosRequestConfig;

        return conf;
    }

    protected addDynamicData<T extends DynamicPropertiesDtoBase>(path:string, requestData:Record<string,any>):Promise<T> {
        return axios.post<T>(this.GetFullPath(path),requestData,this.GetAxiosHeader()).then(x=>{
            return x.data as T
        });
    }

    protected updateDynamicData<T extends DynamicPropertiesDtoBase>(path:string, requestData:Record<string,any>):Promise<T>{
        return axios.post<T>(this.GetFullPath(path),requestData,this.GetAxiosHeader()).then(x=>{
            return x.data as T
        })
    }

    protected getAll<T extends DtoBase>(path:string):Promise<T[]>{
        return axios.get<T[]>(this.GetFullPath(path),this.GetAxiosHeader()).then(x=>{
            return x.data as Array<T>
        });
    }

    protected get<T extends DtoBase>(path:string):Promise<T>{
        return axios.get<T>(this.GetFullPath(path),this.GetAxiosHeader()).then(x=>{
            return x.data as T
        });
    }


    protected post<T extends DtoBase|any>(path:string,request:any):Promise<T>{
        return axios.post<T>(this.GetFullPath(path),request,this.GetAxiosHeader()).then(x=>{
            return x.data as T
        });
    }

    protected getById<T extends DtoBase>(path:string,id:string):Promise<T>{
        return axios.get<T>(this.GetParamsFullPath(path,{id:id}),this.GetAxiosHeader()).then(x=>{
            return x.data as T
        });
    }

    protected remove(path:string,id:string):Promise<void>{
        return axios.post(this.GetFullPath(path),id,this.GetAxiosHeader()).then(x=>{
            return x.data;
        })
    }

}