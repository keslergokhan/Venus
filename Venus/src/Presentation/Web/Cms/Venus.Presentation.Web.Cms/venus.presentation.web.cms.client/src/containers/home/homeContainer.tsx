import type { JSX } from "react"
import { FileManagerInputComponent } from "../../components/fileManager/FileManagerInputComponent";

const HomeContainers = ():JSX.Element =>{

    console.log("test");
    return (<>
        <FileManagerInputComponent></FileManagerInputComponent>
    </>)
}

export default HomeContainers;