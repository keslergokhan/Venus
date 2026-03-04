import type { FieldValues } from "react-hook-form"
import { DynamicFieldComponentEnum, type DynamicFieldsComponentProps } from "./DynamicFieldsComponentProps"


export const DynamicFieldsComponent = <T extends FieldValues>(props:DynamicFieldsComponentProps<T>) =>{

    const {
        register,
        control,
        handleSubmit,
        setValue,
        getValues,
        formState:{errors}
    } = props.useFormReturn;

    return props.fields.map(field=>{
        return (
            <div className="relative z-0 w-full group">
                <label className="block mb-2 text-sm font-medium text-gray-900 text-blue-950">{field.label}</label>

                {field.type == DynamicFieldComponentEnum.Text && <></>}
                {(errors[props.title] && errors[props.title]?.message) && <p className="text-red-500 text-sm mt-1">{errors[props.title]?.message?.toString()}</p>}
            </div>
        )
    });
}