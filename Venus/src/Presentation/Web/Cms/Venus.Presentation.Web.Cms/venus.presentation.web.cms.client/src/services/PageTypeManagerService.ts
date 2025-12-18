import { ServiceBase } from "./base/ServiceBase";
import axios from "axios";
import { ResultDataControl, type IResultDataControl } from "../results";
import type { ReadPageTypeDto } from "../dtos";

export class PageTypeManagerService extends ServiceBase{

    public getPageTypeListAsync = async ():Promise<IResultDataControl<ReadPageTypeDto[]>> =>{
        const result = new ResultDataControl<ReadPageTypeDto[]>();
        
        return result;
    } 

}