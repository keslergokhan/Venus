import './App.css'
import { BrowserRouter, Routes, Route, useNavigate } from "react-router-dom";
import LoginPage from './pages/LoginPage';
import { Toaster } from 'react-hot-toast';
import HomePage from './pages/HomePage';
import DefaultLayout from './layouts/defaultLayout';
import { useEffect, useState } from 'react';
import { AuthenticationContext, AuthenticationContextProps, AuthenticationContextProvider } from './contexts/AuthenticationContext';

function App() {

    

    return (
        <>
            <AuthenticationContextProvider>
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
            </AuthenticationContextProvider>
        </>
    )
}

export default App

