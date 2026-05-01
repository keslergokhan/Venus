export abstract class DtoBase{
    id:string;
}

export abstract class DynamicPropertiesDtoBase extends DtoBase{
    dynamicProperties:string;
    public getFlattenedData = <T>(): T => {
        // null/undefined ve boş string kontrolünü daha kısa yapabiliriz
        if (this.dynamicProperties) {
            try {
                const dynamicPropertiesObject = JSON.parse(this.dynamicProperties);
                return { ...dynamicPropertiesObject, ...this } as T; 
            } catch (error) {
                console.error("Nesne birleştirilme aşamasında problem yaşandı!", error);
            }
        }
        // Eğer veri yoksa boş obje yerine mevcut alanları (this) dönmek daha mantıklı olabilir
        return { ...this } as unknown as T;
    }
}