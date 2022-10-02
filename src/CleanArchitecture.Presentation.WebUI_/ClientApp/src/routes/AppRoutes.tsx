import ApiAuthorzationRoutes from '../components/api-authorization/ApiAuthorizationRoutes';
import Account from "../pages/Account";
import Counter from "../pages/Counter";
import FetchData from "../pages/FetchData";
import Home from "../pages/Home";

const AppRoutes = [
    {
        index: true,
        element: <Home />
    },
    {
        path: '/counter',
        element: <Counter />
    },
    {
        path: '/fetch-data',
        requireAuth: true,
        element: <FetchData />
    },
    {
        path: '/account',
        element: <Account />
    },
    ...ApiAuthorzationRoutes
];

export default AppRoutes;