import { useEffect, useRef, useState } from "react"
import { LoadingComponent, PageTypeListComponent } from "../../components"
import { PageTypeManagerService } from "../../services";
import { ToastHelper } from "../../helpers";
import { ReadPageAboutDto, ReadPageTypeDto } from "../../dtos";


export const PageManagerContainer = () =>{

    const [loading,setLoading] = useState<boolean>(true);
    const pageAboutList = useRef<ReadPageTypeDto[]>(new Array<ReadPageTypeDto>());

    const pageTypeManagerService = new PageTypeManagerService();

    useEffect(()=>{
        pageTypeManagerService.getPageTypeListAsync()
        .then(x=>{
            console.log(x);
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
