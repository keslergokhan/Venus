import { ServiceBase } from "./base/ServiceBase";


export class LoginService extends ServiceBase{
    public loginAsync = async (email:string,password:string)=>{
        console.log("Kayıt olundu");
    }
}