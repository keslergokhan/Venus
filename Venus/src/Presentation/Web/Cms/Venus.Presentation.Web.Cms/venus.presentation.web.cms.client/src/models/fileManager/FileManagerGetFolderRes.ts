import type { ReadFileDto } from "../../dtos/fileManager/ReadFileDto";
import { ReadFolderDto } from "../../dtos/fileManager/ReadFolderDto";

export class FileManagerGetFolderRes {
    /**
     *
     */
    constructor(files:Array<ReadFileDto>,folders:Array<ReadFolderDto>) {
        this.files = files;
        this.folders = folders;
    }
    files:Array<ReadFileDto>;
    folders:Array<ReadFolderDto>
}   