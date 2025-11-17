
export type FileManagerReducerAction = 
| {type:"FileManagerModal",state:boolean}
| {type:"FileManagerModalAndSelectEvent",state:boolean,selectFileEvent:(fileName:string)=>void|null}
| {type:"FileManagerSetSelectEvent",selectFileEvent:(fileName:string)=>void}

export type FileManagerReducerState = {
    fileManagerModal:boolean;
    selectFileEvent:(fileName:string)=>void;
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