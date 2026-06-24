import type { ReadWidgetDto } from "../dtos/widgets/ReadWidgetDto";
import { ServiceBase } from "./base/ServiceBase";

export class WidgetService extends ServiceBase{
    getWidgets(){
        return super.getAll<ReadWidgetDto>("widget/get-all"); 
    }

    updateWidget(data:ReadWidgetDto){
        return super.post<ReadWidgetDto>("widget/update",data);
    }
}