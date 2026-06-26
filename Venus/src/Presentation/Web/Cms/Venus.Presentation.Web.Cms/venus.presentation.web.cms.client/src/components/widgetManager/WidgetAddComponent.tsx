import { useState } from "react";
import { HtmlEditorField } from "../commons";

export interface WidgetAddComponentProps{
}

export function WidgetAddComponent(props:WidgetAddComponentProps){
    const [html,setHtml] = useState<string>("");
    return (
        <form>
            <HtmlEditorField value={html} setValue={setHtml}></HtmlEditorField>
        </form>
    )
}