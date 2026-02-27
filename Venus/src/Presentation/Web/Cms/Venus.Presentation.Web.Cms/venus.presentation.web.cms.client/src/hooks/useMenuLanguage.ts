import { useContext, useEffect, useState } from "react";
import { LanguageService } from "../services";
import { AppContext } from "../contexts/AppContext";
import type { ReadLanguageDto } from "../dtos";
import { ToastHelper } from "../helpers";


export const useMenuLanguage = ():{onChangeEvent:(languageCulture:string)=>void,languages:Array<ReadLanguageDto>,currentLanguage:string} =>{
    const languageService = new LanguageService();
    const [langaugeList,setLanguageList] = useState<Array<ReadLanguageDto>>(new Array<ReadLanguageDto>());
    const [language,setLanguage] = useState<string>("Türkçe");
    const appContext = useContext(AppContext);

    useEffect(()=>{
        if(appContext.languageState.languages && appContext.languageState.languages.length <= 0){
            languageService.getLanguageAsync().then(x=>{
                setLanguageList(x);
                appContext.languageAction({"type":"SetLanguages",languages:x});
            }).catch(x=>{
                ToastHelper.DefaultCatchError(x);
            });
        }
        
    },[]);

    const languageOnChangeEvent = (language:string)=>{
        const selectLanguage = appContext.languageState.languages.find(x=>x.culture == language);
        if(selectLanguage){
            appContext.languageAction({type:"SetLanguage",language:language})
            setLanguage(selectLanguage.name);
        }else{
            ToastHelper.Error("Teknik bir sorun yaşandı, {language} mevcut değil !");
        }
    }

    return {onChangeEvent:languageOnChangeEvent,languages:langaugeList,currentLanguage:language};
}