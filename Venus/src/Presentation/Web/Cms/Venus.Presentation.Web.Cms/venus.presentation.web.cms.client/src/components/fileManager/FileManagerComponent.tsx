import type { JSX } from "react";
import * as Flowbite from "flowbite-react";
import { useEffect, useState } from "react";
import { CTextField, } from "../commons";
import { IconOpenFolder2, IconFile2, IconArrow } from "../commons/icons"
import { IconTypeFile } from "../commons/icons/IconFile";
import { FileManagerService } from "../../services";
import type { ReadFileDto } from "../../dtos/fileManager/ReadFileDto";
import type { ReadFolderDto } from "../../dtos/fileManager/ReadFolderDto";
import { FileManagerGetFolderRes } from "../../models";
import { ToastHelper } from "../../helpers";
import { LoadingComponent } from "../loading/LoadingComponent";
import { IconRefresh } from "../commons/icons/IconRefresh";

export interface FileManagerComponentProps {
    selectFilenName:string
}

export const FileManagerComponent = (): JSX.Element => {
    const [openModal, setOpenModal] = useState<boolean>(false);
    const [fileName,setFileName] = useState<string>("Dosya Seç");
    const fileManagerService = new FileManagerService;
    const [loading,setLoading] = useState<boolean>(false);

    const getFolderAndFileAsync = async ():Promise<FileManagerGetFolderRes>=>{
        setLoading(true);
        return await fileManagerService.GetFoldersAsync({path:"/"}).then(x=>{
            if(x.isSuccess){
                return new FileManagerGetFolderRes(x.data.files,x.data.folder);
            }else{
                ToastHelper.DefaultError();
            }
            return new FileManagerGetFolderRes([],[]);
        }).finally(()=>{
            setLoading(false);
        });
    }
    useEffect(()=>{
        
    },[]);

    const FileItem = (item:ReadFileDto) => {
        return (
            <li>
                <a href="#" className="flex border-gray-400 border-1 rounded-lg text-gray-800 pl-5 items-center p-1 rounded-base group">
                    <IconOpenFolder2 height={10} width={10}></IconOpenFolder2>
                    <span className="flex-1 ms-3">/MetaMask</span>
                    <IconArrow height={10} width={10}></IconArrow>
                </a>
            </li>
        )
    }

    const FolderItem = (item:ReadFolderDto) =>{
        return (
            <li>
                <a href="#" className="flex border-gray-400 border-1 rounded-lg text-gray-800 pl-5 items-center p-1 rounded-base group">
                    <IconTypeFile height={10} width={10} type={".png"}></IconTypeFile>
                    <span className="flex-1 ms-3 ">MetaMask</span>
                </a>
            </li>
        );
    }

    return (
        <>
            <div className="w-[300px]">
                <CTextField value={fileName} onClick={() => { setOpenModal(true) }} placeholder={fileName} Icon={<IconOpenFolder2 height={24} width={24} color="#104e64"></IconOpenFolder2>}
                type="email" id="email" name="email" label="Kullan�c� Ad�" key="email"   ></CTextField>
            </div>
            
            <Flowbite.Modal show={openModal} position={"center"} onClose={() => setOpenModal(false)} >
                <Flowbite.Card className="!bg-amber-50 ">
                    <Flowbite.ModalHeader className="p-1">
                        <span className="text-black">Dosya Yöneticisi</span>
                    </Flowbite.ModalHeader>
                    <Flowbite.ModalBody className="!p-1 !min-h-[300px] !max-h[300px] !h-[300px] relative " >
                        <div onClick={async ()=>{await getFolderAndFileAsync()}}><IconRefresh height={50} width={50} color="black"></IconRefresh></div>
                        <LoadingComponent loading={loading} size="xl">
                            <ul className="my-6 space-y-1">
                                <li>
                                    <a href="#" className="flex border-gray-400 border-1 rounded-lg text-gray-800 pl-5 items-center p-1 rounded-base group">
                                        <IconOpenFolder2 height={10} width={10}></IconOpenFolder2>
                                        <span className="flex-1 ms-3">/MetaMask</span>
                                        <IconArrow height={10} width={10}></IconArrow>
                                    </a>
                                </li>
                                <li>
                                    <a href="#" className="flex border-gray-400 border-1 rounded-lg text-gray-800 pl-5 items-center p-1 rounded-base group">
                                        <IconOpenFolder2 height={10} width={10}></IconOpenFolder2>
                                        <span className="flex-1 ms-3 ">/MetaMask</span>
                                    </a>
                                </li>

                                <li>
                                    <a href="#" className="flex border-gray-400 border-1 rounded-lg text-gray-800 pl-5 items-center p-1 rounded-base group">
                                        <IconTypeFile height={10} width={10} type={".png"}></IconTypeFile>
                                        <span className="flex-1 ms-3 ">MetaMask</span>
                                    </a>
                                </li>
                            </ul>
                        </LoadingComponent>
                    </Flowbite.ModalBody>
                </Flowbite.Card>
            </Flowbite.Modal>
        </>
    );
}