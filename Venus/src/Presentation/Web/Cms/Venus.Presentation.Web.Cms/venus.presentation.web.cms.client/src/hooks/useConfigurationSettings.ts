import { useEffect } from "react"
import { ConfigurationSettingService } from "../services";


export function useConfigurationSettings() {

    useEffect(()=>{
        const configurationSetting = new ConfigurationSettingService();

        configurationSetting.getConfigurationSettings().then(x=>{
            
        })
    },[]);
}