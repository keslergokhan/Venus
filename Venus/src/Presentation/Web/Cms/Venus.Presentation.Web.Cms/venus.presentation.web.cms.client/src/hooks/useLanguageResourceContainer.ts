import { useRef, useState } from "react";
import type { ReadLanguageDto } from "../dtos";

interface useLanguageResourceContainerResult {

}

export const useLanguageResourceContainer = ():useLanguageResourceContainerResult =>{

    const languageList = useRef<ReadLanguageDto[]>([]);
    const [languageResourceList,setLanguageResourceList] = useState<ReadLanguageDto[]>();
    return {};
}