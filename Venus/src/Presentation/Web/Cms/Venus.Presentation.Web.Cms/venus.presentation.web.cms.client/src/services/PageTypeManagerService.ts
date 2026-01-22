import { ServiceBase } from "./base/ServiceBase";
import axios from "axios";
import { ReadPageAboutDto, ReadPageTypeDto } from "../dtos";

export class PageTypeManagerService extends ServiceBase{

    public getPageTypeListAsync = ():Promise<ReadPageTypeDto[]> =>{
        
        return axios.get<ReadPageTypeDto[]>(this.GetFullPath("PageManager/GetPageTypes")).then(x=>{
            return x.data as ReadPageTypeDto[];
        })

    } 

}