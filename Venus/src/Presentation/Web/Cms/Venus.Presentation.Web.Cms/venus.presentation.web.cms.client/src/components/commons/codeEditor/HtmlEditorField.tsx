import { html } from "@codemirror/lang-html";
import { vscodeDark } from "@uiw/codemirror-theme-vscode";
import CodeMirror, { type ReactCodeMirrorRef, type UseCodeMirror } from "@uiw/react-codemirror";
import { useRef } from "react";
import { HtmlEditorHelperField } from "./HtmlEditorHelperField";

export interface HtmlEditorFieldProps{
    value:string
    setValue:(value:string)=>void,
    onContextMenuHandler?:(e: React.MouseEvent<HTMLDivElement>)=>Promise<void>
    handleOnclickHandler?:(e: React.MouseEvent<HTMLDivElement>)=>Promise<void>
}

export function HtmlEditorField(props:HtmlEditorFieldProps){
    const codeMirorRef = useRef<ReactCodeMirrorRef>(null);
    const htmlEditorHelperRef = useRef<HTMLDivElement>(null);
    

    async function onContextMenuHandler(e: React.MouseEvent<HTMLDivElement>){
        props.onContextMenuHandler && await props.onContextMenuHandler(e);
        e.preventDefault();
        if(htmlEditorHelperRef.current){
            htmlEditorHelperRef.current.style.display = "block";
            htmlEditorHelperRef.current.style.position = "fixed";
            htmlEditorHelperRef.current.style.left = `${e.clientX}px`;
            htmlEditorHelperRef.current.style.top = `${e.clientY}px`;
        }
        
        console.log("X:", e.clientX);
        console.log("Y:", e.clientY);
        
    }

    async function handleOnclick(e: React.MouseEvent<HTMLDivElement>){
        props.handleOnclickHandler && await props.handleOnclickHandler(e);
        
        if(htmlEditorHelperRef.current){
            htmlEditorHelperRef.current.style.display = "none";
        }
    }

    async function replaceSelectionHandler(text:string){
        const view = codeMirorRef.current?.view;
        const state = view?.state;
        const transaction = view?.state.replaceSelection(text);
        if(transaction){
            view?.dispatch(transaction);
        }
    }

    return (
        <div>
            <HtmlEditorHelperField htmlEditorHelperRef={htmlEditorHelperRef} replaceSelectionHandler={replaceSelectionHandler}></HtmlEditorHelperField>
            <CodeMirror
                onContextMenu={onContextMenuHandler} onClick={handleOnclick}
                ref={codeMirorRef}
                className="mt-3"
                value={props.value}
                height="300px"
                theme={vscodeDark }
                onChange={props.setValue}
                extensions={[html()]}
            />
        </div>
    )
}