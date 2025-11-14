import { createRoot } from 'react-dom/client'
import './index.css'
import App from './App.tsx'
import "flowbite";       // Flowbite JS interactivity

createRoot(document.getElementById('root')!).render(
    <App />
)
