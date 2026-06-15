import { useEffect } from "react"
import { WidgetService } from "../services/WidgetService"
import { ToastHelper } from "../helpers";

interface useWidgetManagerContainerResult{

}

export function useWidgetManagerContainer():useWidgetManagerContainerResult{


    const service = new WidgetService();
    
    async function getWidgets(){
        try {
            await service.getWidgets();
        } catch (error) {
            ToastHelper.DefaultCatchError(error);
        }     
    }

    useEffect(()=>{
        getWidgets();
        console.log(service.getWidgets());
    },[])

    return {}
}