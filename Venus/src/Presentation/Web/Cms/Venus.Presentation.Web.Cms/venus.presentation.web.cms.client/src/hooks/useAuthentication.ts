import { useLocation, useNavigate } from "react-router-dom";
import { AuthenticationContext, AuthenticationContextProps } from "../contexts/AuthenticationContext";
import { AuthenticationService } from "../services";
import { useContext, useEffect } from "react";
import { ToastHelper } from "../helpers";
import { PageRoute, useCustomNavigate } from "./useCustomNavigate";


export const useAuthentication = (): AuthenticationContextProps => {

    const autContext = useContext(AuthenticationContext);
    const service = new AuthenticationService();
    const [navigation] = useCustomNavigate();
    const location = useLocation();

    useEffect(() => {

        const jwtToken = service.GetUserJwtToken();
        if (jwtToken == null) {
            if (autContext.authenticationState.isAuth) {
                autContext.authenticationAction({ type: "Logaut" });
            }

            navigation(PageRoute.Login);
        } else {
            if (!autContext.authenticationState.isAuth) {
                service.loginValidationAsync()
                    .then(x => {
                        autContext.authenticationAction({ type: "Login", user: x });
                            if(location.pathname == PageRoute.Login){
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