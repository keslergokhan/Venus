import { useForm } from "react-hook-form";
import { z } from 'zod';
import { zodResolver } from '@hookform/resolvers/zod';
import { CTextField } from "../commons";

export interface LoginFormValues {
    email: string;
    password: string;
}

export interface LoginComponentProps {
    onSubmitAsync: (data: LoginFormValues) => Promise<void>;
}

export function LoginComponent(props: LoginComponentProps) {

  // Zod şeması (kurallar burada)
  const schema = z.object({
    email: z.string().email('Geçerli bir email adresi girin'),
    password: z
      .string()
      .min(6, 'Şifre en az 6 karakter olmalı')
      .max(20, 'Şifre en fazla 20 karakter olabilir'),
  });

  type FormValues = z.infer<typeof schema>;
  
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm<FormValues>({resolver: zodResolver(schema)});
 

  return (
    <div className="mx-auto mt-[60px] max-w-sm p-4 bg-white border border-gray-200 rounded-lg shadow-sm sm:p-6 md:p-8 dark:bg-gray-800 dark:border-gray-700">
      
        <form onSubmit={handleSubmit(props.onSubmitAsync)} className="space-y-6" action="#">
          
            <h5 className="text-xl font-medium text-gray-900 dark:text-white">Venus Cms</h5>
            <CTextField type="email" id="email" name="email" label="Kullanıcı Adı" key="email" formRegister={register('email')} FieldErrors={errors.email}  ></CTextField>
            <CTextField type="password" id="password" name="password" label="Şifre" key="password" formRegister={register('password')} FieldErrors={errors.password}  ></CTextField>
            
            <button type="submit" className="w-full text-white bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm px-5 py-2.5 text-center dark:bg-blue-600 dark:hover:bg-blue-700 dark:focus:ring-blue-800">
              Giriş
            </button>
            
        </form>
    </div>
  );
}