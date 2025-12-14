import type { JSX } from "react"
import type { CButtonFieldProps } from "./CButtonFiled";


export const CSmButtonField = (props:CButtonFieldProps):JSX.Element =>{

    let bgColor = `bg-blue-700 hover:bg-blue-800 focus:ring-blue-300`;
    if(props.variant == "error"){
        bgColor = `bg-rose-700 hover:bg-rose-800 focus:ring-rose-300`;
    }else if(props.variant == "warning"){
        bgColor = `bg-amber-700 hover:bg-amber-800 focus:ring-amber-500`;
    }
    const className = `w-full cursor-pointer text-white ${bgColor} focus:ring-2 focus:outline-none  font-medium rounded-lg text-xs px-2 py-1 text-center  ${props.className} `;
    return (
        <button 
        onClick={(e)=>{(props.onClick && props?.onClick(e))}}
        type="submit" className={`${className}`}>
              {props.children}
        </button>
    )
}