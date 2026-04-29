import { useRef, useState } from "react"
import { UrlService } from "../services";
import { ToastHelper } from "../helpers";

export interface useUrlPathControlResult{
    getValue: ()=>string;
    setValue:(url:string)=>void
    isUrlExists:boolean|undefined;
    checkUrlHandler:()=>void;
    fullPath:string
    baseFullPath?:string
}

interface useUrlPathControlProps{
    setValue:(url:string)=>void;
    getValue:()=>string;
    isValidError?:()=>void;
    baseFullPath?:string;
}

export const useUrlPathControl = (props:useUrlPathControlProps) : useUrlPathControlResult =>{
    const [isUrlExists,setUrlExists] = useState<boolean|undefined>(undefined);
    const fullPath = useRef<string>("");
    const urlService = new UrlService();
    
    const setUrlHandler = (url:string)=>{
        props.setValue(url);
        if(props.baseFullPath){
            fullPath.current = props.baseFullPath + url;
        }
    }

    const urlGetValue = ()=>{
        return props.getValue()
    }

   
    const checkUrlHandler = ()=>{
        let fullPath = props.getValue();
        if(props.baseFullPath && !fullPath.startsWith(`${props.baseFullPath}/`)){
            fullPath = `${props.baseFullPath}${props.getValue()}`;
        }
        
        urlService.urlCheck({url:fullPath}).then(x=>{
            setUrlExists(x);
            if(x && props.isValidError){
                props.isValidError();
            }
        }).catch(x=>{
            ToastHelper.DefaultCatchError(x);
        });
    }
   
    return {isUrlExists:isUrlExists,setValue:setUrlHandler,getValue:urlGetValue,checkUrlHandler:checkUrlHandler,fullPath:fullPath.current,baseFullPath:props.baseFullPath}
}