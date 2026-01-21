import { createContext, useReducer, type JSX } from "react";
import { LanguageReducerReducer, type LanguageReducerAction, type LanguageReducerState} from "../reducers/LanguageReducer";


export class AppContextContextProps {
    languageState:LanguageReducerState;
    languageAction:React.Dispatch<LanguageReducerAction>
}

export const AppContext = createContext<AppContextContextProps>(new AppContextContextProps());


export const AppContextProvider = ({ children }: { children: React.ReactNode }):JSX.Element =>{

    var [languageReducerState,languageReducerAction] = useReducer(LanguageReducerReducer,{
        language:"tr-TR",
        languages : []
    });
    
    
    return (
        <AppContext.Provider value={{languageAction:languageReducerAction,languageState:languageReducerState}}>
            {children}
        </AppContext.Provider>
    )
}