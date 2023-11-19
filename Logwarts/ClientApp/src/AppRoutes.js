import { Counter } from "./components/Counter";
import { FetchData } from "./components/FetchData";
import { Home } from "./components/Home";
import { RegularUserPage } from "./Page/RegularUserPage"

const AppRoutes = [
    {
        index: true,
        element: <RegularUserPage />
    },
    {
        path: '/counter',
        element: <Counter />
    },
    
    {
        path: '/regularuser',
        element: <RegularUserPage />
    }
    ,
    {
        path: '/privilegeduser',
        element: <Counter />
    }
];

export default AppRoutes;
