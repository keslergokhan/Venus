import { useState } from 'react'
import './App.css'
import { BrowserRouter, Routes, Route } from "react-router-dom";
import LoginPage from './pages/LoginPage';
import { Toaster } from 'react-hot-toast';

function App() {
  const [count, setCount] = useState(0)

  return (
    <>
        <BrowserRouter>
            <Routes>
                <Route path="/login" element={<LoginPage></LoginPage> }></Route>
              </Routes>
              <Toaster
                  position="top-right"
                 
              />    
        </BrowserRouter>
    </>
  )
}

export default App
