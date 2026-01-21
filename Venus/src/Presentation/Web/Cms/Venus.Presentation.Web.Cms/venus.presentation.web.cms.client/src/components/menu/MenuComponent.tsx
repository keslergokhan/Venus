import { useContext, useEffect, useState, type JSX } from "react";
import {
    Button,
    Dropdown,
    DropdownItem,
    MegaMenu,
    MegaMenuDropdown,
    NavbarBrand,
    NavbarCollapse,
    NavbarLink,
    NavbarToggle,
} from "flowbite-react";
import { NavLink } from "react-router-dom";
import { LanguageService } from "../../services";
import type { ReadLanguageDto } from "../../dtos";
import { ToastHelper } from "../../helpers";
import { AppContext } from "../../contexts/AppContext";

export interface MenuComponentProps {
}


export const MenuComponent = (): JSX.Element => {

    const languageService = new LanguageService();
    const [langaugeList,setLanguageList] = useState<Array<ReadLanguageDto>>(new Array<ReadLanguageDto>());
    const [language,setLanguage] = useState<string>("Türkçe");
    const appContext = useContext(AppContext);

    const languageOnChangeEvent = (language:string)=>{
        const selectLanguage = appContext.languageState.languages.find(x=>x.culture == language);
        if(selectLanguage){
            appContext.languageAction({type:"SetLanguage",language:language})
            setLanguage(selectLanguage.name);
        }else{
            ToastHelper.Error(<>Teknik bir sorun yaşandı, {language} mevcut değil !</>);
        }
    }

    useEffect(()=>{
        if(appContext.languageState.languages && appContext.languageState.languages.length <= 0){
            languageService.getLanguageAsync().then(x=>{
                setLanguageList(x);
                appContext.languageAction({"type":"SetLanguages",languages:x});
            }).catch(x=>{
                ToastHelper.DefaultCatchError(x);
            });
        }
        
    },[]);

    return (
        <MegaMenu className="shadow-lg">
            <NavbarBrand href="/">
                <img alt="" src="/favicon.svg" className="mr-3 h-6 sm:h-9" />
                <span className="self-center whitespace-nowrap text-xl font-semibold dark:text-white">Flowbite</span>
            </NavbarBrand>
            <div className="order-2 hidden items-center md:flex gap-2">
                <Dropdown label={language} inline >
                    {
                        langaugeList.map((x:ReadLanguageDto,i)=>{
                            return <DropdownItem key={i} onClick={()=>{languageOnChangeEvent(x.culture)}}>{x.name}</DropdownItem>
                        })
                    }
                </Dropdown>
                <Button href="#">Sign up</Button>
            </div>
            <NavbarToggle />
            <NavbarCollapse>
                <NavLink to="/home">Anasayfa</NavLink>
                <MegaMenuDropdown toggle={<>İşlemler</>}>
                    <ul className="grid grid-cols-3">
                        <div className="space-y-4 p-4">
                            <NavLink to="page-manager " className="group flex items-center hover:text-primary-600 dark:hover:text-primary-500">
                                <svg
                                    className="me-2 h-3 w-3 text-gray-400 group-hover:text-primary-600 dark:text-gray-500 dark:group-hover:text-primary-500"
                                    aria-hidden="true"
                                    xmlns="http://www.w3.org/2000/svg"
                                    fill="currentColor"
                                    viewBox="0 0 20 20"
                                >
                                    <path d="M10 .5a9.5 9.5 0 1 0 9.5 9.5A9.51 9.51 0 0 0 10 .5ZM9.5 4a1.5 1.5 0 1 1 0 3 1.5 1.5 0 0 1 0-3ZM12 15H8a1 1 0 0 1 0-2h1v-3H8a1 1 0 0 1 0-2h2a1 1 0 0 1 1 1v4h1a1 1 0 0 1 0 2Z" />
                                </svg>
                                Yeni Sayfa
                            </NavLink>
                        </div>
                        <div className="space-y-4 p-4">
                            <li>
                                <a href="#" className="group flex items-center hover:text-primary-600 dark:hover:text-primary-500">
                                    <svg
                                        className="me-2 h-3 w-3 text-gray-400 group-hover:text-primary-600 dark:text-gray-500 dark:group-hover:text-primary-500"
                                        aria-hidden="true"
                                        xmlns="http://www.w3.org/2000/svg"
                                        fill="currentColor"
                                        viewBox="0 0 20 20"
                                    >
                                        <path d="M19 4h-1a1 1 0 1 0 0 2v11a1 1 0 0 1-2 0V2a2 2 0 0 0-2-2H2a2 2 0 0 0-2 2v15a3 3 0 0 0 3 3h14a3 3 0 0 0 3-3V5a1 1 0 0 0-1-1ZM3 4a1 1 0 0 1 1-1h3a1 1 0 0 1 1 1v3a1 1 0 0 1-1 1H4a1 1 0 0 1-1-1V4Zm9 13H4a1 1 0 0 1 0-2h8a1 1 0 0 1 0 2Zm0-3H4a1 1 0 0 1 0-2h8a1 1 0 0 1 0 2Zm0-3H4a1 1 0 0 1 0-2h8a1 1 0 1 1 0 2Zm0-3h-2a1 1 0 0 1 0-2h2a1 1 0 1 1 0 2Zm0-3h-2a1 1 0 0 1 0-2h2a1 1 0 1 1 0 2Z" />
                                        <path d="M6 5H5v1h1V5Z" />
                                    </svg>
                                    Blog
                                </a>
                            </li>
                            <li>
                                <a href="#" className="group flex items-center hover:text-primary-600 dark:hover:text-primary-500">
                                    <svg
                                        className="me-2 h-3 w-3 text-gray-400 group-hover:text-primary-600 dark:text-gray-500 dark:group-hover:text-primary-500"
                                        aria-hidden="true"
                                        xmlns="http://www.w3.org/2000/svg"
                                        fill="currentColor"
                                        viewBox="0 0 20 20"
                                    >
                                        <path d="m17.418 3.623-.018-.008a6.713 6.713 0 0 0-2.4-.569V2h1a1 1 0 1 0 0-2h-2a1 1 0 0 0-1 1v2H9.89A6.977 6.977 0 0 1 12 8v5h-2V8A5 5 0 1 0 0 8v6a1 1 0 0 0 1 1h8v4a1 1 0 0 0 1 1h2a1 1 0 0 0 1-1v-4h6a1 1 0 0 0 1-1V8a5 5 0 0 0-2.582-4.377ZM6 12H4a1 1 0 0 1 0-2h2a1 1 0 0 1 0 2Z" />
                                    </svg>
                                    Newsletter
                                </a>
                            </li>
                            <li>
                                <a href="#" className="group flex items-center hover:text-primary-600 dark:hover:text-primary-500">
                                    <svg
                                        className="me-2 h-3 w-3 text-gray-400 group-hover:text-primary-600 dark:text-gray-500 dark:group-hover:text-primary-500"
                                        aria-hidden="true"
                                        xmlns="http://www.w3.org/2000/svg"
                                        fill="currentColor"
                                        viewBox="0 0 18 18"
                                    >
                                        <path d="M6.143 0H1.857A1.857 1.857 0 0 0 0 1.857v4.286C0 7.169.831 8 1.857 8h4.286A1.857 1.857 0 0 0 8 6.143V1.857A1.857 1.857 0 0 0 6.143 0Zm10 0h-4.286A1.857 1.857 0 0 0 10 1.857v4.286C10 7.169 10.831 8 11.857 8h4.286A1.857 1.857 0 0 0 18 6.143V1.857A1.857 1.857 0 0 0 16.143 0Zm-10 10H1.857A1.857 1.857 0 0 0 0 11.857v4.286C0 17.169.831 18 1.857 18h4.286A1.857 1.857 0 0 0 8 16.143v-4.286A1.857 1.857 0 0 0 6.143 10ZM17 13h-2v-2a1 1 0 0 0-2 0v2h-2a1 1 0 0 0 0 2h2v2a1 1 0 0 0 2 0v-2h2a1 1 0 0 0 0-2Z" />
                                    </svg>
                                    Playground
                                </a>
                            </li>
                            <li>
                                <a href="#" className="group flex items-center hover:text-primary-600 dark:hover:text-primary-500">
                                    <svg
                                        className="me-2 h-3 w-3 text-gray-400 group-hover:text-primary-600 dark:text-gray-500 dark:group-hover:text-primary-500"
                                        aria-hidden="true"
                                        xmlns="http://www.w3.org/2000/svg"
                                        fill="currentColor"
                                        viewBox="0 0 14 20"
                                    >
                                        <path d="M13.383.076a1 1 0 0 0-1.09.217L11 1.586 9.707.293a1 1 0 0 0-1.414 0L7 1.586 5.707.293a1 1 0 0 0-1.414 0L3 1.586 1.707.293A1 1 0 0 0 0 1v18a1 1 0 0 0 1.707.707L3 18.414l1.293 1.293a1 1 0 0 0 1.414 0L7 18.414l1.293 1.293a1 1 0 0 0 1.414 0L11 18.414l1.293 1.293A1 1 0 0 0 14 19V1a1 1 0 0 0-.617-.924ZM10 15H4a1 1 0 1 1 0-2h6a1 1 0 0 1 0 2Zm0-4H4a1 1 0 1 1 0-2h6a1 1 0 1 1 0 2Zm0-4H4a1 1 0 0 1 0-2h6a1 1 0 1 1 0 2Z" />
                                    </svg>
                                    License
                                </a>
                            </li>
                        </div>
                        <div className="space-y-4 p-4">
                            <li>
                                <a href="#" className="group flex items-center hover:text-primary-600 dark:hover:text-primary-500">
                                    <svg
                                        className="me-2 h-3 w-3 text-gray-400 group-hover:text-primary-600 dark:text-gray-500 dark:group-hover:text-primary-500"
                                        aria-hidden="true"
                                        xmlns="http://www.w3.org/2000/svg"
                                        fill="currentColor"
                                        viewBox="0 0 14 20"
                                    >
                                        <path d="M12 0H2a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h10a2 2 0 0 0 2-2V2a2 2 0 0 0-2-2ZM7.5 17.5h-1a1 1 0 0 1 0-2h1a1 1 0 0 1 0 2ZM12 13H2V4h10v9Z" />
                                    </svg>
                                    Contact Us
                                </a>
                            </li>
                            <li>
                                <a href="#" className="group flex items-center hover:text-primary-600 dark:hover:text-primary-500">
                                    <svg
                                        className="me-2 h-3 w-3 text-gray-400 group-hover:text-primary-600 dark:text-gray-500 dark:group-hover:text-primary-500"
                                        aria-hidden="true"
                                        xmlns="http://www.w3.org/2000/svg"
                                        fill="currentColor"
                                        viewBox="0 0 21 21"
                                    >
                                        <path d="m5.4 2.736 3.429 3.429A5.046 5.046 0 0 1 10.134 6c.356.01.71.06 1.056.147l3.41-3.412c.136-.133.287-.248.45-.344A9.889 9.889 0 0 0 10.269 1c-1.87-.041-3.713.44-5.322 1.392a2.3 2.3 0 0 1 .454.344Zm11.45 1.54-.126-.127a.5.5 0 0 0-.706 0l-2.932 2.932c.029.023.049.054.078.077.236.194.454.41.65.645.034.038.078.067.11.107l2.927-2.927a.5.5 0 0 0 0-.707Zm-2.931 9.81c-.024.03-.057.052-.081.082a4.963 4.963 0 0 1-.633.639c-.041.036-.072.083-.115.117l2.927 2.927a.5.5 0 0 0 .707 0l.127-.127a.5.5 0 0 0 0-.707l-2.932-2.931Zm-1.442-4.763a3.036 3.036 0 0 0-1.383-1.1l-.012-.007a2.955 2.955 0 0 0-1-.213H10a2.964 2.964 0 0 0-2.122.893c-.285.29-.509.634-.657 1.013l-.01.016a2.96 2.96 0 0 0-.21 1 2.99 2.99 0 0 0 .489 1.716c.009.014.022.026.032.04a3.04 3.04 0 0 0 1.384 1.1l.012.007c.318.129.657.2 1 .213.392.015.784-.05 1.15-.192.012-.005.02-.013.033-.018a3.011 3.011 0 0 0 1.676-1.7v-.007a2.89 2.89 0 0 0 0-2.207 2.868 2.868 0 0 0-.27-.515c-.007-.012-.02-.025-.03-.039Zm6.137-3.373a2.53 2.53 0 0 1-.35.447L14.84 9.823c.112.428.166.869.16 1.311-.01.356-.06.709-.147 1.054l3.413 3.412c.132.134.249.283.347.444A9.88 9.88 0 0 0 20 11.269a9.912 9.912 0 0 0-1.386-5.319ZM14.6 19.264l-3.421-3.421c-.385.1-.781.152-1.18.157h-.134c-.356-.01-.71-.06-1.056-.147l-3.41 3.412a2.503 2.503 0 0 1-.443.347A9.884 9.884 0 0 0 9.732 21H10a9.9 9.9 0 0 0 5.044-1.388 2.519 2.519 0 0 1-.444-.348ZM1.735 15.6l3.426-3.426a4.608 4.608 0 0 1-.013-2.367L1.735 6.4a2.507 2.507 0 0 1-.35-.447 9.889 9.889 0 0 0 0 10.1c.1-.164.217-.316.35-.453Zm5.101-.758a4.957 4.957 0 0 1-.651-.645c-.033-.038-.077-.067-.11-.107L3.15 17.017a.5.5 0 0 0 0 .707l.127.127a.5.5 0 0 0 .706 0l2.932-2.933c-.03-.018-.05-.053-.078-.076ZM6.08 7.914c.03-.037.07-.063.1-.1.183-.22.384-.423.6-.609.047-.04.082-.092.129-.13L3.983 4.149a.5.5 0 0 0-.707 0l-.127.127a.5.5 0 0 0 0 .707L6.08 7.914Z" />
                                    </svg>
                                    Support Center
                                </a>
                            </li>
                            <li>
                                <a href="#" className="group flex items-center hover:text-primary-600 dark:hover:text-primary-500">
                                    <svg
                                        className="me-2 h-3 w-3 text-gray-400 group-hover:text-primary-600 dark:text-gray-500 dark:group-hover:text-primary-500"
                                        aria-hidden="true"
                                        xmlns="http://www.w3.org/2000/svg"
                                        fill="currentColor"
                                        viewBox="0 0 18 20"
                                    >
                                        <path d="M16 1h-3.278A1.992 1.992 0 0 0 11 0H7a1.993 1.993 0 0 0-1.722 1H2a2 2 0 0 0-2 2v15a2 2 0 0 0 2 2h14a2 2 0 0 0 2-2V3a2 2 0 0 0-2-2Zm-3 14H5a1 1 0 0 1 0-2h8a1 1 0 0 1 0 2Zm0-4H5a1 1 0 0 1 0-2h8a1 1 0 1 1 0 2Zm0-5H5a1 1 0 0 1 0-2h2V2h4v2h2a1 1 0 1 1 0 2Z" />
                                    </svg>
                                    Terms
                                </a>
                            </li>
                        </div>
                    </ul>
                </MegaMenuDropdown>
                <NavbarLink href="#">Team</NavbarLink>
            </NavbarCollapse>
        </MegaMenu>
    );
}