import type { ReadFileDto, ReadFolderDto } from "../../dtos";

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