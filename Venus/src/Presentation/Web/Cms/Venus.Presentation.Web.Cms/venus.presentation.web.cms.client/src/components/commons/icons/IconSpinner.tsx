import { Spinner } from "flowbite-react"


//{size}:{size:?:"xl"|"md"}
export function IconSpinner({size}:{size?:string|"xl"|"md"}){
    return <Spinner className="p-0" aria-label="Center-aligned spinner example" size={(size ? size : "md")} />
}