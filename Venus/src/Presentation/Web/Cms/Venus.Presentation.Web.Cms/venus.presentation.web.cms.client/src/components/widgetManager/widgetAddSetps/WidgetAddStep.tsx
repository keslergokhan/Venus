import type { useWidgetManagerContainer } from "../../../hooks"
import type { Step } from "../../steps/StepManagerComponent"


function addStepContet(){
    return (<>Yeni veri ekleme ekranı</>)
}


export const addWidgetStep:Step<ReturnType<typeof useWidgetManagerContainer>>={
    Content:addStepContet,
    StepTitle() {
        return <>Bu bir başlık</>
    },
    NextHandler:async ()=>{
        console.log("Merhaba dünya");
    },
    StepKey:"add"
}