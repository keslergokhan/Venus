import type { ReadConfigurationSettingDto } from "../dtos";
import { ServiceBase } from "./base/ServiceBase";

export class ConfigurationSettingService extends ServiceBase{
    getConfigurationSettings() {
        return super.getAll<ReadConfigurationSettingDto>("ConfigurationSetting/get-all")
    }
}