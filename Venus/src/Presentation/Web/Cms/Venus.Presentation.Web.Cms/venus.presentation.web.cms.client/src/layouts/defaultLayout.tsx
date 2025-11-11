import { useContext, useEffect, type JSX } from "react";
import { Outlet, useNavigate } from "react-router-dom";
import { AuthenticationContext } from "../contexts/AuthenticationContext";

const DefaultLayout = (): JSX.Element => {
    const navigate = useNavigate();
    const context = useContext(AuthenticationContext);

    useEffect(() => {
        console.log("calis");
        console.log(context.IsAuth);
        if (!context.IsAuth) {
            
            console.log("yönlendir");
            navigate("/login");
        }
    });

    if (!context.IsAuth) {
        return (<>Yükleniyor...</>);
    }
    return (
        <>
            <p>header</p>
            <Outlet />
            <p>footer</p>
        </>
    );
}

export default DefaultLayout;