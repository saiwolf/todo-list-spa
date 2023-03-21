import { useState } from 'react';
import { ThemeContext, themes } from '../_helpers/theme';
import { DropdownToggle, DropdownMenu, DropdownItem, UncontrolledDropdown } from 'reactstrap';

type ToggleThemeProps = {
    theme: string;
}

/**
 * 
 * @param {ToggleThemeProps} ToggleThemeProps Props object containing theme name.
 * @returns A Bootstrap Dropdown Menu for selecting a theme.
 */
export function ToggleTheme({ theme }: ToggleThemeProps): JSX.Element {
    const [darkMode, setDarkMode] = useState(theme === themes.dark ? true : false);

    return (
        <ThemeContext.Consumer>
            {({ changeTheme }) => (
                <UncontrolledDropdown nav inNavbar>
                    <DropdownToggle nav caret>
                        <i className={`bi ${darkMode ? 'bi-moon-stars-fill' : 'bi-sun-fill'}`}></i>&nbsp;
                        <span>{darkMode ? 'Dark' : 'Light'}</span>
                    </DropdownToggle>
                    <DropdownMenu end>
                        <DropdownItem onClick={() => {
                            setDarkMode(false);
                            changeTheme(themes.light);
                        }}>
                            <i className='bi bi-sun-fill'></i>&nbsp;
                            <span>Light</span>
                        </DropdownItem>
                        <DropdownItem onClick={() => {
                            setDarkMode(true);
                            changeTheme(themes.dark);
                        }}>
                            <i className='bi bi-moon-stars-fill'></i>&nbsp;
                            <span>Dark</span>
                        </DropdownItem>
                    </DropdownMenu>
                </UncontrolledDropdown>
            )}
        </ThemeContext.Consumer>
    );
}

export default ToggleTheme;