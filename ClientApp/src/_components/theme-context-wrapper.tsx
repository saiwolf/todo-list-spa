import React, { useState, useEffect } from 'react';
import { ThemeContext, themes } from '../_helpers/theme';

/**
 * Context wrapper for ThemeContext
 * @param {React.PropsWithChildren} props React Props
 * @returns {JSX.Element}
 */

export default function ThemeContextWrapper(props: React.PropsWithChildren) {
    let preferredTheme = localStorage.getItem('theme');
    if (!preferredTheme) {
        preferredTheme = themes.dark;
        localStorage.setItem('theme', themes.dark);
    }

    const [theme, setTheme] = useState(preferredTheme);

    function changeTheme(theme: string) {
        setTheme(theme);
    }

    useEffect(() => {
        switch (theme) {
            case themes.light:
                document.documentElement.setAttribute('data-bs-theme', 'light');
                localStorage.setItem('theme', 'light');
                break;
            case themes.dark:
            default:
                document.documentElement.setAttribute('data-bs-theme', 'dark');
                localStorage.setItem('theme', 'dark');
                break;
        }
    }, [theme]);

    return (
        <ThemeContext.Provider value={{ theme: theme, changeTheme: changeTheme }}>
            {props.children}
        </ThemeContext.Provider>
    );
}