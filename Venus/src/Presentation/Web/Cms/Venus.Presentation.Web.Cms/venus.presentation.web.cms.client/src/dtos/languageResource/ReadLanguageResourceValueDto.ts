import { DtoBase } from "../base/DtoBase";

export class ReadLanguageResourceValueDto extends DtoBase{
    value:string;
    languageId:string;
}