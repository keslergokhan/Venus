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

interface useUrlPathControlProps{
    setValue:(url:string)=>void;
    getValue:()=>string;
    isValidError?:()=>void;
    getBaseFullPath?:()=>string;
}

export const useUrlPathControl = (props:useUrlPathControlProps) : useUrlPathControlResult =>{
    const [isUrlExists,setUrlExists] = useState<boolean|undefined>(undefined);
    const urlService = new UrlService();
    
    const setUrlHandler = (url:string)=>{
        if(props.getBaseFullPath){
            url = props.getBaseFullPath()+url;
        }
        props.setValue(url);
    }

    const urlGetValue = ()=>{
        return props.getValue()
    }

    const baseUrlHandler = () =>{

    }

    const checkUrlHandler = ()=>{
        urlService.urlCheck({url:props.getValue()}).then(x=>{
            setUrlExists(x);
            if(x && props.isValidError){
                props.isValidError();
            }
        }).catch(x=>{
            ToastHelper.DefaultCatchError(x);
        });
    }
   
    return {isUrlExists:isUrlExists,setValue:setUrlHandler,getValue:urlGetValue,checkUrlHandler:checkUrlHandler}
}