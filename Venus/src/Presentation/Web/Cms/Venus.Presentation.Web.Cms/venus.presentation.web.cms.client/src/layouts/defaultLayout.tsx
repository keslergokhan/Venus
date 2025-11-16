import { type JSX } from "react";
import { Outlet } from "react-router-dom";
import { useAuthentication } from "../hooks";
import { HeaderContainer } from "../containers";
import { FileManagerComponent } from "../components";
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
                    <FileManagerComponent></FileManagerComponent>
                    <br></br>
                    <FileManagerComponent></FileManagerComponent>
                </>

            }
        </>
    )
}

export default DefaultLayout;