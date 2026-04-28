import { DtoBase } from "../base/DtoBase";
import type { ReadUrlDto } from "../urls/ReadUrlDto";

export class ReadPageDto extends DtoBase {
    UrlPath:string;
    Title:string;
    Description:string;
    PageAboutId:string;
    Url:ReadUrlDto
}