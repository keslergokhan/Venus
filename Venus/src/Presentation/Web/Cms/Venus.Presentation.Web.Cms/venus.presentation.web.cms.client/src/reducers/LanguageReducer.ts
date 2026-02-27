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
const keyId = "cms_language_id";

const SetLangauge = (language:string,languageId:string) =>{
    localStorage.setItem(key,language);
    localStorage.setItem(keyId,languageId);
}

export const LanguageReducerReducer = (state:LanguageReducerState,action:LanguageReducerAction):LanguageReducerState =>{

    const actionType = action.type;

    if(actionType == "GetLanguage"){
        return {...state}
    }

    if(actionType == "SetLanguages"){
        const defaultLanguage = action.languages.find(x=>x.sort <= 0);
        if(defaultLanguage){
            SetLangauge(defaultLanguage.culture,defaultLanguage.id);
        }
        return {...state,languages:action.languages}
    }

    if(actionType == "SetLanguage"){
       
        return {...state,language:action.language};
    }

    return {...state}
}