import type { JSX } from "react"
import type { CButtonFieldProps } from "./CButtonFiled";


export const CSmButtonField = (props:CButtonFieldProps):JSX.Element =>{

    let className = `w-full text-white bg-blue-700 cursor-pointer hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-xs px-2 py-1 text-center dark:bg-blue-600 dark:hover:bg-blue-700 dark:focus:ring-blue-800 ${props.className} `;
    return (
        <button 
        onClick={(e)=>{(props.onClick && props?.onClick(e))}}
        type="submit" className={`${className}`}>
              {props.children}
        </button>
    )
}