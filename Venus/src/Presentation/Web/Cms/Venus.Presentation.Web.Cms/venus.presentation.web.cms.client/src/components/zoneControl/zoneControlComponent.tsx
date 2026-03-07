import React, { type JSX } from "react";
import { Children, type ReactNode } from "react"


interface ZoneControlComponentProps{
    className?:string,
    zoneKeys:Array<string>,
    children:ReactNode
}

export const ZoneControlComponent = (props:ZoneControlComponentProps):JSX.Element =>{
    
    return <div className={props.className}>
        {Children.map(props.children, (child) => {
            
            // 1. Geçerli bir React elementi mi? (null veya string değilse)
            if (React.isValidElement(child)) {
                // 2. Proplara güvenli erişim için tip ataması
                const childProps = child.props as ZoneControlItemProps;
                if(props.zoneKeys.some(x=>x == childProps.zoneKey)){
                    return childProps.children;
                }


            // 4. İzin verilmiyorsa hiçbir şey gösterme
            }
        })}
    </div>
}

interface ZoneControlItemProps {
    zoneKey:string;
    children:ReactNode
}

export const ZoneControlItem = (props:ZoneControlItemProps) =>{

    return (<>
    
    </>);
}