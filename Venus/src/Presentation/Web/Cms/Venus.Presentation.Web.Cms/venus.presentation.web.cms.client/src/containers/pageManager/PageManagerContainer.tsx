import { useEffect, useRef, useState } from "react"
import { LoadingComponent, PageTypeListComponent } from "../../components"
import { PageTypeManagerService } from "../../services";
import { ToastHelper } from "../../helpers";
import { ReadPageAboutDto } from "../../dtos";


export const PageManagerContainer = () =>{

    const [loading,setLoading] = useState<boolean>(true);
    const pageAboutList = useRef<ReadPageAboutDto[]>(new Array<ReadPageAboutDto>());

    const pageTypeManagerService = new PageTypeManagerService();

    useEffect(()=>{
        pageTypeManagerService.getPageTypeListAsync()
        .then(x=>{
            return x;
        })
        .then(x=>{
            pageAboutList.current = x;
            setLoading(false);
        }).catch(err=>{
            ToastHelper.DefaultCatchError(err);
        })
    },[]);

    return <>
        <LoadingComponent loading={loading}>
            <PageTypeListComponent pageAbouts={pageAboutList.current}></PageTypeListComponent>
        </LoadingComponent>
    </>
}
