
export abstract class ServiceBase {

    protected GetFullPath = (path: string): string => {
        return `https://localhost:7002/api/${path}`;
    }
}