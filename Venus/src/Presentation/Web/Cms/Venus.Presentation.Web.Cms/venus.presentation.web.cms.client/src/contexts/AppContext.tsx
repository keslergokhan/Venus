import { createContext, useReducer, type JSX } from "react";
import { FileManagerReducer, type FileManagerReducerAction, type FileManagerReducerState } from "../reducers/FileManagerReducer";


export class AppContextProps {
    fileManagerState:FileManagerReducerState;
    fileManagerAction:React.Dispatch<FileManagerReducerAction>;
}

export const AppContext = createContext(new AppContextProps());


export const AppContextProvider = ({ children }: { children: React.ReactNode }):JSX.Element =>{

    const fileManagerReducerState:FileManagerReducerState = {
        fileManagerModal:false,
        selectFileEvent:()=>{}
    };
    
    
    const [state,dispatch] = useReducer(FileManagerReducer,fileManagerReducerState);
    
    return (
        <AppContext.Provider value={{fileManagerAction:dispatch,fileManagerState:state}}>
            {children}
        </AppContext.Provider>
    )
}