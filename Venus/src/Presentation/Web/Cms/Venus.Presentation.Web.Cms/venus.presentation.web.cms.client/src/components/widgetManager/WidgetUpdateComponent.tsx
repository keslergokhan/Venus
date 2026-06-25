import type { ReadWidgetDto } from "../../dtos";
import CodeMirror, { type ReactCodeMirrorRef, type UseCodeMirror } from "@uiw/react-codemirror";
import { html } from "@codemirror/lang-html";
import { vscodeDark } from "@uiw/codemirror-theme-vscode";
import { CButtonField, CSmButtonField } from "../commons";
import { useRef, useState } from "react";
import { ToastHelper } from "../../helpers";

interface WidgetUpdateComponentProps{
    selectUpdateWidget?:ReadWidgetDto,
    updateHandler:(data:ReadWidgetDto)=>Promise<void>
}

export function WidgetUpdateComponent(props:WidgetUpdateComponentProps)
{
    const [value,setValue] = useState<string>(props.selectUpdateWidget?.template ?? "");
    const widgetHelperRef = useRef<HTMLInputElement>(null);
    const codeMirorRef = useRef<ReactCodeMirrorRef>(null);

    async function submitHandler(e: React.FormEvent<HTMLFormElement>){
        e.preventDefault();
        if(props.selectUpdateWidget){
            props.selectUpdateWidget.template = value;
            await props.updateHandler(props.selectUpdateWidget);
        }else{
            ToastHelper.Error(<>Beklenmedik bir problem oluştu !</>);
        }
    }

    async function handleOnclick(){
        if(widgetHelperRef.current){
            widgetHelperRef.current.style.display = "none";
        }
    }

    async function handleRightClick(e: React.MouseEvent<HTMLDivElement>){
        e.preventDefault();
        if(widgetHelperRef.current){
            widgetHelperRef.current.style.display = "block";
            widgetHelperRef.current.style.position = "fixed";
            widgetHelperRef.current.style.left = `${e.clientX}px`;
            widgetHelperRef.current.style.top = `${e.clientY}px`;
        }

        
        console.log("X:", e.clientX);
        console.log("Y:", e.clientY);
    };

    async function replaceSelection(text:string){
        const view = codeMirorRef.current?.view;
        const state = view?.state;
        const transaction = view?.state.replaceSelection(text);
        if(transaction){
            view?.dispatch(transaction);
        }
    }

    function WidgetHelper(){

        const Btn = (props:{children:React.ReactNode,html:string})=>{
            return <button className="w-full size-7 h-[30px] cursor-pointer p-0 text-left" onClick={async()=>{await replaceSelection(props.html)}}>{props.children}</button>
        }

        return (<div ref={widgetHelperRef} className="hidden absolute z-10 bg-blue-500 p-0">
            
            <ul className="menu">
                <li>
                    Temel Bilgileri 
                    <ul className="submenu">
                        <li><Btn html={`{{Context.Language.Currency}}`}>Para Birimi</Btn></li>
                        <li><Btn html={`{{Context.Language.CountryCode}}`}>Ülke Kodu</Btn></li>
                        <li><Btn html={`{{Context.Url.FullPath}}`}>Sayfa Tam Adresi</Btn></li>
                        <li><Btn html={`{{Context.Url.Host}}`}>Sitenin Adresi</Btn></li>
                        <li><Btn html={`{{Context.Page.Name}}`}>Sayfa Adı</Btn></li>
                    </ul>
                </li>
                <li>
                    Yardımcılar
                    <ul className="submenu">
                        <li><Btn html={`<venus-lan-resource key-data=""></venus-lan-resource>`}>Çoklu Dil Parçacığı</Btn></li>
                    </ul>
                </li>
                
            </ul>
        </div>);
    }

    return (
        <form onSubmit={submitHandler}>
            <div className="">
                <span className="size-24 text-2xl">{props.selectUpdateWidget?.key}</span>
            </div>
            <div onContextMenu={handleRightClick} onClick={handleOnclick} className="relative">
                <WidgetHelper></WidgetHelper>
                <CodeMirror
                ref={codeMirorRef}
                className="mt-3"
                value={value}
                height="300px"
                theme={vscodeDark }
                onChange={(value)=>{
                    setValue(value);
                }}
                extensions={[html()]}
                />
            </div>
            
            <CButtonField id="blog-submit-btn" type="submit" className="mt-3">Güncelle</CButtonField>
        </form>
    );
}


/**
 

{
    "Language": {
        "Id": "47c696f8-5066-4094-a89f-6b52c9c24694",
        "Name": "T\u00FCrk\u00E7e",
        "CountryCode": "tr",
        "Culture": "tr-TR",
        "Currency": "TL"
    },
    "Url": {
        "IsEntity": false,
        "Schema": "https",
        "Host": "localhost:7092",
        "Region": "",
        "Path": "/bugunun-testi",
        "FullPath": "https://localhost:7092/bugunun-testi",
        "BaseUrl": "https://localhost:7092",
        "Id": "7a03fba5-c457-4d3e-9a58-f425ac4ecfd8",
        "ParentId": null
    },
    "Page": {
        "Id": "74292325-ea66-4049-bf39-16f553924dee",
        "Name": "/bugunun-testi",
        "Description": "/bugunun-testi",
        "Controller": "VenusDefaultPageController",
        "Action": "Index",
        "EntityClassType": null,
        "Entity": null,
        "PageType": 0
    }
}
 */