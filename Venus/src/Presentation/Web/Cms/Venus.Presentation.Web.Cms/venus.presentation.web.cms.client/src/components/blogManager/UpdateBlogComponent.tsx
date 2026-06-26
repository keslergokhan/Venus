import { zodResolver } from "@hookform/resolvers/zod";
import { useUrlPathControl, type UpdateBlogType } from "../../hooks"
import { CButtonField, CTextField, DynamicPropertiesComponent,DynamicPropertiesComponentEnum, UrlInputField, type DynamicPropertyComponentProps } from "..";
import z from "zod";
import { useForm } from "react-hook-form";
import { ReadBlogDto, type ReadPageDto } from "../../dtos";



export interface UpdateBlogComponentProps{
    onSubmit:(data:UpdateBlogType)=>void;
    currentUpdateBlog:ReadBlogDto|null;
    blogPage:ReadPageDto
}

export const BlogDynamicInputFields:Array<DynamicPropertyComponentProps<UpdateBlogType>> = [
    {
        label:"Blog Kategori",
        name :"blogCategory",
        type:DynamicPropertiesComponentEnum.Text,
    },
    {
        label:"Blog içeriği",
        name:"blogContent",
        type:DynamicPropertiesComponentEnum.RichTextEditorField,
    }
];

export function UpdateBlogComponent(props:UpdateBlogComponentProps){
    const blog = props.currentUpdateBlog;

    if(blog==null){
        return <>Yükleniyor...</>
    }

    const schema = z.object({
        id:z.string(),
        urlPath:z.string().min(3,"Lütfen biraz daha anlamlı adres giriniz."),
        title:z.string().min(1,"Lütfen boş geçmeyiniz."),
        description:z.string().min(1,"Lütfen boş geçmeyiniz."),
        blogCategory:z.string().min(5,"Lütfen adınızı giriniz"),
        blogContent:z.string().min(10,"Lütfen biraz daha içeri giriniz"),
    });

    const blogInstance = new ReadBlogDto(); 
    Object.assign(blogInstance, props.currentUpdateBlog);
    const defaultValues = blogInstance.getFlattenedData<UpdateBlogType>();

    const useformObject = useForm<UpdateBlogType>({resolver:zodResolver(schema),defaultValues:defaultValues});
    const {getValues,setValue,setError} = useformObject;
    const {register,formState:{errors}} = useformObject;

    const useUrlControl = useUrlPathControl({baseFullPath:props.blogPage.url.fullPath,getValue:()=>{return getValues("urlPath")},setValue:(url:string)=>setValue("urlPath",url)});
    return (<>
        <form className="space-y-6" onSubmit={useformObject.handleSubmit(props.onSubmit)}>
            <CTextField name="title" id="title" label="Başlık" formRegister={register("title")} fieldErrors={errors.title} type="text"></CTextField>
            <CTextField name="description" id="description" label="Kısa Açıklama" formRegister={register("description")} fieldErrors={errors.description} type="text"></CTextField>
            <UrlInputField useUrlPathControl={useUrlControl} formRegister={(register("urlPath"))} fieldErrors={errors.urlPath}></UrlInputField>
            <DynamicPropertiesComponent title="Dinamik form" fields={BlogDynamicInputFields} useFormReturn={useformObject}></DynamicPropertiesComponent>
            <CButtonField disabled={useUrlControl.isUrlExists} id="blog-submit-btn">Güncelle</CButtonField>
        </form>
    </>)
}