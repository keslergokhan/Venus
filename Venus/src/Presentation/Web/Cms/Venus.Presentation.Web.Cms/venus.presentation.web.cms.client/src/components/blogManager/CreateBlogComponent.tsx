import { zodResolver } from "@hookform/resolvers/zod";
import { useForm } from "react-hook-form";
import z from "zod";
import { CButtonField, CTextField, DynamicFieldComponentEnum, DynamicFieldsComponent, UrlInputField, type DynamicFieldComponentProps } from "..";
import { useUrlPathControl, type CreateBlogType } from "../../hooks";


export interface CreateBlogComponentProps{
    onSubmit:(data:CreateBlogType)=>void
}

export const BlogDynamicInputFields:Array<DynamicFieldComponentProps<CreateBlogType>> = [
    {
        label:"Blog Kategori",
        name :"blogCategory",
        type:DynamicFieldComponentEnum.Text,
    },
    {
        label:"Blog içeriği",
        name:"blogContent",
        type:DynamicFieldComponentEnum.HtmlEditor,
    }
];

export const CreateBlogComponent = (props:CreateBlogComponentProps) =>{

    const schema = z.object({
        urlPath:z.string().min(3,"Lütfen biraz daha anlamlı adres giriniz."),
        title:z.string().min(1,"Lütfen boş geçmeyiniz."),
        description:z.string().min(1,"Lütfen boş geçmeyiniz."),
        blogCategory:z.string().min(5,"Lütfen adınızı giriniz"),
        blogContent:z.string().min(10,"Lütfen biraz daha içeri giriniz"),
    });

    const defaultValues = 
    {
        urlPath:"",
        blogContent:"",
        blogCategory:"",
        description:"",
        title:""
    };
    
    const useformObject = useForm<CreateBlogType>({resolver:zodResolver(schema),defaultValues:defaultValues});

    const {getValues,setValue,setError} = useformObject;
    const {register,formState:{errors}} = useformObject;

    const urlSetValue = (url:string)=>{
        setValue("urlPath",url);
    }

    const urlGetValue = ():string=>{
        return getValues("urlPath");
    }
    const useUrlControl = useUrlPathControl({getValue:()=>{return getValues("urlPath")},setValue:(url:string)=>setValue("urlPath",url)});
    

    return (
        <form className="space-y-6" onSubmit={useformObject.handleSubmit(props.onSubmit)}>
            <CTextField name="title" id="title" label="Başlık" formRegister={register("title")} fieldErrors={errors.title} type="text"></CTextField>
            <CTextField name="description" id="description" label="Kısa Açıklama" formRegister={register("description")} fieldErrors={errors.description} type="text"></CTextField>
            <UrlInputField useUrlPathControl={useUrlControl} formRegister={(register("urlPath"))} fieldErrors={errors.urlPath}></UrlInputField>
            <DynamicFieldsComponent title="Dinamik form" fields={BlogDynamicInputFields} useFormReturn={useformObject}></DynamicFieldsComponent>
            <CButtonField disabled={useUrlControl.isUrlExists} id="blog-submit-btn">Kaydet</CButtonField>
        </form>
    )
}

