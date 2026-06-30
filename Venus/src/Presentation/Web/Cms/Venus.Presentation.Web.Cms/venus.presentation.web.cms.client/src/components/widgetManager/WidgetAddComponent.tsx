import { useState } from "react";
import { HtmlEditorField } from "../commons";
import { WriteWidgetDto } from "../../dtos";
import { useForm } from "react-hook-form";
import {z} from "zod"
import {zodResolver} from "@hookform/resolvers/zod"

export interface WidgetAddComponentProps{
    addHandler:(data:WriteWidgetDto)=>Promise<void>
}

export function WidgetAddComponent(props:WidgetAddComponentProps){
    const [html,setHtml] = useState<string>("");

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


    const widgetUserFormik = useForm<WriteWidgetDto>({resolver:zodResolver(schema),defaultValues:defaultValue});

    return (
        <form>
            <HtmlEditorField value={html} setValue={setHtml}></HtmlEditorField>
        </form>
    )
}