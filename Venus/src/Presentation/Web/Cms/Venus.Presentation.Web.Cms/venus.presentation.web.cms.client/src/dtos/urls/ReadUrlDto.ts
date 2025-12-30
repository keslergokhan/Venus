import { DtoBase } from "../base/DtoBase";
import type { UrlTypeEnum } from "../enums/UrlTypeEnum";

export class ReadUrlDto extends DtoBase{
    path:string;
    fullPath:string;
    urlType:UrlTypeEnum;
    languageId:string;
}
