import axios from "axios";
import { ServiceBase } from "./base/ServiceBase";

export class UrlService extends ServiceBase{
    
    public urlCheck = (props:{url:string}):Promise<boolean> =>{
        return axios.post(this.GetFullPath("PageManager/UrlCheck"),props.url,this.GetAxiosHeader()).then(x=>{
            return x.data
        });
    }


}