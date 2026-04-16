import './App.css'
import { BrowserRouter, Routes, Route} from "react-router-dom";
import LoginPage from './pages/LoginPage';
import { Toaster } from 'react-hot-toast';
import HomePage from './pages/HomePage';
import DefaultLayout from './layouts/defaultLayout';
import { AuthenticationContextProvider } from './contexts/AuthenticationContext';
import PageManagerPage from './pages/PageManager';
import { FileManagerContextProvider } from './contexts/FileManagerContext';
import { AppContextProvider } from './contexts/AppContext';
import IconComponent from './pages/IconComponent';
import 'ckeditor5/ckeditor5.css';
import { BlogPage } from './pages/BlogPage';
import { ConfirmModal } from './components';
function App() {
    return (
        <div className='overflow-x-hidden p-0 m-0'>
            <AuthenticationContextProvider>
                <AppContextProvider>
                    <FileManagerContextProvider>
                        <BrowserRouter>
                            <Routes>
                                <Route path="/login" element={<LoginPage></LoginPage>}></Route>

                                {/* DefaultLayout i�inde olacak sayfalar */}
                                <Route element={<DefaultLayout />}>
                                    <Route path="/home" element={<HomePage />} />
                                    <Route path='/page-manager' element={<PageManagerPage/>}></Route>
                                    <Route path='/blog' element={<BlogPage></BlogPage>}></Route>
                                    {/* ba�ka child sayfalar buraya */}
                                </Route>
                                <Route path="/icon" element={<IconComponent></IconComponent>}></Route>
                            </Routes>
                            <Toaster position="top-right" />
                        </BrowserRouter>
                        <ConfirmModal/>
                    </FileManagerContextProvider>
                </AppContextProvider>
            </AuthenticationContextProvider>
        </div>
    )
}

export default App

