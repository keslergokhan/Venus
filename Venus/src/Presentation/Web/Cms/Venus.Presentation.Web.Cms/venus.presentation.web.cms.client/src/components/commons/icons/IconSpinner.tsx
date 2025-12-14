import { Spinner } from "flowbite-react"
import type { JSX } from "react"


//{size}:{size:?:"xl"|"md"}


export const IconSpinner = ({size}:{size?:string|"xl"|"md"}):JSX.Element =>{
    return <Spinner className="p-0" aria-label="Center-aligned spinner example" size={(size ? size : "md")} />
}