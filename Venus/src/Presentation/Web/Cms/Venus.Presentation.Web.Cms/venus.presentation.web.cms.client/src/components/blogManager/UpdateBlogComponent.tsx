import { useEffect } from "react"
import type { UpdateBlogType } from "../../hooks"



export interface UpdateBlogComponentProps{
    onSubmit:(data:UpdateBlogType)=>void
}

export const UpdateBlogComponent = (props:UpdateBlogComponentProps) =>{
    
    useEffect(()=>{

    },[])

    return (<>
        Update
    </>)
}