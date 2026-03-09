import { Dropdown, DropdownItem, Table, TableCell, TableRow,TableBody } from "flowbite-react"
import type { JSX, ReactNode } from "react"

export interface CTableComponentProps<TData>{
    data:Array<TData>;
    children:ReactNode;
    getRowChildren:(props:{index:number,data:TData})=>JSX.Element
    actions?:Array<Record<string,()=>void>>|undefined
}

export const CTableComponent = <TData extends any>(props:CTableComponentProps<TData>) =>{
    return (
        <div className="overflow-x-auto">
            <Table striped className="[&_th]:bg-transparent">
                {props.children}
                <TableBody className="divide-y [&_td]:bg-transparent" >
                    {
                        props.data.map((item,index)=>{
                            return (props.getRowChildren({index:index,data:item}))
                        })
                    }
                </TableBody>
            </Table>
        </div>
    )
}