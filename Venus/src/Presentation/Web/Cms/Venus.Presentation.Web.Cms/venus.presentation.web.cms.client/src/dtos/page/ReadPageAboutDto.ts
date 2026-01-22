import { DtoBase } from "../base/DtoBase";
import type { ReadUrlDto } from "../urls/ReadUrlDto";

export class ReadPageAboutDto extends DtoBase{
    name:string;
    description:string;
    pageTypeId:string;
    entityDataUrlId:string;
}