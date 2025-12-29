import { ServiceBase } from "./base/ServiceBase";
import axios from "axios";
import { ResultDataControl, type IResultDataControl } from "../results";
import type { ReadPageAboutDto } from "../dtos";

export class PageTypeManagerService extends ServiceBase{

    public getPageTypeListAsync = async ():Promise<IResultDataControl<ReadPageAboutDto[]>> =>{
        
        return axios.get<IResultDataControl<ReadPageAboutDto[]>>(this.GetFullPath("PageManager/GetPageAbouts")).then(x=>{
            return x.data as IResultDataControl<ReadPageAboutDto[]>;
        }).catch(x=>{
            return new ResultDataControl<ReadPageAboutDto[]>();
        })

    } 

}