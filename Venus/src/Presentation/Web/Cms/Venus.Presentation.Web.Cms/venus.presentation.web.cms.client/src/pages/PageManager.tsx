import { NewPageStepsComponent, type Step } from "../components/pageStepsComponents/NewPageStepsManagerComponent";
import { Step1, Step2, Step3, Step4 } from "../components/pageStepsComponents/StepsComponents";

const PageManagerPage = () =>{

    const Steps:Step[] = [
        Step1,
        Step2,
        Step3,
        Step4,
    ]
    
    return (
        <>
            <NewPageStepsComponent {...{Steps}}></NewPageStepsComponent>
        </>
    )
}

export default PageManagerPage;