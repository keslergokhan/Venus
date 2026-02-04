import { type JSX } from "react";
import type { Step, StepProp } from "../NewPageStepsManagerComponent";
import { CButtonField } from "../../commons";


const StepContent = (props:StepProp):JSX.Element =>{
    return (
    <div className="container">
        <div className="">
            {props.data.pageAbouts.map((x,i)=>{
                return <p key={i}>{x.name}</p>
            })}
            <CButtonField id="form-submit" onClick={()=>{
                props.step.FormSutmitHandler(props.step)
            }}>Tamam </CButtonField>
        </div>
    </div>)
}

export const Step1:Step = {
    Key:"step_1",
    StepContent:StepContent,
    Title:"Sayfa Tipi",
    FormFinsh:false,
    NextStep:()=>{},
    FormSutmitHandler:(step:Step)=>{
        step.FormFinsh = true;
        step.NextStep("step_2");
    }
}
