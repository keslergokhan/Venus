import { DtoBase } from "../base/DtoBase";

export class ReadConfigurationSettingDto extends DtoBase{
    key:string;
    value:string;
}