import { createContext, useContext, useRef, useState, type JSX } from "react";


export class AppContextProps {
    fileManagerStateHandler : (state:boolean)=>void;
    fileManagerState:boolean;
    fileManagerSelectHandler:React.RefObject<(fileName:string)=>void>;
}

export const AppContext = createContext(new AppContextProps());


export const AppContextProvider = ({ children }: { children: React.ReactNode }):JSX.Element =>{

    const [modalState,setModalState] = useState<boolean>(false);
    const selectHandler = useRef<(fileName:string)=>void>(()=>{});

    
    return (
        <AppContext.Provider value={
            {
                fileManagerStateHandler:setModalState,
                fileManagerState:modalState,
                fileManagerSelectHandler:selectHandler
            }}>
            {children}
        </AppContext.Provider>
    )
}