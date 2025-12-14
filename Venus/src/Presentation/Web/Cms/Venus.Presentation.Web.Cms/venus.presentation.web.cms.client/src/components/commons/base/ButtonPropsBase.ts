export interface ButtonPropsBase{
    id: string,
    className?: string,
    required?: boolean,
    label?: string,
    children:React.ReactNode,
    variant?: "error" | "warning",
    disabled?:boolean,
    onClick?:(e: React.MouseEvent<HTMLButtonElement>)=>void
}