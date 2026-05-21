import type { ReadUserDto } from "../dtos";
import { SessionKeys, SessionStorageHelper } from "../helpers";

export type AuthenticationReducerAction =
    | { type: "Login", user: ReadUserDto }
    | { type: "Logaut" }
    | { type: "Control"}

export interface AuthenticationReducerState {
    user: ReadUserDto|null;
    isAuth: boolean;
}

export function AuthenticationReducer(state: AuthenticationReducerState,action: AuthenticationReducerAction): AuthenticationReducerState {

    const actionType = action.type;

    if (actionType == "Login") {
        return { isAuth: true, user: action.user };
    }
    else if (actionType == "Logaut") {
        SessionStorageHelper.get<string>(SessionKeys.cmsUser);
        return { isAuth: false, user: null };
    }

    return { isAuth:false,user:null };
}