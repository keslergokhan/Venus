import { DynamicPropertiesDtoBase } from "../base/DtoBase";
import type { ReadUrlDto } from "../urls/ReadUrlDto";

export class ReadBlogDto extends DynamicPropertiesDtoBase{
    title:string;
    description:string;
    urlId:string;
    url:ReadUrlDto;
}