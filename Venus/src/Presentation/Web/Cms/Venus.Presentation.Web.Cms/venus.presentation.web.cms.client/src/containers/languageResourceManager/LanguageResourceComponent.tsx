import type { JSX } from "react";
import { LanguageResourceTableComponent, LanguageResourceUpdateComponent } from "../../components";

const LanguageResourceComponent = ():JSX.Element =>{
    return (<>
        <LanguageResourceTableComponent></LanguageResourceTableComponent>
        <LanguageResourceUpdateComponent></LanguageResourceUpdateComponent>
    </>);
}

export default LanguageResourceComponent