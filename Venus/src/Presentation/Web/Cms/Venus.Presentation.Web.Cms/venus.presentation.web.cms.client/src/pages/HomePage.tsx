import { useContext, type JSX } from "react";
import { AuthenticationContext } from "../contexts/AuthenticationContext";

const LoginPage = (): JSX.Element => {

    const context = useContext(AuthenticationContext);


    return (
        <>
            <button onClick={() => { context.logaut() }}>Çýk buradan</button>
            anasayfa
        </>
    )
}

export default LoginPage;