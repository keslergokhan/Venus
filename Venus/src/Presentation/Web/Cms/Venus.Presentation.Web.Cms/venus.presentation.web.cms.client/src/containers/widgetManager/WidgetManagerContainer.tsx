import { CButtonField, WidgetTableComponent, WidgetUpdateComponent, ZoneControlComponent, ZoneControlItem } from "../../components";
import { useWidgetManagerContainer } from "../../hooks";

function WidgetManagerContainer(){

    var {widgets,
        showContainer,
        goToUpdateHandler,
        refreshTable,
        selectWidget
    } = useWidgetManagerContainer();

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
                    <div className="w-full min-h-[100px]">
                        {selectWidget != null ? <WidgetUpdateComponent selectUpdateWidget={selectWidget}></WidgetUpdateComponent> : "Yükleniyor..."}
                    </div>
                </ZoneControlItem>
                <ZoneControlItem zoneKey={"add"}>
                    Yeni ekle
                </ZoneControlItem>
            </ZoneControlComponent>
        </div>
    );
}

export default WidgetManagerContainer;