import { DtoBase } from "../base/DtoBase";
import type { ReadUrlDto } from "../urls/ReadUrlDto";

export class ReadPageDto extends DtoBase {
    urlPath:string;
    title:string;
    description:string;
    pageAboutId:string;
    url:ReadUrlDto
}