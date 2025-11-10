import { useEffect, type JSX } from "react";
import { LoginComponent, type LoginFormValues } from "../../components";
import { AuthenticationService } from "../../services";
import toast from "react-hot-toast";
import { ToastHelper } from "../../helpers/ToastHelper";


const LoginContainers = ():JSX.Element =>{

    useEffect(() => {
        ToastHelper.Success("Merhaba");
    },[])
    
    const onSubmitAsync = async (data: LoginFormValues): Promise<void> => {

        const service = new AuthenticationService();
        await service.loginAsync(data).then(x => {
            console.log(x);
        });
    };

    return (
        <>
            <LoginComponent onSubmitAsync={onSubmitAsync} ></LoginComponent>
        </>
    )
}

export default LoginContainers;