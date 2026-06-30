import { CButtonField, LoadingComponent, WidgetAddComponent, WidgetTableComponent, WidgetUpdateComponent, ZoneControlComponent, ZoneControlItem } from "../../components";
import { useWidgetManagerContainer } from "../../hooks";

function WidgetManagerContainer(){

    var {widgets,
        showContainer,
        goToUpdateHandler,
        refreshTable,
        selectWidget,
        updateHandler,
        addHandler
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
                    <LoadingComponent loading={(widgets==null)} class="w-full min-h-[100px]">
                        <WidgetTableComponent widgets={widgets} goToUpdateHandler={goToUpdateHandler}></WidgetTableComponent>
                    </LoadingComponent>
                </ZoneControlItem>
                <ZoneControlItem zoneKey={"update"}>
                    <LoadingComponent class="w-full min-h-[100px]" loading={selectWidget == undefined}>
                        <WidgetUpdateComponent updateHandler={updateHandler} selectUpdateWidget={selectWidget}></WidgetUpdateComponent>
                    </LoadingComponent>
                </ZoneControlItem>
                <ZoneControlItem zoneKey={"add"}>
                    <WidgetAddComponent addHandler={addHandler}></WidgetAddComponent>
                </ZoneControlItem>
            </ZoneControlComponent>
        </div>
    );
}

export default WidgetManagerContainer;