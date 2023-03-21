import { createContext } from "react";

/**
 * Themes object.
 */
export const themes = {
    dark: "dark",
    light: "light",
};

/**
 * Theme context.
 */
export const ThemeContext = createContext({
    theme: themes.dark,
    changeTheme: (theme: string) => { },
});