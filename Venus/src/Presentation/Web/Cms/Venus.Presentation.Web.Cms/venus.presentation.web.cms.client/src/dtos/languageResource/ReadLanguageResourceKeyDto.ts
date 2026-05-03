import { DtoBase } from "../base/DtoBase";
import type { ReadLanguageResourceValueDto } from "./ReadLanguageResourceValueDto";

export class ReadLanguageResourceKey extends DtoBase{
    name:string;
    defaultValue:string;
    ResourceValue:ReadLanguageResourceValueDto[]
}