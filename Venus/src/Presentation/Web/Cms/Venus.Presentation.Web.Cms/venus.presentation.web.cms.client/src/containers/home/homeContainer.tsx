import type { JSX } from "react"
import { FileManagerInputComponent } from "../../components/fileManager/FileManagerInputComponent";
import { HtmlEditor } from "../../components";

const HomeContainers = ():JSX.Element =>{

    console.log("test");
    return (<>
        <FileManagerInputComponent></FileManagerInputComponent>
        <HtmlEditor></HtmlEditor>
    </>)
}

export default HomeContainers;