import React from 'react';
import { CKEditor } from '@ckeditor/ckeditor5-react';
import localeTr from 'ckeditor5/translations/tr.js';
import {
    ClassicEditor,
    AccessibilityHelp,
    Alignment, // Metin hizalama (sol, sağ, orta, iki yana yasla)
    Autoformat, // Yazarken otomatik formatlama (örn: * madde işareti yapar)
    AutoLink, // Link yazınca otomatik tıklanabilir yapar
    Autosave, // Otomatik kaydetme desteği
    BlockQuote, // Blok alıntı kutusu
    Bold, // Kalın yazı
    Code, // Satır içi kod (inline code)
    Essentials, // Olmazsa olmaz temel komutlar (Typing, Clipboard vb.)
    FindAndReplace, // Bul ve değiştir özelliği
    FontBackgroundColor, // Yazı arka plan rengi
    FontColor, // Yazı tipi rengi
    FontFamily, // Yazı tipi ailesi (Arial, Courier vb.)
    FontSize, // Yazı boyutu
    SourceEditing, // Kaynak kod butonu için
    GeneralHtmlSupport, // Ekstra HTML etiketlerine izin verir
    Heading, // Başlıklar (H1, H2, H3...)
    HorizontalLine, // Yatay ayırıcı çizgi
    ImageBlock, // Blok şeklinde resim (paragraf arası)
    ImageCaption, // Resim alt yazısı
    ImageInline, // Metin içi resim
    ImageInsert, // URL ile resim ekleme
    ImageInsertViaUrl, // Sadece URL üzerinden resim ekleme desteği
    ImageResize, // Resim boyutlandırma
    ImageStyle, // Resim hizalama stilleri (sola yasla, ortala vb.)
    ImageTextAlternative, // Resim alt (alt) metni
    ImageToolbar, // Resme tıklayınca açılan küçük araç çubuğu
    ImageUpload, // Resim yükleme desteği (Base64 veya Adapter gerektirir)
    Indent, // Girintiyi artır
    IndentBlock, // Paragrafı komple sağa/sola kaydır
    Italic, // Eğik yazı
    Link, // Link ekleme ve düzenleme
    LinkImage, // Resme link verme özelliği
    List, // Madde işaretli ve numaralı listeler
    ListProperties, // Liste stili değiştirme (örn: kare, roma rakamı)
    MediaEmbed, // Video (YouTube/Vimeo) gömme
    Paragraph, // Standart metin paragrafı
    RemoveFormat, // Seçili alanın tüm formatlarını temizler
    SelectAll, // Tümünü seç
    SpecialCharacters, // Özel karakterler (Ω, ©, ™ vb.)
    SpecialCharactersEssentials, // Temel özel karakter seti
    Strikethrough, // Üstü çizili yazı
    Subscript, // Alt simge
    Superscript, // Üst simge
    Table, // Tablo ekleme
    TableCaption, // Tablo başlığı
    TableCellProperties, // Tablo hücresi özellikleri (arka plan, kenarlık)
    TableColumnResize, // Tablo sütun genişliği ayarlama
    TableProperties, // Tablo genel özellikleri
    TableToolbar, // Tabloya tıklayınca açılan araç çubuğu
    TextTransformation, // Metin dönüşümleri (örn: (c) -> ©)
    Underline,
    Highlight, // Altı çizili yazı
    Undo // Geri al ve İleri al
} from 'ckeditor5';
import { Controller, type Control, type FieldError, type FieldValues, type Path, type UseFormRegisterReturn } from 'react-hook-form';



export interface HtmlEditorProps<T extends FieldValues>{
    formRegister?:UseFormRegisterReturn,
    fieldErrors?:FieldError,
    control:Control<T>,
    name:Path<T>
}


