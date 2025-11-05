import { useState } from 'react'
import './App.css'
import { BrowserRouter, Routes, Route } from "react-router-dom";
import LoginPage from './pages/LoginPage';

function App() {
  const [count, setCount] = useState(0)

  return (
    <>
        <BrowserRouter>
            <Routes>
                <Route path="/login" element={<LoginPage></LoginPage> }></Route>
            </Routes>
        </BrowserRouter>
    </>
  )
}

export default App
