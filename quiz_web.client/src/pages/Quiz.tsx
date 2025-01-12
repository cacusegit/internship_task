import { Link } from 'react-router-dom';

function Quiz(){
    return (
        <div>
            <div>
                <div>
                    <h2>Check the HighScores</h2>
                    <Link to="/highscore">
                        <div className='btn'>View HighScores</div>
                    </Link>
                </div>
            </div>
        </div>
    )
}

export default Quiz;