import { useNavigate } from "react-router-dom"
import Tabs from '@mui/material/Tabs';
import Tab from '@mui/material/Tab';
import * as React from 'react';

function Navbar() {

    const navigate = useNavigate();

    function samePageLinkNavigation(
        event: React.MouseEvent<HTMLAnchorElement, MouseEvent>,
    ) {
        if (
            event.defaultPrevented ||
            event.button !== 0 ||
            event.metaKey ||
            event.ctrlKey ||
            event.altKey ||
            event.shiftKey
        ) {
            return false;
        }
        return true;
    }

    interface LinkTabProps {
        label?: string;
        href: string;
        selected?: boolean;
    }

    function LinkTab(props: LinkTabProps) {
        return (
            <Tab
                component='a'
                onClick={(event: React.MouseEvent<HTMLAnchorElement, MouseEvent>) => {
                    event.preventDefault();
                    navigate(props.href);
                }}
                aria-current={props.selected && 'page'}
                {...props}
            />
        );
    }

    const [value, setValue] = React.useState(0);

    const handleChange = (event: React.SyntheticEvent, newValue: number) => {
        if (
            event.type !== 'click' ||
            (event.type === 'click' &&
                samePageLinkNavigation(
                    event as React.MouseEvent<HTMLAnchorElement, MouseEvent>,
                ))
        ) {
            setValue(newValue);
        }
    };

    return (
        <>
            <Tabs
                value={value}
                onChange={handleChange}
                aria-label="nav tabs example"
                role="navigation"
                centered
                sx={{ position: 'fixed', top: 0, left: '50%', transform: 'translate(-50%)', margin: '0 auto' }}
                >
                    <LinkTab label="Quiz" href='/'/>
                    <LinkTab label="Highscores" href='highscore'/> 
                </Tabs>
        </>
    )

}

export default Navbar;