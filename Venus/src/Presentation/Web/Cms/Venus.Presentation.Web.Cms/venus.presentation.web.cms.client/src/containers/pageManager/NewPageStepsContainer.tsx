import { useEffect, useRef, useState } from "react";
import type { ReadPageAboutDto } from "../../dtos";
import { PageTypeManagerService } from "../../services";
import { ToastHelper } from "../../helpers";
import { LoadingComponent } from "../../components";
import { NewPageStepsComponent } from "../../components/pageManager/NewPageStepsComponent";


export const NewPageStepsContainer = () =>{

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

    return (
        <LoadingComponent loading={loading}>
            <NewPageStepsComponent></NewPageStepsComponent>
        </LoadingComponent>
    )
}