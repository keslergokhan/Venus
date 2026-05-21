import { useLocation, useNavigate } from "react-router-dom";
import { AuthenticationContext, AuthenticationContextProps } from "../contexts/AuthenticationContext";
import { AuthenticationService } from "../services";
import { useContext, useEffect } from "react";
import { ToastHelper } from "../helpers";
import { PageRoute, useCustomNavigate } from "./useCustomNavigate";


export function useAuthentication(): AuthenticationContextProps {

    const autContext = useContext(AuthenticationContext);
    const service = new AuthenticationService();
    const [navigation] = useCustomNavigate();
    const location = useLocation();

    async function loginValidation(){

        try {
            const validResult = await service.loginValidationAsync();

            autContext.authenticationAction({ type: "Login", user: validResult });
            if(location.pathname == PageRoute.Login){
                navigation(PageRoute.Home);
            }
        } catch (error) {
            ToastHelper.DefaultError();
            autContext.authenticationAction({ type: "Logaut" });
            navigation(PageRoute.Login);
        }
        

    }

    useEffect(() => {

        const jwtToken = service.GetUserJwtToken();
        if (jwtToken == null) {
            if (autContext.authenticationState.isAuth) {
                autContext.authenticationAction({ type: "Logaut" });
            }

            navigation(PageRoute.Login);
        } else {
            if (!autContext.authenticationState.isAuth) {
                loginValidation();
            }
        }

    },[]);

    return autContext;
}