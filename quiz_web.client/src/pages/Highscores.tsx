import { Link } from 'react-router-dom';

function Highscores() {
    return (
        <div>
            <div>
                <div>
                    <h2>Check the Quiz</h2>
                    <Link to="/">
                        <div className='btn'>View the Quiz</div>
                    </Link>
                </div>
            </div>
        </div>
    )
}

export default Highscores;