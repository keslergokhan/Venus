import { Spinner } from "flowbite-react";
import type { JSX } from "react"

export interface MultiLoadingComponentProps{
    componentKey: string;
    currentLoadingKey:string;
    children:React.ReactNode;
    error?:string;
    size?:"xl"|"md";
    class?:string;
}

export const MultiLoadingComponent = (props:MultiLoadingComponentProps):JSX.Element =>{
    if (props.currentLoadingKey == props.componentKey) return (
        <div className={`${(props.class!==undefined && props.class)} relative`}>
            <div className="flex absolute inset-0 justify-center items-center" >
                <Spinner className="p-0" aria-label="Center-aligned spinner example" size={(props.size ? props.size : "md")} />
            </div>
        </div>
    );
    if (props.error) return <div>Error: {props.error}</div>;
    return <div className={`${(props.class!==undefined && props.class)}`}>{props.children}</div>;  
}
