import { useState } from "react";
import type { LoginFormValues } from "../components";
import { SessionKeys, SessionStorageHelper, ToastHelper } from "../helpers";
import { AuthenticationService } from "../services";
import { useAuthentication } from "./useAuthentication";
import { PageRoute, useCustomNavigate } from "./useCustomNavigate";

export function useLogin(){
    const [loadingState,setLoading] = useState<boolean>(false);
    const [navigate] = useCustomNavigate();
    const authentication =  useAuthentication();
    const service = new AuthenticationService();
    async function onSubmitAsync(data: LoginFormValues): Promise<void> {

        setLoading(true);
        await service.loginAsync(data).then(x => {
            authentication.authenticationAction({ type: "Login", user: x });
            
            SessionStorageHelper.set(SessionKeys.cmsUser, x.jwtToken);
            ToastHelper.Success(`${x.name} ${x.surname} hoşgeldin.`);
            setTimeout(() => {
                navigate(PageRoute.Home);
            },100)
        }).catch(() => {
            setLoading(false);
            authentication.authenticationAction({ type: "Logaut"});
            ToastHelper.Warning("Kullanıcı adı veya şifre yanlış.");
        });
    };

    return {onSubmitAsync,loadingState}
}