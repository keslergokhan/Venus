import type { JSX } from "react"
import { FileManagerInputComponent } from "../../components/fileManager/FileManagerInputComponent";
import { HtmlEditor } from "../../components";
import {z} from "zod";
import { useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import { required } from "zod/v4-mini";

const HomeContainers = ():JSX.Element =>{

    const schema = z.object({
        htmlContent:z.string().min(50,"Lütfen biraz daha içeri giriniz")
    });

    type formValues = z.infer<typeof schema>;

    const {
        register,
        control,
        handleSubmit,
        setValue,
        getValues,
        formState:{errors}
    } = useForm<formValues>({resolver:zodResolver(schema),defaultValues:{htmlContent:""}});
    

    const onSubmit = (data:formValues) =>{
        console.log(data);
    }

    return (<>
        <FileManagerInputComponent></FileManagerInputComponent>
        <form className="space-y-6" onSubmit={handleSubmit(onSubmit)}>
            <HtmlEditor name="htmlContent" control={control} formRegister={register("htmlContent")}  fieldErrors={errors.htmlContent} ></HtmlEditor>
            <button type="submit">Gönder</button>
        </form>
        
        
    </>)
}

export default HomeContainers;