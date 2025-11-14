import { useNavigate } from "react-router-dom";
import { AuthenticationContext, AuthenticationContextProps } from "../contexts/AuthenticationContext";
import { AuthenticationService } from "../services";
import { useContext, useEffect } from "react";
import { ToastHelper } from "../helpers";
import { PageRoute, useCustomNavigate } from "./useCustomNavigate";


export const useAuthentication = (): AuthenticationContextProps => {

    const autContext = useContext(AuthenticationContext);
    const service = new AuthenticationService();
    const [navigation] = useCustomNavigate();

    useEffect(() => {

        const jwtToken = service.userJwtToken();
        if (jwtToken == null) {
            if (autContext.authenticationState.isAuth) {
                autContext.authenticationAction({ type: "Logaut" });
            }

            navigation(PageRoute.Login);
        } else {
            if (!autContext.authenticationState.isAuth) {
                service.loginValidation({ userJwt: jwtToken })
                    .then(x => {
                        if (x.isSuccess && x.data != null) {
                            autContext.authenticationAction({ type: "Login", user: x.data });
                            navigation(PageRoute.Home);
                        }
                    }).catch(() => {
                        ToastHelper.DefaultError();
                        autContext.authenticationAction({ type: "Logaut" });
                        navigation(PageRoute.Login);
                    })
            }
        }

    },[]);

    return autContext;
}