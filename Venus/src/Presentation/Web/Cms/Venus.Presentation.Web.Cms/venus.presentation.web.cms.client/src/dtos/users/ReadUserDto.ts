import { DtoBase } from "../base/DtoBase";

export class ReadUserDto extends DtoBase{
    name:string;
    surname:string;
    email:string;
    jwtToken:string;
}