import { ServiceBase } from "./base/ServiceBase";
import axios from "axios";
import { ReadPageAboutDto } from "../dtos";

export class PageTypeManagerService extends ServiceBase{

    public getPageTypeListAsync = ():Promise<ReadPageAboutDto[]> =>{
        
        return axios.get<ReadPageAboutDto[]>(this.GetFullPath("PageManager/GetPageAbouts")).then(x=>{
            return x.data as ReadPageAboutDto[];
        })

    } 

}