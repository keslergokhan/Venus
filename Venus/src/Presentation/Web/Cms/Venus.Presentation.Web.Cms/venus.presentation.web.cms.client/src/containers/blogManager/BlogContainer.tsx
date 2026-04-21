import { CreateBlogComponent, BlogTableComponent, CButtonField } from "../../components"
import { UpdateBlogComponent } from "../../components/blogManager/UpdateBlogComponent";
import { ZoneControlComponent, ZoneControlItem } from "../../components/zoneControl/zoneControlComponent";
import { useBlogContainer } from "../../hooks";


const BlogContainer = () =>{
    
    const {
        blogs,
        removeHandler,
        updateSelectHandler,
        addHandler,
        setShowContainer,
        showContainer,
        updateHandler,
        refreshTable} = useBlogContainer();

    const isTable = showContainer.find(x=>x=="table")?true:false;

    return (
        
        <div>
            <div className="flex gap-4">
                <CButtonField onClick={()=>{setShowContainer(["add"])}}>Yeni Blog</CButtonField>
                <CButtonField onClick={()=>{refreshTable()}} className={`${(isTable==false&&"bg-red-700")}`}>
                    {(isTable?"Yenile":"İptal")}
                </CButtonField>
            </div>
            <ZoneControlComponent className="mt-4" zoneKeys={showContainer}>
                <ZoneControlItem zoneKey="add">
                    <CreateBlogComponent onSubmit={addHandler}></CreateBlogComponent><br></br>
                </ZoneControlItem>
                <ZoneControlItem zoneKey="update">
                    <UpdateBlogComponent onSubmit={updateHandler}></UpdateBlogComponent>
                </ZoneControlItem>
                <ZoneControlItem zoneKey="table">
                    <BlogTableComponent blogs={blogs} updateOnHandler={updateSelectHandler} removeOnHandler={removeHandler}></BlogTableComponent>
                </ZoneControlItem>
            </ZoneControlComponent>
        </div>
    )
}

export default BlogContainer
