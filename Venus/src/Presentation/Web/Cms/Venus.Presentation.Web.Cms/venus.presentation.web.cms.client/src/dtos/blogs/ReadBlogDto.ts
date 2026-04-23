import { DynamicJsonDtoBase } from "../base/DtoBase";
import type { ReadUrlDto } from "../urls/ReadUrlDto";

export class ReadBlogDto extends DynamicJsonDtoBase{
    title:string;
    description:string;
    urlId:string;
    url:ReadUrlDto
}