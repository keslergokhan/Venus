import type { ReadLanguageResourceKeyDto } from "../dtos";
import { ServiceBase } from "./base/ServiceBase";


export class LanguageResourceService extends ServiceBase{

    public getLanguageResourceAndValue = async () =>{
        return this.getAll<ReadLanguageResourceKeyDto>("language/get-resource");
    }

    public updateLanguageResource = async (props:{LanguageResourceValue:string,LanguageId:string,ResourceId:string}) =>{
        return this.post("language/update-resource",props);
    }
}