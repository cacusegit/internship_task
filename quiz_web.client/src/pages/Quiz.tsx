import Button from '@mui/material/Button';
import Box from '@mui/material/Box';
import Stepper from '@mui/material/Stepper';
import Step from '@mui/material/Step';
import StepLabel from '@mui/material/StepLabel';
import { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import TextField from '@mui/material/TextField';
import { Typography } from '@mui/material';
import StepContent from '@mui/material/StepContent';
import Paper from '@mui/material/Paper';

const steps = [
    {
        label: 'Q1',
        description: 'Question text 1',
    },
    {
        label: 'Q2',
        description: 'Question text 2',
    },
    {
        label: 'Q3',
        description: 'Question text 3',
    },
]



const Quiz = () => {

    const [showStepper, setShowStepper] = useState(false)
    const [activeStep, setActiveStep] = useState(0)
    const [showEmailField, setEmailField] = useState(false)
    const [email, setEmail] = useState('')
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

    return (
        <div>
            {/*Initial button */}
            {!showEmailField && !showStepper && (
                <Button variant='contained' onClick={() => setEmailField(true)} color='primary'> Start The Quiz!</Button>
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
                <Box sx={{ maxWidth: 400 }}>
                    <Stepper activeStep={activeStep} orientation='vertical'>
                        {steps.map((step, index) => (
                            <Step key={step.label}>
                                <StepLabel
                                    optional={index === steps.length - 1 ? (
                                        <Typography variant='caption'>Last Step</Typography>
                                    ) : null}
                                >
                                    {step.label }
                                </StepLabel>
                                <StepContent>
                                    <Typography>{step.description}</Typography>
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
                            <Button onClick={() => { handleReset(); toHighscore(); }} sx={{ mt: 1, mr: 1 }}> To HighScores</Button>
                        </Paper>
                    )}
                </Box>
                )}
        </div>
    )
}

export default Quiz;