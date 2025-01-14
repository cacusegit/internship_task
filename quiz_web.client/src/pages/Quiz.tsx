import Button from '@mui/material/Button';
import Box from '@mui/material/Box';
import Stepper from '@mui/material/Stepper';
import Step from '@mui/material/Step';
import StepLabel from '@mui/material/StepLabel';
import { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import TextField from '@mui/material/TextField';
import { Checkbox, FormControlLabel, Radio, Typography } from '@mui/material';
import StepContent from '@mui/material/StepContent';
import Paper from '@mui/material/Paper';
import axios from 'axios';

interface Answers {
    id: number;
    quizQuestionId: number;
    quizAnswers: string;
    isCorrect: boolean;
}

interface Questions {
    id: number;
    questionText: string;
    questionType: string;
    answers: Answers[];
}
interface ApiResponse {
    $values: {
        id: number;
        questionText: string;
        questionType: string;
        answers: {
            $values: Answers[];
        }
    }[];
}



const Quiz = () => {

    const [questions, setQuestions] = useState<Questions[]>([]);

    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = await axios.get<ApiResponse>("https://localhost:7007/api/QuizQuestion");
                const rawData = response.data;

                const normalizedQuestions = rawData.$values.map((question) => ({
                    id: question.id,
                    questionText: question.questionText,
                    questionType: question.questionType,
                    answers: question.answers.$values
                }));

                setQuestions(normalizedQuestions);
            } catch (error) {
                console.error("Error fetching data:", error);
            }
        };

        fetchData();
    }, []);

    const steps = questions.map((question) => ({
        question: question.questionText,
        questionID: question.answers.map((answer) => answer.quizQuestionId),
        questionType: question.questionType,
        answers: question.answers.map((answer) => answer.quizAnswers)
    }))

    const [showStepper, setShowStepper] = useState(false)
    const [activeStep, setActiveStep] = useState(0)
    const [showEmailField, setEmailField] = useState(false)
    const [email, setEmail] = useState('')
    const [selectedAnswers, setSelectedAnswers] = useState<Record<number, string | string[]>>({});
    const navigate = useNavigate();

    const isEmailValid = email && email.includes('@') && email.includes('.');

    const handleNext = () => {
        setActiveStep((prevActiveStep) => prevActiveStep + 1)
    }

    const handleBack = () => {
        setActiveStep((prevActiveStep) => prevActiveStep - 1);
    }

    const toHighscore = () => {
        navigate('/highscore');
    }
    const handleReset = () => {
        setActiveStep(0);
    }

    const handleAnswerChange = (stepIndex: number, answer: string | string[]) => {
        setSelectedAnswers((prevState) => ({
            ...prevState,
            [stepIndex]: answer,
        }));
    };

    const handleSubmit = async () => {
        try {
            const formattedAnswers = questions.map((question, questionIndex) => {
                const selectedAnswer = selectedAnswers[questionIndex];

                if (question.questionType === "radio-button" || question.questionType === "text") {
                    return {
                        quizQuestionId: question.id,
                        selectedAnswer: selectedAnswer,
                        selectedAnswers: []
                    };
                }

                if (question.questionType === "checkbox") {
                    return {
                        quizQuestionId: question.id,
                        selectedAnswer: "",
                        selectedAnswers: Array.isArray(selectedAnswer) ? selectedAnswer : [selectedAnswer]
                    };
                }

                return null;
            }).filter(item => item !== null);

            const response = await axios.post("https://localhost:7007/api/QuizQuestion/submit", {
                answers: formattedAnswers
            });
            console.log(response.data)

            const newScore = await response.data.score;
    
            await axios.post("https://localhost:7007/api/HighScore/submit", {
                email: email, 
                score: newScore
            });

            console.log("High score submitted successfully.");

        } catch (error) {
            console.error("Error submitting quiz or saving high score:", error);
        }
    };

    return (
        <div>
            {/*Initial button */}
            {!showEmailField && !showStepper && (
                <Button variant='contained' onClick={() => setEmailField(true)} color='primary'>Start The Quiz!</Button>
            )}

            {/*Email Field */}
            {showEmailField && !showStepper && (
                <>
                    <h2>Please enter your email</h2>
                    <TextField id='outlined-basic' label='Required' variant='outlined' value={email}
                        onChange={(e) => setEmail(e.target.value)}></TextField>

                    <div>
                        <Button variant='contained' onClick={() => { setShowStepper(true); }} color='primary' disabled={!isEmailValid}>
                            Begin the Quiz</Button>
                    </div>
                </>
            )}

            {/*Stepper Component */}
            {showStepper && (
                <Box sx={{ maxWidth: 600 }}>

                    <Stepper activeStep={activeStep} orientation='vertical'>
                        {steps.map((step, index) => (

                            <Step key={step.question}>

                                <StepLabel
                                    optional={index === steps.length - 1 ? (
                                        <Typography variant='caption'>Last Step</Typography>
                                    ) : null}
                                >
                                    {step.question}
                                </StepLabel>

                                <StepContent>

                                    <Typography>
                                        {/*radio-button-logic*/}
                                        {step.questionType === "radio-button" && (
                                            <div>
                                                {step.answers.map((answer, idx) => (
                                                    <FormControlLabel key={idx} control={<Radio
                                                        checked={selectedAnswers[index] === answer}
                                                        onChange={() => handleAnswerChange(index, answer)} />} label={answer}></FormControlLabel>
                                                ))}
                                            </div>
                                        )}

                                        {/*text-logic*/}
                                        {step.questionType === "text" && (
                                            <TextField label="Your answer" fullWidth variant="outlined" margin="normal" value={selectedAnswers[index] || ""}
                                                onChange={(e) => handleAnswerChange(index, e.target.value)}></TextField>
                                        )}

                                        {/*checkbox-logic*/}
                                        {step.questionType === "checkbox" && (
                                            <div>
                                                {step.answers.map((answer, idx) => (
                                                    <FormControlLabel key={idx} control={
                                                        <Checkbox checked={Array.isArray(selectedAnswers[index])
                                                        && selectedAnswers[index].includes(answer)}
                                                        onChange={() => {
                                                            const newAnswers = Array.isArray(selectedAnswers[index])
                                                                ? [...selectedAnswers[index]] : [];
                                                            if (newAnswers.includes(answer)) {
                                                                const idx = newAnswers.indexOf(answer);
                                                                newAnswers.splice(idx, 1);
                                                            }
                                                            else {
                                                                newAnswers.push(answer);
                                                            }
                                                            handleAnswerChange(index, newAnswers);
                                                        }}
                                                        />
                                                    } label={answer}
                                                    />
                                                ))}
                                            </div>
                                        )}
                                    </Typography>

                                    <Box sx={{ mb: 2 }}>
                                        <Button variant="contained" onClick={handleNext} sx={{ mt: 1, mr: 1 }}>
                                            {index === steps.length - 1 ? 'Finish' : 'Continue'}
                                        </Button>
                                        <Button disabled={index === 0} onClick={handleBack} sx={{ mt: 1, mr: 1 }}>
                                            Back
                                        </Button>
                                    </Box>

                                </StepContent>
                            </Step>
                        ))}
                    </Stepper>
                    {activeStep === steps.length && (
                        <Paper square elevation={0} sx={{ p: 3 }}>
                            <Typography>All steps completed - you&apos;re finished</Typography>
                            <Button onClick={() => { handleSubmit(); handleReset(); toHighscore(); }} sx={{ mt: 1, mr: 1 }}>To HighScores</Button>
                        </Paper>
                    )}
                </Box>
            )}
        </div>
    );
}

export default Quiz;