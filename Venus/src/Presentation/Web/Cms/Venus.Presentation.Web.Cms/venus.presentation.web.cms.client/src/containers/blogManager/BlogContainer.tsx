import { useState } from "react";
import { CreateBlogComponent, type CreateBlogType,BlogDynamicInputFields, ListBlogComponent } from "../../components"
import { FormHelper } from "../../helpers";
import { ZoneControlComponent, ZoneControlItem } from "../../components/zoneControl/zoneControlComponent";


const BlogContainer = () =>{

    const onSubmitHandler = (data:CreateBlogType) =>{
        console.log(FormHelper.toDynamicObject({data:data,dynamicFields:BlogDynamicInputFields}));
    }

    return (
        <div>
            <CreateBlogComponent onSubmit={onSubmitHandler}></CreateBlogComponent>

            <ZoneControlComponent keys={["add"]}>

                <ZoneControlItem zoneKey="add">
                    Bu bir ekleme alanı
                </ZoneControlItem>
                <ZoneControlItem zoneKey="update">
                    Bu bir güncelleme alanı
                </ZoneControlItem>
            </ZoneControlComponent>
        </div>
    )
}

export default BlogContainer
