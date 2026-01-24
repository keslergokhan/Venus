import { useEffect, useRef, useState } from "react"
import { LoadingComponent, PageAbourtListComponent } from "../../components"
import { PageTypeManagerService } from "../../services";
import { ToastHelper } from "../../helpers";
import { ReadPageAboutDto, ReadPageTypeDto } from "../../dtos";


export const PageManagerListContainer = () =>{

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

    return <>
        <LoadingComponent loading={loading}>
            <PageAbourtListComponent pageAbouts={pageAboutList.current}></PageAbourtListComponent>
        </LoadingComponent>
    </>
}
