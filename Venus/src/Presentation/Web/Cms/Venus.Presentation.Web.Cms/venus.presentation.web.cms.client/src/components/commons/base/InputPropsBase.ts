import type { FieldError, UseFormRegister, UseFormRegisterReturn } from "react-hook-form"

export interface InputPropsBase {
    id: string,
    name: string,
    className?: string,
    placeholder?: string
    required?: boolean,
    label?: string,
    variant?: "standard" | "outlined",
    formRegister?:UseFormRegisterReturn,
    FieldErrors?:FieldError
    
}