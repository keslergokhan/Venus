import { useContext, useEffect, useState } from "react";
import { LanguageService } from "../services";
import { AppContext } from "../contexts/AppContext";
import type { ReadLanguageDto } from "../dtos";
import { SessionKeys, SessionStorageHelper, ToastHelper } from "../helpers";


export function useMenuLanguage():{onChangeEvent:(languageCulture:string)=>void,languages:Array<ReadLanguageDto>,currentLanguage:string} {
    const languageService = new LanguageService();
    const [langaugeList,setLanguageList] = useState<Array<ReadLanguageDto>>(new Array<ReadLanguageDto>());
    const [language,setLanguage] = useState<string>("Türkçe");
    const appContext = useContext(AppContext);

    async function getAndSetLanguage(){
        try {
            const languageResult = await languageService.getLanguageAsync();
            setLanguageList(languageResult);
            appContext.languageAction({"type":"SetLanguages",languages:languageResult});
            if(SessionStorageHelper.has(SessionKeys.languageId)){
                const languageId = SessionStorageHelper.get<string>(SessionKeys.languageId);
                if(languageId){
                    const language = languageResult.find(x=>x.id == languageId);
                    if(language){
                        appContext.languageAction({"type":"SetLanguage",language:language.culture});
                        setLanguage(language.name);
                    }
                } 
            }
        } catch (error) {
            ToastHelper.DefaultCatchError(error);
        }
    }
    useEffect(()=>{
        if(appContext.languageState.languages.length <= 0){
            getAndSetLanguage();
        }else{
            console.log(appContext.languageState.languages);
        }
    },[]);
    
    

    function languageOnChangeEvent(language:string) {
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