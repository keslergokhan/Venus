import { type JSX } from "react";
import { LoginComponent, type LoginFormValues } from "../../components";
import { useLogin } from "../../hooks/useLogin";


const LoginContainers = ():JSX.Element =>{
    
    const {onSubmitAsync} = useLogin();

    return (
        <>
            <LoginComponent onSubmitAsync={onSubmitAsync} ></LoginComponent>
        </>
    )
}

export default LoginContainers;