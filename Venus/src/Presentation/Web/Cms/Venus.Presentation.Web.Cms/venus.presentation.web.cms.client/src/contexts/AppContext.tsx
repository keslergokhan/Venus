import { createContext, useReducer, type JSX } from "react";
import { LanguageReducerReducer, type LanguageReducerAction, type LanguageReducerState} from "../reducers/LanguageReducer";
import { ConfirmModalReducer, type ConfirmModalReducerAction, type ConfirmModalReducerState } from "../reducers/ConfirmModalReducer";


export class AppContextContextProps {
    languageState:LanguageReducerState;
    languageAction:React.Dispatch<LanguageReducerAction>;
    confirmModalState:ConfirmModalReducerState;
    confirmModalAction:React.Dispatch<ConfirmModalReducerAction>
}

export const AppContext = createContext<AppContextContextProps>(new AppContextContextProps());


export const AppContextProvider = ({ children }: { children: React.ReactNode }):JSX.Element =>{

    var [languageReducerState,languageReducerAction] = useReducer(LanguageReducerReducer,{
        language:"tr-TR",
        languages : [],
    });

    var [confirmModalState,confirmModalAction] = useReducer(ConfirmModalReducer,{
        show:false,title:"",body:<></>
    });
    
    return (
        <AppContext.Provider value={{
            languageAction:languageReducerAction,
            languageState:languageReducerState,
            confirmModalState:confirmModalState,
            confirmModalAction:confirmModalAction}}>
            {children}
        </AppContext.Provider>
    )
}