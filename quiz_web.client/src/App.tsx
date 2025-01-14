//import { useEffect, useState } from 'react';
import { Routes, Route } from 'react-router-dom';
import Quiz from './pages/Quiz';
import Highscores from './pages/Highscores'
import './App.css';

function App() {
    return (
        <>
            <Routes>
                <Route path="/" element={<Quiz />} />
                <Route path='/highscore' element={<Highscores /> } />
            </Routes>
        </>
    )
}

export default App