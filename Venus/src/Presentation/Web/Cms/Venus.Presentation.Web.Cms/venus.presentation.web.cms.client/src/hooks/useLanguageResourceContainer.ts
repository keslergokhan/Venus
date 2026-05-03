import { useEffect, useRef, useState } from "react";
import type { ReadLanguageDto, ReadLanguageResourceKeyDto } from "../dtos";
import { LanguageResourceService, LanguageService } from "../services";
import { ToastHelper } from "../helpers";

interface useLanguageResourceContainerResult {
    languageResourceList:ReadLanguageResourceKeyDto[];
    updateHandler:(data:ReadLanguageResourceKeyDto)=>Promise<void>
    refreshTable:()=>void
    showContainers:string[]
    setShowContainer:(keys:string[])=>void
}

export const useLanguageResourceContainer = ():useLanguageResourceContainerResult =>{

    const [showContainers,setContainers] = useState<string[]>(["table"]);
    const languageList = useRef<ReadLanguageDto[]>([]);
    const [languageResourceList,setLanguageResourceList] = useState<ReadLanguageResourceKeyDto[]>([]);
    const languageResourceService = new LanguageResourceService();
    const languageService = new LanguageService();

    useEffect(()=>{
        languageService.getLanguageAsync().then(x=>{
           languageList.current = x;
        });
        refreshTable();
    },[]);

    const updateHandler = async () =>{
        setContainers(["update"]);
    }

    const refreshTable = ():void =>{
        languageResourceService.getLanguageResourceAndValue().then(x=>{
            setLanguageResourceList(x);
            ToastHelper.Success("Veri yenilendi.");
        }).catch(x=>{
            ToastHelper.DefaultCatchError(x);
        });
    }

    const setShowContainer = (keys:string[]):void=>{
        setContainers(keys);
    }

    return {
        languageResourceList,
        updateHandler,
        refreshTable,
        setShowContainer,
        showContainers
    };
}