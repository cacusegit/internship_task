import axios from 'axios';
import { useState, useEffect } from 'react';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';


interface Highscores {
    id: number;
    email: string;
    score: number;
    achievedAt: string;
}
interface ApiResponse {
    $values: {
        id: number;
        email: string;
        score: number;
        achievedAt: string;
    }[];
}


const Highscores = () => {

    const [highScores, setHighScores] = useState<Highscores[]>([]);

    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = await axios.get<ApiResponse>("https://localhost:7007/api/HighScore");
                const rawData = response.data;

                const normalizedScores = rawData.$values.map((highScore) => ({
                    id: highScore.id,
                    email: highScore.email,
                    score: highScore.score,
                    achievedAt: highScore.achievedAt
                }));

                setHighScores(normalizedScores);
            } catch (error) {
                console.error("Error fetching data:", error);
            }
        };

        fetchData();
    }, []);

    return (
        <>
            <h1>HighScores</h1>
            <TableContainer component={Paper}>
                <Table sx={{ minWidth: 650 }} aria-label="HighScore Table">
                        <TableHead>
                            <TableRow>
                                <TableCell>&nbsp;</TableCell>
                                <TableCell>Email</TableCell>
                                <TableCell>Score</TableCell>
                                <TableCell>Achieved At</TableCell>
                            </TableRow>
                        </TableHead>
                        <TableBody>
                            {highScores.map((score, index) => (
                                <TableRow
                                    key={score.id}
                                    sx={{
                                        '&:last-child td, &:last-child th': { border: 0 },
                                        backgroundColor:
                                            index === 0 ? 'gold'
                                            : index === 1 ? 'silver'
                                            : index === 2 ? '#CD7F32'
                                            : 'inherit',
                                    }}>
                                    <TableCell component="th" scope="row">
                                        {index + 1}
                                    </TableCell>
                                    <TableCell>{score.email}</TableCell>
                                    <TableCell>{score.score}</TableCell>
                                    <TableCell>{new Date(score.achievedAt).toLocaleString()}</TableCell>
                                </TableRow>))}
                        </TableBody>
                </Table>
            </TableContainer>
        </>
    )
}

export default Highscores;