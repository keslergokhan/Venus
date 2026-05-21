import type { ReadLanguageDto } from "../dtos";
import { SessionStorageHelper, SessionKeys } from "../helpers";


export type LanguageReducerAction = 
 {type:"SetLanguage",language:string}
| {type:"GetLanguage"}
| {type:"SetLanguages",languages:Array<ReadLanguageDto>}


export interface LanguageReducerState{
    language:string;
    languages:Array<ReadLanguageDto>
}


function SetLangauge(language:string,languageId:string){
    SessionStorageHelper.set(SessionKeys.language,language);
    SessionStorageHelper.set(SessionKeys.languageId,languageId);
}

export function LanguageReducerReducer(state:LanguageReducerState,action:LanguageReducerAction):LanguageReducerState {

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
        const selectLanguage = action.language;
        if(selectLanguage){
            var findLanguage = state.languages.find(x=>x.culture == selectLanguage)
            if(findLanguage){
                SetLangauge(findLanguage.culture,findLanguage.id);
            }
        }
        return {...state,language:action.language};
    }

    return {...state}
}