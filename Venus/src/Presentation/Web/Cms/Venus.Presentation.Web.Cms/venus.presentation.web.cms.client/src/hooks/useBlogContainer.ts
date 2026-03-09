import type { ReadBlogDto } from "../dtos"


export const useBlogContainer = ():{blogs:Array<ReadBlogDto>,removenOnHandler:(data:ReadBlogDto)=>void,updateOnHandler:(data:ReadBlogDto)=>void} =>{

    const removenOnHandler = (data:ReadBlogDto) =>{
        alert("sil");
    }

    const updateOnHandler = (data:ReadBlogDto)=>{
        alert("detay");
    }

    const blogs = [
        {id:"FSDF",description:"AÇIKLAMA",jsonData:"{}",title:"Başlık",urlId:"/url"},
        {id:"FSDF",description:"AÇIKLAMA",jsonData:"{}",title:"Başlık sdfsdf",urlId:"/url"},
        {id:"FSDF",description:"AÇIKLAMA",jsonData:"{}",title:"aaaaaa",urlId:"/url"},
        {id:"FSDF",description:"AÇIKLAMA",jsonData:"{}",title:"aaaaaa",urlId:"/url"},
        {id:"FSDF",description:"AÇIKLAMA",jsonData:"{}",title:"aaaaaa",urlId:"/url"},
        {id:"FSDF",description:"AÇIKLAMA",jsonData:"{}",title:"aaaaaa",urlId:"/url"}
    ] as Array<ReadBlogDto>
    
    return {blogs:blogs,removenOnHandler:removenOnHandler,updateOnHandler:updateOnHandler}
}