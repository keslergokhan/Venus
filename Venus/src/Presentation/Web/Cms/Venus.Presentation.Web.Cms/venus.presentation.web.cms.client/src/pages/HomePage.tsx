import { useContext, useEffect, type JSX } from "react";
import { AuthenticationContext } from "../contexts/AuthenticationContext";

const LoginPage = (): JSX.Element => {

    const autContext = useContext(AuthenticationContext);

    useEffect(() => {
        console.log(autContext.authenticationState);
    })
    return (
        <>
            <button onClick={() => { autContext.authenticationAction({ type: "Logaut" }); }}>Çýk buradan</button>
            anasayfa
        </>
    )
}

export default LoginPage;