import { useRef, useState, type JSX } from "react"
import { CButtonField, IconArrow, IconCheck } from "../commons";
import type { ReadPageAboutDto } from "../../dtos";

export interface AllStepPostData{
    pageAboutId:string|undefined
}

export interface StepData{
    pageAbouts:ReadPageAboutDto[]
}

export interface StepProp{
    /** Mevcut step verisi */
    step:Step;
    /** Tüm steps değerleri */
    steps?:Step[]|undefined;
    /** Steps yapıların ihtiyaç duyduğu ortak veriler */
    data:StepData
    allStepPostData:AllStepPostData
}

export interface Step {
    /** Step component */
    StepContent:React.ComponentType<StepProp>;
    /** Step başlığı */
    Title:string;
    /** Step benzersiz anahtar */
    Key:string;
    /** Step bitiş temsil eder. */
    FormFinsh:boolean;
    /** Başka stepler arası geçiş eventi */
    NextStep:(key:string)=>void;
    /** Step form submit */
    FormSutmitHandler:(step:Step)=>void;
}

export interface NewPageStepsManagerComponentProps{
    Steps:Step[],
    stepData:StepData
}

export const NewPageStepsComponent = (props:NewPageStepsManagerComponentProps) =>{

    const findStep = props.Steps.find(x=>x.Key=="step_1");
    const [currentStep,setCurrentStep] = useState<Step | undefined>(findStep);
    const allStepPostData = useRef<AllStepPostData>(
        {
            pageAboutId:undefined
        }
    );

    const tabOnClickHandler = (x:Step) =>{
        setCurrentStep(x)
    }

    const nextStep = (key:string)=>{
        setCurrentStep(props.Steps.find(x=>x.Key == key));
    }

    props.Steps.forEach(x=>{
        x.NextStep = nextStep;
    })

    const StepBarItem = ({ step, index }: { step: Step; index: number }) => {
        const activeClass = (currentStep?.Key == step.Key) 
        ? "bg-blue-700 "
        :"bg-gray-400 ";
        return <div className={`col-span-4 md:col-span-1 px-4 text-white h-14 flex justify-center items-center cursor-pointer font-medium ${activeClass}`} 
            key={index} 
            onClick={()=>{tabOnClickHandler(step)}}>
                <div className="w-full h-full grid grid-cols-2 justify-evenly items-center">
                    <div className="flex justify-end"><span className="">{step.Title}</span> </div>
                    <div className="flex justify-center items-center gap-5">
                        <IconArrow height={30} width={30}></IconArrow>
                        <span className="flex h-[40px] w-[40px] border-2 rounded-4xl justify-center items-center">
                            {step.FormFinsh ? <IconCheck height={30} width={30}></IconCheck> :(index+1)}
                        </span>
                    </div>
                </div>
        </div>
      }

    const StepContentFun = currentStep?.StepContent;
    return (
        <div className="w-full flex justify-center" id="newpage-Steps-component">
            <div className="container">
                <div className="grid grid-cols-4 rounded overflow-hidden">
                    {
                        props.Steps.map((x,i)=>{
                            return StepBarItem({step:x,index:i});
                        })
                    }
                </div>

                <div className="">
                    {StepContentFun && <StepContentFun key={3} {...{step:currentStep,steps:props.Steps,data:props.stepData,allStepPostData:allStepPostData.current}} ></StepContentFun>}
                </div>

                <div className="w-[100px] hidden">
                    <CButtonField id="form-submit" onClick={()=>{currentStep?.FormSutmitHandler(currentStep)}}>Tamam </CButtonField>
                </div>
            </div>
        </div>
    )
}