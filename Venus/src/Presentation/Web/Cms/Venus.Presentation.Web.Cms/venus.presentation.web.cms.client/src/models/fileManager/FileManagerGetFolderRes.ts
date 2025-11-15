import type { ReadFileDto } from "../../dtos/fileManager/ReadFileDto";
import { ReadFolderDto } from "../../dtos/fileManager/ReadFolderDto";

export class FileManagerGetFolderRes {
    /**
     *
     */
    constructor(files:Array<ReadFileDto>,folder:Array<ReadFolderDto>) {
        
    }
    files:Array<ReadFileDto>;
    folder:Array<ReadFolderDto>
}