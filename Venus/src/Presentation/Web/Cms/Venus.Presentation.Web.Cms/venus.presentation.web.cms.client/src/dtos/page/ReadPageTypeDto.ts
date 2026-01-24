import { DtoBase } from "../base/DtoBase";
import type { ReadUrlDto } from "../urls/ReadUrlDto";
import type { ReadPageAboutDto } from "./ReadPageAboutDto";

export class ReadPageTypeDto extends DtoBase{
    /**
     *
     */
    constructor() {
        super();
        this.urls = [];
    }
    title:string;
    interfaceClassType:string;
    description:string
    urls:ReadUrlDto[]
}