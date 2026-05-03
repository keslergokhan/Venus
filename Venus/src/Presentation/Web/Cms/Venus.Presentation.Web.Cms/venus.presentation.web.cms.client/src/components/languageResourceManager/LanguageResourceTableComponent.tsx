import { TableCell, TableHeadCell } from "flowbite-react";
import type { ReadLanguageResourceKeyDto } from "../../dtos";
import { CTableComponent } from "../table/CTableComponent";
import { CTableBodyRow, CTableHeaderComponent } from "../table/CTableComponentItem";

interface LanguageResourceTableComponentProps{
    languageResources:Array<ReadLanguageResourceKeyDto>;
    updateHandler?:(data:ReadLanguageResourceKeyDto)=>Promise<void>
}

export const LanguageResourceTableComponent = (props:LanguageResourceTableComponentProps) =>{
    
    const baseProps = props;
    const row = (props:{index:number,data:ReadLanguageResourceKeyDto})=>{
        return (
        <CTableBodyRow key={props.index} {...props} updateOnHandler={baseProps.updateHandler}>
            <TableCell>{props.data.key}</TableCell>
        </CTableBodyRow>);
    }
    
    return (

        <CTableComponent data={props.languageResources} getRowChildren={row}>
            <CTableHeaderComponent>
                <TableHeadCell>Key</TableHeadCell>
                <TableHeadCell>İşlem</TableHeadCell>
            </CTableHeaderComponent>
        </CTableComponent>
    );
}