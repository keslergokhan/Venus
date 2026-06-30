import { DtoBase } from "../base/DtoBase";

export class WriteWidgetDto extends DtoBase{
    key:string;
    template:string;
    TemplateDataSchema:string;
    WidgetType:number;
}