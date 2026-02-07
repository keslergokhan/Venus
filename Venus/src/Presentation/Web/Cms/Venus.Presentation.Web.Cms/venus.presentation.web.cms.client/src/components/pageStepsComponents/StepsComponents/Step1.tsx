import { useState, type JSX } from "react";
import type { Step, StepProp } from "../NewPageStepsManagerComponent";
import { CButtonField, IconCheck } from "../../commons";
import { ReadPageAboutDto } from "../../../dtos";
import { ToastHelper } from "../../../helpers";



const StepContent = (props:StepProp):JSX.Element =>{
    const allStepPostData = props.allStepPostData;
    const [selectedPageAbout,setSelectedPageAbout] = useState<ReadPageAboutDto>();

    if(allStepPostData.pageAboutId && selectedPageAbout == null){
        setSelectedPageAbout(props.data.pageAbouts.find(x=>x.id == props.allStepPostData.pageAboutId));
    }
    const stepNextSubmitEvent = () =>{
        if(allStepPostData.pageAboutId == undefined){
            ToastHelper.Warning(<>Lütfen bir sayfa tipi seçiniz</>);
        }else{
            props.step.FormSutmitHandler(props.step);
        }
    }
    const PageAboutCheckCard = ({item}:{item:ReadPageAboutDto}):JSX.Element =>{
        const isSelected = item.id == allStepPostData?.pageAboutId ? true:false;
        return (
            <div className="border-1 p-5 rounded cursor-pointer flex-auto min-w-[200px] " 
                onClick={()=>{
                    allStepPostData.pageAboutId = item.id;
                    setSelectedPageAbout(item);
                }}>
                <div className="flex justify-between min-h-[30px]">
                    <span className={`font-bold ${isSelected && "text-green-700"}`}>{item.name}</span>
                    {isSelected && <IconCheck width={28} height={28} color="green"></IconCheck>}
                </div>
                <div className="mt-1">
                    {item.description}
                </div>
            </div>
        )
    }

    return (
    <div className="container">
        <div className="">
            <div className="flex flex-wrap my-5 gap-5 flex-col md:flex-row">
                {props.data.pageAbouts.map((x,i)=>{
                    return <PageAboutCheckCard item={x} key={i} ></PageAboutCheckCard>
                })}
                
            </div>
            
            <CButtonField id="form-submit" disabled={props.step.FormFinsh} onClick={()=>{
                stepNextSubmitEvent();
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
