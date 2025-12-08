export interface ButtonPropsBase{
    id: string,
    className?: string,
    required?: boolean,
    label?: string,
    children:React.ReactNode,
    variant?: "standard" | "outlined",
    disabled?:boolean,
    onClick?:(e: React.MouseEvent<HTMLInputElement>)=>void
}