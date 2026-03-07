import { Dropdown, DropdownItem, Table, TableCell, TableHead, TableHeadCell, TableRow,TableBody } from "flowbite-react"
import type { JSX, ReactNode } from "react"

export interface CTableComponentProps<TData>{
    data:Array<TData>;
    children:ReactNode;
    getRowChildren:(props:{index:number,data:TData})=>JSX.Element
}

export const CTableHeaderComponent = (props:{children:ReactNode}) =>{
    return (
        <TableHead className="!bg-gray-700 text-[14px] text-white">
            {props.children}
        </TableHead>
    )
}


export const CTableComponent = <TData extends any>(props:CTableComponentProps<TData>) =>{
    return (
        <div className="overflow-x-auto">
            <Table striped className="[&_th]:bg-transparent">
                {props.children}
                <TableBody className="divide-y [&_td]:bg-transparent" >
                    <TableRow className="!bg-gray-300 ">
                        <TableCell >
                        Apple MacBook Pro 17"
                        </TableCell>
                        <TableCell >Sliver</TableCell>
                        <TableCell>Laptop</TableCell>
                        <TableCell>$2999</TableCell>
                        <TableCell>
                            <Dropdown label="İşlem" className="font-bold" size="xs">
                                <DropdownItem>Detay</DropdownItem>
                                <DropdownItem className="text-red-700">Sil</DropdownItem>
                            </Dropdown>
                        </TableCell>
                    </TableRow>
                    {
                        props.data.map((item,index)=>{
                            return props.getRowChildren({index:index,data:item,});
                        })
                    }
               
                </TableBody>
            </Table>
        </div>
    )
}