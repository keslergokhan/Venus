import { useContext, useEffect } from "react"
import { ConfigurationSettingService } from "../services";
import type { ReadConfigurationSettingDto } from "../dtos";
import { SessionStorageHelper, SessionKeys, ToastHelper } from "../helpers";
import { AuthenticationContext } from "../contexts/AuthenticationContext";


export function useConfigurationSettings():{configurationSettings:ReadConfigurationSettingDto[]|null} {

    const configurationSetting = new ConfigurationSettingService();
    const autContext = useContext(AuthenticationContext);
    async function getConfiguration(){
        try{
            if(!autContext.authenticationState.isAuth)
                return;

            if(!SessionStorageHelper.has(SessionKeys.configurationSettings)){
                const configurationAll = await configurationSetting.getConfigurationSettings();
                SessionStorageHelper.set<ReadConfigurationSettingDto[]>(SessionKeys.configurationSettings,configurationAll);
            }
        }catch(err){
            ToastHelper.DefaultCatchError(err);
        }
    }

    useEffect(()=>{
        getConfiguration();
    },[]);

    return {configurationSettings:SessionStorageHelper.get<ReadConfigurationSettingDto[]>(SessionKeys.configurationSettings)}
}