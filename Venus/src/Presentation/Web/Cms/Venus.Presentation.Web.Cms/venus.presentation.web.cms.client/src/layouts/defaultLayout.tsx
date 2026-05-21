import { type JSX } from "react";
import { Outlet } from "react-router-dom";
import { useAuthentication, useConfigurationSettings } from "../hooks";
import { HeaderContainer } from "../containers";
import { FileManagerComponent } from "../components";
function DefaultLayout(): JSX.Element {
    
    const authentication = useAuthentication();
    useConfigurationSettings();

    return (
        <>
            {
                (!authentication.authenticationState.isAuth) ?
                <>Yükleniyor...</>
                :
                <>
                    <HeaderContainer></HeaderContainer>
                    <div className="w-full px-4 py-4">
                        <Outlet />
                    </div>
                    <FileManagerComponent></FileManagerComponent>
                </>

            }
        </>
    )
}

export default DefaultLayout;