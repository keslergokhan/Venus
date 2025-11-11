import './App.css'
import { BrowserRouter, Routes, Route, useNavigate } from "react-router-dom";
import LoginPage from './pages/LoginPage';
import { Toaster } from 'react-hot-toast';
import HomePage from './pages/HomePage';
import DefaultLayout from './layouts/defaultLayout';
import { useEffect, useState } from 'react';
import { AuthenticationContext, AuthenticationContextProps } from './contexts/AuthenticationContext';

function App() {

    
    const [state, setState] = useState<boolean>(false);
    const context = new AuthenticationContextProps();

    context.IsAuth = state;
    context.login = () => {
        context.IsAuth = true;
        setState(true);
    }

    context.logaut = () => {
        context.IsAuth = false;
        setState(false);
    }


    return (
        <>
            <AuthenticationContext.Provider value={context}>
                <BrowserRouter>
                    <Routes>
                        <Route path="/login" element={<LoginPage></LoginPage>}></Route>

                        {/* DefaultLayout içinde olacak sayfalar */}
                        <Route element={<DefaultLayout />}>
                            <Route path="/home" element={<HomePage />} />
                            {/* baþka child sayfalar buraya */}

                        </Route>
                    </Routes>

                    <Toaster position="top-right" />
                </BrowserRouter>
            </AuthenticationContext.Provider>
        </>
    )
}

export default App

