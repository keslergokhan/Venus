import type { JSX } from "react";
import type { InputPropsBase } from "../base/InputPropsBase";


export interface CTextFieldProps extends InputPropsBase {

}


export const CTextField = (props: CTextFieldProps): JSX.Element => {

    
    return (<>
        <input type="text" name="test" placeholder="Bu bir deneme"></input>
    </>)
}

