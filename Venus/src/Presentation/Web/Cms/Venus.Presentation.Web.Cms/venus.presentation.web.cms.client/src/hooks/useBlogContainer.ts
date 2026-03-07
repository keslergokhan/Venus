import type { ReadBlogDto } from "../dtos"


export const useBlogContainer = ():{blogs:Array<ReadBlogDto>} =>{

    const blogs = [
        {id:"FSDF",description:"AÇIKLAMA",jsonData:"{}",title:"Başlık",urlId:"/url"},
        {id:"FSDF",description:"AÇIKLAMA",jsonData:"{}",title:"Başlık sdfsdf",urlId:"/url"},
        {id:"FSDF",description:"AÇIKLAMA",jsonData:"{}",title:"aaaaaa",urlId:"/url"}
    ] as Array<ReadBlogDto>
    
    return {blogs:blogs}
}