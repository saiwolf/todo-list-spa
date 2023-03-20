import { useState } from 'react';
import { ThemeContext, themes } from '../_helpers/theme';
import { Button } from 'reactstrap';

export function ToggleTheme({ theme }: { theme: string}): JSX.Element {
    const [darkMode, setDarkMode] = useState(theme === themes.dark ? true : false);

    return (
        <ThemeContext.Consumer>
            {({ changeTheme }) => (
                <Button
                    color={darkMode ? 'dark' : 'light'}
                    onClick={() => {
                        setDarkMode(!darkMode);
                        changeTheme(darkMode ? themes.light : themes.dark);
                    }}
                >
                    <i className={darkMode ? 'bi bi-sun-fill' : 'bi bi-moon-fill'}></i>&nbsp;
                    <span>{darkMode ? 'Dark' : 'Light'}</span>
                </Button>
            )}
        </ThemeContext.Consumer>
    );
}

export default ToggleTheme;