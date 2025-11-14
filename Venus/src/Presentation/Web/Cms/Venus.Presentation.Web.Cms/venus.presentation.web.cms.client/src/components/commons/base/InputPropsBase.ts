import type { FieldError, UseFormRegisterReturn } from "react-hook-form"

export interface InputPropsBase {
    id: string,
    name: string,
    value?:string,
    className?: string,
    placeholder?: string
    required?: boolean,
    label?: string,
    variant?: "standard" | "outlined",
    formRegister?:UseFormRegisterReturn,
    FieldErrors?:FieldError,
    disabled?:boolean,
    onClick?:(e: React.MouseEvent<HTMLInputElement>)=>void
    
}