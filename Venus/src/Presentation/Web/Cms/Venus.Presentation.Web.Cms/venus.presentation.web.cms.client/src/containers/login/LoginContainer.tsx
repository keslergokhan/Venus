import { type JSX } from "react";
import { LoadingComponent, LoginComponent } from "../../components";
import { useLogin } from "../../hooks/useLogin";


const LoginContainers = ():JSX.Element =>{
    
    const {onSubmitAsync,loadingState} = useLogin();

    return (
        <div className="min-h-[500px] mt-[100px]">
            <LoadingComponent loading={loadingState} size="xl">
                <LoginComponent onSubmitAsync={onSubmitAsync} ></LoginComponent>
            </LoadingComponent>
        </div>
        
    )
}

export default LoginContainers;