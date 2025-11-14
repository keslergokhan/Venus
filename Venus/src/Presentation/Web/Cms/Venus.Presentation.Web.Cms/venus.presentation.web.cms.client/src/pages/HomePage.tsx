import { useContext, useEffect, type JSX } from "react";
import { AuthenticationContext } from "../contexts/AuthenticationContext";

const HomePage = (): JSX.Element => {

    const autContext = useContext(AuthenticationContext);

    useEffect(() => {
        console.log(autContext.authenticationState);
    })
    return (
        <>
        </>
    )
}

export default HomePage;