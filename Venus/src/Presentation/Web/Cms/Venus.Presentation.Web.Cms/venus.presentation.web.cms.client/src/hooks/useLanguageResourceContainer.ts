import { useContext, useEffect, useState } from "react";
import type { ReadLanguageDto, ReadLanguageResourceKeyDto } from "../dtos";
import { LanguageResourceService, LanguageService } from "../services";
import { ToastHelper } from "../helpers";
import { AppContext } from "../contexts/AppContext";

export type UpdateLanguageResourceType = {
    resourceId:string;
    languageResourceValue:string;
}

interface useLanguageResourceContainerResult {
    languageResourceList:ReadLanguageResourceKeyDto[];
    selectToUpdateResourceHandler:(data:ReadLanguageResourceKeyDto)=>Promise<void>
    refreshTable:()=>void
    showContainers:string[]
    setShowContainer:(keys:string[])=>void
    languageList:ReadLanguageDto[],
    selectUpdateResourceKey:ReadLanguageResourceKeyDto|null;
    updateResourceHandler:(data:UpdateLanguageResourceType)=>Promise<void>;
}

export const useLanguageResourceContainer = ():useLanguageResourceContainerResult =>{

    const [showContainers,setContainers] = useState<string[]>(["table"]);
    const [languageResourceList,setLanguageResourceList] = useState<ReadLanguageResourceKeyDto[]>([]);
    const languageResourceService = new LanguageResourceService();
    const [selectUpdateResourceKey,setSelectUpdateResourceKey] = useState<ReadLanguageResourceKeyDto|null>(null);
    const appContext = useContext(AppContext);

    useEffect(()=>{
        refreshTable();
    },[])

    const selectToUpdateResourceHandler = async (data:ReadLanguageResourceKeyDto) =>{
        setContainers(["update"]);
        setSelectUpdateResourceKey(data);
    }

    const updateResourceHandler = async (data:UpdateLanguageResourceType) =>{
        console.log(data);
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
        languageList:appContext.languageState.languages,
        languageResourceList,
        selectToUpdateResourceHandler,
        refreshTable,
        setShowContainer,
        showContainers,
        selectUpdateResourceKey,
        updateResourceHandler
    };
}