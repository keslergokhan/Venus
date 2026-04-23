import axios from "axios";
import type { ReadPageDto } from "../dtos";
import type { CreatePageRequest } from "../models";
import { ServiceBase } from "./base/ServiceBase";

export class PageService extends ServiceBase{
    public createPageAsync = (request:CreatePageRequest):Promise<ReadPageDto> =>{
        return axios.post<ReadPageDto>(this.GetFullPath("PageManager/CreatePage"),request,this.GetAxiosHeader()).then(x=>{
            return x.data as ReadPageDto
        });
    }

    public GetEntityDetailPages = () =>{
        return axios.get<ReadPageDto[]>(this.GetFullPath("pagemanager/GetEntityDetailVenusPages"),this.GetAxiosHeader()).then(x=>{
            return x.data as ReadPageDto[]
        })
    }
}