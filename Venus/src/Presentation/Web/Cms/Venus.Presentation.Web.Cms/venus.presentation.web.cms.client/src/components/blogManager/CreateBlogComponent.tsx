import { zodResolver } from "@hookform/resolvers/zod";
import { useForm } from "react-hook-form";
import z from "zod";
import { CTextField, DynamicFieldComponentEnum, DynamicFieldsComponent, type DynamicFieldComponentProps } from "..";

export type CreateBlogType = {
    Title:string,
    Description:string,
    BlogCategory:string,
    BlogContent:string,
}

export interface CreateBlogComponentProps{
    onSubmit:(data:CreateBlogType)=>void
}

export const BlogDynamicInputFields:Array<DynamicFieldComponentProps<CreateBlogType>> = [
    {
        label:"Blog Kategori",
        name :"BlogCategory",
        type:DynamicFieldComponentEnum.Text,
    },
    {
        label:"Blog içeriği",
        name:"BlogContent",
        type:DynamicFieldComponentEnum.HtmlEditor,
    }
  
];

export const CreateBlogComponent = (props:CreateBlogComponentProps) =>{

    
    const schema = z.object({
        Title:z.string().min(1,"Lütfen boş geçmeyiniz."),
        Description:z.string().min(1,"Lütfen boş geçmeyiniz."),
        BlogCategory:z.string().min(5,"Lütfen adınızı giriniz"),
        BlogContent:z.string().min(10,"Lütfen biraz daha içeri giriniz"),
    });

    const defaultValues = 
    {
        BlogContent:"",
        BlogCategory:"",
        Description:"",
        test:"",
        Title:""
    };
    
    const useformObject = useForm<CreateBlogType>({resolver:zodResolver(schema),defaultValues:defaultValues});
    
    return (
        <form className="space-y-6" onSubmit={useformObject.handleSubmit(props.onSubmit)}>
            <CTextField name="Title" id="Title" label="Başlık" formRegister={useformObject.register("Title")} FieldErrors={useformObject.formState.errors.Title} type="text"></CTextField>
            <CTextField name="Description" id="Description" label="Kısa Açıklama" formRegister={useformObject.register("Description")} FieldErrors={useformObject.formState.errors.Description} type="text"></CTextField>
            <DynamicFieldsComponent title="Dinamik form" fields={BlogDynamicInputFields} useFormReturn={useformObject}></DynamicFieldsComponent>
            <button type="submit">Kaydet</button>
        </form>
    )
}

