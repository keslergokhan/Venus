import axios from "axios";
import { ServiceBase } from "./base/ServiceBase";
import { ResultControl, ResultDataControl, type IResultControl, type IResultDataControl } from "../results";
import type { FileManagerGetFolderRes } from "../models";

export class FileManagerService extends ServiceBase{

    public getFoldersAsync = (props:{path:string}):Promise<FileManagerGetFolderRes> => {
        return axios.post<FileManagerGetFolderRes>(this.GetFullPath("FileManager/GetFolders"),props,this.GetAxiosHeader())
        .then(x=>{
            return x.data as FileManagerGetFolderRes;
        })
    }

    public removeFileAsync = (props:{path:string}):Promise<void> =>{
        return axios.post(this.GetFullPath("FileManager/RemoveFilter"),props,this.GetAxiosHeader())
    }

    public uploadFileAsync = (props:{path:string,file:File})=>{

        const conf = {
            headers: {
                'Authorization': `Bearer ${this.GetUserJwtToken()}`,
            },
            withCredentials: true
        };

        var formData = new FormData();
        formData.append("Path",props.path);
        formData.append("File",props.file);
        
        return axios.post(this.GetFullPath("FileManager/UploadFile"),formData,conf)
    }
}