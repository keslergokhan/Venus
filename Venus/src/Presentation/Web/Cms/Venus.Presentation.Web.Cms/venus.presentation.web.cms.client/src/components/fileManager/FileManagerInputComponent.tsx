import { useContext, useState } from "react";
import { CTextField, IconClose, IconOpenFolder2 } from "../commons";
import { AppContext } from "../../contexts/AppContext";
import type { ReadFileDto } from "../../dtos/fileManager/ReadFileDto";

export const FileManagerInputComponent = () =>{

    const appContext = useContext(AppContext);
    const [fileName,setFileName] = useState<string>("");

    

    const onClickHandler = () =>{
        appContext.fileManagerAction({type:"FileManagerModalAndSelectEvent",state:true,selectFileEvent:(fileItem:ReadFileDto)=>{
            console.log(fileItem);
            setFileName(fileItem.filePath);
        }})
        
    }

    const clearClickHandler = () =>{
        setFileName("");
    }
    
    return (
        <div className="flex">
                <div className="">
                    <CTextField
                        className="max-w-[230px]"
                        value={fileName} 
                        onClick={()=>{onClickHandler()}}
                        placeholder={"Dosya Seç"} 
                        Icon={<IconOpenFolder2  
                        height={24} 
                        width={24} 
                        color="#104e64"></IconOpenFolder2>}
                        type="email" id="email" name="email" label="Kullanıcı Adı" key="email"   ></CTextField>
                </div>
                
                <div className="flex items-center mt-6">
                    {
                        fileName !== "" && <div className="cursor-pointer" onClick={()=>{clearClickHandler()}} ><IconClose height={50} width={50} color="red"></IconClose></div>
                    }
                </div>
            </div>
    );
}