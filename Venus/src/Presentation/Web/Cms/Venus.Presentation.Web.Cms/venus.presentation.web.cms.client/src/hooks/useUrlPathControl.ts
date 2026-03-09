import { useState } from "react"
import { UrlService } from "../services";
import { ToastHelper } from "../helpers";
import type { FieldValues, UseFormGetValues, UseFormTrigger } from "react-hook-form";

export interface useUrlPathControlResult{
    getValue: ()=>string;
    setValue:(url:string)=>void
    isUrlExists:boolean|undefined;
    checkUrlHandler:()=>void;
    
}

export const useUrlPathControl = (props:{setValue:(url:string)=>void,getValue:()=>string,isValidError?:()=>void;}) : useUrlPathControlResult =>{
    const [isUrlExists,setUrlExists] = useState<boolean|undefined>(undefined);
    const urlService = new UrlService();
    
    const setUrlHandler = (url:string)=>{
        props.setValue(url);
    }

    const urlGetValue = ()=>{
        return props.getValue()
    }

    const checkUrlHandler = ()=>{
        urlService.urlCheck({url:props.getValue()}).then(x=>{
            setUrlExists(x);
            if(x && props.isValidError){
                props.isValidError();
                console.log("ffff");
            }
        }).catch(x=>{
            ToastHelper.DefaultCatchError(x);
        });
    }
   
    return {isUrlExists:isUrlExists,setValue:setUrlHandler,getValue:urlGetValue,checkUrlHandler:checkUrlHandler}
}