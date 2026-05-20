import type { ReadBlogDto, ReadPageDto } from "../dtos";
import { ServiceBase } from "./base/ServiceBase";

export class BlogService extends ServiceBase {

    getBlogs(){
        return super.getAll<ReadBlogDto>("blog/get-all");
    }

    removeBlog(id:string){
        return super.remove("blog/remove",id);
    }

    getBlogPage(){
        return super.get<ReadPageDto>("blog/get-page")
    }

    getBlogById(id:string){
        return super.getById<ReadBlogDto>("blog/get",id);
    }

    updateBlog(request:Record<string, any>){
        return super.updateDynamicData<ReadBlogDto>("blog/update",request);
    }

    addBlog(request:Record<string, any>){
        return super.addDynamicData("blog/create",request);
    }

    toggleState(id:string){
        return super.post("blog/toggle-blog-state",id);
    }
}