import type { ReadLanguageDto } from "../dtos";


export type LanguageReducerAction = 
 {type:"SetLanguage",language:string}
| {type:"GetLanguage"}
| {type:"SetLanguages",languages:Array<ReadLanguageDto>}


export interface LanguageReducerState{
    language:string;
    languages:Array<ReadLanguageDto>
}

const key = "cms_language";

const GetLanguageAndSetDefault = () =>{
    let languageLocalStorage = localStorage.getItem(key);

    if(languageLocalStorage == null || languageLocalStorage=="" || languageLocalStorage == undefined){
        SetLangauge("tr-TR");
        languageLocalStorage = "tr-TR";
    }
    return languageLocalStorage;
}

const SetLangauge = (language:string) =>{
   
    localStorage.setItem(key,language);
    return GetLanguageAndSetDefault;
}

export const LanguageReducerReducer = (state:LanguageReducerState,action:LanguageReducerAction):LanguageReducerState =>{

    let languageLocalStorage = GetLanguageAndSetDefault();

    const actionType = action.type;

    if(actionType == "GetLanguage"){
        return {...state,language:languageLocalStorage}
    }

    if(actionType == "SetLanguages"){
        return {...state,languages:action.languages}
    }

    if(actionType == "SetLanguage"){
        SetLangauge(action.language);
        return {...state,language:action.language};
    }

    return {...state}
}