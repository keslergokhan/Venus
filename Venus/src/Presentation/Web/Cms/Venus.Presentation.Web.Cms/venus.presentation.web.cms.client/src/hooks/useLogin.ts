import type { LoginFormValues } from "../components";
import { ToastHelper } from "../helpers";
import { AuthenticationService } from "../services";
import { useAuthentication } from "./useAuthentication";
import { PageRoute, useCustomNavigate } from "./useCustomNavigate";

export const useLogin = ()=>{
    const [navigate] = useCustomNavigate();
    const authentication =  useAuthentication();
    const service = new AuthenticationService();
    const onSubmitAsync = async (data: LoginFormValues): Promise<void> => {

        await service.loginAsync(data).then(x => {
            authentication.authenticationAction({ type: "Login", user: x });
            
            localStorage.setItem("cms_user", x.jwtToken);
            ToastHelper.Success(`${x.name} ${x.surname} hoşgeldin.`);
            setTimeout(() => {
                navigate(PageRoute.Home);
            },100)
        }).catch(() => {
            authentication.authenticationAction({ type: "Logaut"});
            ToastHelper.Warning("Kullanıcı adı veya şifre yanlış.");
        });
    };

    return {onSubmitAsync}
}