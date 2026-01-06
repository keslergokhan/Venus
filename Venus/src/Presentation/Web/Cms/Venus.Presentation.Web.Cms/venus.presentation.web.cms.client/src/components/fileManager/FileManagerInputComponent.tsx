import { useContext, useState } from "react";
import { CTextField, IconClose, IconOpenFolder2 } from "../commons";
import { AppContext } from "../../contexts/AppContext";
import type { ReadFileDto } from "../../dtos";
import { FileManagerContext } from "../../contexts/FileManagerContext";

export const FileManagerInputComponent = () =>{

    const fileManagerContext = useContext(FileManagerContext);
    const [fileName,setFileName] = useState<string>("");

    

    const onClickHandler = () =>{
        fileManagerContext.fileManagerAction({type:"FileManagerModalAndSelectEvent",state:true,selectFileEvent:(fileItem:ReadFileDto)=>{
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
                        fileName !== "" && <div className="cursor-pointer" onClick={()=>{clearClickHandler()}} ><IconClose height={25} width={25} color="red"></IconClose></div>
                    }
                </div>
            </div>
    );
}