import type { JSX } from "react";
import type { InputPropsBase } from "../base/InputPropsBase";


export interface CTextFieldProps extends InputPropsBase {
    type:string
    Icon?:JSX.Element
}


export const CTextField = (props: CTextFieldProps): JSX.Element => {

    let className = `bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500${props.className} `;
    
    if(props.variant && props.variant == "outlined"){
    }else{
    }

    const Icon = () => {
        return props.Icon;
    }

    const Input = () =>{
        if(props.Icon){
            return (
                <div className="relative">
                    
                    <div className="absolute inset-y-0 start-1.5 flex items-center pointer-events-none">
                        <Icon></Icon>
                    </div>
    
                    <input
                        {...props.formRegister}
                        type={props.type}
                        name={props.name}
                        id={props.id}
                        className={`${className} pl-7.5`}
                        placeholder={!props.placeholder ? "":props.placeholder}
                        />
                </div>
            )
        }else{
            return (
                <input
                    {...props.formRegister}
                    type={props.type}
                    name={props.name}
                    id={props.id}
                    className={className}
                    placeholder={!props.placeholder ? "":props.placeholder}
                    />
            )
        }
        
    }
    
    return (
        <div className="relative z-0 w-full group">
            {
                props.label ?
                <label
                    className="block mb-2 text-sm font-medium text-gray-900 dark:text-white"
                >
                {props.label}
                </label>
                :
                <></>
            }
            <Input></Input>
            {props.FieldErrors && <p className="text-red-500 text-sm mt-1">{props.FieldErrors.message}</p>}
        </div>
    )
}

