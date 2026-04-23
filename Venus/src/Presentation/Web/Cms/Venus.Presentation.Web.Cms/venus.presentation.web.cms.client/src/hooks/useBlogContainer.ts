import { useEffect, useRef, useState } from "react";
import { BlogDynamicInputFields, type CreateBlogType } from "../components";
import { ReadBlogDto } from "../dtos"
import { FormHelper, ToastHelper } from "../helpers";
import { BlogService } from "../services";
import { AppContext } from "../contexts/AppContext";
import { useContext } from "react";


export type CreateBlogType = {
    urlPath:string,
    title:string,
    description:string,
    blogCategory:string,
    blogContent:string
}

export type UpdateBlogType = {
    urlPath:string,
    title:string,
    description:string,
    blogCategory:string,
    blogContent:string
}

interface useBlogContainerResult{
    blogs:Array<ReadBlogDto>;
    removeHandler:(data:ReadBlogDto)=>void;
    updateSelectHandler:(data:ReadBlogDto)=>void;
    addHandler:(data:CreateBlogType)=>void;
    setShowContainer:(data:string[])=>void;
    refreshTable:()=>void;
    showContainer:string[];
    selectUpdateBlog:ReadBlogDto|null;
    updateHandler:()=>void
}

export const useBlogContainer = ():useBlogContainerResult =>{
    var blogService = new BlogService();
    const [containers,setContainer] = useState<string[]>(["table"]);
    const blogs = useRef<ReadBlogDto[]>([]);
    const appContext = useContext(AppContext);
    const [selectUpdateBlog,setSelectUpdateBlog] = useState<ReadBlogDto|null>(null);

    useEffect(()=>{
        refreshTable();
    },[])

    /**
     * Aktif container belirleme
     * @param data 
     */
    const setShowContainer = (data:string[])=>{
        setContainer(data);
    }
    
    /**
     * Tablo verilerini yeniden getir.
     */
    const refreshTable = ():void=>{
        ToastHelper.Success("Yenilendi");
        blogService.getAll<ReadBlogDto>("blog/get-all").then(x=>{
            blogs.current = x;
            setShowContainer(["table"]);
        }).catch(x=>{
            ToastHelper.DefaultCatchError(x);
        });
    }

    /**
     * İlgili veriyi temizle.
     * @param data
     */
    const removeHandler = (data:ReadBlogDto) =>{
        appContext.confirmModalAction({action:"Show",approvalHandler:()=>{

            blogService.removeAsync("blog/remove",data.id).then(x=>{
                refreshTable();
            }).catch(x=>{
                ToastHelper.DefaultCatchError(x);
            });

        }});
    }

    /**
     * Seçilen satırı güncelle
     * @param data 
     */
    const updateSelectHandler = (data:ReadBlogDto)=>{
        setContainer(["update"]);
        blogService.get<ReadBlogDto>("blog/get",data.id).then(x=>{
            setSelectUpdateBlog(x);
        }).catch(x=>{
            ToastHelper.DefaultCatchError(x);
        });
    }

    /**
     * Mevcut bloke güncelleme
     */
    const updateHandler = ()=>{

    }

    /**
     * Yeni blog ekleme
     * @param data 
     */
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
        removeHandler,
        updateSelectHandler,
        addHandler,
        setShowContainer,
        showContainer:containers,
        refreshTable,
        selectUpdateBlog:selectUpdateBlog,
        updateHandler
    }
}