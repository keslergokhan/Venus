import axios from "axios";
import { ServiceBase } from "./base/ServiceBase";
import { ResultDataControl, type IResultDataControl } from "../results";
import type { FileManagerGetFolderRes } from "../models";

export class FileManagerService extends ServiceBase{

    public GetFoldersAsync = async (props:{path:string}):Promise<IResultDataControl<FileManagerGetFolderRes>> => {
        return axios.post<IResultDataControl<FileManagerGetFolderRes>>(this.GetFullPath("FileManager/GetFolders"),props,this.GetAxiosHeader())
        .then(x=>{
            return x.data as ResultDataControl<FileManagerGetFolderRes>;
        }).catch(()=>{
            return new ResultDataControl<FileManagerGetFolderRes>();
        });
    } 
}