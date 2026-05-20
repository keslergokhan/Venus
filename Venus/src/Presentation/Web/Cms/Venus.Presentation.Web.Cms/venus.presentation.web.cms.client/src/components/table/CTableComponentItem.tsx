import { Dropdown, DropdownItem, TableCell, TableHead, TableHeadCell, TableRow } from "flowbite-react"
import type { ReactNode } from "react"
import { DtoBase } from "../../dtos/base/DtoBase"
import { EntityStateEnum } from "../../dtos/enums/EntityStateEnum"


export interface CTableHeaderComponentProps{
    children:ReactNode
}

export function CTableHeaderComponent(props:CTableHeaderComponentProps) {
    return (
        <TableHead>
            <TableRow className="!bg-gray-700 text-[14px] text-white">
                <TableHeadCell>Adet</TableHeadCell>
                {props.children}
            </TableRow>
        </TableHead>
    )
}

export interface CTableBodyRowProps<TData extends DtoBase>{
    index:number;
    data:TData;
    children:ReactNode;
    toggleStateHandler?:(id:string)=>Promise<void>;
    removeOnHandler?:(data:TData)=>Promise<void>;
    updateOnHandler?:(data:TData)=>Promise<void>;
}

export function CTableBodyRow<TData extends DtoBase>(props:CTableBodyRowProps<TData>) {
    let customClass = "";
    
    if(props.index % 2 == 1){
        customClass = "!bg-gray-300";
    }

    if(props.data.state === EntityStateEnum.Offline){
        customClass = "!bg-red-300"
    }

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

                    {props.removeOnHandler && <DropdownItem className="text-red-700" onClick={async ()=>{
                        if(props.removeOnHandler){
                            await props.removeOnHandler(props.data);
                        }
                    }}>Sil</DropdownItem>}

                    {
                        props.toggleStateHandler && <DropdownItem onClick={async ()=>{
                            if(props.toggleStateHandler){
                                await props.toggleStateHandler(props.data.id);
                            }
                        }}>
                            {props.data.state == EntityStateEnum.Online ? "Gizle":"Göster"}
                        </DropdownItem>
                    }           
                </Dropdown>
            </TableCell>
        </TableRow>
    )
}
