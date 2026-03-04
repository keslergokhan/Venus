import type { FieldError, FieldValues, Path, UseFormRegisterReturn, UseFormReturn } from "react-hook-form";

export enum DynamicFieldComponentEnum{
    Text = 1,
    Password = 2,
    Email = 3,
    Number = 4,
    Search = 5,
    Tel = 6,
    Url = 7,
    File = 8,
    Image = 9
    
}

export interface DynamicFieldsComponentProps<T extends FieldValues> {
    title:string;
    fields:Array<DynamicFieldComponentProps<T>>
    useFormReturn:UseFormReturn<T>
}

export class DynamicFieldComponentProps<T extends FieldValues> {
    name:Path<T>;
    label:string;
    type:DynamicFieldComponentEnum
    description?:string;
}