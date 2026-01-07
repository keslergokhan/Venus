export interface IResultControl {
    isSuccess: boolean;
    errorMessage:string;
    errorCode:string;
    Success(): IResultControl;
    Fail(): IResultControl
}

export interface IResultDataControl<T> extends IResultControl {
    data: T;
    SetData(data: T): IResultDataControl<T>;
    SetSuccessData(data: T): IResultDataControl<T>;
}

export abstract class ResultControlBase implements IResultControl {
    public isSuccess: boolean;
    public errorMessage:string;
    public errorCode:string;
    /**
     *
     */
    constructor() {
        this.isSuccess = false;
    }
    public Success(): IResultControl {
        this.isSuccess = true;
        return this;
    }

    public Fail(): IResultControl {
        this.isSuccess = false;
        return this;
    }
}