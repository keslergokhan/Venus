import type { ReadUserDto } from "../dtos";
import type { LoginFormRequest } from "../models";
import { ResultDataControl, type IResultDataControl } from "../results";
import { ServiceBase } from "./base/ServiceBase";
import axios from "axios";

export class AuthenticationService extends ServiceBase{

    public loginAsync = async (props: LoginFormRequest): Promise<IResultDataControl<ReadUserDto>> => {

        return axios.post<IResultDataControl<ReadUserDto>>("https://localhost:7002/api/Authentication/Login", props, { withCredentials: true })
            .then(data => {

                return data.data as ResultDataControl<ReadUserDto>;
            
            }).catch(() => {
                return new ResultDataControl<ReadUserDto>();
            });
    }
}