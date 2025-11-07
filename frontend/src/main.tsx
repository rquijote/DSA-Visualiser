import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import { BrowserRouter, Routes, Route } from 'react-router';
import App from './App'
import BubbleSort from './pages/BubbleSort'
import InsertionSort from './pages/InsertionSort';
import SelectionSort from './pages/SelectionSort';
import MergeSort from './pages/MergeSort';
import QuickSort from './pages/QuickSort';

createRoot(document.getElementById('root')!).render(
    <BrowserRouter>
        <StrictMode>
            <Routes>
                <Route path="/" element={<App />} />
                <Route path="/bubble-sort" element={<BubbleSort />} />
                <Route path="/insertion-sort" element={<InsertionSort />} />
                <Route path="/selection-sort" element={<SelectionSort />} />
                <Route path="/merge-sort" element={<MergeSort />} />
                <Route path="/quick-sort" element={<QuickSort />} />
            </Routes>
        </StrictMode>
    </BrowserRouter>
)