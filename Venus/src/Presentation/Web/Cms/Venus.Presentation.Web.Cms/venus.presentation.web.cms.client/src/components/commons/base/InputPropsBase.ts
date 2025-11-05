export interface InputPropsBase {
    id: string,
    name: string,
    className?: string,
    placeholder?: string
    required?: boolean,
    label?: string,
    variant?: "standard" | "outlined"
}