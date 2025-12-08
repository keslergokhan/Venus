import type { ReadFileDto } from "../dtos/fileManager/ReadFileDto";

export type FileManagerReducerAction = 
| {type:"FileManagerModal",state:boolean}
| {type:"FileManagerModalAndSelectEvent",state:boolean,selectFileEvent:(fileItem:ReadFileDto)=>void|null}
| {type:"FileManagerSetSelectEvent",selectFileEvent:(fileItem:ReadFileDto)=>void}

export type FileManagerReducerState = {
    fileManagerModal:boolean;
    selectFileEvent:(fileItem:ReadFileDto)=>void;
}

export const FileManagerReducer = (state:FileManagerReducerState,action:FileManagerReducerAction):FileManagerReducerState => {

    const actionType = action.type;

    if(actionType == "FileManagerModal"){
        return {...state,fileManagerModal:action.state};
    }else if(actionType == "FileManagerModalAndSelectEvent"){
        return {...state,fileManagerModal:action.state,selectFileEvent:action.selectFileEvent}
    }
    else if(actionType == "FileManagerSetSelectEvent"){
        return {...state,selectFileEvent:action.selectFileEvent}
    }

    return {...state}
}