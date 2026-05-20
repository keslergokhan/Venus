import { Spinner } from "flowbite-react";

export interface LoadingComponentProps{
    loading: boolean;
    children:React.ReactNode;
    error?:string;
    size?:"xl"|"md";
    class?:string;
}

export function LoadingComponent(props:LoadingComponentProps){
    if (props.loading) {
            return (
            <div className={`${(props.class!==undefined && props.class)} relative`} >
                <div className="flex absolute inset-0 justify-center items-center">
                    <Spinner className="p-0" aria-label="Center-aligned spinner example" size={(props.size ? props.size : "md")} />
                </div>
            </div>
        );
    }
    if (props.error) return <div>Error: {props.error}</div>;
    return <>{props.children}</>;  
}
