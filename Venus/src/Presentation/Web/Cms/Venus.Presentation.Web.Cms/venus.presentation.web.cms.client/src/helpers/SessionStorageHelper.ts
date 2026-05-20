

export class SessionStorageHelper {
    private static isBrowser(): boolean {
        return typeof window !== "undefined";
    }

    static set<T>(key: string, value: T): void {
        if (!this.isBrowser()) return;

        try {
            const serializedValue = JSON.stringify(value);
            sessionStorage.setItem(key, serializedValue);
        } catch (error) {
            console.error(`SessionStorage set error (${key})`, error);
        }
    }

    static get<T>(key: string): T | null {
        if (!this.isBrowser()) return null;

        try {
            const item = sessionStorage.getItem(key);

            if (!item) return null;

            return JSON.parse(item) as T;
        } catch (error) {
            console.error(`SessionStorage get error (${key})`, error);
            return null;
        }
    }

    static remove(key: string): void {
        if (!this.isBrowser()) return;

        try {
            sessionStorage.removeItem(key);
        } catch (error) {
            console.error(`SessionStorage remove error (${key})`, error);
        }
    }

    static clear(): void {
        if (!this.isBrowser()) return;

        try {
            sessionStorage.clear();
        } catch (error) {
            console.error("SessionStorage clear error", error);
        }
    }

    static has(key: string): boolean {
        if (!this.isBrowser()) return false;

        return sessionStorage.getItem(key) !== null;
    }
}