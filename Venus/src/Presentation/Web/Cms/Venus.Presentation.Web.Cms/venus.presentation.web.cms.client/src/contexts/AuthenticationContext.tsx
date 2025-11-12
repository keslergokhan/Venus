import { createContext, useReducer } from "react";
import type { JSX } from "react/jsx-runtime";
import { AuthenticationReducer, type AuthenticationReducerAction, type AuthenticationReducerState } from "../reducers/AuthenticationReducer";



export class AuthenticationContextProps {
    authenticationState: AuthenticationReducerState;
    authenticationAction:React.Dispatch<AuthenticationReducerAction>;
}

export const AuthenticationContext = createContext<AuthenticationContextProps>(new AuthenticationContextProps());

export const AuthenticationContextProvider = ({ children }: { children: React.ReactNode }): JSX.Element => {

    const reducerState: AuthenticationReducerState = {
        isAuth: false,
        user:null
    }

    const [state, dispatch] = useReducer(AuthenticationReducer, reducerState);


    return (
        <AuthenticationContext.Provider value={{ authenticationState: state, authenticationAction: dispatch }}>
            {children}
        </AuthenticationContext.Provider>
    );

}