import toast from "react-hot-toast";
import type { ReadUserDto } from "../dtos";
import type { LoginFormRequest } from "../models";
import { ResultDataControl, type IResultDataControl } from "../results";
import { ServiceBase } from "./base/ServiceBase";
import axios from "axios";

export class AuthenticationService extends ServiceBase{

    public loginAsync = async (props: LoginFormRequest): Promise<IResultDataControl<ReadUserDto>> => {

        var data = new ResultDataControl<ReadUserDto>();

        axios.post<IResultDataControl<ReadUserDto>>("https://localhost:7002/api/Authentication/Login", props, { withCredentials: true }).then(x => {
            if (x.data.isSuccess) {
                localStorage.setItem("cms_user", x.data.data.jwtToken)
                toast("Merhaba dünya");
            } else {

            }
            
        }).catch(x => {
            console.log(x);
        })

        return data;
    }
}