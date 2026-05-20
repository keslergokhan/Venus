import { useEffect, useRef, useState } from "react";
import { BlogDynamicInputFields } from "../components";
import { ReadBlogDto, ReadPageDto } from "../dtos"
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
    id:string,
    urlPath:string,
    title:string,
    description:string,
    blogCategory:string,
    blogContent:string
}

interface useBlogContainerResult{
    blogs:Array<ReadBlogDto>;
    removeHandler:(data:ReadBlogDto)=>Promise<void>;
    addHandler:(data:CreateBlogType)=>Promise<void>;
    updateSelectHandler:(data:ReadBlogDto)=>Promise<void>;
    setShowContainer:(data:string[])=>void;
    refreshTable:()=>void;
    showContainer:string[];
    selectUpdateBlog:ReadBlogDto|null;
    updateHandler:(data:UpdateBlogType)=>Promise<void>;
    toggleStateHandler:(id:string)=>Promise<void>
    blogPage:ReadPageDto;
}

export function useBlogContainer():useBlogContainerResult {
    var blogService = new BlogService();
    const [containers,setContainer] = useState<string[]>(["table"]);
    const blogs = useRef<ReadBlogDto[]>([]);
    const appContext = useContext(AppContext);
    const [selectUpdateBlog,setSelectUpdateBlog] = useState<ReadBlogDto|null>(null);
    const blogPage = useRef<ReadPageDto>(new ReadPageDto());
    

    useEffect(()=>{
        getBlogPage();
        refreshTable();
    },[])

    /**
     * Aktif container belirleme
     * @param data 
     */
    function setShowContainer(data:string[]) {
        setContainer(data);
    }
    
    /**
     * Tablo verilerini yeniden getir.
     */
    function refreshTable():void {
        ToastHelper.Success("Yenilendi");
        blogService.getBlogs().then(x=>{
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
    async function removeHandler(data:ReadBlogDto) {
        appContext.confirmModalAction({action:"Show",approvalHandler:()=>{

            blogService.removeBlog(data.id).then(x=>{
                refreshTable();
            }).catch(x=>{
                ToastHelper.DefaultCatchError(x);
            });

        }});
    }

    async function getBlogPage(){
        try{
            blogPage.current = await blogService.getBlogPage();
        }catch(err){
            ToastHelper.DefaultCatchError(err);
        }
    }

    async function getBlogById(id:string) {

        if(selectUpdateBlog !=null && selectUpdateBlog.id == id){
            return;
        }

        if(selectUpdateBlog != null){
            return;
        }

        blogService.getBlogById(id).then(x=>{
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
    async function updateSelectHandler(data:ReadBlogDto):Promise<void>{
        setContainer(["update"]);
        getBlogById(data.id);
    }

    /**
     * Mevcut bloke güncelleme
     */
    async function updateHandler(data:UpdateBlogType) {
        const blogRequest = FormHelper.toDynamicObject({data:data,dynamicFields:BlogDynamicInputFields});
        await blogService.updateBlog(blogRequest).then(x=>{
            ToastHelper.Success(`${x.title} güncellendi.`);
        }).catch(err=>{
            ToastHelper.DefaultCatchError(err);
        });
    }

    /**
     * Yeni blog ekleme
     * @param data 
     */
    async function addHandler(data:CreateBlogType) {
     
        const blogRequest = FormHelper.toDynamicObject({data:data,dynamicFields:BlogDynamicInputFields});
        blogService.addBlog(blogRequest).then(x=>{
            if(x as ReadBlogDto){
                const blog = x as ReadBlogDto;
                ToastHelper.Success(`${blog.title} başarıyla eklendi`);
            }
            refreshTable();
        }).catch(x=>{
            ToastHelper.DefaultCatchError(x);
        });
    }

    async function toggleStateHandler(id:string) { 
        await blogService.toggleState(id).then(x=>{
            refreshTable();
        }).catch(x=>{
            console.error("State yönetimi tamamlanamadı",x);
            ToastHelper.DefaultCatchError(x);
        });
    }

    
    return {
        blogPage:blogPage.current,
        blogs:blogs.current,
        removeHandler,
        updateSelectHandler,
        addHandler,
        setShowContainer,
        showContainer:containers,
        refreshTable,
        selectUpdateBlog:selectUpdateBlog,
        updateHandler,
        toggleStateHandler
    }
}