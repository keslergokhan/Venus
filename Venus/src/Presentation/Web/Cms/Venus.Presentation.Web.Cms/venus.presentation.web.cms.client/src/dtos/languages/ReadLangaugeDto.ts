import { DtoBase } from "../base/DtoBase";

export class ReadLanguageDto extends DtoBase{
    name:string;
    countryCode:string;
    culture:string;
    sort:number;
    currency:string
}