import type { ReadBlogDto, ReadPageDto } from "../dtos";
import { ServiceBase } from "./base/ServiceBase";

export class BlogService extends ServiceBase {

    getBlogs = () => {
        return this.getAll<ReadBlogDto>("blog/get-all");
    }

    removeBlog = (id:string) =>{
        return this.remove("blog/remove",id);
    }

    getBlogPage = () => {
        return this.get<ReadPageDto>("blog/get-page")
    }

    getBlogById = (id:string) => {
        return this.getById<ReadBlogDto>("blog/get",id);
    }

    updateBlog = (request:Record<string, any>) =>{
        return this.updateDynamicData<ReadBlogDto>("blog/update",request);
    }

    addBlog = (request:Record<string, any>) => {
        return this.addDynamicData("blog/create",request);
    }

    toggleState = (id:string) => {
        return this.post("blog/toggle-blog-state",id);
    }
}