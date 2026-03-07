export abstract class DtoBase{
    id:string;
}

export abstract class DynamicJsonDtoBase extends DtoBase{
    jsonData:string;
}