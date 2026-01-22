import type { JSX } from "react"
import { CSmButtonField } from "../commons"
import type { ReadPageAboutDto, ReadPageTypeDto } from "../../dtos"
import { Link } from "react-router-dom"


export interface PageTypeListComponentProps {
    pageAbouts:ReadPageTypeDto[]
}

export const PageTypeListComponent = (props:PageTypeListComponentProps):JSX.Element =>{


    const PageAboutItemJsx = ({item}:{item:ReadPageTypeDto}):JSX.Element =>{
        return (
            <div className="col-span-12 md:col-span-3 border py-2 px-2 border-gray-200 min-h-[100px] shadow-lg block bg-gray-300 rounded-xl ">
                <div className="text-lx text-base font-bold flex justify-center">
                    <h5>{item.pageAbout.name}</h5>
                </div>
                <div className="text-sm font-light flex justify-center mt-2 flex-col items-center gap-3">
                    <p>{item.pageAbout.description}</p>
                    <p>{item.urls.length} Sayfa mevcut</p>
                    <div className="w-2/3 gap-1 flex">
                        <CSmButtonField className="max-w-[150px] text-[12px]" id="add-page" >
                            <Link className="block" to={`add?pageTypeId=${item.id}`}>Yeni Sayfa Ekle</Link>
                        </CSmButtonField>
                        <CSmButtonField className="max-w-[150px] text-[12px]" id="add-page" >
                            <Link className="block" to={`detail?pageTypeId=${item.id}`}>Detay</Link>
                        </CSmButtonField>
                    </div>
                </div>
            </div>
        )
    }

    return (    
        <div className="grid-cols-12 grid gap-2 justify-center">
            {
                props.pageAbouts.map((x,i)=>{
                    return <PageAboutItemJsx item={x} key={i}></PageAboutItemJsx>
                })
            }
            
        </div>        
    )
}
