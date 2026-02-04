import { useEffect, useRef, useState } from "react";
import type { Step } from "../components/pageStepsComponents/NewPageStepsManagerComponent"
import { Step1, Step2, Step3, Step4 } from "../components/pageStepsComponents/StepsComponents"
import type { ReadPageAboutDto } from "../dtos";
import { PageTypeManagerService } from "../services";
import { ToastHelper } from "../helpers";


export const useNewPageStepsManager = ():{Steps:Step[],loading:boolean} =>{

    const [loading,setLoading] = useState<boolean>(true);
    const pageAboutList = useRef<ReadPageAboutDto[]>(new Array<ReadPageAboutDto>());

    const pageTypeManagerService = new PageTypeManagerService();

    useEffect(()=>{
        pageTypeManagerService.getPageAboutListAsync()
        .then(x=>{
            console.log(x);
            pageAboutList.current = x;
            setLoading(false);
        }).catch(err=>{
            ToastHelper.DefaultCatchError(err);
        })
    },[]);
    
    return {
        Steps:[Step1,Step2,Step3,Step4],
        loading:loading
    }
}


