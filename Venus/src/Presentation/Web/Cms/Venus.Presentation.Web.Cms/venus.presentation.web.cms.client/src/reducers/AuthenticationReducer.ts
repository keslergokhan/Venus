import type { ReadUserDto } from "../dtos";
import { AuthenticationService } from "../services";

export type AuthenticationReducerAction =
    | { type: "Login", user: ReadUserDto }
    | { type: "Logaut" }
    | { type: "Control"}

export interface AuthenticationReducerState {
    user: ReadUserDto|null;
    isAuth: boolean;
}

export const AuthenticationReducer = (state: AuthenticationReducerState,action: AuthenticationReducerAction): AuthenticationReducerState => {

    const service = new AuthenticationService();
    const actionType = action.type;

    if (actionType == "Login") {
        return { isAuth: true, user: action.user };
    }
    else if (actionType == "Logaut") {
        localStorage.removeItem("cms_user");
        return { isAuth: false, user: null };
    }

    return { isAuth:false,user:null };
}