import { Container } from 'reactstrap';
import NavMenu from './NavMenu';
import { Outlet } from 'react-router-dom';
export function Layout(): JSX.Element {
    return (
        <div>
            <NavMenu />
            <Container tag="main">
                <Outlet />
            </Container>
        </div>
    );
}

export default Layout;