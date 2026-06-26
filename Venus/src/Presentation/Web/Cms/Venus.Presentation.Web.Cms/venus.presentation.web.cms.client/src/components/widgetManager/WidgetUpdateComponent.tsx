import type { ReadWidgetDto } from "../../dtos";
import { CButtonField, CSmButtonField, HtmlEditorField } from "../commons";
import { useRef, useState } from "react";
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
            <div  className="relative">
                <HtmlEditorField setValue={setValue} value={value} ></HtmlEditorField>
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