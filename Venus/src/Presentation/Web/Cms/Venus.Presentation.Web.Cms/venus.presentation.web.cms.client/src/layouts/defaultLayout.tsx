import { type JSX } from "react";
import { Outlet } from "react-router-dom";
import { useAuthentication } from "../hooks";
import { HeaderContainer } from "../containers";
import { FileManagerComponent } from "../components";
import { FileManagerInputComponent } from "../components/fileManager/FileManagerInputComponent";
const DefaultLayout = (): JSX.Element => {
    
    const authentication = useAuthentication();

    return (
        <>
            {
                (!authentication.authenticationState.isAuth) ?
                <>Y�kleniyor...</>
                :
                <>
                    <HeaderContainer></HeaderContainer>
                    <Outlet />
                    <FileManagerInputComponent></FileManagerInputComponent>
                    <FileManagerInputComponent></FileManagerInputComponent>
                    <FileManagerComponent></FileManagerComponent>
                </>

            }
        </>
    )
}

export default DefaultLayout;