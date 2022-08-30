import React from 'react';
import { Routes, Route } from 'react-router-dom';
import AppRoutes from './routes/AppRoutes';
import Layout from './components/Layout';

const App = (): JSX.Element => {
    return (
        <Layout>
            <Routes>
                {AppRoutes.map((route: any, index: any) => {
                    const { element, ...rest } = route;
                    return <Route key={index} {...rest} element={element} />;
                })}
            </Routes>
        </Layout>
    );
}

export default App;
