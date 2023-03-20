import { useState } from 'react';
import { Collapse, Navbar, NavbarBrand, NavbarToggler, NavItem } from 'reactstrap';
import { Link } from 'react-router-dom';
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
          <Navbar className="navbar-expand-lg ng-white mb-3" container light>
            <ul className="navbar-nav flex-grow ms-auto">
              <NavItem>
                <ThemeContext.Consumer>
                  {({ theme }) => (
                    <ToggleTheme theme={theme} />
                  )}
                </ThemeContext.Consumer>
              </NavItem>
            </ul>        
          </Navbar>
      </header>
    );
}