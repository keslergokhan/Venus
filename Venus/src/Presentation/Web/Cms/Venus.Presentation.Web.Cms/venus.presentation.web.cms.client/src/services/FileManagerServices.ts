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
}