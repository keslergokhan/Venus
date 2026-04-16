import { useEffect, useRef, useState } from "react";
import { BlogDynamicInputFields, type CreateBlogType } from "../components";
import { ReadBlogDto } from "../dtos"
import { FormHelper, ToastHelper } from "../helpers";
import { BlogService } from "../services";
import { AppContext } from "../contexts/AppContext";
import { useContext } from "react";

interface useBlogContainerResult{
    blogs:Array<ReadBlogDto>;
    removeHandler:(data:ReadBlogDto)=>void;
    updateHandler:(data:ReadBlogDto)=>void;
    addHandler:(data:CreateBlogType)=>void;
    setShowContainer:(data:string[])=>void;
    refreshTable:()=>void;
    showContainer:string[];
}

export const useBlogContainer = ():useBlogContainerResult =>{
    var blogService = new BlogService();
    const [containers,setContainer] = useState<string[]>(["table"]);
    const blogs = useRef<ReadBlogDto[]>([]);
    const appContext = useContext(AppContext);


    const setShowContainer = (data:string[])=>{
        setContainer(data);
    }
    
    useEffect(()=>{
        refreshTable();
    },[])

    const refreshTable = ():void=>{
        blogService.addDataAsync
        console.log("Yenile");
        ToastHelper.Success("Yenilendi");
        blogService.getDatas<ReadBlogDto>("blog/get").then(x=>{
            blogs.current = x;
            setShowContainer(["table"]);
        }).catch(x=>{
            ToastHelper.DefaultCatchError(x);
        });
    }

    const removeHandler = (data:ReadBlogDto) =>{
        appContext.confirmModalAction({action:"Show",approvalHandler:()=>{console.log("İşlem başarılı")}});
    }

    const updateHandler = (data:ReadBlogDto)=>{
        alert("detay");
    }

    const addHandler = (data:CreateBlogType)=>{
        const blogRequest = FormHelper.toDynamicObject({data:data,dynamicFields:BlogDynamicInputFields});
        console.log(blogRequest);
        blogService.addDataAsync("blog/create",blogRequest).then(x=>{
            if(x as ReadBlogDto){
                const blog = x as ReadBlogDto;
                ToastHelper.Success(`${blog.title} başarıyla eklendi`);
            }
            refreshTable();
        }).catch(x=>{
            ToastHelper.DefaultCatchError(x);
        });
    }

    
    return {
        blogs:blogs.current,
        removeHandler:removeHandler,
        updateHandler:updateHandler,
        addHandler:addHandler,
        setShowContainer:setShowContainer,
        showContainer:containers,
        refreshTable:refreshTable
    }
}