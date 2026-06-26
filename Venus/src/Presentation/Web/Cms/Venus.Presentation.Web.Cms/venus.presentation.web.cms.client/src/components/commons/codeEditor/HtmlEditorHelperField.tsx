
export interface HtmlEditorHelperFieldProps{
    replaceSelectionHandler:(text:string)=>Promise<void>
    htmlEditorHelperRef:React.RefObject<HTMLDivElement | null>
}

export function HtmlEditorHelperField(props:HtmlEditorHelperFieldProps){

    const {replaceSelectionHandler} = {...props};

    const Btn = (props:{children:React.ReactNode,html:string})=>{
        return <button className="w-full size-7 h-[30px] cursor-pointer p-0 text-left" onClick={async()=>{await replaceSelectionHandler(props.html)}}>{props.children}</button>
    }

    return (<div ref={props.htmlEditorHelperRef} className="hidden absolute z-10 bg-blue-500 p-0">
        <ul className="menu">
            <li>
                Temel Bilgileri 
                <ul className="submenu">
                    <li><Btn html={`{{Context.Language.Currency}}`} >Para Birimi</Btn></li>
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