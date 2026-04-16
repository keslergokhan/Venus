import { Toaster } from "react-hot-toast";
import { CreateBlogComponent, type CreateBlogType, BlogTableComponent, CButtonField, ConfirmModal } from "../../components"
import { ZoneControlComponent, ZoneControlItem } from "../../components/zoneControl/zoneControlComponent";
import { useBlogContainer } from "../../hooks";
import { useEffect } from "react";
import { ToastHelper } from "../../helpers";


const BlogContainer = () =>{
    
    const {blogs,removeHandler,updateHandler,addHandler,setShowContainer,showContainer,refreshTable} = useBlogContainer();

    const isTable = showContainer.find(x=>x=="table")?true:false;

    return (
        
        <div>
            <div className="flex gap-4">
                <CButtonField onClick={()=>{setShowContainer(["add"])}}>Yeni Blog</CButtonField>
                <CButtonField onClick={()=>{refreshTable()}}>
                    {(isTable?"Yenile":"İptal")}
                </CButtonField>
            </div>
            <ZoneControlComponent className="mt-4" zoneKeys={showContainer}>
                <ZoneControlItem zoneKey="add">
                    <CreateBlogComponent onSubmit={addHandler}></CreateBlogComponent><br></br>
                </ZoneControlItem>
                <ZoneControlItem zoneKey="table">
                    <BlogTableComponent blogs={blogs} updateOnHandler={updateHandler} removeOnHandler={removeHandler}></BlogTableComponent>
                </ZoneControlItem>
            </ZoneControlComponent>
        </div>
    )
}

export default BlogContainer
