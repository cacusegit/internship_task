import { NavLink } from "react-router-dom"

function Navbar() {
    return (
        <nav>
            <ul>
                <li>
                <NavLink to="/">QUIZ</NavLink>
                </li>
                <li>
                <NavLink to='/highscore'>HIGHSCORES</NavLink>
                </li>
            </ul>
        </nav>
    )

}

export default Navbar;