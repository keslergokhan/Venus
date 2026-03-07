import { DynamicJsonDtoBase } from "../base/DtoBase";

export class ReadBlogDto extends DynamicJsonDtoBase{
    title:string;
    description:string;
    urlId:string;
}