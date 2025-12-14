import type { JSX } from "react";
import * as Flowbite from "flowbite-react";
import { useContext, useEffect, useRef, useState } from "react";
import { IconOpenFolder2, IconArrow, IconArrowLeft, IconClose, IconRefresh, IconSpinner } from "../commons/icons"
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

interface FileItem{
    file:File;
    state:"uploadStart"|"pending"|"loaded";
}

export const FileManagerComponent = (): JSX.Element => {
    const fileManagerService = new FileManagerService;
    const appContext = useContext(AppContext);
    const [loading,setLoading] = useState<boolean>(false);

    /** Dosya yöneticisi mevcut dizin */
    const currentPath = useRef<string[]>([""]);
    /** Mevcut dizinde bulunan dosya ve klasörler */
    const folderAndFileData = useRef<FileManagerGetFolderRes>(new FileManagerGetFolderRes([],[]));
    

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
        setLoading(true);
        await fileManagerService.getFoldersAsync({path:getFullPath()}).then(x=>{
            if(x.isSuccess){
                folderAndFileData.current = new FileManagerGetFolderRes(x.data.files as Array<ReadFileDto>,x.data.folders as Array<ReadFolderDto>);
            }else{
                throw new Error("Dizin çekiler beklenmedik bir problem yaşandı !");
            }
        }).catch(x=>{
            ToastHelper.DefaultCatchError(x);
        }).finally(()=>{
            setLoading(false);
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
     * FileManager Dosyayı seç.
     * @param data 
     */
    const selectFileClickHandlerAsync = async (data:ReadFileDto) =>{
        currentClearPath();
        appContext.fileManagerState.selectFileEvent(data);
        appContext.fileManagerAction({type:"FileManagerModal",state:false});
    }

    /** Dosya yöneticisi dosya sil */
    const removeClickHandlerAsync = async (data:ReadFileDto) =>{

        await fileManagerService.removeFileAsync({path:data.filePath}).then(x=>{
            if(x.isSuccess){
                ToastHelper.Success(`${data.fileName} silindi !`);
               
            }else{
                throw new Error("Dosya silme işleminde beklenmedik bir problem yaşandı !");
            }
        }).catch(x=>{
            ToastHelper.DefaultCatchError(x);
        })
        await getFolderAndFileAsync();
    }

    
    //#region JSX Items ------

    /**
     * FileManager klasör tasarımı
     * @param item 
     * @returns 
     */
    const FolderItemJsx = (item:ReadFolderDto) =>{
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

    /**
     * FileManager dosya tasarımı
     * @param item 
     * @returns 
     */
    const FileItemJsx = (item:ReadFileDto) => {
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

    //#endregion JSX Items END
    return (
        <>
            <Flowbite.Modal show={appContext.fileManagerState.fileManagerModal} position={"center"} onClose={() => appContext.fileManagerAction({type:"FileManagerModal",state:false})} >
                <Flowbite.Card className="!bg-amber-50 ">
                    <Flowbite.ModalHeader className="p-1">
                        <span className="text-black">Dosya Yöneticisi</span>
                    </Flowbite.ModalHeader>
                    <Flowbite.ModalBody className="!p-1 !min-h-[200px] !max-h[300px] !h-[300px] relative !p-0 overflow-x-visible" >
                        <FileManagerUploadComponent getFolderAndFileAsync={getFolderAndFileAsync} fileManagerService={fileManagerService} getFullPath={getFullPath}></FileManagerUploadComponent>
                        <div className="grid grid-cols-2">
                            <div className="col-span-1">
                                Dizin : {getFullPath()}
                            </div>
                            <div className="col-span-1">
                                <div className="grid grid-cols-2 mt-0.5">
                                    <div className="col-span-1 text-sm">
                                        <div className="justify-end flex cursor-pointer" onClick={async ()=>{await folderBackClickHandlerAsync()}}>
                                            {
                                                currentPath.current.length > 1 && <><IconArrowLeft height={50} width={50}></IconArrowLeft> Geri Çık</>
                                            }
                                        </div>
                                    </div>
                                    <div className="col-span-1">
                                        <div className="flex cursor-pointer justify-end text-sm" onClick={async ()=>{await getFolderAndFileAsync()}}>
                                            <IconRefresh height={50} width={50} color="black"></IconRefresh><span>Yenile</span>
                                        </div>
                                    </div>
                                </div>  
                            </div>
                        </div>
                        <LoadingComponent class="!min-h-[300px] !max-h[300px] !h-[300px]" loading={loading} size="xl">
                            <ul className="my-2 space-y-1">
                                {
                                    folderAndFileData.current.folders?.map((x,i) =>{
                                        return <FolderItemJsx key={i} {...x}></FolderItemJsx>
                                    })
                                }
                                {
                                    folderAndFileData.current.files?.map((x,i) =>{
                                        return <FileItemJsx key={i} {...x}></FileItemJsx>
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

interface FileManagerUploadComponentProps{
    fileManagerService:FileManagerService;
    getFullPath:()=>string;
    getFolderAndFileAsync:()=>Promise<void>
}

const FileManagerUploadComponent = (props:FileManagerUploadComponentProps):JSX.Element =>{
    const fileManagerService = props.fileManagerService;
    /** Yüklenmek için seçilen dosya lisesi */
    const selectedFiles = useRef<Array<FileItem>>([]);
    const [uploadedFiles,setUploadedFiles] = useState<Array<FileItem>>([]);
    const [loading,setLoading] = useState<boolean>(false);
    /** Dosya yükleme inputu */
    const fileUploadInput = useRef<HTMLInputElement>(null);

    /** Yüklenecek dosyayı silin. */
    const UploadtedFileClearClickHandler = async (item:FileItem) =>{
        setLoading(true);
        const findFile = selectedFiles.current.find(x=>x.file.name == item.file.name);
        ToastHelper.Success(<>{findFile?.file.name} silindi.</>);
        selectedFiles.current = selectedFiles.current.filter(x=>x.file.name != item.file.name);
        setTimeout(() => {
            setLoading(false);
        }, (10));
    }

    useEffect(()=>{
        console.log(uploadedFiles);
        uploadedFiles.forEach(async (item) => {
            await fileManagerService.uploadFileAsync({file:item.file,path:props.getFullPath()})
            .then(x=>{
                if(x.isSuccess){
                    setUploadedFiles([...uploadedFiles.filter(x=>x.file.name != item.file.name)]);
                    ToastHelper.Success(`${item.file.name} başarıyla yüklendi`);
                }else{
                    throw new Error("Dosya yüklenirken beklenmedik bir problem yaşandı !");
                }
            }).catch(x=>{
                ToastHelper.DefaultCatchError(x);
            });
        });
        setTimeout(() => {
            props.getFolderAndFileAsync();
        }, (100));
    },[uploadedFiles])
   
    /** Yükleme işlemini başlat */
    const uploadStartClickHandlerAsync = async () =>{
        
        const newList = new Array<FileItem>();
        selectedFiles.current.forEach(item => {
            selectedFiles.current = selectedFiles.current.filter(x=>x.file.name !=item.file.name);
            newList.push({file:item.file,state:"uploadStart"} as FileItem);
        });
        
        setUploadedFiles([...uploadedFiles,...newList]);
    }


    /**
     * Yüklenecek dosyalar seçildiğinde
     * @param e 
     */
    const uploadFileInputonChangeHandlerAsync = async (e:React.ChangeEvent<HTMLInputElement>) =>{
        setLoading(true);
        const inputSelectedFileList = e.target.files as FileList;
        console.log(inputSelectedFileList);
        if(inputSelectedFileList.length >= 0){
            Array.from(inputSelectedFileList).forEach(file=>{
                selectedFiles.current.push({file:file,state:"pending"});
            });
        }
        setTimeout(() => {
            setLoading(false);
        }, (0));
    }


    /**
     * Dosya yükleme inputunu aktif etme
     */
    const uploadFileButtonClickHandlerAsync = async () =>{
        fileUploadInput.current?.click();
    }
    

    /**
     * Yüklenecek dosyalar tasarımı
     * @param param0 
     * @returns 
     */
    const UploadetFileItemJsx = ({item}:{item:FileItem})=>{
        return (
            <div>
                <div className="grid grid-cols-12 bg-gray-400 max-w-[175px] min-w-[175px] text-[12px] pl-3 rounded-md py-0.5 px-0.5">
                    <div title={item.file.name} className="col-span-10 max-h-[18px] text-left line-clamp-1">{item.file.name}</div>
                    <div className="col-span-2 text-center cursor-pointer" onClick={()=>{item.state=="pending" && UploadtedFileClearClickHandler(item)}}>
                        {
                            item.state == "uploadStart" ?
                            <IconSpinner></IconSpinner>:<IconClose color="red" height={20} width={20}></IconClose>
                        }
                    </div>  
                </div>
            </div>
            
        )
    }

    return <>
            <LoadingComponent loading={loading} class="max-w-[100%] !w-[100%] h-[110px] max-h-[150px] overflow-y-auto"  size="xl">
                <div className="grid gap-1">
                    <div className="grid gap-1">
                        <div className="flex flex-wrap gap-2">
                            {uploadedFiles.map((x,i)=>{
                                return <UploadetFileItemJsx key={i} item={x} ></UploadetFileItemJsx>
                            })}
                        </div>

                        <div className="flex flex-wrap gap-2">
                            {selectedFiles.current.map((x,i)=>{
                                return <UploadetFileItemJsx key={i} item={x} ></UploadetFileItemJsx>
                            })}
                        </div>
                    </div>
                    <div className="grid grid-cols-2 gap-1">
                        <CSmButtonField variant="warning" className={`${(selectedFiles.current.length ==0 ) ?"hidden":""}`} id="upload-file" onClick={async (e)=>{await uploadStartClickHandlerAsync()}}>Seçilen Dosyaları Yükle</CSmButtonField>
                        <CSmButtonField className={`${(selectedFiles.current.length ==0?"col-span-2":"col-span-1")}`} id="add-file" onClick={async (e)=>{await uploadFileButtonClickHandlerAsync()}}>Yeni Dosya Ekle</CSmButtonField>
                    </div>
                </div>
            </LoadingComponent>
            <input ref={fileUploadInput} onChange={async (e)=>{await uploadFileInputonChangeHandlerAsync(e)}} multiple id="dropzone-file" type="file" className="hidden" />
        </>
}