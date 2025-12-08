import './App.css'
import { BrowserRouter, Routes, Route} from "react-router-dom";
import LoginPage from './pages/LoginPage';
import { Toaster } from 'react-hot-toast';
import HomePage from './pages/HomePage';
import DefaultLayout from './layouts/defaultLayout';
import { AuthenticationContextProvider } from './contexts/AuthenticationContext';
import { AppContextProvider } from './contexts/AppContext';

function App() {

    

    return (
        <>
            <AuthenticationContextProvider>
                <AppContextProvider>
                    <BrowserRouter>
                        <Routes>
                            <Route path="/login" element={<LoginPage></LoginPage>}></Route>

                            {/* DefaultLayout i�inde olacak sayfalar */}
                            <Route element={<DefaultLayout />}>
                                <Route path="/home" element={<HomePage />} />
                                {/* ba�ka child sayfalar buraya */}
                            </Route>
                            
                        </Routes>
                        <Toaster position="top-right" />
                    </BrowserRouter>
                </AppContextProvider>
            </AuthenticationContextProvider>
        </>
    )
}

export default App

