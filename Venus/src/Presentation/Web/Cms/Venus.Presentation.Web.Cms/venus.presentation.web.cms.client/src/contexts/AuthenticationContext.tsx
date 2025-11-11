import { createContext } from "react";

export class AuthenticationContextProps {
    IsAuth: boolean;
    login: () => void;
    logaut: () => void;
}
export const AuthenticationContext = createContext<AuthenticationContextProps>(new AuthenticationContextProps());