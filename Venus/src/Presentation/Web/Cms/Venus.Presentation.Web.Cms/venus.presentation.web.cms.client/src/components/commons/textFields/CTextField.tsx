import type { JSX } from "react";
import type { InputPropsBase } from "../base/InputPropsBase";


export interface CTextFieldProps extends InputPropsBase {
    type:string
    Icon?:JSX.Element
}


export const CTextField = (props: CTextFieldProps): JSX.Element => {

    let className = `bg-gray-50 border border-gray-300 text-sm rounded-lg focus:border-primary-300 focus:outline-none block w-full p-2.5 ${props.className} `;
    
    if(props.variant && props.variant == "outlined"){
    }else{
    }

    const Icon = () => {
        return props.Icon;
    }

    const Input = ()=>{
        return (
            <input
                    onClick={(e)=>{(props.onClick && props?.onClick(e))}}
                    {...props.formRegister}
                    type={props.type}
                    name={props.name}
                    id={props.id}
                    value={props.value}
                    className={`${className} ${(props.Icon) && "pl-7.5"}`}
                    placeholder={!props.placeholder ? "":props.placeholder}
                    disabled={(props.disabled && true)}
                    />
        )
    }
    const InputGroup = () =>{
        if(props.Icon){
            return (
                <div className="relative">
                    
                    <div className="absolute inset-y-0 start-1.5 flex items-center pointer-events-none">
                        <Icon></Icon>
                    </div>
    
                    <Input/>
                </div>
            )
        }else{
            return (
                <Input/>
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
            <InputGroup></InputGroup>
            {props.FieldErrors && <p className="text-red-500 text-sm mt-1">{props.FieldErrors.message}</p>}
        </div>
    )
}

