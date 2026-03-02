import type { JSX } from "react";
import type { Step, StepContentProps } from "../NewPageStepsManagerComponent";
import { CButtonField } from "../../commons";
import { PageService } from "../../../services";
import { CreatePageRequest } from "../../../models";
import { ToastHelper } from "../../../helpers";


const StepContent = (props:StepContentProps):JSX.Element =>{
    
    const pageService = new PageService();
    const onSubmitHandler = () =>{
        const request = new CreatePageRequest();
        request.Title = props.allStepPostData.title ?? "";
        request.Description = props.allStepPostData.description ?? "";
        request.UrlPath = props.allStepPostData.url ?? "";
        request.PageAboutId = props.allStepPostData.pageAboutId ?? "";

        pageService.createPageAsync(request).then(x=>{
            ToastHelper.Success(<>Sayfa oluşturuldu !</>);
            setTimeout(() => {
                props.step.FormSutmitHandler(props.step);
            }, 500);
        }).catch(x=>{
            ToastHelper.DefaultCatchError(x);
        });
        
    }
    return (
    <div className="container">
        <div className="flex justify-center">
            <div className="w-full max-w-xl my-5 p-6 bg-neutral-primary-soft border border-default rounded-base shadow-xs">
                <div className="flex items-center justify-between mb-4">
                    <h5 className="text-xl font-semibold leading-none text-heading">Sayfa Bilgileri</h5>
                </div>
                <div className="flow-root">
                    <ul role="list" className="divide-y divide-default">
                        <li className="py-4 sm:py-4">
                            <div className="flex items-center gap-2">
                                <div className="shrink-0">
                                </div>
                                <div className="flex-1 min-w-0 ms-2">
                                    <p className="font-medium text-heading truncate">
                                        Sayfanın Kategorisi
                                    </p>
                                    <p className="text-sm text-body truncate">
                                        {props.data.pageAbouts.find(x=>x.id == props.allStepPostData.pageAboutId)?.name}
                                    </p>
                                </div>
                            </div>
                        </li>
                        <li className="py-4 sm:py-4">
                            <div className="flex items-center gap-2">
                                <div className="shrink-0">
                                </div>
                                <div className="flex-1 min-w-0 ms-2">
                                    <p className="font-medium text-heading truncate">
                                        Sayfanın Adresi
                                    </p>
                                    <p className="text-sm text-body truncate">
                                        {props.allStepPostData.url}
                                    </p>
                                </div>
                            </div>
                        </li>
                        <li className="py-4 sm:py-4">
                            <div className="flex items-center gap-2">
                                <div className="shrink-0">
                                </div>
                                <div className="flex-1 min-w-0 ms-2">
                                    <p className="font-medium text-heading truncate">
                                        Sayfa Başlığı
                                    </p>
                                    <p className="text-sm text-body truncate">
                                        {props.allStepPostData.title}
                                    </p>
                                </div>
                            </div>
                        </li>
                        <li className="py-4 sm:py-4">
                            <div className="flex items-center gap-2">
                                <div className="shrink-0">
                                </div>
                                <div className="flex-1 min-w-0 ms-2">
                                    <p className="font-medium text-heading truncate">
                                        Sayfa Açıklaması
                                    </p>
                                    <p className="text-sm text-body truncate">
                                        {props.allStepPostData.description}
                                    </p>
                                </div>
                            </div>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
        <CButtonField disabled={props.step.FormFinsh || !props.steps?.find(x=>x.Key == "step_2")?.FormFinsh} id="form-submit" onClick={onSubmitHandler}>Tamam </CButtonField>
    </div>
    )
}

export const Step3:Step = {
    Key:"step_3",
    StepContent:StepContent,
    Title:"Sayfayı oluştur",
    FormFinsh:false,
    NextStep:()=>{},
    FormSutmitHandler:(step:Step)=>{
        step.FormFinsh = true;
        step.NextStep("step_4");
    }
}
