import { Dropdown, DropdownItem, TableCell, TableHeadCell, TableRow } from "flowbite-react";
import { CTableBodyRow, CTableComponent,CTableHeaderComponent } from "..";
import type { ReadBlogDto } from "../../dtos"
import { useBlogContainer } from "../../hooks";

interface BlogTableComponentProps {
    blogs:Array<ReadBlogDto>
    removeOnHandler?:(data:ReadBlogDto)=>void;
    updateOnHandler?:(data:ReadBlogDto)=>void;
}

export const BlogTableComponent = (props:BlogTableComponentProps) =>{

    const baseProps = props;
    
    const row = (props:{index:number,data:ReadBlogDto})=>{
        const {data} = props;
        return (
            <CTableBodyRow {...props} key={props.index} removeOnHandler={baseProps.removeOnHandler} updateOnHandler={baseProps.updateOnHandler} >
                <TableCell>{data.title}</TableCell>
                <TableCell >{data.description}</TableCell>
                <TableCell>Laptop</TableCell>
                <TableCell>$2999</TableCell>
            </CTableBodyRow>
        )
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