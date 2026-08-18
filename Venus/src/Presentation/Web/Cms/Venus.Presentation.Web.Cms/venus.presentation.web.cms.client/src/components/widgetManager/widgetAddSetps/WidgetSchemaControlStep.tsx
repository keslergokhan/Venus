import type { useWidgetManagerContainer } from "../../../hooks"
import type { Step } from "../../steps/StepManagerComponent"


function addStepContet(){
    return (<>Yeni veri ekleme ekranı 2</>)
}


export const schemaWidgetStep:Step<ReturnType<typeof useWidgetManagerContainer>>={
    Content:addStepContet,
    StepTitle() {
        return <>Bu bir başlık</> 
    },
    NextHandler:async ()=>{
        console.log("Merhaba dünya 2");
    },
    StepKey:"schema"
}