import axios from "axios";
import { ServiceBase } from "./base/ServiceBase";
import { ReadLanguageDto } from "../dtos";


export class LanguageService extends ServiceBase{


    public setLanguageAsync = (props:{languageCode:string}):Promise<void> =>{
        return axios.post(this.GetFullPath("Language/SetLanguage"),props,this.GetAxiosHeader())
    }

    public getLanguageAsync = async (): Promise<Array<ReadLanguageDto>> =>{
        return axios.post(this.GetFullPath("Language/GetLanguage"),{},this.GetAxiosHeader()).then(x=>{
            return x.data as Array<ReadLanguageDto>
        })
    }
}