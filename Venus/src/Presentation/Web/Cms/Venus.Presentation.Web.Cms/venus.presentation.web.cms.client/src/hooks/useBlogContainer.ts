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
    goToUpdateHandler:(data:ReadBlogDto)=>Promise<void>;
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
    async function refreshTable():Promise<void> {
        ToastHelper.Success("Yenilendi");
        
        try {
            const blogsResult = await blogService.getBlogs();
            blogs.current = blogsResult;
            setShowContainer(["table"]);
        } catch (error) {
            ToastHelper.DefaultCatchError(error);
        }
        
    }

    /**
     * İlgili veriyi temizle.
     * @param data
     */
    async function removeHandler(data:ReadBlogDto) {
        appContext.confirmModalAction({action:"Show",approvalHandler:async ()=>{
            try {
                const removeResult = await blogService.removeBlog(data.id);
                refreshTable();
            } catch (error) {
                ToastHelper.DefaultCatchError(error);
            }
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

        try {
            const getBlog = await blogService.getBlogById(id);
            setSelectUpdateBlog(getBlog);
        } catch (error) {
            ToastHelper.DefaultCatchError(error);
        }
    }

    /**
     * Seçilen satırı güncelle
     * @param data 
     */
    async function goToUpdateHandler(data:ReadBlogDto):Promise<void>{
        setContainer(["update"]);
        getBlogById(data.id);
    }

    /**
     * Mevcut bloke güncelleme
     */
    async function updateHandler(data:UpdateBlogType) {
        try {
            const blogRequest = FormHelper.toDynamicObject({data:data,dynamicFields:BlogDynamicInputFields});
            const updateResult = await blogService.updateBlog(blogRequest);
            ToastHelper.Success(`${updateResult.title} güncellendi.`);
        } catch (error) {
            ToastHelper.DefaultCatchError(error);
        }
    }

    /**
     * Yeni blog ekleme
     * @param data 
     */
    async function addHandler(data:CreateBlogType) {
     
        const blogRequest = FormHelper.toDynamicObject({data:data,dynamicFields:BlogDynamicInputFields});
        try {
            const addResult = await blogService.addBlog(blogRequest)
            if(addResult as ReadBlogDto){
                const blog = addResult as ReadBlogDto;
                ToastHelper.Success(`${blog.title} başarıyla eklendi`);
            }
            refreshTable();
        } catch (error) {
            ToastHelper.DefaultCatchError(error);
        }
       
    }

    async function toggleStateHandler(id:string) { 
        try {
            const toggleState = await blogService.toggleState(id);
            refreshTable();
        } catch (error) {
            console.error("State yönetimi tamamlanamadı",error);
            ToastHelper.DefaultCatchError(error);
        }
       
    }

    
    return {
        blogPage:blogPage.current,
        blogs:blogs.current,
        removeHandler,
        goToUpdateHandler,
        addHandler,
        setShowContainer,
        showContainer:containers,
        refreshTable,
        selectUpdateBlog:selectUpdateBlog,
        updateHandler,
        toggleStateHandler
    }
}