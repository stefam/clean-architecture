import React from 'react';
import { Container } from 'reactstrap';
import NavMenu from '../NavMenu';

const Layout = (props: any): JSX.Element => {

    return (
        <div>
            <NavMenu />
            <Container>
                {props.children}
            </Container>
        </div>
    );
}

export default Layout;
