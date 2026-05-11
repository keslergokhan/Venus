import type { JSX } from "react";
import type { InputPropsBase } from "../base/InputPropsBase";

export interface CTextAreaFieldProps extends InputPropsBase {
}

export const CTextAreaField = (props:CTextAreaFieldProps):JSX.Element =>{

    let className = `bg-gray-50 border border-gray-300 text-sm rounded-lg focus:border-primary-300 focus:outline-none block w-full p-2.5 ${props.className} `;

    return (
        <div className="relative z-0 w-full group">
            <label className="block mb-2 text-sm font-medium text-gray-900 text-blue-950"></label>
            <textarea 
                className={`${className}`}
                defaultValue={props.value}
                onBlur={(e) => console.log("Odak ayrıldı, değer:", e.target.value)}
            />
            {props.fieldErrors && <p className="text-red-500 text-sm mt-1">{props.fieldErrors.message}</p>}
        </div>
    );
}

