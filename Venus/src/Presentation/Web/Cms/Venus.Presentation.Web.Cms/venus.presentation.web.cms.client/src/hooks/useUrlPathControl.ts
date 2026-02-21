import { useState } from "react"

export interface useUrlPathControlResult{
    url:string;
    setValue:(url:string)=>void
    isUrlExists:boolean
}

export const useUrlPathControl = () : useUrlPathControlResult =>{
    const [isUrlExists,setUrlExists] = useState<boolean>(false);
    const [url,setUrl] = useState<string>("/");

    const aaa = "/hakkimizda";

    
    const setUrlHandler = (url:string)=>{
        if(aaa == url){
            setUrlExists(true);
        }else{
            setUrlExists(false);
        }
        setUrl(url);
    }
   
    return {isUrlExists:isUrlExists,setValue:setUrlHandler,url:url}
}