import { TableCell, TableHeadCell} from "flowbite-react";
import { CTableBodyRow, CTableComponent,CTableHeaderComponent } from "..";
import type { ReadBlogDto } from "../../dtos"

interface BlogTableComponentProps {
    blogs:Array<ReadBlogDto>
    removeOnHandler?:(data:ReadBlogDto)=>Promise<void>;
    updateOnHandler?:(data:ReadBlogDto)=>Promise<void>;
    toggleStateHandler?:(id:string)=>Promise<void>;
}

export function BlogTableComponent(props:BlogTableComponentProps){

    const baseProps = props;
    
    function row(props:{index:number,data:ReadBlogDto}){
        const {data} = props;
        return (
            <CTableBodyRow {...props} key={props.index} toggleStateHandler={baseProps.toggleStateHandler} removeOnHandler={baseProps.removeOnHandler} updateOnHandler={baseProps.updateOnHandler} >
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
                <TableHeadCell>Başlık</TableHeadCell>
                <TableHeadCell>Description</TableHeadCell>
                <TableHeadCell>Kategori</TableHeadCell>
                <TableHeadCell>Price</TableHeadCell>    
                <TableHeadCell>İşlem</TableHeadCell>
            </CTableHeaderComponent>
        </CTableComponent>
    )
}