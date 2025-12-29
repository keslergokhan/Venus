import type { JSX } from "react"
import { CSmButtonField } from "../commons"
import type { ReadPageAboutDto } from "../../dtos"


export interface PageTypeListComponentProps {
    pageAbouts:ReadPageAboutDto[]
}

export const PageTypeListComponent = (props:PageTypeListComponentProps):JSX.Element =>{


    const PageAboutItemJsx = ({name,description}:{name:string,description:string}):JSX.Element =>{
        return (
            <div className=" border py-2 px-2 border-gray-200 max-w-sm min-h-[100px] shadow-lg block bg-gray-300 rounded-xl ">
                <div className="text-lx text-base font-bold flex justify-center">
                    <h5>{name}</h5>
                </div>
                <div className="text-sm font-light flex justify-center mt-2 flex-col items-center gap-3">
                    <p>{description}</p>
                    <CSmButtonField className="max-w-[150px] text-[12px]" id="add-page"  >Yeni Sayfa</CSmButtonField>
                </div>
            </div>
        )
    }

    return (    
        <div className="grid-cols-4 grid gap-2">
            {
                props.pageAbouts.map((x,i)=>{
                    return <PageAboutItemJsx {...x} key={i}></PageAboutItemJsx>
                })
            }
            
        </div>        
    )
}
