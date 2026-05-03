import { DtoBase } from "../base/DtoBase";
import type { ReadLanguageResourceValueDto } from "./ReadLanguageResourceValueDto";

export class ReadLanguageResourceKeyDto extends DtoBase{
    key:string;
    defaultValue:string;
    ResourceValue:ReadLanguageResourceValueDto[]
}