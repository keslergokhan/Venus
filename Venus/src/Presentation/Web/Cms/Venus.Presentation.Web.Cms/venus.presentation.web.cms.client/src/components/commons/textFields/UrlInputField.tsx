import React from "react";
import { useState, type JSX } from "react";
import type { useUrlPathControlResult } from "../../../hooks";


export interface UrlInputFieldProps {
    useUrlPathControl:useUrlPathControlResult
}

export const UrlInputField = (props:UrlInputFieldProps):JSX.Element => {

    const toUrlFormat = (text: string): string => {
        if (!text) return "/";
      
        let formatted = text
          .toLowerCase()
          .trimStart() // baştaki boşluğu engelle
          // Türkçe karakterler
          .replace(/ğ/g, "g")
          .replace(/ü/g, "u")
          .replace(/ş/g, "s")
          .replace(/ı/g, "i")
          .replace(/ö/g, "o")
          .replace(/ç/g, "c")
          // SADECE boşlukları tire yap
          .replace(/ /g, "-")
          // izin verilen karakterler
          .replace(/[^a-z0-9\-\/?&=]/g, "")
          // art arda gelen tireleri tek yap
          .replace(/-+/g, "-")
          // art arda gelen slashleri tek yap
          .replace(/\/+/g, "/");
      
        // başında slash yoksa ekle
        if (!formatted.startsWith("/")) {
          formatted = "/" + formatted;
        }
      
        return formatted;
    };

    const handleChange = (e:React.ChangeEvent<HTMLInputElement>) => {
        props.useUrlPathControl.setValue(toUrlFormat(e.target.value));
    };

    

    return (
    <div className="relative z-0 w-full group">
        <label className="block mb-2 text-sm font-medium text-gray-900 text-blue-950">
            Url
        </label>
        <input
        onChange={handleChange}
        type="text"
        name="path"
        value={props.useUrlPathControl.url}
        id="path"
        className="bg-gray-50 border border-gray-300 text-sm rounded-lg focus:border-primary-300 focus:outline-none block w-full p-2.5"
        placeholder={"/"}
        />
         {props.useUrlPathControl.isUrlExists && <p className="text-red-500 text-sm mt-1">Adres zaten mevcut.</p>}
    </div>)
    
    
}
