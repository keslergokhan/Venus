import React from "react";
import { useState, type JSX } from "react";
import type { useUrlPathControlResult } from "../../../hooks";
import type { FieldError, UseFormRegisterReturn } from "react-hook-form";


export interface UrlInputFieldProps {
    useUrlPathControl:useUrlPathControlResult,
    formRegister?:UseFormRegisterReturn,
    fieldErrors?:FieldError,
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
        props.formRegister?.onChange(e);
    };

    const onBlur = (e:React.FocusEvent<HTMLInputElement>) =>{
        props.useUrlPathControl.checkUrlHandler();
    }
    

    return (
    <div className="relative z-0 w-full group">
        <label className="block mb-2 text-sm font-medium text-gray-900">
            Url
        </label>
        
            <div className="flex bg-gray-50 border border-gray-300 text-sm rounded-lg focus:border-primary-300 focus:outline-none p-0.5 px-3">
                {props.useUrlPathControl.baseFullPath && <div className="p-2 text-right px-0">{props.useUrlPathControl.baseFullPath}</div>}
                <input
                    {...props.formRegister}
                    onBlur={onBlur}
                    onChange={handleChange}
                    type="text"
                    name="url"
                    id="url"
                    className="bg-gray-50 w-full pl-0 p-2 border-none focus:outline-none focus:ring-0 focus:border-transparent"
                    placeholder={"/"}
                    />
            </div>
        
        {props.useUrlPathControl.isUrlExists && <p className="text-red-500 text-sm mt-1">Adres zaten mevcut.</p>}
        {(props.useUrlPathControl.isUrlExists==false && props.useUrlPathControl?.getValue()?.length > 2) && <p className="text-green-500 text-sm mt-1">Adres kullanıma uygun.</p>}
        {props.fieldErrors && <p className="text-red-500 text-sm mt-1">{props.fieldErrors?.message}</p>}
    </div>)
    
    
}
