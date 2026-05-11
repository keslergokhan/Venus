import { useEffect, useState, type JSX } from "react";
import type { ReadLanguageResourceKeyDto, ReadLanguageResourceValueDto } from "../../dtos";
import { CButtonField, HtmlEditor } from "../commons";
import { CTextAreaField } from "../commons";
import z from "zod";
import type { UpdateLanguageResourceType } from "../../hooks/useLanguageResourceContainer";

interface LanguageResourceUpdateComponentProps{
    currentLangaugeResourceKey:ReadLanguageResourceKeyDto|null
}

export const LanguageResourceUpdateComponent = (props:LanguageResourceUpdateComponentProps):JSX.Element =>{
    const [htmlSoruce,setHtmlSource] = useState<boolean>(false);
    const [currentLanguageResourceValue,setCurrentLanguageResourceValue] = useState<ReadLanguageResourceValueDto>();
    useEffect(()=>{

        if(props.currentLangaugeResourceKey){
            const findLan = props.currentLangaugeResourceKey?.resourceValue.find(x=>x.languageId == "47c696f8-5066-4094-a89f-6b52c9c24694");
            console.log(props.currentLangaugeResourceKey);
            if(findLan){
                setCurrentLanguageResourceValue(findLan);
            }
        }
        
    },[]);

    if(!props.currentLangaugeResourceKey){
        return <>Yükleniyor...</>
    }

    if(!currentLanguageResourceValue){
        return <>Yükleniyor...</>
    }

    const schema = z.object({
        id:z.string().min(10,"id değeri formatı uygun değil"),
        value:z.string()
    });

    const defaultValue:UpdateLanguageResourceType = {
        id:currentLanguageResourceValue.id,
        value:currentLanguageResourceValue.value
    };

    return (<>
        <div className="grid grid-cols-1 md:grid-cols-2 w-full relative gap-2">
            <div className="col-span-1 text-center">
                <span className="fond-bold text-xl">{props.currentLangaugeResourceKey.key}</span>
            </div>
            <div className="flex col-span-1 gap-3">
                <CButtonField disabled={htmlSoruce == false ? true:false} onClick={()=>{setHtmlSource(false)}}> Metin </CButtonField>
                <CButtonField disabled={htmlSoruce == true ? true:false} onClick={()=>{setHtmlSource(true)}}> Zengin Metin </CButtonField>
            </div>
        </div>
        <div className="top-2">
            
            {   htmlSoruce==false ?
                <CTextAreaField value={currentLanguageResourceValue.value} name="resourceKeyValue" id="resourceKeyValue" ></CTextAreaField>
                :
                <HtmlEditor name="resourceKeyValue" ></HtmlEditor>
            }
        </div>
    </>);
}