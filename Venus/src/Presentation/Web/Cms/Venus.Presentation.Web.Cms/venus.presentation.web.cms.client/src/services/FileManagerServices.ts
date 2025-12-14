import axios from "axios";
import { ServiceBase } from "./base/ServiceBase";
import { ResultControl, ResultDataControl, type IResultControl, type IResultDataControl } from "../results";
import type { FileManagerGetFolderRes } from "../models";

export class FileManagerService extends ServiceBase{

    public getFoldersAsync = async (props:{path:string}):Promise<IResultDataControl<FileManagerGetFolderRes>> => {
        return axios.post<IResultDataControl<FileManagerGetFolderRes>>(this.GetFullPath("FileManager/GetFolders"),props,this.GetAxiosHeader())
        .then(x=>{
            return x.data as ResultDataControl<FileManagerGetFolderRes>;
        }).catch(()=>{
            return new ResultDataControl<FileManagerGetFolderRes>();
        });
    }

    public removeFileAsync = async (props:{path:string}):Promise<ResultControl> =>{
        return axios.post<IResultControl>(this.GetFullPath("FileManager/RemoveFilter"),props,this.GetAxiosHeader()).then(x=>{
            return x.data as ResultControl;
        }).catch(()=>{
            return new ResultControl();
        });
    }

    public uploadFileAsync = async (props:{path:string,file:File})=>{

        const conf = {
            headers: {
                'Authorization': `Bearer ${this.GetUserJwtToken()}`,
            },
            withCredentials: true
        };

        var formData = new FormData();
        formData.append("Path",props.path);
        formData.append("File",props.file);
        
        return axios.post<IResultControl>(this.GetFullPath("FileManager/UploadFile"),formData,conf).then(x=>{
            return x.data as ResultControl;
        }).catch(()=>{
            return new ResultControl();
        })
    }
}