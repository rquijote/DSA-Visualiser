import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import { BrowserRouter, Routes, Route } from 'react-router';
import App from './App'
import BubbleSort from './pages/BubbleSort'
import React from "react";

createRoot(document.getElementById('root')!).render(
    <BrowserRouter>
        <StrictMode>
            <Routes>
                <Route path="/" element={<App />} />
                <Route path="/bubble-sort" element={<BubbleSort />} />
            </Routes>
        </StrictMode>
    </BrowserRouter>
)