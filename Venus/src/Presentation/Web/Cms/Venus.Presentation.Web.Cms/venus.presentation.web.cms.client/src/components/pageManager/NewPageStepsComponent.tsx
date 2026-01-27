import { useEffect, useState, type JSX } from "react"
import { CButtonField, IconArrow, IconCheck } from "../commons";
import { bool } from "yup";
import { LoadingComponent } from "../loading/LoadingComponent";
import { PageAboutCheckListComponent } from "./PageAboutCheckListComponent";

export interface NewPageStepsComponentProps {

}


interface Step {
    StepContent:React.ComponentType<{step:Step,steps?:Step[]|undefined}>;
    Title:string;
    Key:string;
    FormFinsh:boolean;
    NextStep:(key:string)=>void;
    FormSutmitHandler:(step:Step)=>void;
}

const Step1 = ({step,steps}:{step:Step,steps?:Step[]|undefined}):JSX.Element =>{
    
    return (
    <div className="container">
        <div className="">
         
            <CButtonField id="form-submit" onClick={()=>{
                step.FormSutmitHandler(step);
            }}>Tamam </CButtonField>
        </div>
    </div>)
}

const Step2 = ({step,steps}:{step:Step,steps?:Step[]|undefined}):JSX.Element =>{
    useEffect(()=>{
        alert("fsdf");
    },[]);
    return (
    <>ikinci adım
        <CButtonField id="form-submit" onClick={()=>{
                step.FormSutmitHandler(step);
            }}>Tamam </CButtonField>
    </>)
}

const Step3 = ({step,steps}:{step:Step,steps?:Step[]|undefined}):JSX.Element =>{
    return (
    <>üçüncü adım
        <CButtonField id="form-submit" onClick={()=>{
                step.FormSutmitHandler(step);
            }}>Tamam </CButtonField>
    </>)
}

const Steps:Step[] = [
    {
        Key:"page_category",
        StepContent:Step1,
        Title:"Sayfa Tipi",
        FormFinsh:false,
        NextStep:()=>{},
        FormSutmitHandler:(step:Step)=>{
            step.FormFinsh = true;
            step.NextStep("page_about");
        }
    },
    {
        Key:"page_about",
        StepContent:Step2,
        Title:"Sayfa Bilgileri",
        FormFinsh:false,
        NextStep:()=>{},
        FormSutmitHandler:(step:Step)=>{
            step.FormFinsh = true;
            step.NextStep("page_control");
        }
    },
    {
        Key:"page_control",
        StepContent:Step3,
        Title:"Bilgileri Doğrula",
        FormFinsh:false,
        NextStep:()=>{},
        FormSutmitHandler:(step:Step)=>{
            step.FormFinsh = true;
            step.NextStep("page_save");
        }
    },
    {
        Key:"page_save",
        StepContent:Step3,
        Title:"Kaydet",
        FormFinsh:false,
        NextStep:()=>{},
        FormSutmitHandler:(step:Step)=>{
            step.FormFinsh = true;
            step.NextStep("");
            setTimeout(() => {
                step.NextStep("page_save");
            }, (10));
        }
    }
]

export const NewPageStepsComponent = (props:NewPageStepsComponentProps) =>{

    const findStep = Steps.find(x=>x.Key=="page_category");
    const [currentStep,setCurrentStep] = useState<Step | undefined>(findStep);

    const tabOnClickHandler = (x:Step) =>{
        setCurrentStep(x)
    }

    const nextStep = (key:string)=>{
        setCurrentStep(Steps.find(x=>x.Key == key));
    }

    Steps.forEach(x=>{
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
                        Steps.map((x,i)=>{
                            return StepBarItem({step:x,index:i});
                        })
                    }
                </div>
            

                <div className="">
                    {StepContentFun && <StepContentFun key={3} step={currentStep} steps={Steps}></StepContentFun>}
                </div>

                <div className="w-[100px] hidden">
                    <CButtonField id="form-submit" onClick={()=>{currentStep?.FormSutmitHandler(currentStep)}}>Tamam </CButtonField>
                </div>
            </div>
        </div>
    )
}


