
/**
 * 
 {state:"Show",title:string,content:JSX.Element,approvalHandler:()=>void,rejectionHandler:()=>void}
| {state:"Hidden",closeEvent:()=>void}
 */

export type  ConfirmModalReducerAction = 
  {action:"Show",approvalHandler:()=>Promise<void>}
| {action:"Hidden",lastHandler?:()=>Promise<void>}
| {action:"SetShow",title:string,body:React.ReactNode}

export type ConfirmModalReducerState = {
    show:boolean;
    lastHandler?:()=>Promise<void>;
    approvalHandler?:()=>Promise<void>;
    title:string;
    body:React.ReactNode
}

export function ConfirmModalReducer(state:ConfirmModalReducerState,action:ConfirmModalReducerAction):ConfirmModalReducerState {
    const modalState = action.action;
    const defaultTitle = "Dikkat !";
    const defaultBody = "Silmek istediğinize emin misiniz ?";
    if(modalState=="Show"){
        return ({show:true,title:defaultTitle,body:defaultBody,approvalHandler:action.approvalHandler});
    }else if(modalState=="SetShow"){
        return {show:true,body:action.body,title:action.title};
    }
    else if(modalState=="Hidden"){
        return {show:false,title:defaultTitle,body:defaultBody,lastHandler:action.lastHandler};
    }

    return {...state,title:defaultTitle,body:defaultBody};
}