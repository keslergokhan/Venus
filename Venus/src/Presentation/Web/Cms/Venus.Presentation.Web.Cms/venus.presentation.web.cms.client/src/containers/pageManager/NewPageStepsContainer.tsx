
import { useState } from "react";
import { LoadingComponent } from "../../components";
import { NewPageStepsComponent } from "../../components/pageStepsComponents/NewPageStepsManagerComponent";
import { useNewPageStepsManager } from "../../hooks/useNewPageStepsManager";


export const NewPageStepsContainer = () =>{

   
    const {Steps,loading} = useNewPageStepsManager();
    

    return (
        <LoadingComponent loading={loading}>
            <NewPageStepsComponent Steps={Steps} ></NewPageStepsComponent>
        </LoadingComponent>
    )
}