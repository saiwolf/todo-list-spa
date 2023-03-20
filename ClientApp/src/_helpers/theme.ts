import { createContext } from "react";

export const themes = {
    dark: "dark",
    light: "light",
};

export const ThemeContext = createContext({
    theme: themes.dark,
    changeTheme: (theme: string) => { },
});