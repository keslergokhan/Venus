import { useEffect } from "react"
import { ConfigurationSettingService } from "../services";


export const useConfigurationSettings = ()=>{

    useEffect(()=>{
        const configurationSetting = new ConfigurationSettingService();

        configurationSetting.getConfigurationSettings().then(x=>{
            
        })
    },[]);
}