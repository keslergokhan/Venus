import type { JSX } from "react";
import * as Flowbite from "flowbite-react";
import { useContext, useEffect, useRef, useState } from "react";
import { IconOpenFolder2, IconFile2, IconArrow, IconArrowLeft, IconClose, IconRefresh } from "../commons/icons"
import { IconTypeFile } from "../commons/icons/IconFile";
import { FileManagerService } from "../../services";
import type { ReadFileDto } from "../../dtos/fileManager/ReadFileDto";
import type { ReadFolderDto } from "../../dtos/fileManager/ReadFolderDto";
import { FileManagerGetFolderRes } from "../../models";
import { ToastHelper } from "../../helpers";
import { LoadingComponent } from "../loading/LoadingComponent";
import { AppContext } from "../../contexts/AppContext";
import { CSmButtonField } from "../commons";
import { MultiLoadingComponent } from "../loading/MultiLoadingComponent";

export interface FileManagerComponentProps {
    selectFilenName:string
}

export const FileManagerComponent = (): JSX.Element => {
    const fileManagerService = new FileManagerService;
    const appContext = useContext(AppContext);
    const loadingKeys = {
        FileManagerContent:"FileManagerContent",
        FileMangerUploadContent:"FileMangerUploadContent"
    }
    /** Dosya yükleme inputu */
    const fileUploadInput = useRef<HTMLInputElement>(null);
    /** Yükleniyor eventi */
    const [loadingkey,setLoadingKey] = useState<string>("");
    /** Dosya yöneticisi mevcut dizin */
    const currentPath = useRef<string[]>([""]);
    /** Mevcut dizinde bulunan dosya ve klasörler */
    const folderAndFileData = useRef<FileManagerGetFolderRes>(new FileManagerGetFolderRes([],[]));
    /** Yüklenmek için seçilen dosya lisesi */
    const selectedFiles = useRef<Array<File>>([]);

    useEffect(()=>{
        if(appContext.fileManagerState.fileManagerModal == true){
            getFolderAndFileAsync();
        }
    },[appContext.fileManagerState]);

    /**
     * Mevcut dizini temizle
     */
    const currentClearPath = () =>{
        currentPath.current = [""];
    }

    /**
     * Dosya yöneticisinin mevcut dizini döner
     * @param fileName Mevcut dizine dosya adı dahilet
     * @returns 
     */
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

    /**
     * Mevcut dizinin dosya ve klasörlerini getir.
     */
    const getFolderAndFileAsync = async ():Promise<void> =>{
        setLoadingKey(loadingKeys.FileManagerContent);
        await fileManagerService.getFoldersAsync({path:getFullPath()}).then(x=>{
            if(x.isSuccess){
                folderAndFileData.current = new FileManagerGetFolderRes(x.data.files as Array<ReadFileDto>,x.data.folders as Array<ReadFolderDto>);
            }else{
                throw new Error("Dizin çekiler beklenmedik bir problem yaşandı !");
            }
        }).catch(x=>{
            ToastHelper.DefaultCatchError(x);
        }).finally(()=>{
            setLoadingKey("");
        });
    }

    /**
     * Seçilen dosyanın içerisine gir.
     * @param data 
     */
    const folderOpenClickPathHandlerAsync = async (data:ReadFolderDto) =>{
        currentPath.current = [...currentPath.current,data.name];
        await getFolderAndFileAsync();
    }

    /**
     * Mevcut dosyadan geri çık
     */
    const folderBackClickHandlerAsync = async () =>{
        currentPath.current.pop();
        await getFolderAndFileAsync();
    }

    /**
     * Dosyayı seç.
     * @param data 
     */
    const selectFileClickHandlerAsync = async (data:ReadFileDto) =>{
        currentClearPath();
        appContext.fileManagerState.selectFileEvent(data);
        appContext.fileManagerAction({type:"FileManagerModal",state:false});
    }

    const removeClickHandlerAsync = async (data:ReadFileDto) =>{

        await fileManagerService.removeFileAsync({path:data.filePath}).then(x=>{
            if(x.isSuccess){
                ToastHelper.Success(`${data.fileName} silindi !`);
                getFolderAndFileAsync();
            }else{
                throw new Error("Dosya silme işleminde beklenmedik bir problem yaşandı !");
            }
        }).catch(x=>{
            ToastHelper.DefaultCatchError(x);
        })
    }


    /**
     * Dosya yükleme buttonu
     */
    const uploadFileButtonClickHandlerAsync = async () =>{
        fileUploadInput.current?.click();
        setLoadingKey(loadingKeys.FileMangerUploadContent);
    }

    const uploadFileInputonChangeHandlerAsync = async (e:React.ChangeEvent<HTMLInputElement>) =>{
        const inputSelectedFileList = e.target.files as FileList;
        
        if(inputSelectedFileList.length >= 0){
            Array.from(inputSelectedFileList).forEach(file=>{
                selectedFiles.current.push(file);
            });
        }
        console.log(selectedFiles.current);
        setLoadingKey("");
        
    }



    const FileItem = (item:ReadFileDto) => {
        return (
            <li className="border-gray-400 border-1 rounded-lg"  >
                <div className="grid grid-cols-10">
                    <div className="col-span-9">
                        <a href="javascript:void(0)" onClick={async ()=>{await selectFileClickHandlerAsync(item)}} className="flex  text-gray-800 pl-5 items-center p-1 rounded-base group">
                            <IconTypeFile height={10} width={10} type={".png"}></IconTypeFile>
                            <span className="flex-1 ms-3 cursor-pointer w-1/2 ">{item.fileName}</span>
                        </a>
                    </div>
                    <div className="col-span-1 flex justify-center items-center cursor-pointer" onClick={()=>{removeClickHandlerAsync(item)}}>
                        <IconClose height={23} width={23} color="red" ></IconClose>
                    </div>
                </div>
            </li>
        );
        
    }

    const UploadetFileItem = ()=>{
        return (
            <div>
                <div className="grid grid-cols-12 bg-gray-400 max-w-[175px] min-w-[175px] text-[12px] pl-3 rounded-md py-0.5 px-0.5">
                    <div title="sdfsdf" className="col-span-10 max-h-[18px] text-left line-clamp-1">ASDFA sdfs d -S sdfs dfs dsDF SDF.JPG</div>
                    <div className="col-span-2 text-center cursor-pointer">
                        <IconClose color="red" height={20} width={20}></IconClose>
                    </div>  
                </div>
            </div>
            
        )
    }

    const FolderItem = (item:ReadFolderDto) =>{
        return (
            <li onClick={async ()=>{await folderOpenClickPathHandlerAsync(item)}}>
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
                        <MultiLoadingComponent class="flex flex-wrap gap-2 max-w-[100%] max-h-[100px] overflow-y-auto" currentLoadingKey={loadingkey} componentKey={loadingKeys.FileMangerUploadContent} size="xl">
                                <UploadetFileItem></UploadetFileItem>
                                <UploadetFileItem></UploadetFileItem>
                                <UploadetFileItem></UploadetFileItem>
                                <UploadetFileItem></UploadetFileItem>
                                <UploadetFileItem></UploadetFileItem>
                                <UploadetFileItem></UploadetFileItem>
                                <UploadetFileItem></UploadetFileItem>
                                <UploadetFileItem></UploadetFileItem>
                                <UploadetFileItem></UploadetFileItem>
                                <UploadetFileItem></UploadetFileItem>
                                <UploadetFileItem></UploadetFileItem>
                                <UploadetFileItem></UploadetFileItem>
                                <UploadetFileItem></UploadetFileItem>
                                <UploadetFileItem></UploadetFileItem>
                                <UploadetFileItem></UploadetFileItem>
                                <UploadetFileItem></UploadetFileItem>
                            {selectedFiles.current.map((x,i)=>{
                                return <span key={i}>{x.name}</span>
                            })}
                        </MultiLoadingComponent>
                        <div className="grid grid-cols-2">
                            <div className="col-span-1 ">
                                Dizin : {getFullPath()}
                            </div>
                            <div className="col-span-1">
                                <div className="grid grid-cols-4 mt-0.5">
                                    <div className="col-span-1 text-sm">
                                        <div className="justify-center flex cursor-pointer" onClick={async ()=>{await folderBackClickHandlerAsync()}}>
                                            {
                                                currentPath.current.length > 1 && <><IconArrowLeft height={50} width={50}></IconArrowLeft> Geri Çık</>
                                            }
                                        </div>
                                    </div>
                                    <div className="col-span-2 justify-center flex">
                                        <div className="">
                                            <CSmButtonField id="add-file" onClick={async (e)=>{await uploadFileButtonClickHandlerAsync()}}>Yeni Dosya Ekle</CSmButtonField>
                                            <input ref={fileUploadInput} onChange={async (e)=>{await uploadFileInputonChangeHandlerAsync(e)}} multiple id="dropzone-file" type="file" className="hidden" />
                                        </div>
                                    </div>
                                    <div className="col-span-1 ">
                                        <div className="flex cursor-pointer justify-center text-sm" onClick={async ()=>{await getFolderAndFileAsync()}}>
                                            <IconRefresh height={50} width={50} color="black"></IconRefresh><span>Yenile</span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <MultiLoadingComponent class="!min-h-[300px] !max-h[300px] !h-[300px]" currentLoadingKey={loadingkey} componentKey={loadingKeys.FileManagerContent} size="xl">
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
                        </MultiLoadingComponent>
                        
                    </Flowbite.ModalBody>
                </Flowbite.Card>
            </Flowbite.Modal>
        </>
    );
}

