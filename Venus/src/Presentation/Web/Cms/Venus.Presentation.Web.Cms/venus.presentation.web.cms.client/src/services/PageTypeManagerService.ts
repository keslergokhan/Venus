import { ServiceBase } from "./base/ServiceBase";
import axios from "axios";
import { ReadPageAboutDto, ReadPageTypeDto } from "../dtos";

export class PageTypeManagerService extends ServiceBase{

    public getPageAboutListAsync = ():Promise<ReadPageAboutDto[]> =>{
        return axios.get<ReadPageAboutDto[]>(this.GetFullPath("PageManager/GetPageAbouts")).then(x=>{
            return x.data as ReadPageAboutDto[];
        })

    } 

}