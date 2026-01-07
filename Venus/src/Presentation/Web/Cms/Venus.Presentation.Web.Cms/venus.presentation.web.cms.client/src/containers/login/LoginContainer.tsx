import { type JSX } from "react";
import { LoginComponent, type LoginFormValues } from "../../components";
import { AuthenticationService } from "../../services";
import { PageRoute, useAuthentication, useCustomNavigate } from "../../hooks";
import { ToastHelper } from "../../helpers";


const LoginContainers = ():JSX.Element =>{
    const [navigate] = useCustomNavigate();
    const authentication =  useAuthentication();

    const onSubmitAsync = async (data: LoginFormValues): Promise<void> => {

        const service = new AuthenticationService();
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

    return (
        <>
            <LoginComponent onSubmitAsync={onSubmitAsync} ></LoginComponent>
        </>
    )
}

export default LoginContainers;