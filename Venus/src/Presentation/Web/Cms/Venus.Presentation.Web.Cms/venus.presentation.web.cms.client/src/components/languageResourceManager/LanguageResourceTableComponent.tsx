import { TableCell, TableHeadCell } from "flowbite-react";
import type { ReadLanguageResourceKeyDto } from "../../dtos";
import { CTableComponent } from "../table/CTableComponent";
import { CTableBodyRow, CTableHeaderComponent } from "../table/CTableComponentItem";

interface LanguageResourceTableComponentProps{
    languageResources:Array<ReadLanguageResourceKeyDto>;
    selectToUpdateResourceHandler?:(data:ReadLanguageResourceKeyDto)=>Promise<void>
}

export function LanguageResourceTableComponent(props:LanguageResourceTableComponentProps){
    
    const baseProps = props;
     function row(props:{index:number,data:ReadLanguageResourceKeyDto}){
        return (
        <CTableBodyRow key={props.index} {...props} goToUpdateHandler={baseProps.selectToUpdateResourceHandler}>
            <TableCell>{props.data.key}</TableCell>
            <TableCell>{props.data.defaultValue?.substring(0,250)}{props.data.defaultValue?.length>250 && "..."}</TableCell>
        </CTableBodyRow>);
    }
    
    return (

        <CTableComponent data={props.languageResources} getRowChildren={row}>
            <CTableHeaderComponent>
                <TableHeadCell>Key</TableHeadCell>
                <TableHeadCell>Değer</TableHeadCell>
                <TableHeadCell>İşlem</TableHeadCell>
            </CTableHeaderComponent>
        </CTableComponent>
    );
}