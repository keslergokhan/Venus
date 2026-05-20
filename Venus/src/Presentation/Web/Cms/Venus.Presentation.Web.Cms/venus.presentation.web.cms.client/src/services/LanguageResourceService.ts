import type { ReadLanguageResourceKeyDto } from "../dtos";
import { ServiceBase } from "./base/ServiceBase";


export class LanguageResourceService extends ServiceBase{

    public getLanguageResourceAndValue():Promise<ReadLanguageResourceKeyDto[]>{
        return this.getAll<ReadLanguageResourceKeyDto>("language/get-resource");
    }

    public updateLanguageResource(props:{LanguageResourceValue:string,LanguageId:string,ResourceId:string}):Promise<void> {
        return this.post("language/update-resource",props);
    }
}