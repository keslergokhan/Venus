import type { ReadUserDto } from "../dtos";
import type { LoginFormRequest} from "../models";
import { ServiceBase } from "./base/ServiceBase";
import axios from "axios";

export class AuthenticationService extends ServiceBase{

    public loginAsync = (props: LoginFormRequest): Promise<ReadUserDto> => {

        return axios.post<ReadUserDto>(this.GetFullPath("Authentication/Login"), props, { withCredentials: true })
            .then(data => {

                return data.data as ReadUserDto;
            
            })
    }

    public loginValidationAsync = () : Promise<ReadUserDto> => {
        return axios.post<ReadUserDto>(this.GetFullPath("Authentication/Validate"),{},this.GetAxiosHeader())
            .then(data => {
                return data.data as ReadUserDto;
            })
    }
}