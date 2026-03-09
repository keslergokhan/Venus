import type { JSX } from "react";
import type { Step, StepContentProps } from "../NewPageStepsManagerComponent";
import { useUrlPathControl } from "../../../hooks";
import {z} from 'zod';
import { useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import { CButtonField, CTextField, UrlInputField } from "../..";

const StepContent = (props:StepContentProps):JSX.Element =>{
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
        props.allStepPostData.title = data.title;
        props.allStepPostData.url = data.url;
        props.allStepPostData.description = data.description;
        props.step.FormSutmitHandler(props.step);
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
                {
                    !props.allStepPostData.url?
                    <UrlInputField useUrlPathControl={urlControl} formRegister={register("url")} fieldErrors={errors.url}></UrlInputField>
                    :
                    <CTextField disabled={props.step.FormFinsh} type="text" id="url" name="url" label="url" key="url" value={props.allStepPostData.url}></CTextField>
                }
                
                <CTextField disabled={props.step.FormFinsh} value={props.allStepPostData.title} type="text" id="title" name="title" label="Başık" key="title" formRegister={register("title")} fieldErrors={errors.title} ></CTextField>
                <CTextField disabled={props.step.FormFinsh} value={props.allStepPostData.description} type="description" id="description" name="description" formRegister={register("description")} fieldErrors={errors.description} label="Sayfa Açıklaması" key="description" ></CTextField>
                
                <CButtonField id="form-submit" 
                disabled={props.step.FormFinsh || !props.steps?.find(x=>x.Key == "step_1")?.FormFinsh}>Tamam </CButtonField>
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
        step.FormFinsh = true;
        step.NextStep("step_3");
    }
}
