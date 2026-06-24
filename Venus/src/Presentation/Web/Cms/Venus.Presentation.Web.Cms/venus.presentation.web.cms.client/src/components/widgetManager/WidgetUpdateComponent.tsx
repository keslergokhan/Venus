import type { ReadWidgetDto } from "../../dtos";
import CodeMirror from "@uiw/react-codemirror";
import { html } from "@codemirror/lang-html";
import { vscodeDark } from "@uiw/codemirror-theme-vscode";
import { CButtonField } from "../commons";
import { useState } from "react";
import { ToastHelper } from "../../helpers";

interface WidgetUpdateComponentProps{
    selectUpdateWidget?:ReadWidgetDto,
    updateHandler:(data:ReadWidgetDto)=>Promise<void>
}

export function WidgetUpdateComponent(props:WidgetUpdateComponentProps)
{
    const [value,setValue] = useState<string>(props.selectUpdateWidget?.template ?? "");

    async function submitHandler(e: React.FormEvent<HTMLFormElement>){
        e.preventDefault();
        if(props.selectUpdateWidget){
            props.selectUpdateWidget.template = value;
            await props.updateHandler(props.selectUpdateWidget);
        }else{
            ToastHelper.Error(<>Beklenmedik bir problem oluştu !</>);
        }
        
        
    }

    return (
        <form onSubmit={submitHandler}>
            <div className="">
                <span className="size-24 text-2xl">{props.selectUpdateWidget?.key}</span>
            </div>
            <CodeMirror
            className="mt-3"
            value={value}
            height="300px"
            theme={vscodeDark }
            onChange={(value)=>{
                setValue(value);
            }}
            extensions={[html()]}
            />
            <CButtonField id="blog-submit-btn" className="mt-3">Güncelle</CButtonField>
        </form>
    );
}