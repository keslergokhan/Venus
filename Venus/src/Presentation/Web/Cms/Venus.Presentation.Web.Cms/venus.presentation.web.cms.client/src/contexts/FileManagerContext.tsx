import { createContext, useReducer, type JSX } from "react";
import { FileManagerReducer, type FileManagerReducerAction, type FileManagerReducerState } from "../reducers/FileManagerReducer";


export class FileManagerContextProps {
    fileManagerState:FileManagerReducerState;
    fileManagerAction:React.Dispatch<FileManagerReducerAction>;
}

export const FileManagerContext = createContext(new FileManagerContextProps());


export const FileManagerContextProvider = ({ children }: { children: React.ReactNode }):JSX.Element =>{

    const fileManagerReducerState:FileManagerReducerState = {
        fileManagerModal:false,
        selectFileEvent:()=>{}
    };
    
    
    const [state,dispatch] = useReducer(FileManagerReducer,fileManagerReducerState);
    
    return (
        <FileManagerContext.Provider value={{fileManagerAction:dispatch,fileManagerState:state}}>
            {children}
        </FileManagerContext.Provider>
    )
}