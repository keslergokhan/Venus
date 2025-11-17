import type { JSX } from "react";
import * as Flowbite from "flowbite-react";
import { useContext, useEffect, useRef, useState } from "react";
import { CTextField, } from "../commons";
import { IconOpenFolder2, IconFile2, IconArrow, IconArrowLeft, IconClose } from "../commons/icons"
import { IconTypeFile } from "../commons/icons/IconFile";
import { FileManagerService } from "../../services";
import type { ReadFileDto } from "../../dtos/fileManager/ReadFileDto";
import type { ReadFolderDto } from "../../dtos/fileManager/ReadFolderDto";
import { FileManagerGetFolderRes } from "../../models";
import { ToastHelper } from "../../helpers";
import { LoadingComponent } from "../loading/LoadingComponent";
import { IconRefresh } from "../commons/icons/IconRefresh";
import { AppContext } from "../../contexts/AppContext";

export interface FileManagerComponentProps {
    selectFilenName:string
}

export const FileManagerComponent = (): JSX.Element => {
    const appContext = useContext(AppContext);
    const fileManagerService = new FileManagerService;
    const [loading,setLoading] = useState<boolean>(false);
    const currentPath = useRef<string[]>([""]);

    let folderAndFileData = useRef<FileManagerGetFolderRes>(new FileManagerGetFolderRes([],[]));

    useEffect(()=>{
        if(appContext.fileManagerState.fileManagerModal == true){
            getFolderAndFileAsync();
        }
    },[appContext.fileManagerState]);

    const currentClearPath = () =>{
        currentPath.current = [""];
    }

    const getFullPath = (fileName?:string):string => {
        let fullPath:string = "";
        currentPath.current.forEach(x=>{
            fullPath +=(x==""?"":"/")+x;
        });

        if(fileName && currentPath.current.length>1){
            return fullPath +"/"+ fileName;
        }else if(fileName){
            return fileName;
        }
        return fullPath;
    }

    const getFolderAndFileAsync = async ():Promise<void> =>{
        setLoading(true);
        await fileManagerService.getFoldersAsync({path:getFullPath()}).then(x=>{
            if(x.isSuccess){
                folderAndFileData.current = new FileManagerGetFolderRes(x.data.files as Array<ReadFileDto>,x.data.folders as Array<ReadFolderDto>);
            }else{
                ToastHelper.DefaultError();
            }
        }).finally(()=>{
            setLoading(false);
        });
    }

    const folderOpenPath = (data:ReadFolderDto) =>{
        currentPath.current = [...currentPath.current,data.name];
        getFolderAndFileAsync();
    }

    const folderBackClickHandler = () =>{
        currentPath.current.pop();
        getFolderAndFileAsync();
    }

    const selectFileClickHandlerAsync = async (data:ReadFileDto) =>{
        currentClearPath();
        appContext.fileManagerState.selectFileEvent(data.fileName);
        appContext.fileManagerAction({type:"FileManagerModal",state:false});
    }


    const FileItem = (item:ReadFileDto) => {
        return (
            <li className="cursor-pointer" onClick={async ()=>{await selectFileClickHandlerAsync(item)}}>
                <a href="#" className="flex border-gray-400 border-1 rounded-lg text-gray-800 pl-5 items-center p-1 rounded-base group">
                    <IconTypeFile height={10} width={10} type={".png"}></IconTypeFile>
                    <span className="flex-1 ms-3 ">{item.fileName}</span>
                </a>
            </li>
        );
        
    }

    const FolderItem = (item:ReadFolderDto) =>{
        return (
            <li onClick={()=>{folderOpenPath(item)}}>
                <a href="#" className="flex border-gray-400 border-1 rounded-lg text-gray-800 pl-5 items-center p-1 rounded-base group">
                    <IconOpenFolder2 height={10} width={10}></IconOpenFolder2>
                    <span className="flex-1 ms-3">/{item.name}</span>
                    <IconArrow height={10} width={10}></IconArrow>
                </a>
            </li>
        )
    }
    
    return (
        <>
           
            
            <Flowbite.Modal show={appContext.fileManagerState.fileManagerModal} position={"center"} onClose={() => appContext.fileManagerAction({type:"FileManagerModal",state:false})} >
                <Flowbite.Card className="!bg-amber-50 ">
                    <Flowbite.ModalHeader className="p-1">
                        <span className="text-black">Dosya Yöneticisi</span>
                    </Flowbite.ModalHeader>
                    <Flowbite.ModalBody className="!p-1 !min-h-[300px] !max-h[300px] !h-[300px] relative !p-0" >
                        <div className="grid grid-cols-2">
                            <div className="">
                                Dizin : {getFullPath()}
                            </div>
                            <div className="">
                                <div className="grid grid-cols-2">
                                    <div className="justify-end flex cursor-pointer" onClick={async ()=>{await folderBackClickHandler()}}>
                                        {
                                            currentPath.current.length > 1 && <><IconArrowLeft height={50} width={50}></IconArrowLeft> Geri Çık</>
                                        }
                                        
                                    </div>
                                    <div className="flex cursor-pointer justify-end " onClick={async ()=>{await getFolderAndFileAsync()}}>
                                        <IconRefresh height={50} width={50} color="black"></IconRefresh><span>Yenile</span>
                                    </div>
                                </div>
                                
                            </div>
                        </div>
                        <LoadingComponent loading={loading} size="xl">
                            <ul className="my-2 space-y-1">
                                {
                                    folderAndFileData.current.folders?.map((x,i) =>{
                                        return <FolderItem key={i} {...x}></FolderItem>
                                    })
                                }
                                {
                                    folderAndFileData.current.files?.map((x,i) =>{
                                        return <FileItem key={i} {...x}></FileItem>
                                    })
                                }
                            </ul>
                        </LoadingComponent>
                    </Flowbite.ModalBody>
                </Flowbite.Card>
            </Flowbite.Modal>
        </>
    );
}

