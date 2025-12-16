import { useEffect, type JSX } from "react";
import { Outlet } from "react-router-dom";
import { useAuthentication } from "../hooks";
import { HeaderContainer } from "../containers";
import { FileManagerComponent } from "../components";
const DefaultLayout = (): JSX.Element => {
    
    const authentication = useAuthentication();

    useEffect(()=>{
        console.log("merhaba dünya");
    },[])
    
    return (
        <>
            {
                (!authentication.authenticationState.isAuth) ?
                <>Yükleniyor...</>
                :
                <>
                    <HeaderContainer></HeaderContainer>
                    <div className="container px-4 py-4">
                        <Outlet />
                    </div>
                    <FileManagerComponent></FileManagerComponent>
                </>

            }
        </>
    )
}

export default DefaultLayout;