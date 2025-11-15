import { Spinner } from "flowbite-react";
import type { JSX } from "react"

export interface LoadingComponentProps{
    loading: boolean;
    children:React.ReactNode;
    error?:string;
    size?:"xl"|"md"
}

export const LoadingComponent = (props:LoadingComponentProps):JSX.Element =>{
    if (props.loading) return (
        <div className="flex absolute inset-0 justify-center items-center" >
             <Spinner className="p-0 m-0" aria-label="Center-aligned spinner example" size={(props.size ? props.size : "md")} />
        </div>
    
    );
    if (props.error) return <div>Error: {props.error}</div>;
    return <>{props.children}</>;  
}