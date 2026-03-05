import type { JSX } from "react"
import { FileManagerInputComponent } from "../../components/fileManager/FileManagerInputComponent";
import { CTextField} from "../../components";
import {z} from "zod";
import { useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import { DynamicFieldsComponent } from "../../components/dynamicFields/DynamicFieldsComponent";
import { DynamicFieldComponentEnum, type DynamicFieldComponentProps } from "../../components/dynamicFields/DynamicFieldsComponentProps";
import { FormHelper } from "../../helpers";

const HomeContainers = ():JSX.Element =>{

    const schema = z.object({
        Title:z.string().min(1,"Lütfen boş geçmeyiniz."),
        Description:z.string().min(1,"Lütfen boş geçmeyiniz."),
        BlogCategory:z.string().min(5,"Lütfen adınızı giriniz"),
        BlogContent:z.string().min(10,"Lütfen biraz daha içeri giriniz"),
        test:z.string().min(1,"Lütfen boş geçmeiyniz")
    });

    type formValues = z.infer<typeof schema>;

    const useformObject = useForm<formValues>({resolver:zodResolver(schema),defaultValues:{BlogContent:"",BlogCategory:"",Description:"",test:"",Title:""}});

    const inputField:Array<DynamicFieldComponentProps<formValues>> = [
        {
            label:"Blog Kategori",
            name :"BlogCategory",
            type:DynamicFieldComponentEnum.Text,
        },
        {
            label:"Blog içeriği",
            name:"BlogContent",
            type:DynamicFieldComponentEnum.HtmlEditor,
        },
        {
            label:"test",
            name:"test",
            type:DynamicFieldComponentEnum.Text,
            isCreate:false
        }
    ];

    const onSubmit = (data:formValues) =>{
        console.log(FormHelper.toDynamicObject({data:data,dynamicFields:inputField}));
    }

    return (<>
        <FileManagerInputComponent></FileManagerInputComponent>
        <form className="space-y-6" onSubmit={useformObject.handleSubmit(onSubmit)}>
            <CTextField name="Title" id="Title" label="Başlık" formRegister={useformObject.register("Title")} FieldErrors={useformObject.formState.errors.Title} type="text"></CTextField>
            <CTextField name="Description" id="Description" label="Kısa Açıklama" formRegister={useformObject.register("Description")} FieldErrors={useformObject.formState.errors.Description} type="text"></CTextField>
            <CTextField name="test" id="test" label="Kısa Test Açıklama" formRegister={useformObject.register("test")} FieldErrors={useformObject.formState.errors.test} type="text"></CTextField> 
            <DynamicFieldsComponent title="Dinamik form" fields={inputField} useFormReturn={useformObject}></DynamicFieldsComponent>
            <button type="submit">Gönder</button>
        </form>
        
        
    </>)
}

export default HomeContainers;