import type { JSX } from "react";
import type { Step, StepProp } from "../NewPageStepsManagerComponent";
import { CButtonField } from "../../commons";




const StepContent = (props:StepProp):JSX.Element =>{
    
    return (
    <div className="container">
        <div className="">
            2 component
            <CButtonField id="form-submit" onClick={()=>{
                props.step.FormSutmitHandler(props.step)
            }}>Tamam </CButtonField>
        </div>
    </div>)
}

export const Step2:Step = {
    Key:"step_2",
    StepContent:StepContent,
    Title:"Sayfa Tipi",
    FormFinsh:false,
    NextStep:()=>{},
    FormSutmitHandler:(step:Step)=>{
        step.FormFinsh = true;
        step.NextStep("step_3");
    }
}
