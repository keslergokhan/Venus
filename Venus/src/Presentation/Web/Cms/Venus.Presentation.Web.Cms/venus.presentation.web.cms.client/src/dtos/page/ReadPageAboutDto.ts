import { DtoBase } from "../base/DtoBase";
import type { ReadPageEntityDto } from "./ReadPageEntityDto";
import type { ReadPageTypeDto } from "./ReadPageTypeDto";

export class ReadPageAboutDto extends DtoBase{
    name:string;
    description:string;
    pageTypeId:string;
    entityDataUrlId:string;
    pageType:ReadPageTypeDto;
    pageEntity:ReadPageEntityDto;
    
}