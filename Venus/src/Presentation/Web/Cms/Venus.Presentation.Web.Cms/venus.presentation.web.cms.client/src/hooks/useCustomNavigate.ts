import { useNavigate } from "react-router-dom"


export enum PageRoute {
    Login = "/login",
    Home="/home"
}

export const useCustomNavigate = (): [(route: PageRoute)=>void] => {
    const navigate = useNavigate();

    const navigateHandler = (route: PageRoute) => {
        navigate(route);
    };

    return [navigateHandler]
}