
export class ReadFolderDto{
    id:string;
    name:string;
    createDate:Date;
    files:Array<ReadFolderDto>;
}