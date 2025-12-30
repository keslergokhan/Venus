

export type LanguageReducerAction = 
 {type:"SetLanguage",language:string}
| {type:"GetLanguage"}


export interface LanguageReducerState{
    language:string;
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

    if(actionType == "SetLanguage"){

        return {...state,language:action.language};
    }

    return {...state}
}