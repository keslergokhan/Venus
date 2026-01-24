import type { JSX } from "react";
import { IconArrow, IconClose, IconFile2, IconOpenFolder, IconRefresh, IconSpinner } from "../components/commons";

const IconComponent = ():JSX.Element =>{
    return <>
        <IconArrow height={50} width={50}></IconArrow>
        <IconClose height={50} width={50}></IconClose>
        <IconFile2 height={50} width={50}></IconFile2>
        <IconOpenFolder height={50} width={50}></IconOpenFolder>
        <IconRefresh height={50} width={50}></IconRefresh>
        <IconSpinner size="md"></IconSpinner>
    </>
}

export default IconComponent;