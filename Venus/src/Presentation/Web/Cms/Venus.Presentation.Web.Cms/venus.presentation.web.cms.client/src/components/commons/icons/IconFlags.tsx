import type { IconPropsBase } from "../base/IconPropsBase"

interface FlagProps extends IconPropsBase{
    culture:string
}

export const IconFlag = (props:FlagProps)=>{
    if(props.culture == "tr-TR"){
        return <svg xmlns="http://www.w3.org/2000/svg" {...props} viewBox="0 0 512 512"><mask id="SVGuywqVbel"><circle cx={256} cy={256} r={256} fill="#fff"></circle></mask><g mask="url(#SVGuywqVbel)"><path fill="#d80027" d="M0 0h512v512H0z"></path><g fill="#eee"><path d="m350 182l33 46l54-18l-33 46l33 46l-54-18l-33 46v-57l-54-17l54-18z"></path><path d="M260 370a114 114 0 1 1 54-215a141 141 0 1 0 0 202c-17 9-35 13-54 13"></path></g></g></svg>
    }else if(props.culture == "en-US"){
        return <svg xmlns="http://www.w3.org/2000/svg" {...props} viewBox="0 0 512 512"><mask id="circleFlagsEn0"><circle cx={256} cy={256} r={256} fill="#fff"></circle></mask><g mask="url(#circleFlagsEn0)"><path fill="#eee" d="m0 0l8 22l-8 23v23l32 54l-32 54v32l32 48l-32 48v32l32 54l-32 54v68l22-8l23 8h23l54-32l54 32h32l48-32l48 32h32l54-32l54 32h68l-8-22l8-23v-23l-32-54l32-54v-32l-32-48l32-48v-32l-32-54l32-54V0l-22 8l-23-8h-23l-54 32l-54-32h-32l-48 32l-48-32h-32l-54 32L68 0z"></path><path fill="#0052b4" d="M336 0v108L444 0Zm176 68L404 176h108zM0 176h108L0 68ZM68 0l108 108V0Zm108 512V404L68 512ZM0 444l108-108H0Zm512-108H404l108 108Zm-68 176L336 404v108z"></path><path fill="#d80027" d="M0 0v45l131 131h45zm208 0v208H0v96h208v208h96V304h208v-96H304V0zm259 0L336 131v45L512 0zM176 336L0 512h45l131-131zm160 0l176 176v-45L381 336z"></path></g></svg>
    }
}