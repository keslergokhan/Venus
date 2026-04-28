import { Dropdown, DropdownItem, TableCell, TableHead, TableHeadCell, TableRow } from "flowbite-react"
import type { ReactNode } from "react"
import type { CTableComponentProps } from ".."


export interface CTableHeaderComponentProps{
    children:ReactNode
}

export const CTableHeaderComponent = (props:CTableHeaderComponentProps) =>{
    return (
        <TableHead>
            <TableRow className="!bg-gray-700 text-[14px] text-white">
                <TableHeadCell>Adet</TableHeadCell>
                {props.children}
            </TableRow>
        </TableHead>
    )
}

export interface CTableBodyRowProps<TData extends any>{
    index:number;
    data:TData;
    children:ReactNode;
    removeOnHandler?:(data:TData)=>Promise<void>;
    updateOnHandler?:(data:TData)=>Promise<void>;
}

export const CTableBodyRow = <TData extends any>(props:CTableBodyRowProps<TData>) =>{
    const customClass = (props.index % 2 == 1 ? "!bg-gray-300":"");
    return (
        <TableRow className={customClass}>
            <TableCell>{props.index+1}</TableCell>
                {props.children}
            <TableCell>
                <Dropdown label="İşlem" className="font-bold !border-0 !active:border-0" size="xs">
                    <DropdownItem onClick={async ()=>{
                        if(props.updateOnHandler){
                            await props.updateOnHandler(props.data) 
                        }
                    }}>Güncelle</DropdownItem>
                    <DropdownItem className="text-red-700 " onClick={async ()=>{
                        if(props.removeOnHandler){
                            await props.removeOnHandler(props.data);
                        }
                    }}>Sil</DropdownItem>
                </Dropdown>
            </TableCell>
        </TableRow>
    )
}
