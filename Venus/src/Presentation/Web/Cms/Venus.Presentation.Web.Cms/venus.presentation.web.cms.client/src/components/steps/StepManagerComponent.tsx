import { useState, type JSX } from "react";
import { Button } from "flowbite-react";



export interface StepContentProp<TData>{
    data:TData;
}

export interface Step<TData>{
    StepKey:string;
    Content:React.FC<StepContentProp<TData>>;
    StepTitle:()=>JSX.Element;
    NextHandler:(props:StepContentProp<TData>)=>Promise<void>;
}

export interface StepManagerComponentProps<TData>{
    steps:Step<TData>[],
    stepProp:StepContentProp<TData>,
}

export function StepManagerComponent<TData>(props:StepManagerComponentProps<TData>){

    const [step,setStep] = useState<Step<TData>>(props.steps[0]);

    const StepContent = step.Content;
    return (<>stepler
        
        <div className="flex gap-1">
            {props.steps.map((x,i)=>{
                return <div><Button onClick={()=>{setStep(x)}}>{x.StepTitle()}</Button></div>
            })}
        </div>

        <StepContent {...props.stepProp}></StepContent>
    </>);
}3