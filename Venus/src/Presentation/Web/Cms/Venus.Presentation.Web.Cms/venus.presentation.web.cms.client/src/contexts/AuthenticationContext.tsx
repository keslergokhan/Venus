import { createContext, useReducer } from "react";
import type { JSX } from "react/jsx-runtime";
import { AuthenticationReducer, type AuthenticationReducerAction, type AuthenticationReducerState } from "../reducers/AuthenticationReducer";
import { LanguageReducerReducer, type LanguageReducerAction, type LanguageReducerState } from "../reducers/LanguageReducer";



export class AuthenticationContextProps {
    authenticationState: AuthenticationReducerState;
    authenticationAction:React.Dispatch<AuthenticationReducerAction>;
    languageState:LanguageReducerState;
    languageAction:React.Dispatch<LanguageReducerAction>;
}

export const AuthenticationContext = createContext<AuthenticationContextProps>(new AuthenticationContextProps());

export const AuthenticationContextProvider = ({ children }: { children: React.ReactNode }): JSX.Element => {

    const authReducerState: AuthenticationReducerState = {
        isAuth: false,
        user:null
    }

    const languageReducerState:LanguageReducerState = {
        language:"tr-TR",
    }

    const [authState, authdispatch] = useReducer(AuthenticationReducer, authReducerState);
    const [languageState,languageDispatch] = useReducer(LanguageReducerReducer,languageReducerState);

    const contextValue = { 
        authenticationState: authState, 
        authenticationAction: authdispatch,
        languageState : languageReducerState,
        languageAction :languageDispatch,
    } as AuthenticationContextProps;

    return (
        <AuthenticationContext.Provider value={contextValue}>
            {children}
        </AuthenticationContext.Provider>
    );

}