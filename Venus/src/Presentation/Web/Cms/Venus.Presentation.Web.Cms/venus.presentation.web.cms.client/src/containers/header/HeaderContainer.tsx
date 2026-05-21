import { MenuComponent } from "../../components"
import { useMenuLanguage } from "../../hooks";

function HeaderContainer(){
    
    const {onChangeEvent,languages,currentLanguage} = useMenuLanguage();
    
    return (
        <MenuComponent currentLanguage={currentLanguage} languages={languages} onChangeEvent={onChangeEvent}></MenuComponent>
    )
}

export default HeaderContainer;