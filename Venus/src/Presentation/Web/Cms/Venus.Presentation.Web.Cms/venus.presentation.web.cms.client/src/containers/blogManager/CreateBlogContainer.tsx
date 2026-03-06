import { CreateBlogComponent, type CreateBlogType,BlogDynamicInputFields } from "../../components"
import { FormHelper } from "../../helpers";


const CreateBlogContainer = () =>{

    const onSubmitHandler = (data:CreateBlogType) =>{
        console.log(FormHelper.toDynamicObject({data:data,dynamicFields:BlogDynamicInputFields}));
    }

    return (
        <div>
            <CreateBlogComponent onSubmit={onSubmitHandler}></CreateBlogComponent>
        </div>
    )
}

export default CreateBlogContainer