export const HtmlEditor = <T extends FieldValues>(props:HtmlEditorProps<T>)=>{

    return (
        <div style={{ padding: '20px' }}>

            <Controller
                name={props.name}
                control={props.control}
                render={({ field }) => (
                    <CKEditor
                        editor={ ClassicEditor }
                        onChange={(event,editor)=>{
                            console.log(editor.data);
                            field.onChange(editor.getData())
                        }}
                        onBlur={field.onBlur}
                        config={ {
                            licenseKey: 'GPL', // Ücretsiz kullanım anahtarı
                            language: 'tr',
                            translations: [ localeTr ],

                            // --- TÜM ÜCRETSİZ PLUGINLER ---
                            plugins: [
                                AccessibilityHelp, Alignment, Autoformat, AutoLink, Autosave, BlockQuote, Bold, Code,
                                Essentials, FindAndReplace, FontBackgroundColor, FontColor, FontFamily, FontSize,
                                GeneralHtmlSupport, Heading, Highlight, HorizontalLine, ImageBlock, ImageCaption, ImageInline,
                                ImageInsert, ImageInsertViaUrl, ImageResize, ImageStyle, ImageTextAlternative, ImageToolbar,
                                ImageUpload, Indent, IndentBlock, Italic, Link, LinkImage, List, ListProperties,
                                MediaEmbed, Paragraph, RemoveFormat, SelectAll, SourceEditing, SpecialCharacters, 
                                SpecialCharactersEssentials, Strikethrough, Subscript, Superscript, Table, TableCaption, 
                                TableCellProperties, TableColumnResize, TableProperties, TableToolbar, TextTransformation, 
                                Underline, Undo
                            ],

                            // --- TOOLBAR DİZİLİMİ (GRUPLANMIŞ) ---
                            toolbar: {
                                items: [
                                    'sourceEditing', // Kaynak Kod (<>)
                                    '|',
                                    'undo', 'redo',
                                    '|',
                                    'heading',
                                    '|',
                                    'fontFamily', 'fontSize', 'fontColor', 'fontBackgroundColor', 'highlight',
                                    '|',
                                    'bold', 'italic', 'underline', 'strikethrough', 'subscript', 'superscript', 'code', 'removeFormat',
                                    '|',
                                    'link', 'insertImageViaUrl', 'mediaEmbed', 'insertTable', 'blockQuote', 'specialCharacters', 'horizontalLine',
                                    '|',
                                    'alignment',
                                    '|',
                                    'bulletedList', 'numberedList', 'indent', 'outdent',
                                    '|',
                                    'findAndReplace', 'selectAll'
                                ],
                                shouldNotGroupWhenFull: true // Toolbar sığmazsa alt satıra geçer, gizlemez
                            },

                            // --- ÖZEL AYARLAR ---
                            
                            // 1. Resim Ayarları (URL ile ekleme aktif)
                            image: {
                                toolbar: [
                                    'toggleImageCaption', 'imageTextAlternative', '|',
                                    'imageStyle:inline', 'imageStyle:block', 'imageStyle:side', '|',
                                    'linkImage'
                                ],
                                insert: {
                                    type: 'auto' // Hem dosya seçme hem URL girişi sağlar
                                }
                            },

                            // 2. HTML Desteği (Yazdığınız hiçbir HTML silinmez)
                            htmlSupport: {
                                allow: [
                                    {
                                        name: /.*/,
                                        attributes: true,
                                        classes: true,
                                        styles: true
                                    }
                                ]
                            },

                            // 3. Tablo Ayarları
                            table: {
                                contentToolbar: [
                                    'tableColumn', 'tableRow', 'mergeTableCells', 'tableProperties', 'tableCellProperties'
                                ]
                            },

                            // 4. Başlıkları Türkçeleştirme
                            heading: {
                                options: [
                                    { model: 'paragraph', title: 'Paragraf', class: 'ck-heading_paragraph' },
                                    { model: 'heading1', view: 'h1', title: 'Başlık 1', class: 'ck-heading_heading1' },
                                    { model: 'heading2', view: 'h2', title: 'Başlık 2', class: 'ck-heading_heading2' },
                                    { model: 'heading3', view: 'h3', title: 'Başlık 3', class: 'ck-heading_heading3' }
                                ]
                            }
                        } }
                        data="<p></p>"
                    />
                )}
                />
           
            {props.fieldErrors && <p className="text-red-500 text-sm mt-1">{props.fieldErrors.message}</p>}
        </div>
    );
}