import { DtoBase } from "../base/DtoBase";

export class ReadPageAboutDto extends DtoBase{
    name:string;
    description:string;
    pageTypeId:string;
    entityDataUrlId:string;
    
}