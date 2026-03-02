import { ServiceBase } from "./base/ServiceBase";
import axios from "axios";
import { ReadPageAboutDto, ReadPageTypeDto } from "../dtos";
import type { CreatePageRequest } from "../models";
import { ReadPageDto } from "../dtos/page/ReadPageDto";

export class PageTypeManagerService extends ServiceBase{

    public getPageAboutListAsync = ():Promise<ReadPageAboutDto[]> =>{
        return axios.get<ReadPageAboutDto[]>(this.GetFullPath("PageManager/GetPageAbouts")).then(x=>{
            return x.data as ReadPageAboutDto[];
        })
    }

    public createPageAsync = (request:CreatePageRequest):Promise<ReadPageDto> =>{
        return axios.post<ReadPageDto>(this.GetFullPath("PageManager/CreatePage"),request).then(x=>{
            return x.data as ReadPageDto
        });
    }

}