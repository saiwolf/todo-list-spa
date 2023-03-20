import { useState } from 'react';
import { Navbar, NavbarBrand, NavItem } from 'reactstrap';
import ToggleTheme from './ToggleTheme';
import './NavMenu.css';
import { ThemeContext } from '../_helpers/theme';

export default function NavMenu(): JSX.Element {
    const [collapsed, setCollapsed] = useState<boolean>(true);

    const toggleNavbar = () => {
        setCollapsed(!collapsed);
    };

    return(
        <header>
          <Navbar className="navbar-expand-lg border-bottom ng-white mb-3" container light>
            <NavbarBrand className="mx-auto" href="/">Todo List App</NavbarBrand>
            <ul className="navbar-nav flex-grow ms-auto">              
              <ThemeContext.Consumer>
                {({ theme }) => (
                  <ToggleTheme theme={theme} />
                )}
              </ThemeContext.Consumer>              
            </ul>        
          </Navbar>
      </header>
    );
}