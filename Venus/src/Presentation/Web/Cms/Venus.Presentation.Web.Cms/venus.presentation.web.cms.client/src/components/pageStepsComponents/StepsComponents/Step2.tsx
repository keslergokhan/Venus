import type { JSX } from "react";
import type { Step, StepProp } from "../NewPageStepsManagerComponent";
import { CButtonField, CTextField } from "../../commons";
import { UrlInputField } from "../../commons/textFields";
import { useUrlPathControl } from "../../../hooks";

const StepContent = (props:StepProp):JSX.Element =>{

    const urlControl = useUrlPathControl();
    return (
    <div className="container">
        <div className="mt-5">
            <form className="space-y-6" action="#">
            
                <UrlInputField useUrlPathControl={urlControl}></UrlInputField>
                <CTextField type="text" id="title" name="title" label="Başık" key="title" ></CTextField>
                <CTextField type="description" id="description" name="description" label="Sayfa Açıklaması" key="description" ></CTextField>
                
                <CButtonField id="form-submit" onClick={()=>{
                    props.step.FormSutmitHandler(props.step)
                }}>Tamam </CButtonField>

                <button type="submit" style={{display:"none"}} className=" w-full text-white bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm px-5 py-2.5 text-center dark:bg-blue-600 dark:hover:bg-blue-700 dark:focus:ring-blue-800">
                    Giriş
                </button>
            </form>
        </div>
    </div>)
}

export const Step2:Step = {
    Key:"step_2",
    StepContent:StepContent,
    Title:"Sayfa Bilgileri",
    FormFinsh:false,
    NextStep:()=>{},
    FormSutmitHandler:(step:Step)=>{
        step.FormFinsh = true;
        step.NextStep("step_3");
    }
}
