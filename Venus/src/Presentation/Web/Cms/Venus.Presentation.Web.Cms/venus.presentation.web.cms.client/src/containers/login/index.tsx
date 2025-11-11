import { useContext, type JSX } from "react";
import { LoginComponent, type LoginFormValues } from "../../components";
import { AuthenticationService } from "../../services";
import { ToastHelper } from "../../helpers/ToastHelper";
import { AuthenticationContext } from "../../contexts/AuthenticationContext";
import { useNavigate } from "react-router-dom";


const LoginContainers = ():JSX.Element =>{

    const context = useContext(AuthenticationContext);
    const navigate = useNavigate();

    const onSubmitAsync = async (data: LoginFormValues): Promise<void> => {

        const service = new AuthenticationService();
        await service.loginAsync(data).then(x => {
            context.login();
            navigate("/home");
            ToastHelper.Success(`${x.data.name} ${x.data.surname} hoşgeldin.`);
        }).catch(() => {
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