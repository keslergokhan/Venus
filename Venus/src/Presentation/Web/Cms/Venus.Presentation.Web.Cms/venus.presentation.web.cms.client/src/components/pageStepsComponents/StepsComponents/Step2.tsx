import type { JSX } from "react";
import type { Step, StepProp } from "../NewPageStepsManagerComponent";
import { CButtonField, CTextField } from "../../commons";
import { ParentUrlSelect, UrlInputField } from "../../commons/textFields";
import { useUrlPathControl } from "../../../hooks";
import {z} from 'zod';
import { useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";

const StepContent = (props:StepProp):JSX.Element =>{

    
    const schema = z.object({
        url:z.string().min(3,"Lütfen biraz daha anlamlı adres giriniz."),
        title:z.string().min(5,"Lütfen daha fazla detay giriniz.").max(65,"Başlık en fazla 65 karakter olabilir."),
        description:z.string().min(10,"Lütfen daha fazla detay giriniz.").max(500,"Açıklama en fazla 500 karakter olabilir.")
    })
    
    type FormValues = z.infer<typeof schema>;
    
    const {
        register,
        handleSubmit,
        setValue,
        getValues,
        formState:{errors}
    } = useForm<FormValues>({resolver:zodResolver(schema)});

    const onSubmit = (data:FormValues) =>{
        console.log(data);
    }

    const urlSetValue = (url:string)=>{
        setValue("url",url);
    }

    const urlGetValue = ():string=>{
        return getValues("url");
    }
    
    const urlControl = useUrlPathControl({getValue:urlGetValue,setValue:urlSetValue});
    
    return (
    <div className="container">
        <div className="mt-5">
            <form className="space-y-6" onSubmit={handleSubmit(onSubmit)}>
            
                <UrlInputField useUrlPathControl={urlControl} formRegister={register("url")} FieldErrors={errors.url}></UrlInputField>
                <CTextField type="text" id="title" name="title" label="Başık" key="title" formRegister={register("title")} FieldErrors={errors.title} ></CTextField>
                <CTextField type="description" id="description" name="description" formRegister={register("description")} FieldErrors={errors.description} label="Sayfa Açıklaması" key="description" ></CTextField>
                
                <CButtonField id="form-submit" onClick={()=>{
                    
                }}>Tamam </CButtonField>

                <button type="submit" style={{display:"none"}} className=" w-full text-white bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm px-5 py-2.5 text-center dark:bg-blue-600 dark:hover:bg-blue-700 dark:focus:ring-blue-800">
                    Giriş
                </button>
            </form>
        </div>
    </div>)
}

export const Step2:Step = {
    Key:"step_2",
    StepContent:StepContent,
    Title:"Sayfa Bilgileri",
    FormFinsh:false,
    NextStep:()=>{},
    FormSutmitHandler:(step:Step)=>{
        //step.FormFinsh = true;
        //step.NextStep("step_3");
    }
}
