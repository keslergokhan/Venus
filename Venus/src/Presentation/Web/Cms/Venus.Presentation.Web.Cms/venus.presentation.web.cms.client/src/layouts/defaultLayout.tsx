import { type JSX } from "react";
import { Outlet } from "react-router-dom";
import { useAuthentication } from "../hooks";
import { HeaderContainer } from "../containers";
const DefaultLayout = (): JSX.Element => {
    
    const authentication = useAuthentication();

    return (
        <>
            {
                (!authentication.authenticationState.isAuth) ?
                <>Yükleniyor...</>
                :
                <>
                    <HeaderContainer></HeaderContainer>
                    <Outlet />
                </>

            }
        </>
    )
}

export default DefaultLayout;