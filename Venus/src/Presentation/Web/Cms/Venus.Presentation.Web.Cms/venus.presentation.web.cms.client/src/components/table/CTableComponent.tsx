import { Dropdown, DropdownItem, Table, TableCell, TableRow,TableBody, Pagination } from "flowbite-react"
import { useState, type JSX, type ReactNode } from "react"

export interface CTableComponentProps<TData>{
    data:Array<TData>;
    children:ReactNode;
    getRowChildren:(props:{index:number,data:TData})=>JSX.Element
    actions?:Array<Record<string,()=>void>>|undefined
}

export const CTableComponent = <TData extends any>(props:CTableComponentProps<TData>) =>{
    
    // 1. Sayfa State'i
    const [currentPage, setCurrentPage] = useState(1);
    const itemsPerPage = 10; // Her sayfada kaç kayıt olacak?
    // 2. Hesaplamalar
    let totalPages = Math.ceil(props.data.length / itemsPerPage);
    
    // Tabloda gösterilecek verinin başlangıç ve bitiş indekslerini hesapla
    const startIndex = (currentPage - 1) * itemsPerPage;
    const endIndex = startIndex + itemsPerPage;
    
    // Veriyi dilimle (Sadece mevcut sayfayı gösterir)
    let currentItems = new Array<TData>();

    if(props.data && props.data.length>0){
        currentItems = props.data.slice(startIndex, endIndex);
    }

    // 3. Sayfa Değiştirme Fonksiyonu
    const onPageChange = (page: number) => {
        setCurrentPage(page);
        // İsteğe bağlı: Sayfa değişince tablonun başına kaydır
        window.scrollTo({ top: 0, behavior: 'smooth' });
    };

    const PaginationTemlate = ()=>{
        if(totalPages>0){
            return <div className="inline-block">
                        <span className="text-sm text-gray-700 dark:text-gray-400 flex justify-end gap-2">
                            Gösterilen: 
                            <span className="font-semibold text-gray-900 dark:text-white">1-{itemsPerPage}</span> / 
                            <span className="font-semibold text-gray-900 dark:text-white">{props.data.length}</span>
                        </span>
                        <Pagination currentPage={currentPage} totalPages={totalPages} onPageChange={onPageChange} showIcons />
                    </div>
        }else{
            return <></>
        }
        
    }


    return (
        <div className="overflow-x-auto ">
            <Table striped className="[&_th]:bg-transparent">
                {props?.children}
                <TableBody className="divide-y [&_td]:bg-transparent" >
                    {
                        (currentItems && currentItems.length > 0) && currentItems.map((item,index)=>{
                            return (props.getRowChildren({index:index,data:item}))
                        })
                    }
                </TableBody>
            </Table>
            <div className="w-full py-1 flex justify-end">
                <PaginationTemlate></PaginationTemlate>
            </div>
        </div>
    )
}