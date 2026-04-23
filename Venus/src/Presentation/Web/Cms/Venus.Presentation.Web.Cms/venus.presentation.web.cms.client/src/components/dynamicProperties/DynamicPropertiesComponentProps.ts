import type { FieldError, FieldValues, Path, UseFormRegisterReturn, UseFormReturn } from "react-hook-form";

export enum DynamicPropertiesComponentEnum{
    Text = 1,
    Password = 2,
    Email = 3,
    Number = 4,
    Search = 5,
    Tel = 6,
    Url = 7,
    File = 8,
    Image = 9,
    HtmlEditor = 10
    
}

export interface DynamicPropertiesComponentProps<T extends FieldValues> {
    title:string;
    fields:Array<DynamicPropertyComponentProps<T>>
    useFormReturn:UseFormReturn<T>
}

export class DynamicPropertyComponentProps<T extends FieldValues> {
    name:Path<T>;
    label:string;
    type:DynamicPropertiesComponentEnum
    description?:string|undefined;
    isCreate?:boolean|undefined
}