import { TableCell, TableHeadCell } from "flowbite-react";
import type { ReadWidgetDto } from "../../dtos/widgets/ReadWidgetDto";
import { CTableBodyRow, CTableHeaderComponent } from "../table/CTableComponentItem";
import { CTableComponent } from "../table/CTableComponent";

interface WidgetTableComponentProps{
    widgets:ReadWidgetDto[],
    removeOnHandler?:(data:ReadWidgetDto)=>Promise<void>;
    goToUpdateHandler?:(data:ReadWidgetDto)=>Promise<void>;
    toggleStateHandler?:(id:string)=>Promise<void>;
}

export function WidgetTableComponent(props:WidgetTableComponentProps){
    const basePorps = props;
    function row(props:{index:number,data:ReadWidgetDto}){
        return (
            <CTableBodyRow 
            {...props} 
            key={props.index} 
            removeOnHandler={basePorps.removeOnHandler} 
            goToUpdateHandler={basePorps.goToUpdateHandler}>
                <TableCell>{props.data.key}</TableCell>
            </CTableBodyRow>
        );
    }

    return (
        <CTableComponent data={props.widgets} getRowChildren={row}>
            <CTableHeaderComponent>
                <TableHeadCell>Başlık</TableHeadCell>
                <TableHeadCell>İşlemler</TableHeadCell>
            </CTableHeaderComponent>
        </CTableComponent>
    );
}
