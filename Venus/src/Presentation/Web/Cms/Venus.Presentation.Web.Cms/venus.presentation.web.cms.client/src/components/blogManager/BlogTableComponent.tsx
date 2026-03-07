import { Dropdown, DropdownItem, TableCell, TableHeadCell, TableRow } from "flowbite-react";
import { CTableComponent,CTableHeaderComponent } from "..";
import type { ReadBlogDto } from "../../dtos"
import { useBlogContainer } from "../../hooks";

interface BlogTableComponentProps {
    blogs:Array<ReadBlogDto>
}

export const BlogTableComponent = (props:BlogTableComponentProps) =>{

    const row = (props:{index:number,data:ReadBlogDto})=>{
        return <TableRow className="!bg-gray-300 ">
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
    }

    return (
        <CTableComponent data={props.blogs} getRowChildren={row} >
            <CTableHeaderComponent>
                <TableHeadCell>Product name</TableHeadCell>
                <TableHeadCell>Color</TableHeadCell>
                <TableHeadCell>Category</TableHeadCell>
                <TableHeadCell>Price</TableHeadCell>
                <TableHeadCell>İşlem</TableHeadCell>
            </CTableHeaderComponent>
        </CTableComponent>
    )
}