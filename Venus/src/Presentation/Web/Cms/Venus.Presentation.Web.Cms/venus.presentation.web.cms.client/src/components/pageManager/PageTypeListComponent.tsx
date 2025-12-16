import type { JSX } from "react"
import { CButtonField, CSmButtonField } from "../commons"


export interface PageTypeListComponentProps {

}

export const PageTypeListComponent = (props:PageTypeListComponentProps):JSX.Element =>{
    return (
        <div className="border py-2 px-2 border-gray-200 max-w-sm min-h-[100px] shadow-lg block bg-gray-300 rounded-xl ">
            <div className="text-lx text-base font-bold flex justify-center">
                <h5>VenusDefaultPage</h5>
            </div>
            <div className="text-sm font-light flex justify-center mt-2 flex-col items-center gap-3">
                <p>Varsayılan temel içerik sayfası</p>
                <CSmButtonField className="max-w-[150px] text-[12px]" id="add-page"  >Yeni Sayfa</CSmButtonField>
            </div>
        </div>
    )
}
