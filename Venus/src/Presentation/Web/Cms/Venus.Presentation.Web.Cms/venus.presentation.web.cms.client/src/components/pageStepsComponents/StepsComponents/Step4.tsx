import type { JSX } from "react";
import type { Step, StepContentProps } from "../NewPageStepsManagerComponent";
import { CButtonField } from "../../commons";

const StepContent = (props:StepContentProps):JSX.Element =>{
    
    return (
        <div className="container">
            <div className="flex justify-center">
                <div className="w-full max-w-xl my-5 p-6 bg-neutral-primary-soft border border-default rounded-base shadow-xs">
                    <div className="flex items-center justify-between mb-4">
                        <h5 className="text-xl font-semibold leading-none text-heading">Sayfayı Gözden Geçir</h5>
                    </div>
                    <div className="flow-root">
                        <ul role="list" className="divide-y divide-default">
                            <li className="py-4 sm:py-4">
                                <div className="flex items-center gap-2">
                                    <div className="shrink-0">
                                    </div>
                                    <div className="flex-1 min-w-0 ms-2">
                                        <p className="font-medium text-heading truncate">
                                            <a href={props.allStepPostData.url} target="_blank" rel="noopener noreferrer" >{props.allStepPostData.title}</a>
                                        </p>
                                    </div>
                                </div>
                            </li>
                           
                        </ul>
                    </div>
                </div>
            </div>
            <CButtonField id="form-submit" onClick={()=>{
                props.step.FormSutmitHandler(props.step)
            }}>Tamam </CButtonField>
        </div>
    )
}

export const Step4:Step = {
    Key:"step_4",
    StepContent:StepContent,
    Title:"Sayfa Kontrolü",
    FormFinsh:false,
    NextStep:()=>{},
    FormSutmitHandler:(step:Step)=>{
        step.FormFinsh = true;
        step.NextStep("");
        setTimeout(() => {
            step.NextStep("step_4");
        }, (10));
    }
}
