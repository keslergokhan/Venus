import type { JSX } from "react";
import { CButtonField, LanguageResourceTableComponent, LanguageResourceUpdateComponent, ZoneControlComponent, ZoneControlItem } from "../../components";
import { useLanguageResourceContainer } from "../../hooks";

const LanguageResourceComponent = ():JSX.Element =>{

    const {
        languageResourceList,
        updateHandler,
        setShowContainer,
        refreshTable,
        showContainers,
        selectUpdateResourceKey
    } = useLanguageResourceContainer();

    const isTable = showContainers.find(x=>x=="table")?true:false;3
    return (<>
        <div className="flex gap-4">
            <CButtonField onClick={()=>{
                if(isTable){
                    refreshTable()
                }else{
                    setShowContainer(["table"]);
                }
            }} className={`${(isTable==false&&"bg-red-700")}`}>
                {(isTable?"Yenile":"İptal")}
            </CButtonField>
        </div>
        <ZoneControlComponent className="mt-4" zoneKeys={showContainers}>
            <ZoneControlItem zoneKey="table">
                <LanguageResourceTableComponent languageResources={languageResourceList} updateHandler={updateHandler} ></LanguageResourceTableComponent>
            </ZoneControlItem>
            <ZoneControlItem zoneKey="update">
                <LanguageResourceUpdateComponent currentLangaugeResourceKey={selectUpdateResourceKey} ></LanguageResourceUpdateComponent>
            </ZoneControlItem>
        </ZoneControlComponent>
       
        
    </>);
}

export default LanguageResourceComponent