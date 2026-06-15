import { DtoBase } from "../base/DtoBase";

export class ReadWidgetDto extends DtoBase{
    key:string;
    template:string;
    TemplateDataSchema:string;
    WidgetType:number;
}