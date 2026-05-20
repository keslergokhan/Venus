import { useEffect, useState, type JSX } from "react";
import type { ReadLanguageDto, ReadLanguageResourceKeyDto, ReadLanguageResourceValueDto } from "../../dtos";
import { CButtonField, HtmlEditor, IconFlag } from "../commons";
import { CTextAreaField } from "../commons";
import z from "zod";
import type { UpdateLanguageResourceType } from "../../hooks/useLanguageResourceContainer";
import { useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";

interface LanguageResourceUpdateComponentProps{
    currentLangaugeResourceKey:ReadLanguageResourceKeyDto|null
    languageList:ReadLanguageDto[]
    updateResourceHandler:(data:UpdateLanguageResourceType)=>Promise<void>;
}

export function LanguageResourceUpdateComponent(props:LanguageResourceUpdateComponentProps){
    const [htmlSoruce,setHtmlSource] = useState<boolean>(false);
    const [currentLanguageResourceValue,setCurrentLanguageResourceValue] = useState<ReadLanguageResourceValueDto>();
    const [language,setLanguage] = useState<ReadLanguageDto|null>(null);

    useEffect(()=>{
        const language = props.languageList.find(x=>x.culture=="tr-TR");
        if(language){
            setLanguage(language);
        }
        if(props.currentLangaugeResourceKey){
            const findResource = props.currentLangaugeResourceKey?.resourceValue.find(x=>x.languageId == "47c696f8-5066-4094-a89f-6b52c9c24694");
            if(findResource){
                setCurrentLanguageResourceValue(findResource);
                setValue("resourceId",props.currentLangaugeResourceKey.id);
                setValue("languageResourceValue",findResource?.value);
                setValue("languageId",findResource?.languageId);
            }
        }
    },[]);

    useEffect(()=>{
        if(props.currentLangaugeResourceKey){
            const findResource = props.currentLangaugeResourceKey?.resourceValue.find(x=>x.languageId == language?.id);
            if(findResource){
                setCurrentLanguageResourceValue(findResource);
                setValue("languageId",findResource?.languageId);
                setValue("resourceId",props.currentLangaugeResourceKey?.id);
                setValue("languageResourceValue",findResource?.value);
            }
        }
    },[language])


    const schema = z.object({
        resourceId:z.string().min(1,"id değeri formatı uygun değil"),
        languageResourceValue:z.string(),
        languageId:z.string()
    });

    const defaultValue:UpdateLanguageResourceType = {
        resourceId:props.currentLangaugeResourceKey?.id ?? "",
        languageResourceValue:"",
        languageId:""
    };

    function setFlagClickHandler(language:ReadLanguageDto){
        setLanguage(language);
    }


    const form = useForm<UpdateLanguageResourceType>({resolver:zodResolver(schema),defaultValues:defaultValue});
    const {register,formState:{errors}} = form;
    const {setValue} = form;

    return (<>
        {!props.currentLangaugeResourceKey || !currentLanguageResourceValue ? 
            <>Yükleniyor...</>
            :<>
                <div className="grid grid-cols-1 md:grid-cols-3 w-full relative gap-2">
                    <div className="col-span-1 text-center">
                            <span className="fond-bold text-xl">{props.currentLangaugeResourceKey.key}</span>
                        </div>
                        <div className="col-span-1 text-center flex gap-2 justify-end pt-2 text-lx">
                            {props.languageList?.map((x,i)=>{
                                return <span onClick={()=>{setFlagClickHandler(x)}} key={i} className="w-[100px] p-0 m-0 flex gap-1 cursor-pointer">
                                        <IconFlag height={24} width={24} culture={x.culture}></IconFlag>
                                        {x.name}
                                    </span>
                            })}
                        </div>
                        <div className="flex col-span-1 gap-3">
                            <CButtonField disabled={htmlSoruce == false ? true:false} onClick={()=>{setHtmlSource(false)}}> Metin </CButtonField>
                            <CButtonField disabled={htmlSoruce == true ? true:false} onClick={()=>{setHtmlSource(true)}}> Zengin Metin </CButtonField>
                        </div>
                    </div>
                    <div className="top-2">
                        <form onSubmit={form.handleSubmit(props.updateResourceHandler)}>
                            <input hidden value={props.currentLangaugeResourceKey.id} {...form.register("resourceId")}></input>
                            {   htmlSoruce==false ?
                                <CTextAreaField name="languageResourceValue" id="languageResourceValue"  formRegister={form.register("languageResourceValue")} fieldErrors={errors.languageResourceValue} ></CTextAreaField>
                                :
                                <HtmlEditor name="languageResourceValue" control={form.control} ></HtmlEditor>
                            }
                            <CButtonField>Kaydet</CButtonField>
                        </form>
                        
                    </div>
            </>
        }
    </>);
}