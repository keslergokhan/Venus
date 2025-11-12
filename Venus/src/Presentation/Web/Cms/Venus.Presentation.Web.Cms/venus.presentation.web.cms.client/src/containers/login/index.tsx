import {  useContext, type JSX } from "react";
import { LoginComponent, type LoginFormValues } from "../../components";
import { AuthenticationService } from "../../services";
import { ToastHelper } from "../../helpers/ToastHelper";
import { AuthenticationContext } from "../../contexts/AuthenticationContext";


const LoginContainers = ():JSX.Element =>{


    const autContext = useContext(AuthenticationContext);

    const onSubmitAsync = async (data: LoginFormValues): Promise<void> => {

        const service = new AuthenticationService();
        await service.loginAsync(data).then(x => {
            autContext.authenticationAction({ type: "Login", user: x.data });
            
            localStorage.setItem("cms_user", x.data.jwtToken);
            ToastHelper.Success(`${x.data.name} ${x.data.surname} hoşgeldin.`);
        }).catch(() => {
            autContext.authenticationAction({ type: "Logaut"});
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