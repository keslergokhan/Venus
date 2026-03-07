import { useState } from "react";
import { CreateBlogComponent, type CreateBlogType,BlogDynamicInputFields, BlogTableComponent, CButtonField } from "../../components"
import { FormHelper } from "../../helpers";
import { ZoneControlComponent, ZoneControlItem } from "../../components/zoneControl/zoneControlComponent";
import { Dropdown, DropdownItem } from "flowbite-react";
import { useBlogContainer } from "../../hooks";


const BlogContainer = () =>{
    
    const {blogs} = useBlogContainer();
    const [blogKeys,setBlogKeys] = useState<string[]>(["table"]);

    const onSubmitHandler = (data:CreateBlogType) =>{
        console.log(FormHelper.toDynamicObject({data:data,dynamicFields:BlogDynamicInputFields}));
    }

    return (
        <div>
            
            <div className="flex gap-4">
                <CButtonField onClick={()=>{setBlogKeys(["add"])}}>Yeni Blog</CButtonField>
                <CButtonField onClick={()=>{setBlogKeys(["table"])}}>Bloglar</CButtonField>
            </div>
            
            <ZoneControlComponent className="mt-4" zoneKeys={blogKeys}>
                <ZoneControlItem zoneKey="add">
                    <CreateBlogComponent onSubmit={onSubmitHandler}></CreateBlogComponent>
                </ZoneControlItem>
                <ZoneControlItem zoneKey="table">
                    <BlogTableComponent blogs={blogs}></BlogTableComponent>
                </ZoneControlItem>
            </ZoneControlComponent>
        </div>
    )
}

export default BlogContainer
