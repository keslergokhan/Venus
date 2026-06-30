import { useEffect, useState } from "react"
import { WidgetService } from "../services/WidgetService"
import { ToastHelper } from "../helpers";
import type { ReadWidgetDto, WriteWidgetDto } from "../dtos";

interface useWidgetManagerContainerResult{
    widgets:ReadWidgetDto[],
    showContainer:(showComponents?:string[])=>string[]|undefined,
    goToUpdateHandler:(data:ReadWidgetDto)=>Promise<void>,
    refreshTable:()=>Promise<void>
    selectWidget:ReadWidgetDto|undefined,
    updateHandler:(data:ReadWidgetDto)=>Promise<void>
    addHandler:(data:WriteWidgetDto)=>Promise<void>
}

export function useWidgetManagerContainer():useWidgetManagerContainerResult{

    const [containers,setContainer] = useState<string[]>(["table"]);
    const [widgets,setWidgets] = useState<ReadWidgetDto[]>([]);
    const [selectWidget,setSelectWidget] = useState<ReadWidgetDto>();

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

    async function goToUpdateHandler(data:ReadWidgetDto){
        setContainer(["update"]);
        setSelectWidget(data);
    }

    async function updateHandler(data:ReadWidgetDto){
        ToastHelper.Success("İşlem başarıyla güncellendi !");
        try {
            const result = await service.updateWidget(data);
            ToastHelper.Success(`${data.key}, güncellendi.`)
        } catch (error) {
            ToastHelper.DefaultCatchError(error);
        }
        
        console.log(data);
    }

    async function addHandler(data:WriteWidgetDto){

    }

    useEffect(()=>{
        refreshTable();
    },[]);

    return {widgets,showContainer,goToUpdateHandler,refreshTable,selectWidget,updateHandler,addHandler}
}