import type { FieldValues } from "react-hook-form";
import type { DynamicPropertyComponentProps } from "../components";

export class FormHelper {
    
    public static toDynamicObject = <TFieldValues extends FieldValues>(props:{
        dynamicFields:Array<DynamicPropertyComponentProps<TFieldValues>>,
        data:TFieldValues
    }):Record<string, any> => {
        var object = Object.keys(props.data).reduce((acc, key) => {
            if (props.dynamicFields.some(f => f.name === key)) {
                if (!acc["dynamicProperties"]) {
                    acc["dynamicProperties"] = {};
                }
                acc["dynamicProperties"][key] = props.data[key as keyof TFieldValues];
            }else{
                acc[key] = props.data[key as keyof TFieldValues];
            }

            return acc;
        }, {} as Record<string, any>);

        if(object["dynamicProperties"]){
            object["dynamicProperties"] = JSON.stringify(object["dynamicProperties"]);
        }

        return object;
    }
}