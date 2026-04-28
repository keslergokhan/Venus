import { useEffect, useRef, useState } from "react";
import { BlogDynamicInputFields } from "../components";
import { ReadBlogDto, ReadPageDto } from "../dtos"
import { FormHelper, ToastHelper } from "../helpers";
import { BlogService } from "../services";
import { AppContext } from "../contexts/AppContext";
import { useContext } from "react";
import { xid } from "zod";


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
    removeHandler:(data:ReadBlogDto)=>Promise<void>;
    updateSelectHandler:(data:ReadBlogDto)=>Promise<void>;
    addHandler:(data:CreateBlogType)=>Promise<void>;
    setShowContainer:(data:string[])=>void;
    refreshTable:()=>void;
    showContainer:string[];
    selectUpdateBlog:ReadBlogDto|null;
    updateHandler:()=>void;
    basePage:ReadPageDto;
}

export const useBlogContainer = ():useBlogContainerResult =>{
    var blogService = new BlogService();
    const [containers,setContainer] = useState<string[]>(["table"]);
    const blogs = useRef<ReadBlogDto[]>([]);
    const appContext = useContext(AppContext);
    const [selectUpdateBlog,setSelectUpdateBlog] = useState<ReadBlogDto|null>(null);
    const basePage = useRef<ReadPageDto>(new ReadPageDto());
    

    useEffect(()=>{
        getBasePage();
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
    const removeHandler = async (data:ReadBlogDto) =>{
        appContext.confirmModalAction({action:"Show",approvalHandler:()=>{

            blogService.removeAsync("blog/remove",data.id).then(x=>{
                refreshTable();
            }).catch(x=>{
                ToastHelper.DefaultCatchError(x);
            });

        }});
    }

    const getBasePage = async () => {
        try{
            basePage.current = await blogService.get<ReadPageDto>("blog/get-base-path");
        }catch(err){
            ToastHelper.DefaultCatchError(err);
        }
    }

    const getBlogById = async (id:string) =>{

        if(selectUpdateBlog !=null && selectUpdateBlog.id == id){
            return;
        }

        if(selectUpdateBlog != null){
            return;
        }

        blogService.getById<ReadBlogDto>("blog/get",id).then(x=>{
            if(selectUpdateBlog==null){
                setSelectUpdateBlog(x);
            }
        }).catch(x=>{
            ToastHelper.DefaultCatchError(x);
        });
    }

    /**
     * Seçilen satırı güncelle
     * @param data 
     */
    const updateSelectHandler = async (data:ReadBlogDto)=>{
        setContainer(["update"]);
        getBlogById(data.id);
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
    const addHandler = async (data:CreateBlogType)=>{
     
        const blogRequest = FormHelper.toDynamicObject({data:data,dynamicFields:BlogDynamicInputFields});
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
        basePage:basePage.current,
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