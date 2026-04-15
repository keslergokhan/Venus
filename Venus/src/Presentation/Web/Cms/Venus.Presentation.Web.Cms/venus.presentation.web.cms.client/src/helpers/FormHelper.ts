import type { FieldValues } from "react-hook-form";
import type { DynamicFieldComponentProps } from "../components";

export class FormHelper {
    
    public static toDynamicObject = <TFieldValues extends FieldValues>(props:{
        dynamicFields:Array<DynamicFieldComponentProps<TFieldValues>>,
        data:TFieldValues
    }):Record<string, any> => {
        var object = Object.keys(props.data).reduce((acc, key) => {
            if (props.dynamicFields.some(f => f.name === key)) {
                if (!acc["jsonData"]) {
                    acc["jsonData"] = {};
                }
                acc["jsonData"][key] = props.data[key as keyof TFieldValues];
            }else{
                acc[key] = props.data[key as keyof TFieldValues];
            }

            return acc;
        }, {} as Record<string, any>);

        if(object["jsonData"]){
            object["jsonData"] = JSON.stringify(object["jsonData"]);
        }

        return object;
    }
}