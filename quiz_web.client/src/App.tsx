import { Routes, Route } from 'react-router-dom';
import Quiz from './pages/Quiz';
import Highscores from './pages/Highscores'
import './App.css';
import {createTheme, ThemeProvider } from '@mui/material';
import { purple } from "@mui/material/colors";
import NavBar from './components/Navbar'

const App = () => {
    const theme = createTheme({
        palette: {
            primary: {
                main: purple[400]
            }
        }
    })

    return (
        <ThemeProvider theme={theme}>
            <NavBar />
                <Routes>
                    <Route path="/" element={<Quiz />} />
                    <Route path='/highscore' element={<Highscores /> } />
                </Routes>
        </ThemeProvider>
    )
}

export default App