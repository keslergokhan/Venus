import { CButtonField, LoadingComponent, WidgetAddComponent, WidgetTableComponent, WidgetUpdateComponent, ZoneControlComponent, ZoneControlItem } from "../../components";
import { StepManagerComponent, type StepContentProp, type StepManagerComponentProps } from "../../components/steps/StepManagerComponent";
import { addWidgetStep } from "../../components/widgetManager/widgetAddSetps/WidgetAddStep";
import { schemaWidgetStep } from "../../components/widgetManager/widgetAddSetps/WidgetSchemaControlStep";
import { useWidgetManagerContainer } from "../../hooks";

function WidgetManagerContainer(){

    var widgetManager = useWidgetManagerContainer();

    var {widgets,
        showContainer,
        goToUpdateHandler,
        refreshTable,
        selectWidget,
        updateHandler,
        addHandler
    } = widgetManager;

    const isTable = (showContainer() ?? []).find(x=>x=="table")?true:false;

    

    const stepManagerProp:StepManagerComponentProps<ReturnType<typeof useWidgetManagerContainer>> = {
        stepProp:{
            data:widgetManager
        },
        steps:[addWidgetStep,schemaWidgetStep]
    }
    
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
                    {/** <WidgetAddComponent addHandler={addHandler}></WidgetAddComponent> */}
                    <StepManagerComponent {...stepManagerProp}></StepManagerComponent>
                </ZoneControlItem>
            </ZoneControlComponent>
        </div>
    );
}

export default WidgetManagerContainer;