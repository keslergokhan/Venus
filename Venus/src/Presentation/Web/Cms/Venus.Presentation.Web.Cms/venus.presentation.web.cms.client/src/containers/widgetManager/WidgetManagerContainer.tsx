import { CButtonField, WidgetTableComponent, ZoneControlComponent, ZoneControlItem } from "../../components";
import { useWidgetManagerContainer } from "../../hooks";
import CodeMirror from "@uiw/react-codemirror";
import { html } from "@codemirror/lang-html";
import { vscodeDark } from "@uiw/codemirror-theme-vscode";


function WidgetManagerContainer(){

    var {widgets,
        showContainer,
        goToUpdateHandler,
        refreshTable} = useWidgetManagerContainer();

    const isTable = (showContainer() ?? []).find(x=>x=="table")?true:false;

    return (
        <div>
            <div className="flex gap-4">
                <CButtonField onClick={()=>{showContainer(["add"])}}>Yeni Blog</CButtonField>
                <CButtonField onClick={()=>{refreshTable()}} className={`${(isTable==false&&"bg-red-700")}`}>
                    {(isTable?"Yenile":"İptal")}
                </CButtonField>
            </div>
            
            <ZoneControlComponent className="mt-4" zoneKeys={showContainer() ?? []}>
                <ZoneControlItem zoneKey={"table"}>
                    <WidgetTableComponent widgets={widgets} goToUpdateHandler={goToUpdateHandler}></WidgetTableComponent>
                </ZoneControlItem>
                <ZoneControlItem zoneKey={"update"}>
                <CodeMirror
                    value={widgets.find(x=>x.key == "Deneme.Sablonu")?.template}
                    height="300px"
                    theme={vscodeDark }
                    extensions={[html()]}
                    />
                </ZoneControlItem>
                <ZoneControlItem zoneKey={"add"}>
                    Yeni ekle
                </ZoneControlItem>
            </ZoneControlComponent>
        </div>
    );
}

export default WidgetManagerContainer;