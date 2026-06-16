import { useEffect, useState } from "react"
import { WidgetService } from "../services/WidgetService"
import { ToastHelper } from "../helpers";
import type { ReadWidgetDto } from "../dtos/widgets/ReadWidgetDto";

interface useWidgetManagerContainerResult{
    widgets:ReadWidgetDto[],
    showContainer:(showComponents?:string[])=>string[]|undefined,
    goToUpdateHandler:(data:ReadWidgetDto)=>Promise<void>,
    refreshTable:()=>Promise<void>
}

export function useWidgetManagerContainer():useWidgetManagerContainerResult{

    const [containers,setContainer] = useState<string[]>(["table"]);
    const [widgets,setWidgets] = useState<ReadWidgetDto[]>([]);
    const service = new WidgetService();
    
    function showContainer(showComponents?:string[]){
        if(showComponents!=null){
            setContainer(showComponents);
            return showComponents;
        }
        return containers;
    }

    async function refreshTable(){
        ToastHelper.Success("Yenilendi");
        try {
            const result = await service.getWidgets();
            setWidgets(result);
        } catch (error) {
            ToastHelper.DefaultCatchError(error);
        }finally{
            setContainer(["table"]);
        }
    }

    async function goToUpdateHandler(){
        setContainer(["update"]);
    }

    useEffect(()=>{
        refreshTable();
    },[]);

    return {widgets,showContainer,goToUpdateHandler,refreshTable}
}