import { useContext, useEffect, type JSX } from "react";
import { Outlet, useNavigate } from "react-router-dom";
import { AuthenticationContext } from "../contexts/AuthenticationContext";
import { AuthenticationService } from "../services";
import { ToastHelper } from "../helpers/ToastHelper";

const DefaultLayout = (): JSX.Element => {
    const autContext = useContext(AuthenticationContext);
    const service = new AuthenticationService();
    const navigation = useNavigate();

    useEffect(() => {

        const jwtToken = service.userJwtToken();

        if (jwtToken == null) {
            if (autContext.authenticationState.isAuth) {
                autContext.authenticationAction({ type: "Logaut" });
            }
            
            navigation("/login");
        } else {
            if (!autContext.authenticationState.isAuth) {
                console.log("iþlem baþladý");
                service.loginValidation({ userJwt: jwtToken })
                    .then(x => {
                        if (x.isSuccess && x.data != null) {
                            autContext.authenticationAction({ type: "Login", user: x.data });
                            navigation("/home");
                        }
                    }).catch(x => {
                        ToastHelper.DefaultError();
                        autContext.authenticationAction({ type: "Logaut" });
                        navigation("/login");
                    })
            }
        }

    });

    return (
        <>
            {
                (!autContext.authenticationState.isAuth) ?
                <>Yükleniyor...</>
                :
                <>
                    <p>header</p>
                    <Outlet />
                    <p>footer</p>
                </>

            }
        </>
    )
}

export default DefaultLayout;