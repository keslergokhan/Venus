import React, { useState } from "react";
import { CButtonField, HtmlEditorField } from "../commons";
import { TemplateVariableSchema, WriteWidgetDto } from "../../dtos";
import {z} from "zod"
import { WidgetService } from "../../services";
import { ToastHelper } from "../../helpers";
import { StepManagerComponent } from "../steps/StepManagerComponent";

export interface WidgetAddComponentProps{
    addHandler:(data:WriteWidgetDto)=>Promise<void>
}

export function WidgetAddComponent(props:WidgetAddComponentProps){
    const widgetService = new WidgetService();
    const [html,setHtml] = useState<string>("");
    const [variableSchema,setVariableSchema] = useState<TemplateVariableSchema[]>([]);
    

    const schema = z.object({
        id:z.string(),
        key:z.string(),
        template:z.string(),
        state:z.number(),
        TemplateDataSchema:z.string(),
        WidgetType:z.number()
    });

    const defaultValue:WriteWidgetDto = {
        id:"",
        key:"",
        state:1,
        template:"",
        TemplateDataSchema:"",
        WidgetType:1
    }


    async function submitHandler(e:React.FormEvent<HTMLFormElement>){
        e.preventDefault();

        try {
            const result = await widgetService.createTemplateSchema(html);
            setVariableSchema(result.templateDataSchemaList);
            
        } catch (error) {
            ToastHelper.DefaultCatchError(error);
        }
        console.log(html);
    }


    return (
        <form onSubmit={submitHandler}>

            <HtmlEditorField value={html} setValue={setHtml}></HtmlEditorField>

            <CButtonField type="submit">Tamam</CButtonField>
            
        </form>
    )
}


