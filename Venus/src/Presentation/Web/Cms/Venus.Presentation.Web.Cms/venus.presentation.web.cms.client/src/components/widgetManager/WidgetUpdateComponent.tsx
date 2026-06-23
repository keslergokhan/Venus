import type { ReadWidgetDto } from "../../dtos";
import CodeMirror from "@uiw/react-codemirror";
import { html } from "@codemirror/lang-html";
import { vscodeDark } from "@uiw/codemirror-theme-vscode";

interface WidgetUpdateComponentProps{
    selectUpdateWidget:ReadWidgetDto
}

export function WidgetUpdateComponent(props:WidgetUpdateComponentProps)
{
    return (
        <CodeMirror
            value={props.selectUpdateWidget.template}
            height="300px"
            theme={vscodeDark }
            extensions={[html()]}
            />
    );
}