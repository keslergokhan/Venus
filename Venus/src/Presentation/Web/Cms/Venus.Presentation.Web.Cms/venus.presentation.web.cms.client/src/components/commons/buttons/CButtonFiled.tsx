import type { JSX } from "react"
import type { ButtonPropsBase } from "../base/ButtonPropsBase"

export interface CButtonFieldProps extends ButtonPropsBase {
}

export const CButtonField = (props:CButtonFieldProps):JSX.Element =>{

    let className = `cursor-pointer w-full text-white bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm px-5 py-2.5 text-center dark:bg-blue-600 dark:hover:bg-blue-700 dark:focus:ring-blue-800 ${props.className} `;
    return (
        <button type="submit" className={`${className}`} onClick={props.onClick}>
              {props.children}
        </button>
    )
}