import type { ReadUserDto } from "../dtos";
import type { LoginFormRequest, LoginValidationReuqest } from "../models";
import { ResultDataControl, type IResultDataControl } from "../results";
import { ServiceBase } from "./base/ServiceBase";
import axios from "axios";

export class AuthenticationService extends ServiceBase{

    public userJwtToken = ():string|null => {
        return localStorage.getItem("cms_user");
    }

    public loginAsync = async (props: LoginFormRequest): Promise<IResultDataControl<ReadUserDto>> => {

        return axios.post<IResultDataControl<ReadUserDto>>(this.GetFullPath("Authentication/Login"), props, { withCredentials: true })
            .then(data => {

                return data.data as ResultDataControl<ReadUserDto>;
            
            }).catch(() => {
                return new ResultDataControl<ReadUserDto>();
            });
    }

    public loginValidation = async (props: LoginValidationReuqest) => {
        return axios.post<IResultDataControl<ReadUserDto>>(this.GetFullPath("Authentication/Validate"),
            null,  // ? Request body yoksa null veya boþ obje
            {
                headers: {
                    'Authorization': `Bearer ${props.userJwt}`,
                },
                withCredentials: true
            })
            .then(data => {
                return data.data as ResultDataControl<ReadUserDto>;
            }).catch(() => {
                return new ResultDataControl<ReadUserDto>();
            })
    }
}