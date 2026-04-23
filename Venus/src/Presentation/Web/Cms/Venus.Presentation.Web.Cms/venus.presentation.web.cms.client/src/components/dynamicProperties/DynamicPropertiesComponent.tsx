import type { FieldValues } from "react-hook-form"
import { DynamicPropertiesComponentEnum, type DynamicPropertiesComponentProps } from "./DynamicPropertiesComponentProps"
import { CTextField, HtmlEditor } from "../commons";


export const DynamicPropertiesComponent = <T extends FieldValues>(props:DynamicPropertiesComponentProps<T>) =>{

    const {
        register,
        control,
        handleSubmit,
        setValue,
        getValues,
        formState:{errors}
    } = props.useFormReturn;

    return props.fields.map((field,index)=>{
        if(field.isCreate!=false){
            return (
                <div className="" key={index}>
                    
                    {field.type == DynamicPropertiesComponentEnum.Text && 
                    <CTextField id={field.name} key={index} name={field.name} type="text" label={field.label} formRegister={register(field.name)} ></CTextField>}
    
                    {field.type == DynamicPropertiesComponentEnum.HtmlEditor && 
                    <HtmlEditor label={field.label} key={index} control={control} name={field.name} ></HtmlEditor>}
    
                    {(errors[field.name]) && <p className="text-red-500 text-sm mt-1">{errors[field.name]?.message?.toString()}</p>}
                </div>
            )
        }
    });
}